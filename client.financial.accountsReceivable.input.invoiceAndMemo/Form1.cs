using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace client.financial.accountsReceivable.input.invoiceAndMemo
{
    public partial class Form1 : Form
    {
        private ctDynamicsSL.financial.accountsReceivable.input.invoiceAndMemo.invoiceAndMemo myIMObjValue = null;
        public ctDynamicsSL.financial.accountsReceivable.input.invoiceAndMemo.screen myScreen = null;
        
        
        public Form1()
        {
            InitializeComponent();
        }

        public ctDynamicsSL.financial.accountsReceivable.input.invoiceAndMemo.invoiceAndMemo myIMObj
        {
            //used for access to the webservice.  automatically creates the object if necessary
            get
            {
                if (myIMObjValue == null)
                {
                    //if we get here, then the object is not created
                    ctDynamicsSL.financial.accountsReceivable.input.invoiceAndMemo.ctDynamicsSLHeader Header = new ctDynamicsSL.financial.accountsReceivable.input.invoiceAndMemo.ctDynamicsSLHeader();
                    Header.siteID = System.Configuration.ConfigurationManager.AppSettings["SITEID"];
                    Header.cpnyID = System.Configuration.ConfigurationManager.AppSettings["CPNYID"];
                    Header.licenseKey = System.Configuration.ConfigurationManager.AppSettings["LICENSEKEY"];
                    Header.licenseName = System.Configuration.ConfigurationManager.AppSettings["LICENSENAME"];
                    Header.licenseExpiration = System.Configuration.ConfigurationManager.AppSettings["LICENSEEXPIRATION"];
                    Header.siteKey = System.Configuration.ConfigurationManager.AppSettings["SITEKEY"];
                    Header.softwareName = "CTAPI";
                    myIMObjValue = new ctDynamicsSL.financial.accountsReceivable.input.invoiceAndMemo.invoiceAndMemo();
                    myIMObjValue.ctDynamicsSLHeaderValue = Header;
                    myIMObjValue.Timeout = 300000;
                }
                return myIMObjValue;
            }
            set
            {
                myIMObjValue = value;
            }
        }

        //Button action to release a batch,  setup to automatically load the batch first
        private void btnRelease_Click(object sender, EventArgs e)
        {
            myScreen = myIMObj.getScreenByBatNbr(tbBatNbr.Text);
            if (myScreen.errorMessage != "")
            {
                MessageBox.Show("Error: " + myScreen.errorMessage);
                return;
            }
            else
            {
                myScreen = myIMObj.editScreen("RELEASENOW", myScreen);
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
            myScreen = myIMObj.getScreenByBatNbr(tbBatNbr.Text);
            if (myScreen.errorMessage != "")
            {
                MessageBox.Show("Error: " + myScreen.errorMessage);
                return;
            }
            btnSaveAll.Enabled = true;

            try { tbRefNbr.Text = myScreen.myARDoc.RefNbr; }
            catch { }
            try { tbCustID.Text = myScreen.myARDoc.CustId; }
            catch { }
            gvARTran.DataSource = myScreen.myARTran;

            tbScreen.Text = ctStandardLib.ctHelper.serializeObject(myScreen).Replace("><", ">" + Environment.NewLine + "<");
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
                myScreen.myARDoc = new ctDynamicsSL.financial.accountsReceivable.input.invoiceAndMemo.ARDoc();
                myScreen.myARDoc.CpnyID = myScreen.myBatch.CpnyID;
                myScreen.myARDoc.CustId = tbCustID.Text.Trim();
                myScreen.myARDoc = myIMObj.getNewARDoc(myScreen.myARDoc);
                myScreen.myARDoc.BankAcct = myIMObj.getAcctXrefsByAcct("", myScreen.myBatch.CpnyID)[0].Acct;//"1035";
                myScreen.myARDoc.BankSub = myIMObj.getSubXrefsBySub("", myScreen.myBatch.CpnyID)[0].Sub; //"00000000";
            }
            myScreen.myARTran = (ctDynamicsSL.financial.accountsReceivable.input.invoiceAndMemo.ARTran[])gvARTran.DataSource;
            if (myScreen.myARTran == null)
            {
                MessageBox.Show("ARTRAN is null");
                return;
            }
            myScreen = myIMObj.editScreen("UPDATE", myScreen);

            if (myScreen.errorMessage != "")
            {
                MessageBox.Show("Error: " + myScreen.errorMessage);
                return;
            }
            else
            {
                tbRefNbr.Text = myScreen.myARDoc.RefNbr.Trim();
                gvARTran.DataSource = myScreen.myARTran;
            }
            MessageBox.Show("Saved Successfully!");
        }

        //Pulls up the batch list search box
        private void btnSearch_Click(object sender, EventArgs e)
        {
            batchesPopup newPopup = new batchesPopup(this, tbBatNbr.Text);
            newPopup.ShowDialog();
        }

        //Creates an empty new payment batch entry
        //With a default doc and line items
        private void btnNew_Click(object sender, EventArgs e)
        {
            ctDynamicsSL.financial.accountsReceivable.input.invoiceAndMemo.customer myCustomer = myIMObj.getCustomersByCustID("")[0];

            myScreen = myIMObj.getNewscreen(null);
            myScreen.myARDoc.CustId = myCustomer.CustID; //require custID
            myScreen.myARDoc.DocType = "IN"; //doctype required
            myScreen.myARDoc.DocDate = System.DateTime.Now;
            myScreen.myARDoc.DueDate = myScreen.myARDoc.DocDate.AddDays(30);
            myScreen.myARDoc.Terms = myCustomer.Terms;

            myScreen.myARTran[0].Acct = myIMObj.getAcctXrefsByAcct("", myScreen.myBatch.CpnyID)[0].Acct; //required
            myScreen.myARTran[0].Sub = myIMObj.getSubXrefsBySub("", myScreen.myBatch.CpnyID)[0].Sub;
            myScreen.myARTran[0].TranType = "IN";
           
            myScreen.batchNote = new ctDynamicsSL.financial.accountsReceivable.input.invoiceAndMemo.Snote();
            myScreen.batchNote.sNoteText = "my test batch note";
            myScreen.invoiceNote = new ctDynamicsSL.financial.accountsReceivable.input.invoiceAndMemo.Snote();
            myScreen.invoiceNote.sNoteText = "my test invoice note";

            myScreen = myIMObj.editScreen("ADD", myScreen);
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

        /// <summary>
        /// Example use of the search Invoices call
        /// All paramaters are optional.
        /// Final param: uses the nameValuePairs object array for customization purposes.
        /// </summary>
        private void btnSearchInvoices_Click(object sender, EventArgs e)
        {
            var invoices = myIMObj.searchInvoiceAndMemo("", "IN", "", "", "", "", "", "", System.DateTime.Now.AddDays(-30), System.DateTime.Now, null);
            var serializedInvoices = ctStandardLib.ctHelper.serializeObject(invoices);
            MessageBox.Show(serializedInvoices);
            tbScreen.Text = serializedInvoices.Replace("><", ">" + System.Environment.NewLine + "<");
        }

        //This will add an Additional ARDoc and ARTran to an exissting open batch
        private void btnAddNewDoc_Click(object sender, EventArgs e)
        {
            if (myScreen == null)
            {
                MessageBox.Show("You must load a batch first!");
                return;
            }
            else
            {
                if (myScreen.myBatch.Status != "H")
                {
                    MessageBox.Show("You can only add items to an open batch!");
                    return;
                }
            }
            if (tbCustID.Text.Trim() == "")
            {
                MessageBox.Show("You must select a custID first!");
                return;
            }

            myScreen.errorMessage = "";

            //clear out any alread loaded docs,tranns
            myScreen.myARDoc = new ctDynamicsSL.financial.accountsReceivable.input.invoiceAndMemo.ARDoc();
            myScreen.myARTran = new ctDynamicsSL.financial.accountsReceivable.input.invoiceAndMemo.ARTran[0];
            List<ctDynamicsSL.financial.accountsReceivable.input.invoiceAndMemo.ARTran> newARTrans = new List<ctDynamicsSL.financial.accountsReceivable.input.invoiceAndMemo.ARTran>();


            myScreen.myARDoc.BatNbr = myScreen.myBatch.BatNbr;
            myScreen.myARDoc.CpnyID = myScreen.myBatch.CpnyID;
            myScreen.myARDoc.CustId = tbCustID.Text.Trim();
            myScreen.myARDoc.DocDate = System.DateTime.Now;

            //load any defaults based on cpnyId and custID
            myScreen.myARDoc = myIMObj.getNewARDoc(myScreen.myARDoc);
            myScreen.myARDoc.DocType = "IN"; //doctype required

            //lets validate and add our new ardoc to the screen object
            {
                var validate = myIMObj.editARDoc("VALIDATEONLY", myScreen.myARDoc);
                if (!String.IsNullOrWhiteSpace(validate.errorMessage))
                {
                    MessageBox.Show(validate.errorMessage);
                    return;
                }
            }

            //create our new artrans, validate them and add them to the newARTrans collection
            {
                var newARTran = new ctDynamicsSL.financial.accountsReceivable.input.invoiceAndMemo.ARTran();
                newARTran.CpnyID = myScreen.myBatch.CpnyID;
                newARTran.BatNbr = myScreen.myBatch.BatNbr;

                //load any defaults
                newARTran = myIMObj.getNewARTran(newARTran);

                newARTran.Acct = myIMObj.getAcctXrefsByAcct("", myScreen.myBatch.CpnyID)[0].Acct; //required
                newARTran.Sub = myIMObj.getSubXrefsBySub("", myScreen.myBatch.CpnyID)[0].Sub;
                newARTran.TranType = myScreen.myARDoc.DocType;

                {
                    var validate = myIMObj.editARTran("VALIDATEONLY", newARTran);
                    if (!String.IsNullOrWhiteSpace(validate.errorMessage))
                    {
                        MessageBox.Show(validate.errorMessage);
                        return;
                    }
                    else
                    {
                        newARTrans.Add(newARTran);
                    }
                }
            }

            //all new artrans are vaildated, lets add to the screen
            myScreen.myARTran = newARTrans.ToArray();

            
            //lets update our batch screen object
            {
                var validate = myIMObj.editScreen("VALIDATEONLY", myScreen);
                if (!String.IsNullOrWhiteSpace(validate.errorMessage))
                {
                    MessageBox.Show(validate.errorMessage);
                    return;
                }
                else
                {
                    MessageBox.Show("About to save: " + System.Environment.NewLine + ctStandardLib.ctHelper.serializeObject(myScreen));
                    var add = myIMObj.editScreen("UPDATE", myScreen);
                    if (!String.IsNullOrWhiteSpace(add.errorMessage))
                    {
                        MessageBox.Show(add.errorMessage);
                        return;
                    }
                    else
                    {
                        myScreen = add;
                    }
                }
            }
        }
    }
}
