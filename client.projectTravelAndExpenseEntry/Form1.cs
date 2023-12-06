using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace client.projectTravelAndExpenseEntry
{
    public partial class Form1 : Form
    {
        private ctDynamicsSL.project.timeAndExpense.input.projectTravelAndExpenseEntry.projectTravelAndExpenseEntry myPTEServiceValue = null;
        private ctDynamicsSL.project.projectController.maintenance.projectMaintenance.projectMaintenance myPJServiceValue = null;
        public ctDynamicsSL.project.timeAndExpense.input.projectTravelAndExpenseEntry.screen myScreen = null;
        private ctDynamicsSL.common.common myCommonServiceValue = null;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnPVs_Click(object sender, EventArgs e)
        {
            MessageBox.Show("about: " + ctStandardLib.ctHelper.serializeObject(myPTEService.about()));
            MessageBox.Show("getExpenseReportDetailsByID: " + ctStandardLib.ctHelper.serializeObject(myPTEService.getExpenseReportDetailsByID("")));
            try { MessageBox.Show("getExpenseReportByExactID: " + ctStandardLib.ctHelper.serializeObject(myPTEService.getExpenseReportByExactID("",""))); } catch { }
            MessageBox.Show("getEmployeesByID: " + ctStandardLib.ctHelper.serializeObject(myPTEService.getEmployeesByID("")));
            try { MessageBox.Show("getEmployeeByExactID: " + ctStandardLib.ctHelper.serializeObject(myPTEService.getEmployeeByExactID(""))); } catch { }
            MessageBox.Show("getEmployeeProjectsByID: " + ctStandardLib.ctHelper.serializeObject(myPTEService.getEmployeeProjectsByID("", "")));
            MessageBox.Show("getProjectTasksByID: " + ctStandardLib.ctHelper.serializeObject(myPTEService.getProjectTasksByID("", "")));
            MessageBox.Show("getProjectSubTasksByID: " + ctStandardLib.ctHelper.serializeObject(myPTEService.getProjectSubTasksByID("", "", "", "")));
            MessageBox.Show("getCompaniesByCpnyID: " + ctStandardLib.ctHelper.serializeObject(myPTEService.getCompaniesByCpnyID("")));
        }

        public ctDynamicsSL.project.timeAndExpense.input.projectTravelAndExpenseEntry.projectTravelAndExpenseEntry myPTEService
        {
            //used for access to the webservice.  automatically creates the object if necessary
            get
            {
                if (myPTEServiceValue == null)
                {
					myPTEServiceValue = new ctDynamicsSL.project.timeAndExpense.input.projectTravelAndExpenseEntry.projectTravelAndExpenseEntry
					{
						Timeout = 300000,
						ctDynamicsSLHeaderValue = new ctDynamicsSL.project.timeAndExpense.input.projectTravelAndExpenseEntry.ctDynamicsSLHeader
						{
							siteID = System.Configuration.ConfigurationManager.AppSettings["SITEID"],
							cpnyID = System.Configuration.ConfigurationManager.AppSettings["CPNYID"],
							licenseKey = System.Configuration.ConfigurationManager.AppSettings["LICENSEKEY"],
							licenseName = System.Configuration.ConfigurationManager.AppSettings["LICENSENAME"],
							licenseExpiration = System.Configuration.ConfigurationManager.AppSettings["LICENSEEXPIRATION"],
							siteKey = System.Configuration.ConfigurationManager.AppSettings["SITEKEY"],
							softwareName = "CTAPI",
						}
					};
				}

				return myPTEServiceValue;
            }
            set
            {
                myPTEServiceValue = value;
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
							softwareName = "CTAPI",
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
        private void btnSearch_Click(object sender, EventArgs e)
        {
            expenseReportsPopup newPopup = new expenseReportsPopup(this, tbEmployee.Text, tbDocNbr.Text);
            newPopup.ShowDialog();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            myScreen = myPTEService.getScreenByDocNbr(tbEmployee.Text.Trim(), tbDocNbr.Text.Trim());
            if (myScreen.errorMessage != "")
            {
                MessageBox.Show("Error: " + myScreen.errorMessage);
                return;
            }
            gvDetails.DataSource = myScreen.myPJEXPDET;
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
                myScreen = (ctDynamicsSL.project.timeAndExpense.input.projectTravelAndExpenseEntry.screen)ctStandardLib.ctHelper.deSerializeObject(myScreen.GetType(), tbScreen.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deserializing textbox data: " + ex.Message);
            }
            myScreen.myPJEXPDET = (ctDynamicsSL.project.timeAndExpense.input.projectTravelAndExpenseEntry.PJEXPDET[])gvDetails.DataSource;

            myScreen = myPTEService.editScreen("UPDATE", myScreen);
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
            myScreen = myPTEService.getNewscreen(null);
            var myEmployee = myPTEService.getEmployeeByExactID(tbEmployee.Text);
            myScreen.myPJEXPHDR.employee = myEmployee.employee;

            myScreen.myPJEXPHDR = myPTEService.getNewPJEXPHDR(myScreen.myPJEXPHDR);
            //myScreen.myPJEXPHDR.approver = myEmployee.manager1;  //required, defaults from employee

            System.Collections.Generic.List<ctDynamicsSL.project.timeAndExpense.input.projectTravelAndExpenseEntry.PJEXPDET> outLines
                = new System.Collections.Generic.List<ctDynamicsSL.project.timeAndExpense.input.projectTravelAndExpenseEntry.PJEXPDET>();
            {
                var tmpItem = myPTEService.getNewPJEXPDET(null, myScreen.myPJEXPHDR);

                //set required fields
                tmpItem.exp_type = myPTEService.getExpenseTypesByID("")[0].exp_type;
                tmpItem.project = myPTEService.getEmployeeProjectsByID(myScreen.myPJEXPHDR.employee, "")[0].project;
                tmpItem.pjt_entity = myPTEService.getProjectTasksByID(tmpItem.project, "")[0].pjt_entity; // set task
                //tmpItem.gl_acct = "";//set gl account
                //tmpItem.gl_subacct = "";//set sub acct
                //set optional fields
                outLines.Add(tmpItem);
            }

            myScreen.myPJEXPDET = outLines.ToArray();
            {
                var validate = myPTEService.editScreen("VALIDATEONLY", myScreen);
                if (validate.errorMessage.Trim() != "")
                {
                    MessageBox.Show("Validation Error: " + validate.errorMessage);
                    return;
                }
            }

            myScreen = myPTEService.editScreen("ADD", myScreen);
            if (myScreen.errorMessage != "")
            {
                MessageBox.Show("Error: " + myScreen.errorMessage);
                return;
            }
            else
            {
                tbDocNbr.Text = myScreen.myPJEXPHDR.docnbr;
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
