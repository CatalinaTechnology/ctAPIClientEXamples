using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace client.financial.accountsReceivable.input.paymentEntry
{
    public partial class Form1 : Form
    {
        private ctDynamicsSL.financial.accountsReceivable.input.paymentEntry.paymentEntry myPEObjValue = null;
        public ctDynamicsSL.financial.accountsReceivable.input.paymentEntry.screen myScreen = null;

        public Form1()
        {
            InitializeComponent();
        }

        public ctDynamicsSL.financial.accountsReceivable.input.paymentEntry.paymentEntry myPEObj
        {
            //used for access to the webservice.  automatically creates the object if necessary
            get
            {
                if (myPEObjValue == null)
                {
                    //if we get here, then the object is not created
                    ctDynamicsSL.financial.accountsReceivable.input.paymentEntry.ctDynamicsSLHeader Header = new ctDynamicsSL.financial.accountsReceivable.input.paymentEntry.ctDynamicsSLHeader();
                    Header.siteID = System.Configuration.ConfigurationManager.AppSettings["SITEID"];
                    Header.cpnyID = System.Configuration.ConfigurationManager.AppSettings["CPNYID"];
                    Header.licenseKey = System.Configuration.ConfigurationManager.AppSettings["LICENSEKEY"];
                    Header.licenseName = System.Configuration.ConfigurationManager.AppSettings["LICENSENAME"];
                    Header.licenseExpiration = System.Configuration.ConfigurationManager.AppSettings["LICENSEEXPIRATION"];
                    Header.siteKey = System.Configuration.ConfigurationManager.AppSettings["SITEKEY"];
                    Header.softwareName = "CTAPI";
                    myPEObjValue = new ctDynamicsSL.financial.accountsReceivable.input.paymentEntry.paymentEntry();
                    myPEObjValue.ctDynamicsSLHeaderValue = Header;
                    myPEObjValue.Timeout = 300000;
                }
                return myPEObjValue;
            }
            set
            {
                myPEObjValue = value;
            }
        }


        private void btnLoadBatch_Click(object sender, EventArgs e)
        {
            myScreen = myPEObj.getScreenByBatNbr(tbBatNbr.Text);
            if (myScreen.errorMessage != "")
            {
                MessageBox.Show("Error: " + myScreen.errorMessage);
                return;
            }
            tbRefNbr.Text = myScreen.myARDoc.RefNbr;
            tbCustID.Text = myScreen.myARDoc.CustId;
            gvARTran.DataSource = myScreen.myARTran;
            btnUpdate.Enabled = true;
            tbScreen.Text = ctStandardLib.ctHelper.serializeObject(myScreen).Replace("><", ">" + Environment.NewLine + "<");
        }

        //Used to save a batch that has been loaded
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (myScreen == null)
            {
                MessageBox.Show("You must load a batch first!");
                return;
            }

            MessageBox.Show(ctStandardLib.ctHelper.serializeObject(myScreen).Replace("><", ">" + Environment.NewLine + "<"));
            myScreen = myPEObj.editScreen("UPDATE", myScreen);
            if (myScreen.errorMessage != "")
            {
                MessageBox.Show("Error: " + myScreen.errorMessage);
                return;
            }
            tbRefNbr.Text = myScreen.myARDoc.RefNbr;
            tbCustID.Text = myScreen.myARDoc.CustId;
            gvARTran.DataSource = myScreen.myARTran;
            btnUpdate.Enabled = true;
            tbScreen.Text = ctStandardLib.ctHelper.serializeObject(myScreen).Replace("><", ">" + Environment.NewLine + "<");
        }

        //Pulls up the batch list search box
        private void btnSearch_Click(object sender, EventArgs e)
        {
            batchesPopup newPopup = new batchesPopup(this, tbBatNbr.Text);
            newPopup.ShowDialog();
        }

        //Creates an empty new generic batch
        private void btnNew_Click(object sender, EventArgs e)
        {
            myScreen = myPEObj.getNewscreen(null);
            myScreen.myARDoc.CustId = myPEObj.getCustomersByCustID("")[0].CustID;//pick first custid available
            myScreen.myARDoc.BankAcct = myPEObj.getAcctXrefsByAcct("", System.Configuration.ConfigurationSettings.AppSettings["CPNYID"])[0].Acct;//pick first bankacct available
            myScreen.myARDoc.BankSub = myPEObj.getSubXrefsBySub("", System.Configuration.ConfigurationSettings.AppSettings["CPNYID"])[0].Sub;//pick first banksub available
            
            ctDynamicsSL.financial.accountsReceivable.input.paymentEntry.Snote batchNote = new ctDynamicsSL.financial.accountsReceivable.input.paymentEntry.Snote();
            batchNote.sNoteText ="test batch note";
            myScreen.batchNote = batchNote;

            ctDynamicsSL.financial.accountsReceivable.input.paymentEntry.Snote documentNote = new ctDynamicsSL.financial.accountsReceivable.input.paymentEntry.Snote();
            documentNote.sNoteText = "test document note";
            myScreen.documentNote = documentNote;

            myScreen = myPEObj.editScreen("ADD", myScreen);
            if (myScreen.errorMessage != "")
            {
                btnUpdate.Enabled = false;
                tbBatNbr.Text = "";
                tbRefNbr.Text = "";
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

        //Pulls up the refNbr list search box
        private void btnSearchRefNbr_Click(object sender, EventArgs e)
        {
            arDocsPopup newPopup = new arDocsPopup(this, tbRefNbr.Text);
            newPopup.ShowDialog();
        }

        //Pulls up the custID list search box
        private void btnSearchCustID_Click(object sender, EventArgs e)
        {
            custIDsPopup newPopup = new custIDsPopup(this, tbCustID.Text);
            newPopup.ShowDialog();
        }

        public void loadARTrans()
        {
            myScreen.myARTran = myPEObj.getARTransByBatNbrAndRefNbrAndCustID(tbBatNbr.Text, tbRefNbr.Text, tbCustID.Text);
            gvARTran.DataSource = myScreen.myARTran;
        }
    }
}

