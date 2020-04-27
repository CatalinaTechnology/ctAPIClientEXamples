using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace client.receipts
{
    public partial class Form1 : Form
    {

        private ctDynamicsSL.purchaseOrders.purchaseOrders myPurchaseOrdersServiceValue = null;
        public ctDynamicsSL.purchaseOrders.poBatch myPOBatch = null;
        public Form1()
        {
            InitializeComponent();
        }

        public ctDynamicsSL.purchaseOrders.purchaseOrders myPurchaseOrdersService
        {
            //used for access to the webservice.  automatically creates the object if necessary
            get
            {
                if (myPurchaseOrdersServiceValue == null)
                {
                    //if we get here, then the object is not created
                    ctDynamicsSL.purchaseOrders.ctDynamicsSLHeader Header = new ctDynamicsSL.purchaseOrders.ctDynamicsSLHeader();
                    Header.siteID = System.Configuration.ConfigurationManager.AppSettings["SITEID"];
                    Header.cpnyID = System.Configuration.ConfigurationManager.AppSettings["CPNYID"];
                    Header.licenseKey = System.Configuration.ConfigurationManager.AppSettings["LICENSEKEY"];
                    Header.licenseName = System.Configuration.ConfigurationManager.AppSettings["LICENSENAME"];
                    Header.licenseExpiration = System.Configuration.ConfigurationManager.AppSettings["LICENSEEXPIRATION"];
                    Header.siteKey = System.Configuration.ConfigurationManager.AppSettings["SITEKEY"];
                    Header.softwareName = "CTAPI";
                    myPurchaseOrdersServiceValue = new ctDynamicsSL.purchaseOrders.purchaseOrders();
                    myPurchaseOrdersServiceValue.ctDynamicsSLHeaderValue = Header;
                    myPurchaseOrdersServiceValue.Timeout = 300000;
                }
                return myPurchaseOrdersServiceValue;
            }
            set
            {
                myPurchaseOrdersServiceValue = value;
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            saveReceipt(true);
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            myPOBatch = myPurchaseOrdersService.getReceipt(tbBatNbr.Text);
            if (!myPOBatch.returnVal.success)
            {
                MessageBox.Show("Error: " + myPOBatch.returnVal.returnString);
                return;
            }
            btnUpdate.Enabled = true;
            tbOrder.Text = ctStandardLib.ctHelper.serializeObject(myPOBatch).Replace("><", ">" + Environment.NewLine + "<");
            gvDocuments.DataSource = myPOBatch.Documents;

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            saveReceipt(false);
        }

        public void saveReceipt(System.Boolean bCreateNew)
        {
            ctDynamicsSL.purchaseOrders.poBatch myBatch = null;

            if (!bCreateNew)
            {
                if (tbBatNbr.Text.Trim() == "")
                {
                    MessageBox.Show("Please enter batNbr");
                    return;
                }
                //if there is a bat number, then 
                //first load the receipt from the db
                myBatch = myPurchaseOrdersService.getReceipt(tbBatNbr.Text);
                if (myBatch == null)
                {
                    MessageBox.Show("BatNbr not found!");
                    return;
                }
                if (!myBatch.returnVal.success)
                {
                    //there was an error retrieving the PO number
                    MessageBox.Show(myBatch.returnVal.returnString);
                    return;
                }
            }

            if (myBatch == null)
            {   //new batch
                myBatch = new ctDynamicsSL.purchaseOrders.poBatch();
                myBatch.BatchHandling = "H";
                myBatch.Status = "H";
                myBatch.PerPost = "201112";
                myBatch.Documents = new ctDynamicsSL.purchaseOrders.poDocument[1];
                myBatch.Documents[0] = new ctDynamicsSL.purchaseOrders.poDocument();
                
                myBatch.Documents[0].RcptType = "R";
                myBatch.Documents[0].RcptDate = System.DateTime.Now;
                myBatch.Documents[0].DfltFromPO = "A";
                myBatch.Documents[0].RcptQty = 1;
                myBatch.Documents[0].QtyTotal = 1;
                myBatch.Documents[0].PONbr = "000011";
                myBatch.Documents[0].S4Future01 = "123456";
                myBatch.Documents[0].CreateAD = false;
                //myBatch.Documents[0].Details = new ctDynamicsSL.purchaseOrders.poDetail[1];
                //myBatch.Documents[0].Details[0] = new ctDynamicsSL.purchaseOrders.poDetail();
                //myBatch.Documents[0].Details[0].Acct = "1320";
                //myBatch.Documents[0].Details[0].SubAcct = "00000945";
                //myBatch.Documents[0].Details[0].InvtID = "700018534";
                
                if (tbBatNbr.Text.Trim() != "")
                {
                    myBatch.BatNbr = tbBatNbr.Text.Trim();
                }
                else
                {
                    myBatch.BatNbr = "";
                }
            }
            else
            {
                myBatch.Documents[0].Details[0].RcptQty = 9;
                myBatch.Documents[0].Details[0].CuryUnitCost = 5;
            }

            // save it after filling in some of the fields from the screen
            ctDynamicsSL.purchaseOrders.poBatch oNewReceipt = null;
            if (bCreateNew)
            {
                oNewReceipt = myPurchaseOrdersService.saveNewReceipt(myBatch);
            }
            else
            {
                oNewReceipt = myPurchaseOrdersService.saveReceipt(myBatch);
            }

            if (!oNewReceipt.returnVal.success)
            {
                MessageBox.Show(oNewReceipt.returnVal.returnString);
                return;
            }
            else
            {

            }
        }
    }
}
