using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace client.financial.accountsPayable.input.voucherAndAdjustmentEntry
{
    public partial class Form1 : Form
    {
        private ctDynamicsSL.financial.accountsPayable.input.voucherAndAdjustmentEntry.voucherAndAdjustmentEntry myVAObjValue = null;
        public ctDynamicsSL.financial.accountsPayable.input.voucherAndAdjustmentEntry.screen myScreen = null;

        public Form1()
        {
            InitializeComponent();
        }

        public ctDynamicsSL.financial.accountsPayable.input.voucherAndAdjustmentEntry.voucherAndAdjustmentEntry myVAObj
        {
            //used for access to the webservice.  automatically creates the object if necessary
            get
            {
                if (myVAObjValue == null)
                {
                    //if we get here, then the object is not created
                    ctDynamicsSL.financial.accountsPayable.input.voucherAndAdjustmentEntry.ctDynamicsSLHeader Header = new ctDynamicsSL.financial.accountsPayable.input.voucherAndAdjustmentEntry.ctDynamicsSLHeader();
                    Header.siteID = System.Configuration.ConfigurationManager.AppSettings["SITEID"];
                    Header.cpnyID = System.Configuration.ConfigurationManager.AppSettings["CPNYID"];
                    Header.licenseKey = System.Configuration.ConfigurationManager.AppSettings["LICENSEKEY"];
                    Header.licenseName = System.Configuration.ConfigurationManager.AppSettings["LICENSENAME"];
                    Header.licenseExpiration = System.Configuration.ConfigurationManager.AppSettings["LICENSEEXPIRATION"];
                    Header.siteKey = System.Configuration.ConfigurationManager.AppSettings["SITEKEY"];
                    Header.softwareName = "CTAPI";
                    myVAObjValue = new ctDynamicsSL.financial.accountsPayable.input.voucherAndAdjustmentEntry.voucherAndAdjustmentEntry();
                    myVAObjValue.ctDynamicsSLHeaderValue = Header;
                    myVAObjValue.Timeout = 300000;
                }
                return myVAObjValue;
            }
            set
            {
                myVAObjValue = value;
            }
        }


        private void btnLoadBatch_Click(object sender, EventArgs e)
        {
            myScreen = myVAObj.getScreenByBatNbr(tbBatNbr.Text);
            if (myScreen.errorMessage != "")
            {
                MessageBox.Show("Error: " + myScreen.errorMessage);
                return;
            }
            tbRefNbr.Text = myScreen.myAPDoc.RefNbr;
            tbVendID.Text = myScreen.myAPDoc.VendId;
            gvAPTran.DataSource = myScreen.myAPTran;
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

            myScreen.myAPDoc.VendId = myVAObj.getVendorsByID(tbVendID.Text)[0].VendId;
            foreach (ctDynamicsSL.financial.accountsPayable.input.voucherAndAdjustmentEntry.APTran tmpTran in myScreen.myAPTran)
            {
                tmpTran.VendId = myScreen.myAPDoc.VendId;
                tmpTran.CuryTranAmt = tmpTran.CuryUnitPrice * tmpTran.Qty;
            }
            MessageBox.Show(ctStandardLib.ctHelper.serializeObject(myScreen).Replace("><", ">" + Environment.NewLine + "<"));
            myScreen = myVAObj.editScreen("UPDATE", myScreen);
            if (myScreen.errorMessage != "")
            {
                MessageBox.Show("Error: " + myScreen.errorMessage);
                return;
            }
            tbRefNbr.Text = myScreen.myAPDoc.RefNbr;
            tbVendID.Text = myScreen.myAPDoc.VendId;
            gvAPTran.DataSource = myScreen.myAPTran;
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
            myScreen = myVAObj.getNewscreen(null);
            if (tbVendID.Text.Trim() == "")
            {
                tbVendID.Text = myScreen.myAPDoc.VendId = myVAObj.getVendorsByID("")[0].VendId.Trim();//pick first vendID available
            }
            myScreen.myAPDoc.VendId = myVAObj.getVendorsByID(tbVendID.Text)[0].VendId;
            myScreen.myAPDoc.Terms = myVAObj.getVendorsByID(tbVendID.Text)[0].Terms;
            myScreen.myAPDoc.PmtMethod = myVAObj.getVendorsByID(tbVendID.Text)[0].PmtMethod;

            myScreen.myAPDoc.DocType = "VO";
            //myScreen.myAPDoc.Terms = myVAObj.getTermsByID("")[0].TermsId;//pick first termsID available
            myScreen.myAPDoc.CuryOrigDocAmt = 100;
            myScreen.myAPDoc.Status = "A";
            //myScreen.myAPDoc.Acct = myVAObj.getAcctXrefsByAcct("", myScreen.myBatch.CpnyID)[0].Acct;//get first acct
            //myScreen.myAPDoc.Sub = myVAObj.getSubXrefsBySub("", myScreen.myBatch.CpnyID)[0].Sub; //get first sub


            ctDynamicsSL.financial.accountsPayable.input.voucherAndAdjustmentEntry.Snote batchNote = new ctDynamicsSL.financial.accountsPayable.input.voucherAndAdjustmentEntry.Snote();
            batchNote.sNoteText ="test batch note";
            myScreen.batchNote = batchNote;

            ctDynamicsSL.financial.accountsPayable.input.voucherAndAdjustmentEntry.Snote documentNote = new ctDynamicsSL.financial.accountsPayable.input.voucherAndAdjustmentEntry.Snote();
            documentNote.sNoteText = "test document note";
            myScreen.documentNote = documentNote;

            List<ctDynamicsSL.financial.accountsPayable.input.voucherAndAdjustmentEntry.APTran> apTrans = new List<ctDynamicsSL.financial.accountsPayable.input.voucherAndAdjustmentEntry.APTran>();
            try
            {
                ctDynamicsSL.financial.accountsPayable.input.voucherAndAdjustmentEntry.APTran tmpTran = myVAObj.getNewAPTran(null);
                tmpTran.CpnyID = myScreen.myBatch.CpnyID;
                tmpTran.LineType = "N";
                tmpTran.Acct = myVAObj.getAcctXrefsByAcct("", myScreen.myBatch.CpnyID)[0].Acct;//get first acct
                tmpTran.Sub = myVAObj.getSubXrefsBySub("", myScreen.myBatch.CpnyID)[0].Sub; //get first sub
                tmpTran.TranDesc = "line 1";
                tmpTran.trantype = "VO";
                tmpTran.LineType = "N";
                tmpTran.DrCr = "D";
                tmpTran.Qty = 1;
                tmpTran.CuryUnitPrice = 100;
                tmpTran.CuryTranAmt = 100;
                tmpTran.VendId = myScreen.myAPDoc.VendId;
                apTrans.Add(tmpTran);
            }
            catch { }
            try
            {
                ctDynamicsSL.financial.accountsPayable.input.voucherAndAdjustmentEntry.APTran tmpTran = myVAObj.getNewAPTran(null);
                tmpTran.CpnyID = myScreen.myBatch.CpnyID;
                tmpTran.LineType = "N";
                tmpTran.Acct = myVAObj.getAcctXrefsByAcct("", myScreen.myBatch.CpnyID)[0].Acct;//get first acct
                tmpTran.Sub = myVAObj.getSubXrefsBySub("", myScreen.myBatch.CpnyID)[0].Sub; //get first sub
                tmpTran.TranDesc = "line 2";
                tmpTran.trantype = "VO";
                tmpTran.LineType = "N";
                tmpTran.DrCr = "D";
                tmpTran.Qty = 2;
                tmpTran.CuryUnitPrice = 100;
                tmpTran.CuryTranAmt = 200;
                tmpTran.VendId = myScreen.myAPDoc.VendId;
                apTrans.Add(tmpTran);
            }
            catch { }
            myScreen.myAPTran = apTrans.ToArray();

            myScreen = myVAObj.editScreen("ADD", myScreen);
            if (myScreen.errorMessage != "")
            {
                btnUpdate.Enabled = false;
                tbBatNbr.Text = "";
                tbRefNbr.Text = "";
                gvAPTran.DataSource = null;
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
            apDocsPopup newPopup = new apDocsPopup(this, tbRefNbr.Text);
            newPopup.ShowDialog();
        }

        //Pulls up the vendID list search box
        private void btnSearchVendID_Click(object sender, EventArgs e)
        {
            vendorsPopup newPopup = new vendorsPopup(this, tbVendID.Text);
            newPopup.ShowDialog();
        }

        public void loadAPTrans()
        {
            myScreen.myAPTran = myVAObj.getAPTransByRefNbr(tbRefNbr.Text);
            gvAPTran.DataSource = myScreen.myAPTran;
        }

    }
}

