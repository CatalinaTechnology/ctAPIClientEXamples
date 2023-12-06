using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace client.project.projectController.maintenance.projectMaintenance
{
    public partial class Form1 : Form
    {
        private ctDynamicsSL.project.projectController.maintenance.projectMaintenance.projectMaintenance myPMServiceValue = null;
        public ctDynamicsSL.project.projectController.maintenance.projectMaintenance.screen myScreen = null;
        private ctDynamicsSL.common.common myCommonServiceValue = null;


        public Form1()
        {
            InitializeComponent();
        }

        private void btnPVs_Click(object sender, EventArgs e)
        {
            try { MessageBox.Show(ctStandardLib.ctHelper.serializeObject(myPMService.getScreenByProjectID("blank")).Replace("><", ">" + System.Environment.NewLine + "<")); } catch (Exception ex) { MessageBox.Show("Error in getScreenByProjectID: " + ex.Message); }
            try { MessageBox.Show(ctStandardLib.ctHelper.serializeObject(myPMService.getNewscreen(null)).Replace("><", ">" + System.Environment.NewLine + "<")); } catch (Exception ex) { MessageBox.Show("Error in getNewscreen: " + ex.Message); }
            try { MessageBox.Show(ctStandardLib.ctHelper.serializeObject(myPMService.getNewPJPROJ(null)).Replace("><", ">" + System.Environment.NewLine + "<")); } catch (Exception ex) { MessageBox.Show("Error in getNewPJPROJ: " + ex.Message); }
            try { MessageBox.Show(ctStandardLib.ctHelper.serializeObject(myPMService.getNewPJADDR(null)).Replace("><", ">" + System.Environment.NewLine + "<")); } catch (Exception ex) { MessageBox.Show("Error in getNewPJADDR: " + ex.Message); }
            try { MessageBox.Show(ctStandardLib.ctHelper.serializeObject(myPMService.getNewPJPENT(null)).Replace("><", ">" + System.Environment.NewLine + "<")); } catch (Exception ex) { MessageBox.Show("Error in getNewPJPENT: " + ex.Message); }
            try { MessageBox.Show(ctStandardLib.ctHelper.serializeObject(myPMService.getNewPJPENTEX(null)).Replace("><", ">" + System.Environment.NewLine + "<")); } catch (Exception ex) { MessageBox.Show("Error in getNewPJPENTEX: " + ex.Message); }
            try { MessageBox.Show(ctStandardLib.ctHelper.serializeObject(myPMService.getNewPJPTDSUM(null)).Replace("><", ">" + System.Environment.NewLine + "<")); } catch (Exception ex) { MessageBox.Show("Error in getNewPJPTDSUM: " + ex.Message); }
            try { MessageBox.Show(ctStandardLib.ctHelper.serializeObject(myPMService.getNewPJPROJEX(null)).Replace("><", ">" + System.Environment.NewLine + "<")); } catch (Exception ex) { MessageBox.Show("Error in getNewPJPROJEX: " + ex.Message); }
            try { MessageBox.Show(ctStandardLib.ctHelper.serializeObject(myPMService.getNewPJProjEDD(null)).Replace("><", ">" + System.Environment.NewLine + "<")); } catch (Exception ex) { MessageBox.Show("Error in getNewPJProjEDD: " + ex.Message); }
            try { MessageBox.Show(ctStandardLib.ctHelper.serializeObject(myPMService.getProjectsByID("blank")).Replace("><", ">" + System.Environment.NewLine + "<")); } catch (Exception ex) { MessageBox.Show("Error in getProjectsByID: " + ex.Message); }
            try { MessageBox.Show(ctStandardLib.ctHelper.serializeObject(myPMService.getProjectTemplatesByType("blank")).Replace("><", ">" + System.Environment.NewLine + "<")); } catch (Exception ex) { MessageBox.Show("Error in getProjectTemplatesByType: " + ex.Message); }
            try { MessageBox.Show(ctStandardLib.ctHelper.serializeObject(myPMService.getProjectByExactID("blank")).Replace("><", ">" + System.Environment.NewLine + "<")); } catch (Exception ex) { MessageBox.Show("Error in getProjectByExactID: " + ex.Message); }
            try { MessageBox.Show(ctStandardLib.ctHelper.serializeObject(myPMService.getPJPENTsByID("blank", "blank")).Replace("><", ">" + System.Environment.NewLine + "<")); } catch (Exception ex) { MessageBox.Show("Error in getPJPENTsByID: " + ex.Message); }
            try { MessageBox.Show(ctStandardLib.ctHelper.serializeObject(myPMService.getPJPENTByExactID("blank", "blank")).Replace("><", ">" + System.Environment.NewLine + "<")); } catch (Exception ex) { MessageBox.Show("Error in getPJPENTByExactID: " + ex.Message); }
            try { MessageBox.Show(ctStandardLib.ctHelper.serializeObject(myPMService.getPJPENTEXsByID("blank", "blank")).Replace("><", ">" + System.Environment.NewLine + "<")); } catch (Exception ex) { MessageBox.Show("Error in getPJPENTEXsByID: " + ex.Message); }
            try { MessageBox.Show(ctStandardLib.ctHelper.serializeObject(myPMService.getPJPENTEXByExactID("blank", "blank")).Replace("><", ">" + System.Environment.NewLine + "<")); } catch (Exception ex) { MessageBox.Show("Error in getPJPENTEXByExactID: " + ex.Message); }
            try { MessageBox.Show(ctStandardLib.ctHelper.serializeObject(myPMService.getPJPTDSUMsByID("blank", "blank", "blank")).Replace("><", ">" + System.Environment.NewLine + "<")); } catch (Exception ex) { MessageBox.Show("Error in : " + ex.Message); }
            try { MessageBox.Show(ctStandardLib.ctHelper.serializeObject(myPMService.getPJPTDSUMByExactID("blank", "blank", "blank")).Replace("><", ">" + System.Environment.NewLine + "<")); } catch (Exception ex) { MessageBox.Show("Error in getPJPTDSUMByExactID: " + ex.Message); }
            try { MessageBox.Show(ctStandardLib.ctHelper.serializeObject(myPMService.getPJPROJEXsByID("blank")).Replace("><", ">" + System.Environment.NewLine + "<")); } catch (Exception ex) { MessageBox.Show("Error in getPJPROJEXsByID: " + ex.Message); }
            try { MessageBox.Show(ctStandardLib.ctHelper.serializeObject(myPMService.getPJPROJEXByExactID("blank")).Replace("><", ">" + System.Environment.NewLine + "<")); } catch (Exception ex) { MessageBox.Show("Error in getPJPROJEXByExactID: " + ex.Message); }
            try { MessageBox.Show(ctStandardLib.ctHelper.serializeObject(myPMService.getPJProjEDDsByID("blank")).Replace("><", ">" + System.Environment.NewLine + "<")); } catch (Exception ex) { MessageBox.Show("Error in getPJProjEDDsByID: " + ex.Message); }
            try { MessageBox.Show(ctStandardLib.ctHelper.serializeObject(myPMService.getCompaniesByCpnyID("blank")).Replace("><", ">" + System.Environment.NewLine + "<")); } catch (Exception ex) { MessageBox.Show("Error in getCompaniesByCpnyID: " + ex.Message); }
            try { MessageBox.Show(ctStandardLib.ctHelper.serializeObject(myPMService.getContractsByID("blank")).Replace("><", ">" + System.Environment.NewLine + "<")); } catch (Exception ex) { MessageBox.Show("Error in getContractsByID: " + ex.Message); }
            try { MessageBox.Show(ctStandardLib.ctHelper.serializeObject(myPMService.getContractTypesByID("blank")).Replace("><", ">" + System.Environment.NewLine + "<")); } catch (Exception ex) { MessageBox.Show("Error in getContractTypesByID: " + ex.Message); }
            try { MessageBox.Show(ctStandardLib.ctHelper.serializeObject(myPMService.getUtilizationTypesByID("blank")).Replace("><", ">" + System.Environment.NewLine + "<")); } catch (Exception ex) { MessageBox.Show("Error in getUtilizationTypesByID: " + ex.Message); }
            try { MessageBox.Show(ctStandardLib.ctHelper.serializeObject(myPMService.getSubsByID("blank")).Replace("><", ">" + System.Environment.NewLine + "<")); } catch (Exception ex) { MessageBox.Show("Error in getSubsByID: " + ex.Message); }
            try { MessageBox.Show(ctStandardLib.ctHelper.serializeObject(myPMService.getEmployeesByID("blank")).Replace("><", ">" + System.Environment.NewLine + "<")); } catch (Exception ex) { MessageBox.Show("Error in getEmployeesByID: " + ex.Message); }
            try { MessageBox.Show(ctStandardLib.ctHelper.serializeObject(myPMService.getCustomersByID("blank")).Replace("><", ">" + System.Environment.NewLine + "<")); } catch (Exception ex) { MessageBox.Show("Error in getCustomersByID: " + ex.Message); }
            try { MessageBox.Show(ctStandardLib.ctHelper.serializeObject(myPMService.getSalespersonsByID("blank")).Replace("><", ">" + System.Environment.NewLine + "<")); } catch (Exception ex) { MessageBox.Show("Error in getSalespersonsByID: " + ex.Message); }
            try { MessageBox.Show(ctStandardLib.ctHelper.serializeObject(myPMService.getCurrencyByID("blank")).Replace("><", ">" + System.Environment.NewLine + "<")); } catch (Exception ex) { MessageBox.Show("Error in getCurrencyByID: " + ex.Message); }
            try { MessageBox.Show(ctStandardLib.ctHelper.serializeObject(myPMService.getCurrencyRateTypesByID("blank")).Replace("><", ">" + System.Environment.NewLine + "<")); } catch (Exception ex) { MessageBox.Show("Error in getCurrencyRateTypesByID: " + ex.Message); }
            try { MessageBox.Show(ctStandardLib.ctHelper.serializeObject(myPMService.getAllocationMethodsByID("blank")).Replace("><", ">" + System.Environment.NewLine + "<")); } catch (Exception ex) { MessageBox.Show("Error in getAllocationMethodsByID: " + ex.Message); }
            try { MessageBox.Show(ctStandardLib.ctHelper.serializeObject(myPMService.getRateTableIDsByID("blank")).Replace("><", ">" + System.Environment.NewLine + "<")); } catch (Exception ex) { MessageBox.Show("Error in getRateTableIDsByID: " + ex.Message); }
            try { MessageBox.Show(ctStandardLib.ctHelper.serializeObject(myPMService.getLaborAcctsByID("blank")).Replace("><", ">" + System.Environment.NewLine + "<")); } catch (Exception ex) { MessageBox.Show("Error in getLaborAcctsByID: " + ex.Message); }
            try { MessageBox.Show(ctStandardLib.ctHelper.serializeObject(myPMService.getProjectControllerSetup("blank", "blank")).Replace("><", ">" + System.Environment.NewLine + "<")); } catch (Exception ex) { MessageBox.Show("Error in getProjectControllerSetup: " + ex.Message); }
            try { MessageBox.Show(ctStandardLib.ctHelper.serializeObject(myPMService.getTasks("blank", "blank")).Replace("><", ">" + System.Environment.NewLine + "<")); } catch (Exception ex) { MessageBox.Show("Error in getTasks: " + ex.Message); }
            try { MessageBox.Show(ctStandardLib.ctHelper.serializeObject(myPMService.getPJCODESByTypeAndID("blank", "blank")).Replace("><", ">" + System.Environment.NewLine + "<")); } catch (Exception ex) { MessageBox.Show("Error in getPJCODESByTypeAndID: " + ex.Message); }
            try { MessageBox.Show(ctStandardLib.ctHelper.serializeObject(myPMService.getEarnTypeCodesByID("blank")).Replace("><", ">" + System.Environment.NewLine + "<")); } catch (Exception ex) { MessageBox.Show("Error in getEarnTypeCodesByID: " + ex.Message); }
            try { MessageBox.Show(ctStandardLib.ctHelper.serializeObject(myPMService.getTaxIDsByID("blank")).Replace("><", ">" + System.Environment.NewLine + "<")); } catch (Exception ex) { MessageBox.Show("Error in getTaxIDsByID: " + ex.Message); }
            try { MessageBox.Show(ctStandardLib.ctHelper.serializeObject(myPMService.getWarehouseLocationsByID("blank")).Replace("><", ">" + System.Environment.NewLine + "<")); } catch (Exception ex) { MessageBox.Show("Error in getWarehouseLocationsByID: " + ex.Message); }
            try { MessageBox.Show(ctStandardLib.ctHelper.serializeObject(myPMService.getGLAcctsByID("blank")).Replace("><", ">" + System.Environment.NewLine + "<")); } catch (Exception ex) { MessageBox.Show("Error in getGLAcctsByID: " + ex.Message); }
            try { MessageBox.Show(ctStandardLib.ctHelper.serializeObject(myPMService.getLaborClassesByID("blank")).Replace("><", ">" + System.Environment.NewLine + "<")); } catch (Exception ex) { MessageBox.Show("Error in getLaborClassesByID: " + ex.Message); }
            try { MessageBox.Show(ctStandardLib.ctHelper.serializeObject(myPMService.getPJAcctsByID("blank")).Replace("><", ">" + System.Environment.NewLine + "<")); } catch (Exception ex) { MessageBox.Show("Error in getPJAcctsByID: " + ex.Message); }
            try { MessageBox.Show(ctStandardLib.ctHelper.serializeObject(myPMService.getWorkCompCodesByID("blank")).Replace("><", ">" + System.Environment.NewLine + "<")); } catch (Exception ex) { MessageBox.Show("Error in getWorkCompCodesByID: " + ex.Message); }
            try { MessageBox.Show(ctStandardLib.ctHelper.serializeObject(myPMService.getSOAddressesByID("blank", "blank")).Replace("><", ">" + System.Environment.NewLine + "<")); } catch (Exception ex) { MessageBox.Show("Error in getSOAddressesByID: " + ex.Message); }
            try { MessageBox.Show(ctStandardLib.ctHelper.serializeObject(myPMService.getCurrTypeCodesByID("blank")).Replace("><", ">" + System.Environment.NewLine + "<")); } catch (Exception ex) { MessageBox.Show("Error in getCurrTypeCodesByID: " + ex.Message); }
            try { MessageBox.Show(ctStandardLib.ctHelper.serializeObject(myPMService.getRateTypeCodesByID("blank")).Replace("><", ">" + System.Environment.NewLine + "<")); } catch (Exception ex) { MessageBox.Show("Error in getRateTypeCodesByID: " + ex.Message); }
            try { MessageBox.Show(ctStandardLib.ctHelper.serializeObject(myPMService.getNewAddressInformationScreen(null)).Replace("><", ">" + System.Environment.NewLine + "<")); } catch (Exception ex) { MessageBox.Show("Error in getNewAddressInformationScreen: " + ex.Message); }
            try { MessageBox.Show(ctStandardLib.ctHelper.serializeObject(myPMService.getNewBillingInformationScreen(null)).Replace("><", ">" + System.Environment.NewLine + "<")); } catch (Exception ex) { MessageBox.Show("Error in getNewBillingInformationScreen: " + ex.Message); }
            try { MessageBox.Show(ctStandardLib.ctHelper.serializeObject(myPMService.getNewPJBILL(null)).Replace("><", ">" + System.Environment.NewLine + "<")); } catch (Exception ex) { MessageBox.Show("Error in getNewPJBILL: " + ex.Message); }
            try { MessageBox.Show(ctStandardLib.ctHelper.serializeObject(myPMService.getPJBILLsByID("blank")).Replace("><", ">" + System.Environment.NewLine + "<")); } catch (Exception ex) { MessageBox.Show("Error in getPJBILLsByID: " + ex.Message); }
            try { MessageBox.Show(ctStandardLib.ctHelper.serializeObject(myPMService.getPJBILLByExactID("blank")).Replace("><", ">" + System.Environment.NewLine + "<")); } catch (Exception ex) { MessageBox.Show("Error in getPJBILLByExactID: " + ex.Message); }
            try { MessageBox.Show(ctStandardLib.ctHelper.serializeObject(myPMService.getBillingInformationScreen("blank")).Replace("><", ">" + System.Environment.NewLine + "<")); } catch (Exception ex) { MessageBox.Show("Error in getBillingInformationScreen: " + ex.Message); }
            try { MessageBox.Show(ctStandardLib.ctHelper.serializeObject(myPMService.getNewPJRULEX(null)).Replace("><", ">" + System.Environment.NewLine + "<")); } catch (Exception ex) { MessageBox.Show("Error in getNewPJRULEX: " + ex.Message); }
            try { MessageBox.Show(ctStandardLib.ctHelper.serializeObject(myPMService.getPJRULEXsByID("blank", "blank")).Replace("><", ">" + System.Environment.NewLine + "<")); } catch (Exception ex) { MessageBox.Show("Error in getPJRULEXsByID: " + ex.Message); }
            try { MessageBox.Show(ctStandardLib.ctHelper.serializeObject(myPMService.getPJRULEXByExactID("blank", "blank")).Replace("><", ">" + System.Environment.NewLine + "<")); } catch (Exception ex) { MessageBox.Show("Error in getPJRULEXByExactID: " + ex.Message); }
            try { MessageBox.Show(ctStandardLib.ctHelper.serializeObject(myPMService.getAddressInformationScreen("blank", "blank")).Replace("><", ">" + System.Environment.NewLine + "<")); } catch (Exception ex) { MessageBox.Show("Error in getAddressInformationScreen: " + ex.Message); }
            try { MessageBox.Show(ctStandardLib.ctHelper.serializeObject(myPMService.getPJADDRsByID("blank", "blank")).Replace("><", ">" + System.Environment.NewLine + "<")); } catch (Exception ex) { MessageBox.Show("Error in getPJADDRsByID: " + ex.Message); }
            try { MessageBox.Show(ctStandardLib.ctHelper.serializeObject(myPMService.getPJADDRByExactID("blank", "blank")).Replace("><", ">" + System.Environment.NewLine + "<")); } catch (Exception ex) { MessageBox.Show("Error in getPJADDRByExactID: " + ex.Message); }
            try { MessageBox.Show(ctStandardLib.ctHelper.serializeObject(myPMService.getPJINVTXTsByID("blank", "blank")).Replace("><", ">" + System.Environment.NewLine + "<")); } catch (Exception ex) { MessageBox.Show("Error in getPJINVTXTsByID: " + ex.Message); }
            try { MessageBox.Show(ctStandardLib.ctHelper.serializeObject(myPMService.getPJINVTXTByExactID("blank", "blank")).Replace("><", ">" + System.Environment.NewLine + "<")); } catch (Exception ex) { MessageBox.Show("Error in getPJINVTXTByExactID: " + ex.Message); }
            try { MessageBox.Show(ctStandardLib.ctHelper.serializeObject(myPMService.getNewPJINVTXT(null)).Replace("><", ">" + System.Environment.NewLine + "<")); } catch (Exception ex) { MessageBox.Show("Error in getNewPJINVTXT: " + ex.Message); }
        }

        //used to retrieve a full project screen object
        private void btnLoad_Click(object sender, EventArgs e)
        {
            myScreen = myPMService.getScreenByProjectID(tbProject.Text.Trim());
            if (myScreen.errorMessage != "")
            {
                MessageBox.Show("Error: " + myScreen.errorMessage);
                return;
            }
            btnUpdate.Enabled = true;
            tbScreen.Text = ctStandardLib.ctHelper.serializeObject(myScreen).Replace("><", ">" + Environment.NewLine + "<");
        }

        //Used to save a project
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (myScreen == null)
            {
                MessageBox.Show("You must load a project first!");
                return;
            }

            try
            {//get our screen xml in case any manual changes were made
                myScreen = (ctDynamicsSL.project.projectController.maintenance.projectMaintenance.screen)ctStandardLib.ctHelper.deSerializeObject(myScreen.GetType(), tbScreen.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deserializing textbox data: " + ex.Message);
            }

            var validate = myPMService.editScreen("VALIDATEONLY", myScreen);
            if (validate.errorMessage.Trim() != "")
            {
                MessageBox.Show("Validation Error: " + validate.errorMessage);
                return;
            }

            myScreen.myPJPROJ.lupd_prog = "test";
            myScreen = myPMService.editScreen("UPDATE", myScreen);
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

        //Pulls up the project list search box
        private void btnSearch_Click(object sender, EventArgs e)
        {
            projectsPopup newPopup = new projectsPopup(this, tbProject.Text);
            newPopup.ShowDialog();
        }

        //Creates an empty new generic project
        private void btnNew_Click(object sender, EventArgs e)
        {
            myScreen = myPMService.getNewscreen(null);

            //cpnyID required
            myScreen.myPJPROJ.CpnyId = System.Configuration.ConfigurationManager.AppSettings["CPNYID"];

            {
                String projectID = tbProject.Text.Trim();
                if (projectID == "")
                {
                    //projectID required, using our builtin counter table as example
                    projectID = myCommonService.getNextCounterAsString("PROJECTID");
                }
                myScreen.myPJPROJ.project = projectID;
               // myScreen.myPJPROJEX.project = projectID;
            }

            myScreen.myPJPROJ.project_desc = "my test project: " + myScreen.myPJPROJ.project;

            //myScreen.myPJPROJ.manager1 = myPMService.getEmployeesByID("")[0].employee; //not required, just picking first employee for example

            ctDynamicsSL.project.projectController.maintenance.projectMaintenance.Snote projectNote = new ctDynamicsSL.project.projectController.maintenance.projectMaintenance.Snote();
            projectNote.sNoteText = "test project note";
            myScreen.projectNote = projectNote;
            /*
            {
                var validate = myPMService.editScreen("VALIDATEONLY", myScreen);
                if (validate.errorMessage.Trim() != "")
                {
                    MessageBox.Show("Validation Error: " + validate.errorMessage);
                    return;
                }
            }
            */
            myScreen.myPJPROJ.lupd_prog = "MYTEST";
            myScreen = myPMService.editScreen("ADD", myScreen);
            if (myScreen.errorMessage != "")
            {
                MessageBox.Show("Error: " + myScreen.errorMessage);
                return;
            }
            else
            {
                tbProject.Text = myScreen.myPJPROJ.project;
                btnLoad.PerformClick();
                btnUpdate.Enabled = true;
            }

        }

        /// <summary>
        /// instantiate the projectMaintenance web service
        /// </summary>
        public ctDynamicsSL.project.projectController.maintenance.projectMaintenance.projectMaintenance myPMService
        {
            //used for access to the webservice.  automatically creates the object if necessary
            get
            {
                if (myPMServiceValue == null)
                {
                    //if we get here, then the object is not created
                    ctDynamicsSL.project.projectController.maintenance.projectMaintenance.ctDynamicsSLHeader Header = new ctDynamicsSL.project.projectController.maintenance.projectMaintenance.ctDynamicsSLHeader();
                    Header.siteID = System.Configuration.ConfigurationManager.AppSettings["SITEID"];
                    Header.cpnyID = System.Configuration.ConfigurationManager.AppSettings["CPNYID"];
                    Header.licenseKey = System.Configuration.ConfigurationManager.AppSettings["LICENSEKEY"];
                    Header.licenseName = System.Configuration.ConfigurationManager.AppSettings["LICENSENAME"];
                    Header.licenseExpiration = System.Configuration.ConfigurationManager.AppSettings["LICENSEEXPIRATION"];
                    Header.siteKey = System.Configuration.ConfigurationManager.AppSettings["SITEKEY"];
                    Header.softwareName = "CTAPI";
                    myPMServiceValue = new ctDynamicsSL.project.projectController.maintenance.projectMaintenance.projectMaintenance();
                    myPMServiceValue.ctDynamicsSLHeaderValue = Header;
                    myPMServiceValue.Timeout = 300000;
                }
                return myPMServiceValue;
            }
            set
            {
                myPMServiceValue = value;
            }
        }

        /// <summary>
        /// instantiate the ctapi common web service
        /// </summary>
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

        private void tbScreen_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnAddAddress_Click(object sender, EventArgs e)
        {
            if (myScreen == null)
            {
                MessageBox.Show("You must load a project first!");
                return;
            }

            var outActionType = "UPDATE";

            var myAddressScreen = myPMService.getAddressInformationScreen(myScreen.myPJPROJ.project, "PR"); //project address
            if (myAddressScreen.myPJADDR == null)
            {
                //doesn't exist yet, lets get a new entry with defaults
                outActionType = "ADD";
                myAddressScreen = myPMService.getNewAddressInformationScreen(myAddressScreen);
                myAddressScreen.myPJADDR.addr_key = myScreen.myPJPROJ.project;
            }
            myAddressScreen.myPJADDR.addr_type_cd = "PR"; //project address type

            myAddressScreen.myPJADDR.addr1 = "1 Test Rd.";
            myAddressScreen.myPJADDR.city = System.Guid.NewGuid().ToString().Substring(0, 8);
            myAddressScreen.myPJADDR.state = "CA";
            myAddressScreen.myPJADDR.zip = "90210";
            myAddressScreen.myPJADDR.phone = "9998887777";

            {
                var validate = myPMService.editAddressInformationScreen("VALIDATEONLY", myAddressScreen);
                if (!String.IsNullOrWhiteSpace(validate.errorMessage))
                {
                    MessageBox.Show("Error validating screen: " + validate.errorMessage);
                    return;
                }
            }

            {
                var edit = myPMService.editAddressInformationScreen(outActionType, myAddressScreen); 
                if (!String.IsNullOrWhiteSpace(edit.errorMessage))
                {
                    MessageBox.Show("Error editing screen: " + edit.errorMessage);
                }
                tbScreen.Text = ctStandardLib.ctHelper.serializeObject(edit).Replace("><", ">" + System.Environment.NewLine + "<");
                return;
            }
        }

        private void btnAddBillingInfo_Click(object sender, EventArgs e)
        {
            if (myScreen == null)
            {
                MessageBox.Show("You must load a project first!");
                return;
            }

            ctDynamicsSL.project.projectController.maintenance.projectMaintenance.billingInformationScreen myBillingInformationScreen = null;
            try
            {
                myBillingInformationScreen = myPMService.getBillingInformationScreen(myScreen.myPJPROJ.project);
                if (myBillingInformationScreen.myPJBILL!= null)
                {
                    if (!String.IsNullOrWhiteSpace(myBillingInformationScreen.errorMessage))
                    {
                        throw new Exception(myBillingInformationScreen.errorMessage);
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error loading Billing Information Screen! " + ex.Message);
            }

            String actionType = "";
            if (myBillingInformationScreen.myPJBILL == null)
            {
                actionType = "ADD";
                myBillingInformationScreen.myPJBILL = new ctDynamicsSL.project.projectController.maintenance.projectMaintenance.PJBILL();
                myBillingInformationScreen.myPJBILL.project = myScreen.myPJPROJ.project;
                myBillingInformationScreen = myPMService.getNewBillingInformationScreen(myBillingInformationScreen);
            }
            else
            {
                actionType = "UPDATE";
            }

            myBillingInformationScreen.myPJBILL.bill_type_cd = "CP"; //required
            myBillingInformationScreen.myPJBILL.approver = "00103"; //required
            myBillingInformationScreen.myPJBILL.project_billwith= myScreen.myPJPROJ.project; //required

            if (myBillingInformationScreen.invoiceHeader == null)
            {
                myBillingInformationScreen.invoiceHeader = myPMService.getNewPJINVTXT(null);
                myBillingInformationScreen.invoiceHeader.project = myBillingInformationScreen.myPJBILL.project;
            }
            myBillingInformationScreen.invoiceHeader.z_text = "my invoice header text";

            if (myBillingInformationScreen.projectComment == null)
            {
                myBillingInformationScreen.projectComment = myPMService.getNewPJINVTXT(null);
                myBillingInformationScreen.projectComment.project = myBillingInformationScreen.myPJBILL.project;
            }
            myBillingInformationScreen.projectComment.z_text = "my project comment text";

            if (myBillingInformationScreen.invoiceFooter == null)
            {
                myBillingInformationScreen.invoiceFooter = myPMService.getNewPJINVTXT(null);
                myBillingInformationScreen.invoiceFooter.project = myBillingInformationScreen.myPJBILL.project;
            }
            myBillingInformationScreen.invoiceFooter.z_text = "my invoice footer text";

            {
                var validate = myPMService.editBillingInformationScreen("VALIDATEONLY", myBillingInformationScreen);
                if (!String.IsNullOrWhiteSpace(validate.errorMessage))
                {
                    MessageBox.Show("Error validating screen: " + validate.errorMessage);
                    return;
                }
            }

            {
                var edit = myPMService.editBillingInformationScreen(actionType, myBillingInformationScreen);
                if (!String.IsNullOrWhiteSpace(edit.errorMessage))
                {
                    MessageBox.Show("Error editing screen: " + edit.errorMessage);
                }
                tbScreen.Text = ctStandardLib.ctHelper.serializeObject(edit).Replace("><", ">" + System.Environment.NewLine + "<");
                return;
            }
        }
    }
}
