using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace client.orderManagement.maintenance.customerContacts
{
    public partial class Form1 : Form
    {
        private ctDynamicsSL.financial.accountsReceivable.maintenance.customerMaintenance.customerMaintenance myCustomersServiceValue = null;
        private ctDynamicsSL.orderManagement.maintenance.customerContacts.customerContacts myContactsServiceValue = null;
        public ctDynamicsSL.orderManagement.maintenance.customerContacts.screen myScreen = null;

        public ctDynamicsSL.orderManagement.maintenance.customerContacts.customerContacts myContactsService
        {
            //used for access to the webservice.  automatically creates the object if necessary
            get
            {
                if (myContactsServiceValue == null)
                {
                    //if we get here, then the object is not created
                    ctDynamicsSL.orderManagement.maintenance.customerContacts.ctDynamicsSLHeader Header = new ctDynamicsSL.orderManagement.maintenance.customerContacts.ctDynamicsSLHeader();
                    Header.siteID = System.Configuration.ConfigurationManager.AppSettings["SITEID"];
                    Header.cpnyID = System.Configuration.ConfigurationManager.AppSettings["CPNYID"];
                    Header.licenseKey = System.Configuration.ConfigurationManager.AppSettings["LICENSEKEY"];
                    Header.licenseName = System.Configuration.ConfigurationManager.AppSettings["LICENSENAME"];
                    Header.licenseExpiration = System.Configuration.ConfigurationManager.AppSettings["LICENSEEXPIRATION"];
                    Header.siteKey = System.Configuration.ConfigurationManager.AppSettings["SITEKEY"];
                    Header.softwareName = "CTAPI";
                    myContactsServiceValue = new ctDynamicsSL.orderManagement.maintenance.customerContacts.customerContacts();
                    myContactsServiceValue.ctDynamicsSLHeaderValue = Header;
                    myContactsServiceValue.Timeout = 300000;
                }
                return myContactsServiceValue;
            }
            set
            {
                myContactsServiceValue = value;
            }
        }

        public ctDynamicsSL.financial.accountsReceivable.maintenance.customerMaintenance.customerMaintenance myCustomersService
        {
            //used for access to the webservice.  automatically creates the object if necessary
            get
            {
                if (myCustomersServiceValue == null)
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
                    myCustomersServiceValue = new ctDynamicsSL.financial.accountsReceivable.maintenance.customerMaintenance.customerMaintenance();
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
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            customersPopup newPopup = new customersPopup(this, tbCustID.Text);
            newPopup.ShowDialog();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            myScreen = myContactsService.getScreenByCustID(tbCustID.Text.Trim());
            tbCustID.Text = myScreen.myCustID;
            gvContacts.DataSource = myScreen.myCustContacts;
            tbScreen.Text = ctStandardLib.ctHelper.serializeObject(myScreen);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (myScreen == null)
            {
                MessageBox.Show("You must load a customer first!");
                return;
            }

            myScreen.myCustContacts = (ctDynamicsSL.orderManagement.maintenance.customerContacts.CustContact[])gvContacts.DataSource;
            {
                var tmpScreen = myContactsService.editScreen("UPDATE", myScreen);
                if (tmpScreen.errorMessage.Trim() != "")
                {
                    MessageBox.Show(tmpScreen.errorMessage);
                    return;
                }
                else
                {
                    MessageBox.Show("Updated!");
                    tbCustID.Text = tmpScreen.myCustID;
                    btnLoad_Click(null, null);
                }
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            if (myScreen == null)
            {
                MessageBox.Show("You must load a customer first!");
                return;
            }

            tbCustID.Text = myScreen.myCustID;
            ctDynamicsSL.orderManagement.maintenance.customerContacts.CustContact newContact = myContactsService.getNewCustContact(null);

            //contactID requires a unique per custID value.  
            //For testing purposes we just use a partial guid
            newContact.ContactID = System.Guid.NewGuid().ToString().Replace("-", "").Substring(0, 10);
            newContact.CustID = myScreen.myCustID;
            newContact.Name = "My new test custID: " + newContact.ContactID;

            {
                var tmpNewContact = myContactsService.editCustContact("ADD", newContact);
                if (tmpNewContact.errorMessage.Trim() != "")
                {
                    MessageBox.Show(tmpNewContact.errorMessage);
                    return;
                }
                else
                {
                    newContact = tmpNewContact;
                    MessageBox.Show("Added: " + ctStandardLib.ctHelper.serializeObject(newContact));
                    btnLoad_Click(null, null);
                }
            }
        }

    }
}
