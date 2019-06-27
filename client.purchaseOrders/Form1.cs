using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace client.purchaseOrders
{
    public partial class Form1 : Form
    {
        private ctDynamicsSL.purchaseOrders.purchaseOrders myPurchaseOrdersServiceValue = null;
        public ctDynamicsSL.purchaseOrders.purchaseOrder myPurchaseOrder = null;

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


        private void btnLoad_Click(object sender, EventArgs e)
        {
            myPurchaseOrder = myPurchaseOrdersService.getPurchaseOrder(tbPONbr.Text);
            if (!myPurchaseOrder.returnVal.success)
            {
                MessageBox.Show("Error: " + myPurchaseOrder.returnVal.returnString);
                return;
            }
            btnUpdate.Enabled = true;
            tbOrder.Text = ctStandardLib.ctHelper.serializeObject(myPurchaseOrder).Replace("><", ">" + Environment.NewLine + "<");
            gvSOLine.DataSource = myPurchaseOrder.LineItems;
        }

        //Used to save a batch that has been loaded
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (myPurchaseOrder == null)
            {
                MessageBox.Show("You must load an purchaseOrder first!");
                return;
            }

            MessageBox.Show(ctStandardLib.ctHelper.serializeObject(myPurchaseOrder).Replace("><", ">" + Environment.NewLine + "<"));
            myPurchaseOrder = myPurchaseOrdersService.savePurchaseOrder(myPurchaseOrder);
            if (!myPurchaseOrder.returnVal.success)
            {
                MessageBox.Show("Error: " + myPurchaseOrder.returnVal.returnString);
            }
            else
            {
                MessageBox.Show("Save complete!");
            }
        }

        //Pulls up the batch list search box
        private void btnSearch_Click(object sender, EventArgs e)
        {
            purchaseOrdersPopup newPopup = new purchaseOrdersPopup(this, tbPONbr.Text);
            newPopup.ShowDialog();
        }

        //Creates an empty new generic batch
        private void btnNew_Click(object sender, EventArgs e)
        {
            myPurchaseOrder = new ctDynamicsSL.purchaseOrders.purchaseOrder();
            if (tbPONbr.Text.Trim() != "")
            {
                myPurchaseOrder.PONbr = tbPONbr.Text.Trim();
            }
            else
            {
                myPurchaseOrder.PONbr = "";// System.Guid.NewGuid().ToString().Substring(0, 6);
            }

            myPurchaseOrder.VendId = "CATALY01"; //vendid required
            myPurchaseOrder.Status = "P"; //open is default

            myPurchaseOrder.LineItems = new ctDynamicsSL.purchaseOrders.poLineItem[1];
            myPurchaseOrder.LineItems[0] = new ctDynamicsSL.purchaseOrders.poLineItem();
            myPurchaseOrder.LineItems[0].InvtID = "1000-AV-SYS";//a valid invtID is required
            myPurchaseOrder.LineItems[0].PC_Flag = "Y"; //billable flag is required
            myPurchaseOrder.LineItems[0].PurchaseType = "GS";  //Purchase type is required.
            myPurchaseOrder.LineItems[0].RcptPctAct = "N"; //receipt action is required
            myPurchaseOrder.LineItems[0].RcptPctMax = 100; //receipt qty max required
            myPurchaseOrder.LineItems[0].RcptPctMin = 100; //receipt qty min required
            myPurchaseOrder.LineItems[0].SiteID = ""; // siteid is required
            myPurchaseOrder.LineItems[0].UOM = "EA"; //purchunit is required
            myPurchaseOrder.LineItems[0].QtyOrd = 1;
            myPurchaseOrder.LineItems[0].CuryUnitCost = 100; //forces default pricing
            myPurchaseOrder.LineItems[0].ProjectID = "";//projectID required
            myPurchaseOrder.LineItems[0].PurAcct = "";//account required
            myPurchaseOrder.LineItems[0].PurSub = "";// sub account required    
            myPurchaseOrder.LineItems[0].TaskID = "";//task is required

            myPurchaseOrder = myPurchaseOrdersService.saveNewPurchaseOrder(myPurchaseOrder);
            if (!myPurchaseOrder.returnVal.success)
            {
                btnUpdate.Enabled = false;
                tbPONbr.Text = "";
                gvSOLine.DataSource = null;
                tbOrder.Text = ctStandardLib.ctHelper.serializeObject(myPurchaseOrder).Replace("><", ">" + Environment.NewLine + "<");
                MessageBox.Show("Error: " + myPurchaseOrder.returnVal.returnString);
                return; 
            }
            else
            {
                tbPONbr.Text = myPurchaseOrder.PONbr;
                btnLoad.PerformClick();
            }
        }

        private void btnMoveLines_Click(object sender, EventArgs e)
        {
            tbAltPONbr.Text = tbAltPONbr.Text.Trim();
            if (tbAltPONbr.Text == "")
            {
                MessageBox.Show("You must select a destination PONbr!");
                return;
            }

            ctDynamicsSL.purchaseOrders.nameValuePairs[] outParams = new ctDynamicsSL.purchaseOrders.nameValuePairs[1];
            outParams[0] = new ctDynamicsSL.purchaseOrders.nameValuePairs();
            outParams[0].name = "PONBR";
            outParams[0].value = tbAltPONbr.Text;
            ctDynamicsSL.purchaseOrders.PurchOrd[] altPO = myPurchaseOrdersService.getPurchOrds(0, 0, outParams);
            if (altPO.Length > 1)
            {
                MessageBox.Show("Too many Destination PO results!");
                return;
            }
            if (altPO.Length == 0)
            {
                MessageBox.Show("Invalid destination PONbr!");
                return;
            }
            //if we get here, we know we have a valid destination PO.

            if (gvSOLine.SelectedRows.Count == 0)
            {
                MessageBox.Show("No Rows Selected!");
                return;
            }

            ctDynamicsSL.purchaseOrders.purchaseOrder originalPO = myPurchaseOrdersService.getPurchaseOrder(tbPONbr.Text);
            ctDynamicsSL.purchaseOrders.poLineItem[] origOriginalItems = originalPO.LineItems;
            List<ctDynamicsSL.purchaseOrders.poLineItem> newOriginalItems = new List<ctDynamicsSL.purchaseOrders.poLineItem>();

            ctDynamicsSL.purchaseOrders.purchaseOrder destinationPO = myPurchaseOrdersService.getPurchaseOrder(tbAltPONbr.Text);
            ctDynamicsSL.purchaseOrders.poLineItem[] origDestinationItems = destinationPO.LineItems;
            List<ctDynamicsSL.purchaseOrders.poLineItem> newDestinationItems = new List<ctDynamicsSL.purchaseOrders.poLineItem>();
            newDestinationItems.AddRange(origDestinationItems);


            foreach (System.Windows.Forms.DataGridViewRow tmpRow in gvSOLine.SelectedRows)
            {
                String tmpRowLineRef = tmpRow.Cells["LINEREF"].Value.ToString().Trim().ToUpper();

                foreach (ctDynamicsSL.purchaseOrders.poLineItem tmpOrigItem in originalPO.LineItems)
                {
                    if (tmpRowLineRef == tmpOrigItem.LineRef.ToString().Trim().ToUpper())
                    {
                        ctDynamicsSL.purchaseOrders.poLineItem tmpItem = tmpOrigItem;
                        tmpItem.LineRef = "";
                        newDestinationItems.Add(tmpItem);
                        break;
                    }
                }
            }

            destinationPO.LineItems = newDestinationItems.ToArray();
            destinationPO = myPurchaseOrdersService.savePurchaseOrder(destinationPO);
            MessageBox.Show(ctStandardLib.ctHelper.serializeObject(destinationPO.returnVal));

            for (System.Int32 i = 0; i < origOriginalItems.Length; i++)
            {
                if (origOriginalItems[i].LineRef.Trim() != "")
                {
                    newOriginalItems.Add(origOriginalItems[i]);
                }
            }
            if (newOriginalItems.Count > 0)
            {
                originalPO.LineItems = newOriginalItems.ToArray();
                originalPO = myPurchaseOrdersService.savePurchaseOrder(originalPO);
            }
            else
            {
                originalPO = myPurchaseOrdersService.getPurchaseOrder(originalPO.PONbr);
                originalPO.Status = "X";
                originalPO = myPurchaseOrdersService.savePurchaseOrder(originalPO);
            }
            MessageBox.Show(ctStandardLib.ctHelper.serializeObject(originalPO.returnVal));
        }

        private void gvSOLine_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}

