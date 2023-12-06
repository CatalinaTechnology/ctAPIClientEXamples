using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace client.project.projectController.maintenance.projectEmployeeMaintenance
{
    /*PA.EMP.00 and TM.EPJ.00 */

    public partial class Form1 : Form
    {
        private ctDynamicsSL.common.common myCommonServiceValue = null;
        private ctDynamicsSL.project.projectController.maintenance.projectEmployeeMaintenance.projectEmployeeMaintenance myPEMServiceValue = null;

        //The main object that holds all the data represented in the SL screen
        public ctDynamicsSL.project.projectController.maintenance.projectEmployeeMaintenance.screen myScreen = null;

        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Calls all the gets/pvs/lookups in the web service for testing purposes
        /// </summary>
        private void btnGets_Click(object sender, EventArgs e)
        {
            try{MessageBox.Show("about: " + ctStandardLib.ctHelper.serializeObject(myPEMService.about())); } catch { }
            try{MessageBox.Show("getEmployeesByID: " + ctStandardLib.ctHelper.serializeObject(myPEMService.getEmployeesByID(""))); } catch { }
            try{MessageBox.Show("getEmployeeByExactID: " + ctStandardLib.ctHelper.serializeObject(myPEMService.getEmployeeByExactID(""))); } catch { }
            try{MessageBox.Show("getEmployeeTypesByID: " + ctStandardLib.ctHelper.serializeObject(myPEMService.getEmployeeTypesByID("")));} catch { }
            try{MessageBox.Show("getPJCodeByIDAndType: " + ctStandardLib.ctHelper.serializeObject(myPEMService.getPJCodeByIDAndType("", ""))); } catch { }
            try{MessageBox.Show("getVendorsByID: " + ctStandardLib.ctHelper.serializeObject(myPEMService.getVendorsByID(""))); } catch { }
            try{MessageBox.Show("getSubsByID: " + ctStandardLib.ctHelper.serializeObject(myPEMService.getSubsByID(""))); } catch { }
            try{MessageBox.Show("getRevenueAcctsByID: " + ctStandardLib.ctHelper.serializeObject(myPEMService.getRevenueAcctsByID(""))); } catch { }
            try{MessageBox.Show("getCostAcctsByID: "  + ctStandardLib.ctHelper.serializeObject(myPEMService.getCostAcctsByID(""))); } catch { }
            try{MessageBox.Show("getUsersByID: " + ctStandardLib.ctHelper.serializeObject(myPEMService.getUsersByID(""))); } catch { }
        }


        /// <summary>
        /// Loads the screen object using the employeeID
        /// </summary>
        private void btnLoad_Click(object sender, EventArgs e)
        {
            try
            {
                myScreen = myPEMService.getScreenByEmployee(tbEmployee.Text.Trim());
                if (myScreen.errorMessage != "")
                {
                    MessageBox.Show("Error: " + myScreen.errorMessage);
                    return;
                }
                tbScreen.Text = ctStandardLib.ctHelper.serializeObject(myScreen).Replace("><", ">" + Environment.NewLine + "<");

                gvPJEMPLOY.DataSource = null; //force reset of the datagridview
                {
                    //make a temporary array of PJEMPLOY just for tying to the datagridview
                    var tmp = new ctDynamicsSL.project.projectController.maintenance.projectEmployeeMaintenance.PJEMPLOY[1];
                    tmp[0] = myScreen.myPJEMPLOY;
                    gvPJEMPLOY.DataSource = tmp;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unexepected error: " + ex.Message);
            }
        }

        /// <summary>
        /// Saves any changes to the loaded employee back to SL
        /// </summary>
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (myScreen == null)
            {
                MessageBox.Show("You must load an employee first!");
                return;
            }

            {
                //make a temporary array of PJEMPLOY just for reading any changes from the datagridview
                var tmp = new ctDynamicsSL.project.projectController.maintenance.projectEmployeeMaintenance.PJEMPLOY[1];
                tmp = (ctDynamicsSL.project.projectController.maintenance.projectEmployeeMaintenance.PJEMPLOY[])gvPJEMPLOY.DataSource;
                //apply changes to our screen object
                myScreen.myPJEMPLOY = tmp[0];
            }

            try
            {
                //this will only validate all data but not save any changes to SL  (optional)
                var validate = myPEMService.editScreen("VALIDATEONLY", myScreen);
                if (validate.errorMessage.Trim() != "")
                {
                    MessageBox.Show("Error in Validation: " + validate.errorMessage);
                    return;
                }
                else
                {
                    //passed validation, lets update the employee
                    var update = myPEMService.editScreen("UPDATE", myScreen);
                    if (update.errorMessage.Trim() != "")
                    {
                        MessageBox.Show("Error in Update: " + update.errorMessage);
                        return;
                    }
                    else
                    {
                        //save complete, lets make sure our screen object has the latest data and update the grid and textbox
                        myScreen = update;
                        tbScreen.Text = ctStandardLib.ctHelper.serializeObject(myScreen).Replace("><", ">" + Environment.NewLine + "<");
                        gvPJEMPLOY.DataSource = null; //force reset of the datagridview
                        {
                            //make a temporary array of PJEMPLOY just for tying to the datagridview
                            var tmp = new ctDynamicsSL.project.projectController.maintenance.projectEmployeeMaintenance.PJEMPLOY[1];
                            tmp[0] = myScreen.myPJEMPLOY;
                            gvPJEMPLOY.DataSource = tmp;
                        }
                        MessageBox.Show("Save complete!");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unexepected error: " + ex.Message);
            }
        }

        /// <summary>
        /// Opens up a datagrid window listing any PJEMPLOY entries that are LIKE % the EmployeeID entered in the textbox
        /// </summary>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            employeesPopup newPopup = new employeesPopup(this);
            newPopup.ShowDialog();
        }


        /// <summary>
        ///Creates an empty new generic employee
        /// </summary>
        private void btnNew_Click(object sender, EventArgs e)
        {
            try
            {
                //clear out any currently load screen
                myScreen = myPEMService.getNewscreen(null);
                gvPJEMPLOY.DataSource = null;
                tbScreen.Text = "";


                //cpnyID required
                myScreen.myPJEMPLOY.CpnyId = System.Configuration.ConfigurationManager.AppSettings["CPNYID"];

                //employeeID is a required field
                {
                    String employeeID = tbEmployee.Text.Trim();
                    if (employeeID == "")
                    {
                        //employeeID required, using our builtin counter table as example if one is not entered
                        employeeID = myCommonService.getNextCounterAsString("EMPLOYEE");
                    }
                    myScreen.myPJEMPLOY.employee = employeeID;
                }

                myScreen.myPJEMPLOY.emp_name = "my test employee: " + myScreen.myPJEMPLOY.employee;
                myScreen.myPJEMPLOY.gl_subacct = myPEMService.getSubsByID("")[0].Sub; //required, just picking the first one

                myScreen.myPJEMPLOY.manager1 = myPEMService.getEmployeesByID("")[0].employee; //not required, just picking first employee for example

                //exampe of how to set the note in the screen
                ctDynamicsSL.project.projectController.maintenance.projectEmployeeMaintenance.Snote employeeNote = new ctDynamicsSL.project.projectController.maintenance.projectEmployeeMaintenance.Snote();
                employeeNote.sNoteText = "test employee note";
                myScreen.employeeNote = employeeNote;

                //this will only validate all data but not save any changes to SL  (optional)
                var validate = myPEMService.editScreen("VALIDATEONLY", myScreen);
                if (validate.errorMessage.Trim() != "")
                {
                    MessageBox.Show("Validation Error: " + validate.errorMessage);
                    return;
                }
                else
                {
                    //passed validation, lets ADD the employee
                    var add = myPEMService.editScreen("ADD", myScreen);
                    if (add.errorMessage.Trim() != "")
                    {
                        MessageBox.Show("Error in Add: " + add.errorMessage);
                        return;
                    }
                    else
                    {
                        //save complete, lets make sure our screen object has the latest data and update the grid and textbox
                        myScreen = add;
                        tbEmployee.Text = myScreen.myPJEMPLOY.employee.Trim();
                        tbScreen.Text = ctStandardLib.ctHelper.serializeObject(myScreen).Replace("><", ">" + Environment.NewLine + "<");
                        gvPJEMPLOY.DataSource = null; //force reset of the datagridview
                        {
                            //make a temporary array of PJEMPLOY just for tying to the datagridview
                            var tmp = new ctDynamicsSL.project.projectController.maintenance.projectEmployeeMaintenance.PJEMPLOY[1];
                            tmp[0] = myScreen.myPJEMPLOY;
                            gvPJEMPLOY.DataSource = tmp;
                        }
                        MessageBox.Show("Save complete!");
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Unexepected error: " + ex.Message);
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

        /// <summary>
        /// Reference to the projectEmployeeMaintence web service.
        /// automatically creates the object if necessary
        /// </summary>
        public ctDynamicsSL.project.projectController.maintenance.projectEmployeeMaintenance.projectEmployeeMaintenance myPEMService
        {
            get
            {
                if (myPEMServiceValue == null)
                {
                    //if we get here, then the object is not created
                    ctDynamicsSL.project.projectController.maintenance.projectEmployeeMaintenance.ctDynamicsSLHeader Header = new ctDynamicsSL.project.projectController.maintenance.projectEmployeeMaintenance.ctDynamicsSLHeader();
                    Header.siteID = System.Configuration.ConfigurationManager.AppSettings["SITEID"];
                    Header.cpnyID = System.Configuration.ConfigurationManager.AppSettings["CPNYID"];
                    Header.licenseKey = System.Configuration.ConfigurationManager.AppSettings["LICENSEKEY"];
                    Header.licenseName = System.Configuration.ConfigurationManager.AppSettings["LICENSENAME"];
                    Header.licenseExpiration = System.Configuration.ConfigurationManager.AppSettings["LICENSEEXPIRATION"];
                    Header.siteKey = System.Configuration.ConfigurationManager.AppSettings["SITEKEY"];
                    Header.softwareName = "CTAPI";
                    myPEMServiceValue = new ctDynamicsSL.project.projectController.maintenance.projectEmployeeMaintenance.projectEmployeeMaintenance();
                    myPEMServiceValue.ctDynamicsSLHeaderValue = Header;
                    myPEMServiceValue.Timeout = 300000;
                }
                return myPEMServiceValue;
            }
            set
            {
                myPEMServiceValue = value;
            }
        }

    }
}
