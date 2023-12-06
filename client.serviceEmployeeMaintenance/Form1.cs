using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace client.fieldService.serviceDispatch.maintenance.serviceEmployeeMaintenance
{
    public partial class Form1 : Form
    {
        private ctDynamicsSL.common.common myCommonServiceValue = null;
        private ctDynamicsSL.fieldService.serviceDispatch.maintenance.serviceEmployeeMaintenance.serviceEmployeeMaintenance mySEMServiceValue = null;
        private ctDynamicsSL.fieldService.serviceDispatch.maintenance.serviceEmployeeMaintenance.screen myScreen = null;
        public Form1()
        {
            InitializeComponent();
        }


        /// <summary>
        /// opens the popup window that searches for service employee entries from the smEmp table in SL
        /// </summary>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            employeesPopup newPopup = new employeesPopup(this);
            newPopup.ShowDialog();
        }


        /// <summary>
        /// Loads a service employee screen object
        /// </summary>
        private void btnLoad_Click(object sender, EventArgs e)
        {
            try
            {
                myScreen = mySEMService.getScreenByEmployee(tbEmployeeID.Text.Trim());
                if (myScreen.errorMessage != "")
                {
                    MessageBox.Show("Error: " + myScreen.errorMessage);
                    return;
                }
                ctDynamicsSL.fieldService.serviceDispatch.maintenance.serviceEmployeeMaintenance.smEmp[] tmpArray = new ctDynamicsSL.fieldService.serviceDispatch.maintenance.serviceEmployeeMaintenance.smEmp[1];
                tmpArray[0] = myScreen.mysmEmp;
                gvsmEmp.DataSource = tmpArray;
                btnUpdate.Enabled = true;
                tbScreen.Text = ctStandardLib.ctHelper.serializeObject(myScreen).Replace("><", ">" + Environment.NewLine + "<");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unexpected error in Load: " + ex.Message);
            }
        }


        /// <summary>
        /// Sample code to generate a new service employee smEmp entry
        /// required fields marked as so
        /// lookups for all fields also listed
        /// </summary>
        private void btnNew_Click(object sender, EventArgs e)
        {
            try
            {
                String tmpEmployeeID = tbEmployeeID.Text.Trim();
                if (tmpEmployeeID == "")
                {//employeeID required, generating one
                    tmpEmployeeID = myCommonService.getNextCounterAsString("SMEMPLOYEEID");
                }

                //create a blank smEmp object
                var newEntry = new ctDynamicsSL.fieldService.serviceDispatch.maintenance.serviceEmployeeMaintenance.smEmp();
                newEntry.EmployeeId = tmpEmployeeID;//required
                newEntry.CpnyID = System.Configuration.ConfigurationManager.AppSettings["CPNYID"];//required

                //load any defaults that are dependent on cpnyID set above
                newEntry = mySEMService.getNewsmEmp(newEntry);//loads defaults

                newEntry.EmployeeFirstName = "Testing";//required
                newEntry.EmployeeLastName = "Guy";//required
                //not required fields; but if set they must be valid
                newEntry.employeeaddress1 = "1 Test Rd.";
                newEntry.EmployeeCity = "Beverly Hills";
                try
                {
                    newEntry.EmployeeBranchID = mySEMService.getBranchesByID("")[0].BranchId;
                }
                catch { }
                try
                {
                    newEntry.EmployeePayRollId = mySEMService.getPayrollIDsByID("")[0].EmpId;
                }
                catch { }
                try
                {
                    newEntry.InvtSiteID = mySEMService.getSitesByID("")[0].SiteId;
                }
                catch { }
                try
                {
                    newEntry.EmployeeState = mySEMService.getStatesByID("")[0].StateProvId;
                }
                catch { }
                try
                {
                    newEntry.TemplateID = mySEMService.getTemplatesByID("")[0].TemplateId;
                }
                catch { }
                try
                {
                    newEntry.EmployeeZip = mySEMService.getZipCodesByID("")[0].ZipId;
                }
                catch { }
                try
                {
                    newEntry.EmployeeType = mySEMService.getEmployeeClassesByID("")[0].Empclassid;
                }
                catch { }

                //populate a screen object with our new entry
                myScreen = new ctDynamicsSL.fieldService.serviceDispatch.maintenance.serviceEmployeeMaintenance.screen();
                myScreen.mysmEmp = newEntry;

                //make a call to validate the screen
                var validate = mySEMService.editScreen("VALIDATEONLY", myScreen);
                if (validate.errorMessage.Trim() != "")
                {
                    //if errorMessage is blank, then validation failed
                    MessageBox.Show(validate.errorMessage);
                    return;
                }
                else
                {
                    //passed validation, lets save the new entry with ADD
                    var result = mySEMService.editScreen("ADD", myScreen);
                    if (result.errorMessage.Trim() != "")
                    {
                        //Error saving!
                        MessageBox.Show(result.errorMessage);
                        return;
                    }
                    else
                    {
                        //no errors in saving, lets save the results to the screen
                        myScreen = result;
                        tbScreen.Text = ctStandardLib.ctHelper.serializeObject(myScreen).Replace("><", ">" + Environment.NewLine + "<");
                        ctDynamicsSL.fieldService.serviceDispatch.maintenance.serviceEmployeeMaintenance.smEmp[] tmpArray = new ctDynamicsSL.fieldService.serviceDispatch.maintenance.serviceEmployeeMaintenance.smEmp[1];
                        tmpArray[0] = myScreen.mysmEmp;
                        gvsmEmp.DataSource = tmpArray;
                        tbEmployeeID.Text = myScreen.mysmEmp.EmployeeId;
                        MessageBox.Show("New Complete!");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unexpected error in New:: " + ex.Message);
            }
        }

        /// <summary>
        /// sample code to update a loaded service employee
        /// </summary>
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (myScreen == null)
            {
                MessageBox.Show("You must load an employee before updating!");
                return;
            }

            try
            {
                //pull our smEmp entry from the grid on window to get any changes
                ctDynamicsSL.fieldService.serviceDispatch.maintenance.serviceEmployeeMaintenance.smEmp[] tmpArray = (ctDynamicsSL.fieldService.serviceDispatch.maintenance.serviceEmployeeMaintenance.smEmp[])gvsmEmp.DataSource;
                //set the updated data to our screen object
                myScreen.mysmEmp = tmpArray[0];

                //test the data with the VALIDATEONLY call
                var validate = mySEMService.editScreen("VALIDATEONLY", myScreen);
                if (validate.errorMessage.Trim() != "")
                {
                    //failed validation, error out
                    MessageBox.Show(validate.errorMessage);
                    return;
                }
                else
                {
                    //passed validation, lets UPDATE the entry
                    var result = mySEMService.editScreen("UPDATE", myScreen);
                    if (result.errorMessage.Trim() != "")
                    {
                        //failed for some reason
                        MessageBox.Show(result.errorMessage);
                        return;
                    }
                    else
                    {
                        //UPDATE complete, lets reload the current data to the window
                        myScreen = result;
                        tbScreen.Text = ctStandardLib.ctHelper.serializeObject(myScreen).Replace("><", ">" + Environment.NewLine + "<");
                        tmpArray = new ctDynamicsSL.fieldService.serviceDispatch.maintenance.serviceEmployeeMaintenance.smEmp[1];
                        tmpArray[0] = myScreen.mysmEmp;
                        gvsmEmp.DataSource = tmpArray;
                        MessageBox.Show("Update Complete!");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unexpected error in Update: " + ex.Message);
            }
        }

        /// <summary>
        /// Test button to test all the gets/lookups in the service
        /// </summary>
        private void btnGets_Click(object sender, EventArgs e)
        {
            tbScreen.Text = "";
            String tmpOutput = "";
            try { tmpOutput = "getBranchesByID: " + ctStandardLib.ctHelper.serializeObject(mySEMService.getBranchesByID("")); MessageBox.Show(tmpOutput); tbScreen.Text += tmpOutput + System.Environment.NewLine; } catch { }
            try { tmpOutput = "getPayrollIDsByID: " + ctStandardLib.ctHelper.serializeObject(mySEMService.getPayrollIDsByID("")); MessageBox.Show(tmpOutput); tbScreen.Text += tmpOutput + System.Environment.NewLine; } catch { }
            try { tmpOutput = "getSitesByID: " + ctStandardLib.ctHelper.serializeObject(mySEMService.getSitesByID("")); MessageBox.Show(tmpOutput); tbScreen.Text += tmpOutput + System.Environment.NewLine; } catch { }
            try { tmpOutput = "getStatesByID: " + ctStandardLib.ctHelper.serializeObject(mySEMService.getStatesByID("")); MessageBox.Show(tmpOutput); tbScreen.Text += tmpOutput + System.Environment.NewLine; } catch { }
            try { tmpOutput = "getTemplatesByID: " + ctStandardLib.ctHelper.serializeObject(mySEMService.getTemplatesByID("")); MessageBox.Show(tmpOutput); tbScreen.Text += tmpOutput + System.Environment.NewLine; } catch { }
            try { tmpOutput = "getZipCodesByID: " + ctStandardLib.ctHelper.serializeObject(mySEMService.getZipCodesByID("")); MessageBox.Show(tmpOutput); tbScreen.Text += tmpOutput + System.Environment.NewLine; } catch { }
            try { tmpOutput = "getEmployeeClassesByID: " + ctStandardLib.ctHelper.serializeObject(mySEMService.getEmployeeClassesByID("")); MessageBox.Show(tmpOutput); tbScreen.Text += tmpOutput + System.Environment.NewLine; } catch { }
            try { tmpOutput = "getEmployeesByID: " + ctStandardLib.ctHelper.serializeObject(mySEMService.getEmployeesByID("")); MessageBox.Show(tmpOutput); tbScreen.Text += tmpOutput + System.Environment.NewLine; } catch { }
            try { tmpOutput = "getEmployeeByExactID: " + ctStandardLib.ctHelper.serializeObject(mySEMService.getEmployeeByExactID(mySEMService.getEmployeesByID("")[0].EmployeeId)); MessageBox.Show(tmpOutput); tbScreen.Text += tmpOutput + System.Environment.NewLine; } catch { }
            try { tmpOutput = "getNewscreen: " + ctStandardLib.ctHelper.serializeObject(mySEMService.getNewscreen(null)); MessageBox.Show(tmpOutput); tbScreen.Text += tmpOutput + System.Environment.NewLine; } catch { }
            try { tmpOutput = "getNewsmEmp: " + ctStandardLib.ctHelper.serializeObject(mySEMService.getNewsmEmp(null)); MessageBox.Show(tmpOutput); tbScreen.Text += tmpOutput + System.Environment.NewLine; } catch { }
            try { tmpOutput = "getScreenByEmployee: " + ctStandardLib.ctHelper.serializeObject(mySEMService.getScreenByEmployee(mySEMService.getEmployeesByID("")[0].EmployeeId)); MessageBox.Show(tmpOutput); tbScreen.Text += tmpOutput + System.Environment.NewLine; } catch { }
        }

        /// <summary>
        /// Reference to the serviceEmployeeMaintenance web service.
        /// automatically creates the object if necessary
        /// </summary>
        public ctDynamicsSL.fieldService.serviceDispatch.maintenance.serviceEmployeeMaintenance.serviceEmployeeMaintenance mySEMService
        {
            get
            {
                if (mySEMServiceValue == null)
                {
                    //if we get here, then the object is not created
                    var Header = new ctDynamicsSL.fieldService.serviceDispatch.maintenance.serviceEmployeeMaintenance.ctDynamicsSLHeader();
                    Header.siteID = System.Configuration.ConfigurationManager.AppSettings["SITEID"];
                    Header.cpnyID = System.Configuration.ConfigurationManager.AppSettings["CPNYID"];
                    Header.licenseKey = System.Configuration.ConfigurationManager.AppSettings["LICENSEKEY"];
                    Header.licenseName = System.Configuration.ConfigurationManager.AppSettings["LICENSENAME"];
                    Header.licenseExpiration = System.Configuration.ConfigurationManager.AppSettings["LICENSEEXPIRATION"];
                    Header.siteKey = System.Configuration.ConfigurationManager.AppSettings["SITEKEY"];
                    Header.softwareName = "CTAPI";
                    mySEMServiceValue = new ctDynamicsSL.fieldService.serviceDispatch.maintenance.serviceEmployeeMaintenance.serviceEmployeeMaintenance();
                    mySEMServiceValue.ctDynamicsSLHeaderValue = Header;
                    mySEMServiceValue.Timeout = 300000;
                }
                return mySEMServiceValue;
            }
            set
            {
                mySEMServiceValue = value;
            }
        }

        /// <summary>
        /// Reference to the common web service.
        /// automatically creates the object if necessary
        /// </summary>
        public ctDynamicsSL.common.common myCommonService
        {
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

    }

}
