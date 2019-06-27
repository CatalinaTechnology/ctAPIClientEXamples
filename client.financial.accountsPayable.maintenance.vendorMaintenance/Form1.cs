using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace client.financial.accountsPayable.maintenance.vendorMaintenance
{
    public partial class Form1 : Form
    {
        private ctDynamicsSL.financial.accountsPayable.maintenance.vendorMaintenance.vendorMaintenance myVendorsServiceValue = null;
        private ctDynamicsSL.common.common myCommonServiceValue = null;
        public ctDynamicsSL.financial.accountsPayable.maintenance.vendorMaintenance.screen myScreen = null;

        public Form1()
        {
            InitializeComponent();
        }


        public ctDynamicsSL.financial.accountsPayable.maintenance.vendorMaintenance.vendorMaintenance myVendorsService
        {
            //used for access to the webservice.  automatically creates the object if necessary
            get
            {
                if (myVendorsServiceValue == null)
                {
                    //if we get here, then the object is not created
                    myVendorsServiceValue = new ctDynamicsSL.financial.accountsPayable.maintenance.vendorMaintenance.vendorMaintenance
                    {
                        Timeout = 300000,
                        ctDynamicsSLHeaderValue = new ctDynamicsSL.financial.accountsPayable.maintenance.vendorMaintenance.ctDynamicsSLHeader
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
                return myVendorsServiceValue;
            }
            set
            {
                myVendorsServiceValue = value;
            }
        }

        public ctDynamicsSL.common.common myCommonsService
        {
            //used for access to the webservice.  automatically creates the object if necessary
            get
            {
                if (myCommonServiceValue == null)
                {
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
            myScreen = myVendorsService.getScreenByVendID(tbVendID.Text);

            if (myScreen.errorMessage != "")
            {
                MessageBox.Show("Error: " + myScreen.errorMessage);
                return;
            }
            btnUpdate.Enabled = true;
            tbScreen.Text = ctStandardLib.ctHelper.serializeObject(myScreen).Replace("><", ">" + Environment.NewLine + "<");
        }

        //Used to save a batch that has been loaded
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (myScreen == null)
            {
                MessageBox.Show("You must load a vendor first!");
                return;
            }

            myScreen.errorMessage = "";
            MessageBox.Show(ctStandardLib.ctHelper.serializeObject(myScreen).Replace("><", ">" + Environment.NewLine + "<"));

            myScreen = myVendorsService.editScreen("UPDATE", myScreen);
            if (myScreen.errorMessage != "")
            {
                MessageBox.Show("Error: " + myScreen.errorMessage);
            }
            else
            {
                MessageBox.Show("Save complete!");
            }

        }

        //Pulls up the customer list search box
        private void btnSearch_Click(object sender, EventArgs e)
        {
            vendorsPopup newPopup = new vendorsPopup(this);
            newPopup.ShowDialog();
        }

        //Creates an empty new generic batch
        private void btnNew_Click(object sender, EventArgs e)
        {
            myScreen = myVendorsService.getNewscreen(null);
            //we need to generate an invtID, for example purposes we will just use our counter and a random string
            myScreen.myVendor.VendId = "VEND"+myCommonsService.getNextCounter("VENDID").Tables[0].Rows[0]["OUTAMT"].ToString().Trim();

            /*example setting fields*/
            myScreen.myVendor.Name = "my test vendor" + myScreen.myVendor.VendId;
            myScreen.myVendor.TaxId00 = myVendorsService.getTaxIDsByTaxIDAndType("", "")[0].TaxId;//pick first entry
            myScreen.myVendor.Country = myVendorsService.getCountriesByCountryID("US")[0].CountryID;//pick first entry
            myScreen.myVendor.State = myVendorsService.getStatesByStateProvID("NJ")[0].StateProvId;//pick first entry
            myScreen.myVendor.CuryId = myVendorsService.getCurrencyByCuryID("")[0].CuryId;//pick first entry
            //myScreen.myVendor.LCCode = myVendorsService.getLandedCostsByID("")[0].LCCode;//pick first entry
            myScreen.myVendor.Terms = myVendorsService.getTermsByTermsID("")[0].TermsId;//pick first entry
            myScreen.myVendor.ClassID = myVendorsService.getVendClassesByClassID("")[0].ClassID;//pick first entry
            /*example setting fields*/

            try
            {
                ctDynamicsSL.financial.accountsPayable.maintenance.vendorMaintenance.Snote myVendorNote = new ctDynamicsSL.financial.accountsPayable.maintenance.vendorMaintenance.Snote();
                myVendorNote.sNoteText = "My test vendor note";
                myScreen.vendorNote = myVendorNote;
            }
            catch { }

            myScreen.errorMessage = "";
            try
            {
                ctDynamicsSL.financial.accountsPayable.maintenance.vendorMaintenance.screen validateScreen = myVendorsService.editScreen("VALIDATEONLY", myScreen);
                if (validateScreen.errorMessage != "")
                {
                    MessageBox.Show("Error: " + validateScreen.errorMessage);
                    return;
                }
            }
            catch { }

            myScreen = myVendorsService.editScreen("ADD", myScreen);
            if (myScreen.errorMessage != "")
            {
                btnUpdate.Enabled = false;
                tbVendID.Text = "";
                tbScreen.Text = ctStandardLib.ctHelper.serializeObject(myScreen).Replace("><", ">" + Environment.NewLine + "<");
                MessageBox.Show("Error: " + myScreen.errorMessage);
                return;
            }
            else
            {
                tbVendID.Text = myScreen.myVendor.VendId.Trim();
                btnLoad.PerformClick();
            }
        }

    }
}

