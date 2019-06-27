using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace client.project.timeAndExpense.maintenance.projectEmployeePositionRateMaintenance
{
    public partial class Form1 : Form
    {
        private ctDynamicsSL.common.common myCommonServiceValue = null;
        private ctDynamicsSL.project.timeAndExpense.maintenance.projectEmployeePositionRateMaintenance.projectEmployeePositionRateMaintenance myPEPRMServiceValue = null;
        private ctDynamicsSL.project.timeAndExpense.maintenance.projectEmployeePositionRateMaintenance.screen myScreen = null;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            employeesPopup newPopup = new employeesPopup(this);
            newPopup.ShowDialog();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            try
            {
                myScreen = myPEPRMService.getScreenByEmployee(tbEmployee.Text.Trim());
                if (myScreen.errorMessage != "")
                {
                    MessageBox.Show("Error: " + myScreen.errorMessage);
                    return;
                }
                btnUpdate.Enabled = true;
                tbScreen.Text = ctStandardLib.ctHelper.serializeObject(myScreen).Replace("><", ">" + Environment.NewLine + "<");
                gvPJEMPPJT.DataSource = myScreen.myPJEMPPJT;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unexpected error in Load: " + ex.Message);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            myScreen.myPJEMPPJT = (ctDynamicsSL.project.timeAndExpense.maintenance.projectEmployeePositionRateMaintenance.PJEMPPJT[])gvPJEMPPJT.DataSource;

            try
            {
                var validate = myPEPRMService.editScreen("VALIDATEONLY", myScreen);
                if (validate.errorMessage.Trim() != "")
                {
                    MessageBox.Show(validate.errorMessage);
                    return;
                }
                else
                {
                    var result = myPEPRMService.editScreen("UPDATE", myScreen);
                    if (result.errorMessage.Trim() != "")
                    {
                        MessageBox.Show(result.errorMessage);
                        return;
                    }
                    else
                    {
                        myScreen = result;
                        tbScreen.Text = ctStandardLib.ctHelper.serializeObject(myScreen).Replace("><", ">" + Environment.NewLine + "<");
                        gvPJEMPPJT.DataSource = myScreen.myPJEMPPJT;
                        MessageBox.Show("Update Complete!");
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Unexpected error in Update: " + ex.Message);
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            if (myScreen == null)
            {
                MessageBox.Show("You must load an employee first.");
                return;
            }

            var newEntry = new ctDynamicsSL.project.timeAndExpense.maintenance.projectEmployeePositionRateMaintenance.PJEMPPJT();
            newEntry.employee = myScreen.myPJEMPLOY.employee; //required
            newEntry = myPEPRMService.getNewPJEMPPJT(newEntry);//get any employee specific defaults
            newEntry.effect_date = System.DateTime.Now.AddDays(myScreen.myPJEMPPJT.Length); //required, setting date just for example
            newEntry.project = myPEPRMService.getProjectsByID("")[0].project; //required, just picking first one found from search;

            try
            {
                var outScreen = myScreen; //create a temporary duplicate of the loaded screen
                var outEntries = new System.Collections.Generic.List<ctDynamicsSL.project.timeAndExpense.maintenance.projectEmployeePositionRateMaintenance.PJEMPPJT>();
                outEntries.AddRange(myScreen.myPJEMPPJT); //add original entries from screen.
                outEntries.Add(newEntry); //add our new entry to the array.
                outScreen.myPJEMPPJT = outEntries.ToArray();

                var validate = myPEPRMService.editScreen("VALIDATEONLY", outScreen);
                if (validate.errorMessage.Trim() != "")
                {
                    MessageBox.Show(validate.errorMessage);
                    return;
                }
                else
                {
                    var result = myPEPRMService.editScreen("", outScreen);//leaving actionType blank will let the system determine if entries are new based on the keys.
                    if (result.errorMessage.Trim() != "")
                    {
                        MessageBox.Show(result.errorMessage);
                        return;
                    }
                    else
                    {
                        myScreen = result;
                        tbScreen.Text = ctStandardLib.ctHelper.serializeObject(myScreen).Replace("><", ">" + Environment.NewLine + "<");
                        gvPJEMPPJT.DataSource = myScreen.myPJEMPPJT;
                        MessageBox.Show("New Complete!");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unexpected error in New:: " + ex.Message);
            }
        }

        private void btnPVs_Click(object sender, EventArgs e)
        {

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
        public ctDynamicsSL.project.timeAndExpense.maintenance.projectEmployeePositionRateMaintenance.projectEmployeePositionRateMaintenance myPEPRMService
        {
            //used for access to the webservice.  automatically creates the object if necessary
            get
            {
                if (myPEPRMServiceValue == null)
                {
                    //if we get here, then the object is not created
                    ctDynamicsSL.project.timeAndExpense.maintenance.projectEmployeePositionRateMaintenance.ctDynamicsSLHeader Header = new ctDynamicsSL.project.timeAndExpense.maintenance.projectEmployeePositionRateMaintenance.ctDynamicsSLHeader();
                    Header.siteID = System.Configuration.ConfigurationManager.AppSettings["SITEID"];
                    Header.cpnyID = System.Configuration.ConfigurationManager.AppSettings["CPNYID"];
                    Header.licenseKey = System.Configuration.ConfigurationManager.AppSettings["LICENSEKEY"];
                    Header.licenseName = System.Configuration.ConfigurationManager.AppSettings["LICENSENAME"];
                    Header.licenseExpiration = System.Configuration.ConfigurationManager.AppSettings["LICENSEEXPIRATION"];
                    Header.siteKey = System.Configuration.ConfigurationManager.AppSettings["SITEKEY"];
                    Header.softwareName = "CTAPI";
                    myPEPRMServiceValue = new ctDynamicsSL.project.timeAndExpense.maintenance.projectEmployeePositionRateMaintenance.projectEmployeePositionRateMaintenance();
                    myPEPRMServiceValue.ctDynamicsSLHeaderValue = Header;
                    myPEPRMServiceValue.Timeout = 300000;
                }
                return myPEPRMServiceValue;
            }
            set
            {
                myPEPRMServiceValue = value;
            }
        }

    }
}
