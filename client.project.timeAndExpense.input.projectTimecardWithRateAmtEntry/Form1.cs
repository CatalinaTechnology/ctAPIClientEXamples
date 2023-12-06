using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace client.project.timeAndExpense.input.projectTimecardWithRateAmtEntry
{
    public partial class Form1 : Form
    {
        private ctDynamicsSL.project.timeAndExpense.input.projectTimecardWithRateAmtEntry.projectTimecardWithRateAmtEntry myPTCServiceValue = null;
        private ctDynamicsSL.project.projectController.maintenance.projectMaintenance.projectMaintenance myPJServiceValue = null;
        public ctDynamicsSL.project.timeAndExpense.input.projectTimecardWithRateAmtEntry.screen myScreen = null;
        private ctDynamicsSL.common.common myCommonServiceValue = null;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnPVs_Click(object sender, EventArgs e)
        {
            MessageBox.Show("about: " + ctStandardLib.ctHelper.serializeObject(myPTCService.about()));
            MessageBox.Show("getTimecardEntriesByID: " + ctStandardLib.ctHelper.serializeObject(myPTCService.getTimecardEntriesByID("","")));
            try { MessageBox.Show("getTimecardEntryByExactID: " + ctStandardLib.ctHelper.serializeObject(myPTCService.getTimecardEntryByExactID("",""))); } catch { }
            MessageBox.Show("getTimecardDetailsByID: " + ctStandardLib.ctHelper.serializeObject(myPTCService.getTimecardDetailsByID("")));
            try { MessageBox.Show("getTimecardDetailByLineNbr: " + ctStandardLib.ctHelper.serializeObject(myPTCService.getTimecardDetailByLineNbr("", ""))); } catch { }
            MessageBox.Show("getEmployeesByID: " + ctStandardLib.ctHelper.serializeObject(myPTCService.getEmployeesByID("")));
            try { MessageBox.Show("getEmployeeByExactID: " + ctStandardLib.ctHelper.serializeObject(myPTCService.getEmployeeByExactID(""))); } catch { }
            MessageBox.Show("getSitesByTerminalCode: " + ctStandardLib.ctHelper.serializeObject(myPTCService.getSitesByTerminalCode("")));
            MessageBox.Show("getEmployeeProjectsByID: " + ctStandardLib.ctHelper.serializeObject(myPTCService.getEmployeeProjectsByID("", "")));
            MessageBox.Show("getProjectTasksByID: " + ctStandardLib.ctHelper.serializeObject(myPTCService.getProjectTasksByID("", "")));
            MessageBox.Show("getProjectSubTasksByID: " + ctStandardLib.ctHelper.serializeObject(myPTCService.getProjectSubTasksByID("", "", "", "")));
            MessageBox.Show("getLaborClassesByID: " + ctStandardLib.ctHelper.serializeObject(myPTCService.getLaborClassesByID("")));
            MessageBox.Show("getSubsByID: " + ctStandardLib.ctHelper.serializeObject(myPTCService.getSubsByID("")));
            MessageBox.Show("getUnionCodesByID: " + ctStandardLib.ctHelper.serializeObject(myPTCService.getUnionCodesByID("")));
            MessageBox.Show("getWorkCompCodesByID: " + ctStandardLib.ctHelper.serializeObject(myPTCService.getWorkCompCodesByID("")));
            MessageBox.Show("getShiftCodesByID: " + ctStandardLib.ctHelper.serializeObject(myPTCService.getShiftCodesByID("")));
            MessageBox.Show("getEarnTypeCodesByID: " + ctStandardLib.ctHelper.serializeObject(myPTCService.getEarnTypeCodesByID("")));
            MessageBox.Show("getCompaniesByCpnyID: " + ctStandardLib.ctHelper.serializeObject(myPTCService.getCompaniesByCpnyID("")));
        }

        public ctDynamicsSL.project.timeAndExpense.input.projectTimecardWithRateAmtEntry.projectTimecardWithRateAmtEntry myPTCService
        {
            //used for access to the webservice.  automatically creates the object if necessary
            get
            {
                if (myPTCServiceValue == null)
                {
                    //if we get here, then the object is not created
                    ctDynamicsSL.project.timeAndExpense.input.projectTimecardWithRateAmtEntry.ctDynamicsSLHeader Header = new ctDynamicsSL.project.timeAndExpense.input.projectTimecardWithRateAmtEntry.ctDynamicsSLHeader();
                    Header.siteID = System.Configuration.ConfigurationManager.AppSettings["SITEID"];
                    Header.cpnyID = System.Configuration.ConfigurationManager.AppSettings["CPNYID"];
                    Header.licenseKey = System.Configuration.ConfigurationManager.AppSettings["LICENSEKEY"];
                    Header.licenseName = System.Configuration.ConfigurationManager.AppSettings["LICENSENAME"];
                    Header.licenseExpiration = System.Configuration.ConfigurationManager.AppSettings["LICENSEEXPIRATION"];
                    Header.siteKey = System.Configuration.ConfigurationManager.AppSettings["SITEKEY"];
                    Header.softwareName = "CTAPI";
                    myPTCServiceValue = new ctDynamicsSL.project.timeAndExpense.input.projectTimecardWithRateAmtEntry.projectTimecardWithRateAmtEntry();
                    myPTCServiceValue.ctDynamicsSLHeaderValue = Header;
                    myPTCServiceValue.Timeout = 300000;
                }
                return myPTCServiceValue;
            }
            set
            {
                myPTCServiceValue = value;
            }
        }

        public ctDynamicsSL.project.projectController.maintenance.projectMaintenance.projectMaintenance myPJService
        {
            //used for access to the webservice.  automatically creates the object if necessary
            get
            {
                if (myPJServiceValue == null)
                {
                    //if we get here, then the object is not created
                    var Header = new ctDynamicsSL.project.projectController.maintenance.projectMaintenance.ctDynamicsSLHeader();
                    Header.siteID = System.Configuration.ConfigurationManager.AppSettings["SITEID"];
                    Header.cpnyID = System.Configuration.ConfigurationManager.AppSettings["CPNYID"];
                    Header.licenseKey = System.Configuration.ConfigurationManager.AppSettings["LICENSEKEY"];
                    Header.licenseName = System.Configuration.ConfigurationManager.AppSettings["LICENSENAME"];
                    Header.licenseExpiration = System.Configuration.ConfigurationManager.AppSettings["LICENSEEXPIRATION"];
                    Header.siteKey = System.Configuration.ConfigurationManager.AppSettings["SITEKEY"];
                    Header.softwareName = "CTAPI";
                    myPJServiceValue = new ctDynamicsSL.project.projectController.maintenance.projectMaintenance.projectMaintenance();
                    myPJServiceValue.ctDynamicsSLHeaderValue = Header;
                    myPJServiceValue.Timeout = 300000;
                }
                return myPJServiceValue;
            }
            set
            {
                myPJServiceValue = value;
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
        private void btnSearch_Click(object sender, EventArgs e)
        {
            timecardsPopup newPopup = new timecardsPopup(this, tbEmployee.Text, tbDocNbr.Text);
            newPopup.ShowDialog();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            myScreen = myPTCService.getScreenByDocNbr(tbEmployee.Text.Trim(), tbDocNbr.Text.Trim());
            if (myScreen.errorMessage != "")
            {
                MessageBox.Show("Error: " + myScreen.errorMessage);
                return;
            }
            gvDetails.DataSource = myScreen.myPJLABDET;
            btnUpdate.Enabled = true;
            tbScreen.Text = ctStandardLib.ctHelper.serializeObject(myScreen).Replace("><", ">" + Environment.NewLine + "<");

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (myScreen == null)
            {
                MessageBox.Show("You must load a timecard first!");
                return;
            }

            try
            {
                myScreen = (ctDynamicsSL.project.timeAndExpense.input.projectTimecardWithRateAmtEntry.screen)ctStandardLib.ctHelper.deSerializeObject(myScreen.GetType(), tbScreen.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deserializing textbox data: " + ex.Message);
            }
            myScreen.myPJLABDET = (ctDynamicsSL.project.timeAndExpense.input.projectTimecardWithRateAmtEntry.PJLABDET[])gvDetails.DataSource;

            myScreen = myPTCService.editScreen("UPDATE", myScreen);
            if (myScreen.errorMessage != "")
            {
                MessageBox.Show("Error: " + myScreen.errorMessage);
            }
            else
            {
                tbScreen.Text = ctStandardLib.ctHelper.serializeObject(myScreen).Replace("><", ">" + Environment.NewLine + "<");
                MessageBox.Show("Save complete!");
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            myScreen = myPTCService.getNewscreen(null);
            myScreen.myPJLABHDR.employee = myPTCService.getEmployeesByID("")[0].employee;
            myScreen.myPJLABHDR.Approver = myPTCService.getEmployeesByID("")[1].employee;
            myScreen.myPJLABHDR.le_status = "I";
            myScreen.myPJLABHDR.le_type = "R";
            myScreen.myPJLABHDR.le_id10 = 0;

            System.Collections.Generic.List<ctDynamicsSL.project.timeAndExpense.input.projectTimecardWithRateAmtEntry.PJLABDET> outLines
                = new System.Collections.Generic.List<ctDynamicsSL.project.timeAndExpense.input.projectTimecardWithRateAmtEntry.PJLABDET>();
            {
                var tmpItem = myPTCService.getNewPJLABDET(null);
                //set required fields
                tmpItem.CpnyId_chrg = System.Configuration.ConfigurationManager.AppSettings["CPNYID"];
                tmpItem.project = myPJService.getProjectsByID("P0001")[0].project;//set project
                tmpItem.pjt_entity = myPTCService.getProjectTasksByID(tmpItem.project, "")[0].pjt_entity; // set task
                tmpItem.labor_class_cd = myPTCService.getLaborClassesByID("")[0].code_value;//set labor class 
                tmpItem.gl_acct = "";//set gl account
                tmpItem.gl_subacct = "";//set sub acct
                //set optional fields
                tmpItem.total_hrs = 8;
                outLines.Add(tmpItem);
            }

            myScreen.myPJLABDET = outLines.ToArray();
            {
                var validate = myPTCService.editScreen("VALIDATEONLY", myScreen);
                if (validate.errorMessage.Trim() != "")
                {
                    MessageBox.Show("Validation Error: " + validate.errorMessage);
                    return;
                }
            }

            myScreen = myPTCService.editScreen("ADD", myScreen);
            if (myScreen.errorMessage != "")
            {
                MessageBox.Show("Error: " + myScreen.errorMessage);
                return;
            }
            else
            {
                tbDocNbr.Text = myScreen.myPJLABHDR.docnbr;
                btnLoad.PerformClick();
                btnUpdate.Enabled = true;
            }
        }

        private void btnEmployeeSearch_Click(object sender, EventArgs e)
        {
            employeesPopup newPopup = new employeesPopup(this, tbEmployee.Text);
            newPopup.ShowDialog();
        }
    }
}
