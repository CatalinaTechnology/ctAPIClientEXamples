using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace client.financial.accountsReceivable.maintenance.customerMaintenance
{
    public partial class Form1 : Form
    {
        private ctDynamicsSL.financial.accountsReceivable.maintenance.customerMaintenance.customerMaintenance myCMObjValue = null;
        public ctDynamicsSL.financial.accountsReceivable.maintenance.customerMaintenance.screen myScreen = null;

        public ctDynamicsSL.financial.accountsReceivable.maintenance.customerMaintenance.customerMaintenance myCMObj
        {
            //used for access to the webservice.  automatically creates the object if necessary
            get
            {
                if (myCMObjValue == null)
                {
                    //if we get here, then the object is not created
                    ctDynamicsSL.financial.accountsReceivable.maintenance.customerMaintenance.ctDynamicsSLHeader Header = new ctDynamicsSL.financial.accountsReceivable.maintenance.customerMaintenance.ctDynamicsSLHeader();
                    Header.siteID = System.Configuration.ConfigurationManager.AppSettings["SITEID"];
                    Header.cpnyID = System.Configuration.ConfigurationManager.AppSettings["CPNYID"];
                    Header.licenseKey = System.Configuration.ConfigurationManager.AppSettings["LICENSEKEY"];
                    Header.licenseName = System.Configuration.ConfigurationManager.AppSettings["LICENSENAME"];
                    Header.licenseExpiration = System.Configuration.ConfigurationManager.AppSettings["LICENSEEXPIRATION"];
                    Header.siteKey = System.Configuration.ConfigurationManager.AppSettings["SITEKEY"];
                    Header.softwareName = "CTAPI";
                    myCMObjValue = new ctDynamicsSL.financial.accountsReceivable.maintenance.customerMaintenance.customerMaintenance();
                    myCMObjValue.ctDynamicsSLHeaderValue = Header;
                    myCMObjValue.Timeout = 300000;
                }
                return myCMObjValue;
            }
            set
            {
                myCMObjValue = value;
            }
        }
        
        public Form1()
        {
            InitializeComponent();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            myScreen = myCMObj.getScreenByCustID(tbCustID.Text);
            if (myScreen.errorMessage.Trim() != "")
            {
                MessageBox.Show("Error: " + myScreen.errorMessage);
                myScreen = null;
                return;
            }
            btnUpdate.Enabled = true;
            tbScreen.Text = ctStandardLib.ctHelper.serializeObject(myScreen).Replace("><", ">" + Environment.NewLine + "<");
            
            tbClassID.Text = myScreen.myCustomer.ClassId;
            tbUser2.Text = myScreen.myCustomer.User2;
            tbUser5.Text = myScreen.myCustomer.User5;
            tbSlsPerID.Text = myScreen.myCustomer.SlsperId;
            tbNotes.Text = myScreen.myCustomer.notes;
        }

        //Pulls up the customer list search box
        private void btnSearch_Click(object sender, EventArgs e)
        {
            customersPopup newPopup = new customersPopup(this, tbCustID.Text);
            newPopup.ShowDialog();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            myScreen = myCMObj.getNewscreen(null);
            myScreen.myCustomer.ClassId = "TECH";
            myScreen = myCMObj.getNewscreen(myScreen);

            myScreen.myCustomer.Name = "TEST";//required
            myScreen.myCustomer.ArAcct = myCMObj.getAcctXrefsByAcct("")[0].Acct;
            myScreen.myCustomer.ArSub = myCMObj.getSubXrefsBySub("")[0].Sub;//required
            //myScreen.myCustomer.ClassId = myCMObj.getCustClassesByID("")[0].ClassId;//required
            myScreen.myCustomer.TaxDflt = "C";//required C=Customer record, A = shipToID record
            myScreen.myCustomer.Status = "A";//required
            myScreen.myCustomer.StmtCycleId = myCMObj.getARStmtsByID("01")[0].StmtCycleId; //required
            myScreen.myCustomer.StmtType = "O"; //required
            myScreen.myCustomer.Terms = myCMObj.getTermsByID("30")[0].TermsId;//required
            myScreen.myCustomer.DfltShipToId = "DEFAULT"; //default shiptoid for new customers
            myScreen.myCustomer.SlsperId = myCMObj.getSalespersonsByID("")[0].SlsperId;

            var tmpValidation = myCMObj.editScreen("VALIDATEONLY", myScreen);
            if (myScreen.errorMessage != "")
            {
                //error validating all objects
                MessageBox.Show("Error: " + myScreen.errorMessage);
                tbScreen.Text = myScreen.errorMessage;
                return;
            }
            
            myScreen = myCMObj.editScreen("ADD", myScreen);
            if (myScreen.errorMessage != "")
            {
                btnUpdate.Enabled = false;
                tbCustID.Text = "";
                tbScreen.Text = ctStandardLib.ctHelper.serializeObject(myScreen).Replace("><", ">" + Environment.NewLine + "<");
                MessageBox.Show("Error: " + myScreen.errorMessage);
                return;
            }
            else
            {
                tbCustID.Text = myScreen.myCustomer.CustId;
                btnLoad.PerformClick();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (myScreen == null)
            {
                MessageBox.Show("You must load a customer first!");
                return;
            }

            MessageBox.Show(ctStandardLib.ctHelper.serializeObject(myScreen).Replace("><", ">" + Environment.NewLine + "<"));

            myScreen.myCustomer.ClassId = tbClassID.Text;
            myScreen.myCustomer.User2 = tbUser2.Text;
            myScreen.myCustomer.User5 = tbUser5.Text;
            myScreen.myCustomer.SlsperId = tbSlsPerID.Text;

            var tmpValidation = myCMObj.editScreen("VALIDATEONLY", myScreen);
            if (tmpValidation.errorMessage != "")
            {
                //error validating all objects
                MessageBox.Show("Error: " + tmpValidation.errorMessage);
                tbScreen.Text = tmpValidation.errorMessage;
                return;
            }

            myScreen = myCMObj.editScreen("UPDATE", myScreen);
            if (myScreen.errorMessage != "")
            {
                MessageBox.Show("Error: " + myScreen.errorMessage);
            }
            else
            {
                MessageBox.Show("Save complete!");
            }

        }
    }
}
