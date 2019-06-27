using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace client.orders
{
    public partial class Form1 : Form
    {
        private ctDynamicsSL.orders.orders myOrdersServiceValue = null;
        public ctDynamicsSL.orders.order myOrder = null;

        public Form1()
        {
            InitializeComponent();
        }

        public ctDynamicsSL.orders.orders myOrdersService
        {
            //used for access to the webservice.  automatically creates the object if necessary
            get
            {
                if (myOrdersServiceValue == null)
                {
                    //if we get here, then the object is not created
                    ctDynamicsSL.orders.ctDynamicsSLHeader Header = new ctDynamicsSL.orders.ctDynamicsSLHeader();
                    Header.siteID = System.Configuration.ConfigurationManager.AppSettings["SITEID"];
                    Header.cpnyID = System.Configuration.ConfigurationManager.AppSettings["CPNYID"];
                    Header.licenseKey = System.Configuration.ConfigurationManager.AppSettings["LICENSEKEY"];
                    Header.licenseName = System.Configuration.ConfigurationManager.AppSettings["LICENSENAME"];
                    Header.licenseExpiration = System.Configuration.ConfigurationManager.AppSettings["LICENSEEXPIRATION"];
                    Header.siteKey = System.Configuration.ConfigurationManager.AppSettings["SITEKEY"];
                    Header.softwareName = "CTAPI";
                    myOrdersServiceValue = new ctDynamicsSL.orders.orders();
                    myOrdersServiceValue.ctDynamicsSLHeaderValue = Header;
                    myOrdersServiceValue.Timeout = 300000;
                }
                return myOrdersServiceValue;
            }
            set
            {
                myOrdersServiceValue = value;
            }
        }



        private void btnLoad_Click(object sender, EventArgs e)
        {
            myOrder = myOrdersService.getOrder(tbOrdNbr.Text);
            if (myOrder.errorString != "")
            {
                MessageBox.Show("Error: " + myOrder.errorString);
                return;
            }
            btnUpdate.Enabled = true;
            tbOrder.Text = ctStandardLib.ctHelper.serializeObject(myOrder).Replace("><", ">" + Environment.NewLine + "<");
            gvSOLine.DataSource = myOrder.orderItems;
        }

        //Used to save a batch that has been loaded
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (myOrder == null)
            {
                MessageBox.Show("You must load an order first!");
                return;
            }

            MessageBox.Show(ctStandardLib.ctHelper.serializeObject(myOrder).Replace("><", ">" + Environment.NewLine + "<"));
            myOrder = myOrdersService.placeOrder(myOrder);
            if (myOrder.errorString != "")
            {
                MessageBox.Show("Error: " + myOrder.errorString);
            }
            else
            {
                MessageBox.Show("Save complete!");
            }
        }

        //Pulls up the batch list search box
        private void btnSearch_Click(object sender, EventArgs e)
        {
            ordersPopup newPopup = new ordersPopup(this, tbOrdNbr.Text);
            newPopup.ShowDialog();
        }

        //Creates an empty new generic batch
        private void btnNew_Click(object sender, EventArgs e)
        {
            myOrder = new ctDynamicsSL.orders.order();
            myOrder.CustID = "VALIDCUSTID"; // required
            myOrder.SOTypeID = "VALIDSOTYPE"; //required
            myOrder.ShipViaID = "VALIDSHIPVIA";
                
            //at least one line item required
            myOrder.orderItems = new ctDynamicsSL.orders.orderItem[1];
            myOrder.orderItems[0] = new ctDynamicsSL.orders.orderItem();
            myOrder.orderItems[0].InvtID = "VALIDINVTID"; //required
            myOrder.orderItems[0].QtyOrd = 1; //required
            myOrder.orderItems[0].CurySlsPrice = -999876;  // required, secret number to force solomon to price
            myOrder.orderItems[0].CuryCost = -999876;  // required, secret number to force solomon defaults
            myOrder.orderItems[0].Taxable = -1; //force SL default rules

            myOrder = myOrdersService.placeOrder(myOrder);
            if (myOrder.errorString != "")
            {
                btnUpdate.Enabled = false;
                tbOrdNbr.Text = "";
                gvSOLine.DataSource = null;
                tbOrder.Text = ctStandardLib.ctHelper.serializeObject(myOrder).Replace("><", ">" + Environment.NewLine + "<");
                MessageBox.Show("Error: " + myOrder.errorString);
                return;
            }
            else
            {
                tbOrdNbr.Text = myOrder.OrdNbr;
                btnLoad.PerformClick();
            }
        }
    }
}

