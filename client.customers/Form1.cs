using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace client.customers
{
    /// <summary>
    /// Main Form
    /// </summary>
    public partial class Form1 : Form
    {
        private ctDynamicsSL.common.common myCommonServiceValue = null;
        private ctDynamicsSL.customers.customers myCustomersServiceValue = null;

        /// <summary>
        /// global variable for myCustomer
        /// </summary>
        public ctDynamicsSL.customers.customer myCustomer = null;

        /// <summary>
        /// constructor
        /// </summary>
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Create Customer Service Reference
        /// </summary>
        public ctDynamicsSL.customers.customers myCustomersService
        {
            //used for access to the webservice.  automatically creates the object if necessary
            get
            {
                if (myCustomersServiceValue == null)
                {
                    //if we get here, then the object is not created
                    myCustomersServiceValue = new ctDynamicsSL.customers.customers
                    {
                        Timeout = 300000,
                        ctDynamicsSLHeaderValue = new ctDynamicsSL.customers.ctDynamicsSLHeader
                        {
                            siteID = System.Configuration.ConfigurationManager.AppSettings["SITEID"],
                            cpnyID = System.Configuration.ConfigurationManager.AppSettings["CPNYID"],
                            licenseKey = System.Configuration.ConfigurationManager.AppSettings["LICENSEKEY"],
                            licenseName = System.Configuration.ConfigurationManager.AppSettings["LICENSENAME"],
                            licenseExpiration = System.Configuration.ConfigurationManager.AppSettings["LICENSEEXPIRATION"],
                            siteKey = System.Configuration.ConfigurationManager.AppSettings["SITEKEY"],
                            softwareName = "CTAPI"
                        }
                    };
                }
                return myCustomersServiceValue;
            }
            set
            {
                myCustomersServiceValue = value;
            }
        }

        /// <summary>
        /// Create Common Service reference
        /// </summary>
        public ctDynamicsSL.common.common myCommonsService
        {
            //used for access to the webservice.  automatically creates the object if necessary
            get
            {
                if (myCommonServiceValue == null)
                {
                    //if we get here, then the object is not created
                    myCommonServiceValue = new ctDynamicsSL.common.common
                    {
                        Timeout = 300000,
                        ctDynamicsSLHeaderValue = new ctDynamicsSL.common.ctDynamicsSLHeader
                        {
                            siteID = System.Configuration.ConfigurationManager.AppSettings["SITEID"],
                            cpnyID = System.Configuration.ConfigurationManager.AppSettings["CPNYID"],
                            licenseKey = System.Configuration.ConfigurationManager.AppSettings["LICENSEKEY"],
                            licenseName = System.Configuration.ConfigurationManager.AppSettings["LICENSENAME"],
                            licenseExpiration = System.Configuration.ConfigurationManager.AppSettings["LICENSEEXPIRATION"],
                            siteKey = System.Configuration.ConfigurationManager.AppSettings["SITEKEY"],
                            softwareName = "CTAPI"
                        }
                    };

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
            myCustomer = myCustomersService.getCustomer(tbCustID.Text);
            if (myCustomer.errorString != "")
            {
                MessageBox.Show("Error: " + myCustomer.errorString);
                return;
            }
            btnUpdate.Enabled = true;
            tbScreen.Text = ctStandardLib.ctHelper.serializeObject(myCustomer).Replace("><", ">" + Environment.NewLine + "<");
            gvSOAddress.DataSource = myCustomer.addresses;
        }

        //Used to save a batch that has been loaded
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (myCustomer == null)
            {
                MessageBox.Show("You must load a customer first!");
                return;
            }

            MessageBox.Show(ctStandardLib.ctHelper.serializeObject(myCustomer).Replace("><", ">" + Environment.NewLine + "<"));

            myCustomer = myCustomersService.saveCustomer(myCustomer);
            if (myCustomer.errorString != "")
            {
                MessageBox.Show("Error: " + myCustomer.errorString);
            }
            else
            {
                MessageBox.Show("Save complete!");
            }

        }

        //Pulls up the batch list search box
        private void btnSearch_Click(object sender, EventArgs e)
        {
            customersPopup newPopup = new customersPopup(this, tbCustID.Text);
            newPopup.ShowDialog();
        }

        //Creates an empty new generic batch
        private void btnNew_Click(object sender, EventArgs e)
        {
            myCustomer = new ctDynamicsSL.customers.customer();
            String custID = myCommonsService.getNextCounter("CUSTID").Tables[0].Rows[0]["OUTAMT"].ToString().Trim(); //get a nnew incremented custID
            myCustomer.CustID = custID;//required
            myCustomer.Name = "TEST";//required
            myCustomer.ArAcct = "VALIDACCT";//required
            myCustomer.ArSub = "VALIDSUB";//required
            myCustomer.ClassId = "VALIDCLASSID";//required
            myCustomer.TaxDflt = "C";//required C=Customer record, A = shipToID record
            myCustomer.Status = "A";//required
            myCustomer.StmtCycleID = "01"; //required
            myCustomer.StmtType = "O"; //required
            myCustomer.Terms = "30";//required
            myCustomer.DfltShipToId = "DEFAULT"; //required

            myCustomer.addresses = new ctDynamicsSL.customers.address[1];
            myCustomer.addresses[0] = new ctDynamicsSL.customers.address();
            myCustomer.addresses[0].ShipToId = "DEFAULT";//sl standard for default address shipToID
            myCustomer.addresses[0].Name = "TEST";

            myCustomer = myCustomersService.saveNewCustomer(myCustomer, true);
            if (myCustomer.errorString != "")
            {
                btnUpdate.Enabled = false;
                tbCustID.Text = "";
                gvSOAddress.DataSource = null;
                tbScreen.Text = ctStandardLib.ctHelper.serializeObject(myCustomer).Replace("><", ">" + Environment.NewLine + "<");
                MessageBox.Show("Error: " + myCustomer.errorString);
                return;
            }
            else
            {
                tbCustID.Text = myCustomer.CustID;
                btnLoad.PerformClick();
            }
        }
    }
}

