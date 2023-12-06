using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace client.financial.accountsReceivable.input.paymentApplication
{
    public partial class Form1 : Form
    {
        private ctDynamicsSL.financial.accountsReceivable.input.paymentApplication.paymentApplication myPAObjValue = null;
        public ctDynamicsSL.financial.accountsReceivable.input.paymentApplication.screen myScreen = null;
        public ctDynamicsSL.financial.accountsReceivable.input.paymentApplication.ARDoc[] releasedCustomerARDocs = null;
        public ctDynamicsSL.financial.accountsReceivable.input.paymentApplication.ARDoc qpInvoice = null;
        
        public Form1()
        {
            InitializeComponent();
        }

        public ctDynamicsSL.financial.accountsReceivable.input.paymentApplication.paymentApplication myPAObj
        {
            //used for access to the webservice.  automatically creates the object if necessary
            get
            {
                if (myPAObjValue == null)
                {
                    //if we get here, then the object is not created
                    ctDynamicsSL.financial.accountsReceivable.input.paymentApplication.ctDynamicsSLHeader Header = new ctDynamicsSL.financial.accountsReceivable.input.paymentApplication.ctDynamicsSLHeader();
                    Header.siteID = System.Configuration.ConfigurationManager.AppSettings["SITEID"];
                    Header.cpnyID = System.Configuration.ConfigurationManager.AppSettings["CPNYID"];
                    Header.licenseKey = System.Configuration.ConfigurationManager.AppSettings["LICENSEKEY"];
                    Header.licenseName = System.Configuration.ConfigurationManager.AppSettings["LICENSENAME"];
                    Header.licenseExpiration = System.Configuration.ConfigurationManager.AppSettings["LICENSEEXPIRATION"];
                    Header.siteKey = System.Configuration.ConfigurationManager.AppSettings["SITEKEY"];
                    Header.softwareName = "CTAPI";
                    myPAObjValue = new ctDynamicsSL.financial.accountsReceivable.input.paymentApplication.paymentApplication();
                    myPAObjValue.ctDynamicsSLHeaderValue = Header;
                    myPAObjValue.Timeout = 300000;
                }
                return myPAObjValue;
            }
            set
            {
                myPAObjValue = value;
            }
        }

        //Button action to release a batch,  setup to automatically load the batch first
        private void btnRelease_Click(object sender, EventArgs e)
        {
            myScreen = myPAObj.getScreenByBatNbr(tbBatNbr.Text);
            if (myScreen.errorMessage != "")
            {
                MessageBox.Show("Error: " + myScreen.errorMessage);
                return;
            }
            else
            {
                myScreen = myPAObj.editScreen("RELEASENOW", myScreen);
                if (myScreen.errorMessage != "")
                {
                    MessageBox.Show("Error: " + myScreen.errorMessage);
                    return;
                }
                else
                {
                    tbScreen.Text = ctStandardLib.ctHelper.serializeObject(myScreen).Replace("><", ">" + Environment.NewLine + "<");
                }
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            myScreen = myPAObj.getScreenByBatNbr(tbBatNbr.Text);
            if (myScreen.errorMessage != "")
            {
                MessageBox.Show("Error: " + myScreen.errorMessage);
                return;
            }
            btnSaveAll.Enabled = true;

            if (tbRefNbr.Text != "")
            {
                try
                { 
                    myScreen.myARDoc = myPAObj.getARDocsByApplBatNbrAndRefNbr(myScreen.myBatch.BatNbr, tbRefNbr.Text)[0];
                    tbRefNbr.Text = myScreen.myARDoc.RefNbr.Trim();
                    tbCustID.Text = myScreen.myARDoc.CustId.Trim();
                }
                catch
                {
                    tbCustID.Text = "";
                }

            }
            if ((tbCustID.Text.Trim() != "") && (tbRefNbr.Text.Trim() != ""))
            {
                try
                {
                    gvARTran.DataSource = myPAObj.getARTransByBatNbrAndRefNbrAndCustID(myScreen.myBatch.BatNbr, myScreen.myARDoc.RefNbr, myScreen.myARDoc.CustId);
                }
                catch
                {
                    gvARTran.DataSource=null;
                }
            }

        }

        //Used to save a batch that has been loaded
        private void btnSaveAll_Click(object sender, EventArgs e)
        {
            if (myScreen == null)
            {
                MessageBox.Show("You must load a batch first!");
                return;
            }
            if (tbCustID.Text.Trim() == "")
            {
                MessageBox.Show("You must select a custID first!");
                return;
            }

            myScreen.errorMessage = "";
            MessageBox.Show(ctStandardLib.ctHelper.serializeObject(myScreen).Replace("><", ">" + Environment.NewLine + "<"));
            if (myScreen.myARDoc == null)
            {
                MessageBox.Show("No Payment Doc found, generating a new one for custID: " + tbCustID.Text);
                //if our PA doc is not set, we need to create one.
                myScreen.myARDoc = new ctDynamicsSL.financial.accountsReceivable.input.paymentApplication.ARDoc();
                myScreen.myARDoc.CpnyID = myScreen.myBatch.CpnyID;
                myScreen.myARDoc.CustId = tbCustID.Text.Trim();
                myScreen.myARDoc = myPAObj.getNewARDoc(myScreen.myARDoc);
                myScreen.myARDoc.BankAcct = myPAObj.getAcctXrefsByAcct("", myScreen.myBatch.CpnyID)[0].Acct;//"1035";
                myScreen.myARDoc.BankSub = myPAObj.getSubXrefsBySub("", myScreen.myBatch.CpnyID)[0].Sub; //"00000000";
            }
            myScreen.myARTran = (ctDynamicsSL.financial.accountsReceivable.input.paymentApplication.ARTran[])gvARTran.DataSource;
            if (myScreen.myARTran == null)
            {
                MessageBox.Show("ARTRAN is null");
                return;
            }
            myScreen = myPAObj.editScreen("UPDATE", myScreen);

            if (myScreen.errorMessage != "")
            {
                MessageBox.Show("Error: " + myScreen.errorMessage);
            }
            else
            {
                tbRefNbr.Text = myScreen.myARDoc.RefNbr.Trim();
                gvARTran.DataSource = myScreen.myARTran;
            }
        }

        //Pulls up the batch list search box
        private void btnSearch_Click(object sender, EventArgs e)
        {
            batchesPopup newPopup = new batchesPopup(this, tbBatNbr.Text);
            newPopup.ShowDialog();
        }

        //Creates an empty new payment batch entry
        //This will have no ardocs or transactions
        private void btnNew_Click(object sender, EventArgs e)
        {
            myScreen = myPAObj.getNewscreen(null);
            myScreen.myARDoc = null;//force override to clear out ardoc
            myScreen = myPAObj.editScreen("ADD", myScreen);
            if (myScreen.errorMessage != "")
            {
                btnSaveAll.Enabled = false;
                tbBatNbr.Text = "";
                gvARTran.DataSource = null;
                tbScreen.Text = ctStandardLib.ctHelper.serializeObject(myScreen).Replace("><", ">" + Environment.NewLine + "<");
                MessageBox.Show("Error: " + myScreen.errorMessage);
                return;
            }
            else
            {
                tbBatNbr.Text = myScreen.myBatch.BatNbr;
                btnLoadBatch.PerformClick();
            }
        }



        //Pulls up the custID list search box
        private void btnSearchCustID_Click(object sender, EventArgs e)
        {
            custIDsPopup newPopup = new custIDsPopup(this, tbCustID.Text);
            newPopup.ShowDialog();
        }


        //Searches for release ARDocs for the customer
        private void btnArDocSearch_Click(object sender, EventArgs e)
        {
            arDocsPopup newPopup = new arDocsPopup(this, tbRefNbr.Text);
            newPopup.ShowDialog();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnQuickPay_Click(object sender, EventArgs e)
        {
            if (qpInvoice==null)
            {
                MessageBox.Show("Must Select an Invoice to Pay!");
                return;
            }
            
            myScreen = myPAObj.getNewscreen(null);
            myScreen.myBatch.CpnyID = System.Configuration.ConfigurationManager.AppSettings["CPNYID"];
            myScreen.myBatch = myPAObj.getNewBatch(myScreen.myBatch);
            myScreen.myBatch.CuryCrTot = Math.Abs(qpInvoice.DocBal);
            myScreen.myBatch.CuryCtrlTot = myScreen.myBatch.CuryCrTot;
            myScreen.myBatch.CuryEffDate = System.DateTime.Now;
            myScreen.myBatch.Descr = "Batch for Payment on Invoice #" + qpInvoice.RefNbr;

            myScreen.myARDoc = new ctDynamicsSL.financial.accountsReceivable.input.paymentApplication.ARDoc();
            myScreen.myARDoc.CpnyID = myScreen.myBatch.CpnyID;
            myScreen.myARDoc.CustId = qpInvoice.CustId;
            myScreen.myARDoc = myPAObj.getNewARDoc(myScreen.myARDoc);

            myScreen.myARDoc.LineCntr = 1;
            myScreen.myARDoc.CuryDocBal = Math.Abs(qpInvoice.DocBal);
            myScreen.myARDoc.DocBal = Math.Abs(qpInvoice.DocBal);
            myScreen.myARDoc.OrigDocAmt = Math.Abs(qpInvoice.DocBal);
            myScreen.myARDoc.CuryOrigDocAmt = Math.Abs(qpInvoice.DocBal);
            myScreen.myARDoc.ApplBatNbr = myScreen.myBatch.BatNbr;
            myScreen.myARDoc.BatNbr = myScreen.myBatch.BatNbr;

            myScreen.myARTran = new ctDynamicsSL.financial.accountsReceivable.input.paymentApplication.ARTran[1];
            myScreen.myARTran[0] = new ctDynamicsSL.financial.accountsReceivable.input.paymentApplication.ARTran();
            myScreen.myARTran[0].CpnyID = myScreen.myBatch.CpnyID;
            myScreen.myARTran[0].CustId = myScreen.myARDoc.CustId;
            myScreen.myARTran[0] = myPAObj.getNewARTran(myScreen.myARTran[0]);
            myScreen.myARTran[0].CmmnPct = (-1 * Math.Abs(qpInvoice.DocBal));
            myScreen.myARTran[0].CuryId = myScreen.myARDoc.CuryId;
            myScreen.myARTran[0].CuryRate = myScreen.myARDoc.CuryRate;
            myScreen.myARTran[0].CuryTranAmt = Math.Abs(qpInvoice.DocBal);
            myScreen.myARTran[0].TranAmt = Math.Abs(qpInvoice.DocBal);
            myScreen.myARTran[0].LineId = 1;
            myScreen.myARTran[0].LineNbr = 0;
            myScreen.myARTran[0].SiteId = qpInvoice.RefNbr;//invoice being paid

            myScreen = myPAObj.editScreen("ADD", myScreen);
            if (myScreen.errorMessage != "")
            {
                btnSaveAll.Enabled = false;
                tbBatNbr.Text = "";
                gvARTran.DataSource = null;
                tbScreen.Text = ctStandardLib.ctHelper.serializeObject(myScreen).Replace("><", ">" + Environment.NewLine + "<");
                MessageBox.Show("Error: " + myScreen.errorMessage);
                return;
            }
            else
            {
                tbBatNbr.Text = myScreen.myBatch.BatNbr;
                tbCustID.Text = myScreen.myARDoc.CustId.Trim();
                tbRefNbr.Text = myScreen.myARDoc.RefNbr.Trim();
                btnLoadBatch.PerformClick();
                MessageBox.Show("Save Complete!");
            }
        }

        private void btnQPInvoice_Click(object sender, EventArgs e)
        {
            arDocsPopup newPopup = new arDocsPopup(this,true);
            newPopup.ShowDialog();
        }

    }
}

