using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace client.orderManagement.input.shippers
{
    public partial class Form1 : Form
    {
        private ctDynamicsSL.orderManagement.input.shippers.shippers myShippersServiceValue = null;
        private ctDynamicsSL.orders.orders myOrdersServiceValue = null;
        private ctDynamicsSL.customers.customers myCustomersServiceValue = null;
        private ctDynamicsSL.common.common myCommonServiceValue = null;
        public ctDynamicsSL.orderManagement.input.shippers.screen myScreen = null;

        public Form1()
        {
            InitializeComponent();
        }

        public ctDynamicsSL.orderManagement.input.shippers.shippers myShippersService
        {
            //used for access to the webservice.  automatically creates the object if necessary
            get
            {
                if (myShippersServiceValue == null)
                {
                    //if we get here, then the object is not created
                    ctDynamicsSL.orderManagement.input.shippers.ctDynamicsSLHeader Header = new ctDynamicsSL.orderManagement.input.shippers.ctDynamicsSLHeader();
                    Header.siteID = System.Configuration.ConfigurationManager.AppSettings["SITEID"];
                    Header.cpnyID = System.Configuration.ConfigurationManager.AppSettings["CPNYID"];
                    Header.licenseKey = System.Configuration.ConfigurationManager.AppSettings["LICENSEKEY"];
                    Header.licenseName = System.Configuration.ConfigurationManager.AppSettings["LICENSENAME"];
                    Header.licenseExpiration = System.Configuration.ConfigurationManager.AppSettings["LICENSEEXPIRATION"];
                    Header.siteKey = System.Configuration.ConfigurationManager.AppSettings["SITEKEY"];
                    Header.softwareName = "CTAPI";
                    myShippersServiceValue = new ctDynamicsSL.orderManagement.input.shippers.shippers();
                    myShippersServiceValue.ctDynamicsSLHeaderValue = Header;
                    myShippersServiceValue.Timeout = 300000;
                }
                return myShippersServiceValue;
            }
            set
            {
                myShippersServiceValue = value;
            }
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

        public ctDynamicsSL.customers.customers myCustomersService
        {
            //used for access to the webservice.  automatically creates the object if necessary
            get
            {
                if (myCustomersServiceValue == null)
                {
                    //if we get here, then the object is not created
                    ctDynamicsSL.customers.ctDynamicsSLHeader Header = new ctDynamicsSL.customers.ctDynamicsSLHeader();
                    Header.siteID = System.Configuration.ConfigurationManager.AppSettings["SITEID"];
                    Header.cpnyID = System.Configuration.ConfigurationManager.AppSettings["CPNYID"];
                    Header.licenseKey = System.Configuration.ConfigurationManager.AppSettings["LICENSEKEY"];
                    Header.licenseName = System.Configuration.ConfigurationManager.AppSettings["LICENSENAME"];
                    Header.licenseExpiration = System.Configuration.ConfigurationManager.AppSettings["LICENSEEXPIRATION"];
                    Header.siteKey = System.Configuration.ConfigurationManager.AppSettings["SITEKEY"];
                    Header.softwareName = "CTAPI";
                    myCustomersServiceValue = new ctDynamicsSL.customers.customers();
                    myCustomersServiceValue.ctDynamicsSLHeaderValue = Header;
                    myCustomersServiceValue.Timeout = 300000;
                }
                return myCustomersServiceValue;
            }
            set
            {
                myCustomersServiceValue = value;
            }
        }

        public ctDynamicsSL.common.common myCommonService
        {
            //used for access to the webservice.  automatically creates the object if necessary
            get
            {
                if (myCommonServiceValue == null)
                {
                    //if we get here, then the object is not created
                    ctDynamicsSL.common.ctDynamicsSLHeader Header = new ctDynamicsSL.common.ctDynamicsSLHeader();
                    Header.siteID = System.Configuration.ConfigurationManager.AppSettings["SITEID"];
                    Header.cpnyID = System.Configuration.ConfigurationManager.AppSettings["CPNYID"];
                    Header.licenseKey = System.Configuration.ConfigurationManager.AppSettings["LICENSEKEY"];
                    Header.licenseName = System.Configuration.ConfigurationManager.AppSettings["LICENSENAME"];
                    Header.licenseExpiration = System.Configuration.ConfigurationManager.AppSettings["LICENSEEXPIRATION"];
                    Header.siteKey = System.Configuration.ConfigurationManager.AppSettings["SITEKEY"];
                    Header.softwareName = "CTAPI";
                    myCommonServiceValue = new ctDynamicsSL.common.common();
                    myCommonServiceValue.ctDynamicsSLHeaderValue = Header;
                    myCommonServiceValue.Timeout = 300000;
                }
                return myCommonServiceValue;
            }
            set
            {
                myCommonServiceValue = value;
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            myScreen = myShippersService.getScreenByShipperID(tbShipperID.Text);
            if (myScreen.errorMessage != "")
            {
                MessageBox.Show("Error: " + myScreen.errorMessage);
                return;
            }
            btnUpdate.Enabled = true;
            tbScreen.Text = ctStandardLib.ctHelper.serializeObject(myScreen).Replace("><", ">" + Environment.NewLine + "<");
            gvSOShipLine.DataSource = myScreen.mySOShipLine;
        }

        //Used to save a batch that has been loaded
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (myScreen == null)
            {
                MessageBox.Show("You must load a shipper first!");
                return;
            }

            //MessageBox.Show(ctStandardLib.ctHelper.serializeObject(myScreen).Replace("><", ">" + Environment.NewLine + "<"));
            myScreen = myShippersService.editScreen("UPDATE", myScreen);
            if (myScreen.errorMessage != "")
            {
                MessageBox.Show("Error: " + myScreen.errorMessage);
            }
            else
            {
                MessageBox.Show("Save complete!");
            }
        }

        //Pulls up the batch list search box
        private void btnSearch_Click(object sender, EventArgs e)
        {
            shippersPopup newPopup = new shippersPopup(this, tbShipperID.Text);
            newPopup.ShowDialog();
        }

        //Creates an empty new generic batch
        private void btnNew_Click(object sender, EventArgs e)
        {
            myScreen = new ctDynamicsSL.orderManagement.input.shippers.screen();
            myScreen.mySOShipHeader = new ctDynamicsSL.orderManagement.input.shippers.SOShipHeader();
            myScreen.mySOShipHeader.CpnyID = System.Configuration.ConfigurationManager.AppSettings["CPNYID"];
            myScreen.mySOShipHeader.SOTypeID = "SO";
            myScreen.mySOShipHeader.CustID = tbCustID.Text;
            myScreen.mySOShipHeader.ShiptoType = "C";
            myScreen.mySOShipHeader.ShipCustID = tbCustID.Text;
            myScreen.mySOShipHeader.ShiptoID = myCustomersService.getCustomerValue(myScreen.mySOShipHeader.ShipCustID, "DFLTSHIPTOID");
            myScreen.mySOShipHeader.CustOrdNbr = tbCustOrdNbr.Text;
            myScreen.mySOShipHeader.OrdNbr = tbOrdNbr.Text;
            myScreen = myShippersService.getNewscreen(myScreen);
            myScreen.mySOShipHeader.ShipperID = myCommonService.getNextCounter("SHIPPERID").Tables[0].Rows[0]["OUTAMT"].ToString().Trim();
            myScreen.mySOShipHeader.ShipViaID = myShippersService.getShipViaIDsByID("")[0].ShipViaID.Trim();//just pick first one

            List<ctDynamicsSL.orderManagement.input.shippers.SOShipLine> myLineItems = new List<ctDynamicsSL.orderManagement.input.shippers.SOShipLine>();
            try
            {
                ctDynamicsSL.orderManagement.input.shippers.SOShipLine item1 = new ctDynamicsSL.orderManagement.input.shippers.SOShipLine();
                ctDynamicsSL.orderManagement.input.shippers.Inventory tmpInventory = myShippersService.getInventoriesForSaleByID("")[0];
                item1.CpnyID = myScreen.mySOShipHeader.CpnyID;
                item1.InvtID = tmpInventory.InvtID;
                item1 = myShippersService.getNewSOShipLine(item1);
                myLineItems.Add(item1);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding line item: " + ex.Message);
                return;
            }
            myScreen.mySOShipLine = myLineItems.ToArray();

            ctDynamicsSL.orderManagement.input.shippers.Snote shipperNote = new ctDynamicsSL.orderManagement.input.shippers.Snote();
            shipperNote.sNoteText = "test shipper note";
            myScreen.headerNote = shipperNote;

            myScreen = myShippersService.editScreen("ADD", myScreen);
            if (myScreen.errorMessage != "")
            {
                MessageBox.Show("Error: " + myScreen.errorMessage);
                return;
            }
            else
            {
                tbShipperID.Text = myScreen.mySOShipHeader.ShipperID;
                btnLoad.PerformClick();
            }

        }

        private void btnCustomer_Click(object sender, EventArgs e)
        {
            customersPopup newPopup = new customersPopup(this, tbCustID.Text);
            newPopup.ShowDialog();
        }

        private void btnCustOrdNbr_Click(object sender, EventArgs e)
        {

        }

        private void btnOrdNbr_Click(object sender, EventArgs e)
        {
            ordersPopup newPopup = new ordersPopup(this, tbOrdNbr.Text);
            newPopup.ShowDialog();
        }

    }
}

