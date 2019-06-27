using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace client.project.timeAndExpense.maintenance.projectExpenseTypeMaintenance
{
    public partial class Form1 : Form
    {
        private ctDynamicsSL.common.common myCommonServiceValue = null;
        private ctDynamicsSL.project.timeAndExpense.maintenance.projectExpenseTypeMaintenance.projectExpenseTypeMaintenance myPETMServiceValue = null;
        private ctDynamicsSL.project.timeAndExpense.maintenance.projectExpenseTypeMaintenance.screen myScreen = null;

        public Form1()
        {
            InitializeComponent();
            doLoadScreen();
        }


        /// <summary>
        /// creates a new expense type just using test/default values
        /// </summary>
        private void btnNew_Click(object sender, EventArgs e)
        {
            try
            {
                ctDynamicsSL.project.timeAndExpense.maintenance.projectExpenseTypeMaintenance.PJEXPTYP myExpenseType = myPETMService.getNewPJEXPTYP(null);
                //Key: exp_type required
                if (tbExpenseTypeID.Text.Trim() != "")
                {
                    myExpenseType.exp_type = tbExpenseTypeID.Text.Trim().ToUpper();
                }
                else
                {
                    //generating one using our counter since one was not specified
                    myExpenseType.exp_type = System.Guid.NewGuid().ToString().Substring(0, 4);
                }
                myExpenseType.desc_exp = "my test expense type";
                myExpenseType.default_rate = 100;
                myExpenseType.units_flag = "N"; //N,Y
                myExpenseType.gl_acct = myPETMService.getAccountsByAcct("")[0].Acct;//gl_accct is required, just selecting first one
                myExpenseType.tax_flag = "Y"; //N,Y
                myExpenseType.taxid = myPETMService.getTaxIDsByTaxID("")[0].TaxId;//required if tax_flag=Y
                //myExpenseType.noo

                var validate = myPETMService.editPJEXPTYP("VALIDATEONLY", myExpenseType);
                if (validate.errorMessage.Trim() != "")
                {
                    MessageBox.Show("Error validating expense type: " + validate.errorMessage);
                }
                else
                {
                    var result = myPETMService.editPJEXPTYP("ADD", myExpenseType);
                    if (result.errorMessage.Trim() != "")
                    {
                        MessageBox.Show("Error ADD expense type: " + result.errorMessage);
                    }
                    else
                    {
                        myExpenseType = null;
                        doLoadScreen();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unexpected error: " + ex.Message);
            }
        }

        /// <summary>
        /// loads the screen object and all expense types in the system
        /// </summary>
        private void doLoadScreen()
        {
            tbExpenseTypeID.Text = "";
            try
            {
                myScreen = myPETMService.getScreen();
                if (myScreen.errorMessage.Trim() != "")
                {
                    MessageBox.Show("Error loading screen: " + myScreen.errorMessage);
                }
                gvScreen.DataSource = myScreen.myPJEXPTYP;
                tbScreen.Text = ctStandardLib.ctHelper.serializeObject(myScreen).Replace("><", ">" + Environment.NewLine + "<");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unexpected error: " + ex.Message);
                tbScreen.Text = "Unexpected error: " + ex.Message;
                myScreen = null;
            }
        }

        /// <summary>
        /// That saves all expense types in the system from the grid 
        /// </summary>
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                myScreen.myPJEXPTYP = (ctDynamicsSL.project.timeAndExpense.maintenance.projectExpenseTypeMaintenance.PJEXPTYP[])gvScreen.DataSource;
                var validate = myPETMService.editScreen("VALIDATEONLY", myScreen);
                if (validate.errorMessage.Trim() != "")
                {
                    MessageBox.Show("Error validating screen: " + validate.errorMessage);
                }
                else
                {
                    var result = myPETMService.editScreen("UPDATE", myScreen);
                    if (result.errorMessage.Trim() != "")
                    {
                        MessageBox.Show("Error updating screen: " + result.errorMessage);
                    }
                    else
                    {
                        myScreen = result;
                        doLoadScreen();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unexpected error: " + ex.Message);
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
        public ctDynamicsSL.project.timeAndExpense.maintenance.projectExpenseTypeMaintenance.projectExpenseTypeMaintenance myPETMService
        {
            //used for access to the webservice.  automatically creates the object if necessary
            get
            {
                if (myPETMServiceValue == null)
                {
                    //if we get here, then the object is not created
                    ctDynamicsSL.project.timeAndExpense.maintenance.projectExpenseTypeMaintenance.ctDynamicsSLHeader Header = new ctDynamicsSL.project.timeAndExpense.maintenance.projectExpenseTypeMaintenance.ctDynamicsSLHeader();
                    Header.siteID = System.Configuration.ConfigurationManager.AppSettings["SITEID"];
                    Header.cpnyID = System.Configuration.ConfigurationManager.AppSettings["CPNYID"];
                    Header.licenseKey = System.Configuration.ConfigurationManager.AppSettings["LICENSEKEY"];
                    Header.licenseName = System.Configuration.ConfigurationManager.AppSettings["LICENSENAME"];
                    Header.licenseExpiration = System.Configuration.ConfigurationManager.AppSettings["LICENSEEXPIRATION"];
                    Header.siteKey = System.Configuration.ConfigurationManager.AppSettings["SITEKEY"];
                    Header.softwareName = "CTAPI";
                    myPETMServiceValue = new ctDynamicsSL.project.timeAndExpense.maintenance.projectExpenseTypeMaintenance.projectExpenseTypeMaintenance();
                    myPETMServiceValue.ctDynamicsSLHeaderValue = Header;
                    myPETMServiceValue.Timeout = 300000;
                }
                return myPETMServiceValue;
            }
            set
            {
                myPETMServiceValue = value;
            }
        }

    }
}
