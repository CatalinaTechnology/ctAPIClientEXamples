using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace client.projectInvoiceAndAdjustmentMaintenance
{
    public partial class Form1 : Form
    {
        private ctDynamicsSL.common.common myCommonServiceValue = null;
        private ctDynamicsSL.project.flexibleBillings.input.projectInvoiceAndAdjustmentMaintenance.projectInvoiceAndAdjustmentMaintenance myIAMServiceValue = null;
        public ctDynamicsSL.project.flexibleBillings.input.projectInvoiceAndAdjustmentMaintenance.screen myScreen = null;
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Load an existing invoice
        /// </summary>
        private void btnLoad_Click(object sender, EventArgs e)
        {
            dgvRegular.DataSource = null;
            dgvTRD.DataSource = null;

            try
            {
                myScreen = myIAMService.getScreenByDraftNumber(tbDraftNum.Text.ToUpper().Trim());
                if (myScreen.errorMessage.Trim() != "")
                {
                    throw new Exception(myScreen.errorMessage.Trim());
                }
                if (myScreen.myPJINVHDR == null)
                {
                    throw new Exception("Draft Number not found!");
                }
                tbProjectID.Text = myScreen.myPJINVHDR.project_billwith.Trim().ToUpper();
                tbDraftNum.Text = myScreen.myPJINVHDR.draft_num.Trim().ToUpper();
                dgvRegular.DataSource = myScreen.myPJInvDet;
                dgvTRD.DataSource = myScreen.myPJInvDet_TRD;
                tbScreen.Text = ctStandardLib.ctHelper.serializeObject(myScreen).Replace("><", ">" + Environment.NewLine + "<");
            }catch(Exception ex)
            {
                MessageBox.Show("Error loading: " + ex.Message);
            }
        }

        /// <summary>
        /// Update an existing invoice
        /// </summary>
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (myScreen == null)
            {
                MessageBox.Show("You must load an entry first!");
                return;
            }

            myScreen.myPJInvDet = (ctDynamicsSL.project.flexibleBillings.input.projectInvoiceAndAdjustmentMaintenance.PJInvDet[])dgvRegular.DataSource;
            myScreen.myPJInvDet_TRD = (ctDynamicsSL.project.flexibleBillings.input.projectInvoiceAndAdjustmentMaintenance.PJInvDet[])dgvTRD.DataSource;

            var validate = myIAMService.editScreen("VALIDATEONLY", myScreen);
            if (validate.errorMessage.Trim() != "")
            {
                MessageBox.Show("Error: " + validate.errorMessage);
            }
            else
            {
                var result = myIAMService.editScreen("UPDATE", myScreen);
                if (result.errorMessage.Trim() != "")
                {
                    MessageBox.Show("Error: " + validate.errorMessage);
                }
                else
                {
                    myScreen = result;
                    tbDraftNum.Text = myScreen.myPJINVHDR.draft_num.Trim();
                    btnLoad_Click(null, null);
                    MessageBox.Show("Complete!");
                }
            }
        }

        /// <summary>
        /// This creates a new generic Invoice Entry 
        /// </summary>
        private void btnNew_Click(object sender, EventArgs e)
        {
            try
            { 
                if (tbProjectID.Text.Trim() == "")
                {
                    MessageBox.Show("You must select a valid billing project first!");
                    return;
                }
                else
                {
                    var tmpProject = myIAMService.getProjectsByExactID(tbProjectID.Text.Trim());
                    if (tmpProject == null)
                    {
                        MessageBox.Show("Invalid ProjectID!");
                        return;
                    }
                    else
                    {
                        tbProjectID.Text = tmpProject.project.Trim().ToUpper();
                    }
                }

                ctDynamicsSL.project.flexibleBillings.input.projectInvoiceAndAdjustmentMaintenance.screen newScreen = new ctDynamicsSL.project.flexibleBillings.input.projectInvoiceAndAdjustmentMaintenance.screen();
                newScreen.myPJINVHDR = new ctDynamicsSL.project.flexibleBillings.input.projectInvoiceAndAdjustmentMaintenance.PJINVHDR();
                newScreen.myPJINVHDR.CpnyId = System.Configuration.ConfigurationManager.AppSettings["CPNYID"];
                newScreen.myPJINVHDR.project_billwith = tbProjectID.Text;
                newScreen = myIAMService.getNewscreen(newScreen); //load defaults global, cpnyID and project specific
            
                if (newScreen.errorMessage.Trim() != "")
                {
                    MessageBox.Show(newScreen.errorMessage);
                    return;
                }

                newScreen.myPJINVHDR.customer = myIAMService.getCustomersByID("C315")[0].CustId.Trim(); // custID required, picking first entry as example;
                newScreen.myPJINVHDR.doctype = "IN"; //IN,AD *required
                newScreen.myPJINVHDR.end_date = System.DateTime.Now.AddDays(1); //required

                newScreen.myPJInvDet = new ctDynamicsSL.project.flexibleBillings.input.projectInvoiceAndAdjustmentMaintenance.PJInvDet[1];
                newScreen.myPJInvDet[0] = new ctDynamicsSL.project.flexibleBillings.input.projectInvoiceAndAdjustmentMaintenance.PJInvDet();
                newScreen.myPJInvDet[0].CpnyId = newScreen.myPJINVHDR.CpnyId;
                newScreen.myPJInvDet[0].source_trx_date = System.DateTime.Now;
                newScreen.myPJInvDet[0].project = newScreen.myPJINVHDR.project_billwith;
                newScreen.myPJInvDet[0].project_billwith = newScreen.myPJINVHDR.project_billwith;

                //load any defaults based on values already set
                newScreen.myPJInvDet[0] = myIAMService.getNewPJInvDet(newScreen.myPJInvDet[0]);
                newScreen.myPJInvDet[0].li_type = "I"; //I,O required
                newScreen.myPJInvDet[0].acct = myIAMService.getAccountCategoriesForProjectByAcct(newScreen.myPJInvDet[0].project, "")[0].acct; //required, picking first entry as example.
                newScreen.myPJInvDet[0].pjt_entity = myIAMService.getTasks(newScreen.myPJInvDet[0].project, "")[0].pjt_entity; //required, picking first entry as example.

                newScreen.myPJInvDet_TRD = new ctDynamicsSL.project.flexibleBillings.input.projectInvoiceAndAdjustmentMaintenance.PJInvDet[1];
                newScreen.myPJInvDet_TRD[0] = new ctDynamicsSL.project.flexibleBillings.input.projectInvoiceAndAdjustmentMaintenance.PJInvDet();
                newScreen.myPJInvDet_TRD[0].CpnyId = newScreen.myPJINVHDR.CpnyId;
                newScreen.myPJInvDet_TRD[0].source_trx_date = System.DateTime.Now;
                newScreen.myPJInvDet_TRD[0].project = newScreen.myPJINVHDR.project_billwith;
                newScreen.myPJInvDet_TRD[0].project_billwith = newScreen.myPJINVHDR.project_billwith;

                //load any defaults based on values already set
                newScreen.myPJInvDet_TRD[0] = myIAMService.getNewPJInvDet(newScreen.myPJInvDet_TRD[0]); 
                newScreen.myPJInvDet_TRD[0].li_type = "R"; //T,R,B,D,A required
                newScreen.myPJInvDet_TRD[0].acct = myIAMService.getTRDAccountCategoriesByAcct("")[0].acct; //required, picking first entry as example.
                newScreen.myPJInvDet_TRD[0].pjt_entity = myIAMService.getTasks(newScreen.myPJInvDet_TRD[0].project, "")[0].pjt_entity; //required, picking first entry as example.

                tbScreen.Text = ctStandardLib.ctHelper.serializeObject(newScreen).Replace("><", ">" + System.Environment.NewLine + "<");

                var validatedScreen = myIAMService.editScreen("VALIDATEONLY", newScreen);
                if (validatedScreen.errorMessage.Trim() != "")
                {
                    MessageBox.Show("Validation Error: " + validatedScreen.errorMessage);
                    return;
                }
                else
                {
                    var savedScreen = myIAMService.editScreen("ADD", newScreen);
                    if (savedScreen.errorMessage.Trim() != "")
                    {
                        MessageBox.Show("Adding Error: " + savedScreen.errorMessage);
                        return;
                    }
                    else
                    {
                        myScreen = savedScreen;
                        tbProjectID.Text = myScreen.myPJINVHDR.project_billwith;
                        tbDraftNum.Text = myScreen.myPJINVHDR.draft_num;
                        dgvRegular.DataSource = null;
                        dgvTRD.DataSource = null;
                        dgvRegular.DataSource = myScreen.myPJInvDet;
                        dgvTRD.DataSource = myScreen.myPJInvDet_TRD;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unknown Error: " + ex.Message);
            }
        }

        /// <summary>
        /// opens the popup window that searches for projects
        /// </summary>
        private void btnProjectSearch_Click(object sender, EventArgs e)
        {
            projectsPopup newPopup = new projectsPopup(this);
            newPopup.ShowDialog();

        }

        /// <summary>
        /// opens the popup window that searches for invoices
        /// </summary>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            invoicesPopup newPopup = new invoicesPopup(this);
            newPopup.ShowDialog();

        }

        /// <summary>
        /// For testing/example purposes this calls all the gets/pvs/lookup functions in the web service
        /// </summary>
        private void btnGets_Click(object sender, EventArgs e)
        {
            MessageBox.Show("about: " + ctStandardLib.ctHelper.serializeObject(myIAMService.about()));
            MessageBox.Show("getScreenByDraftNumber: " + ctStandardLib.ctHelper.serializeObject(myIAMService.getScreenByDraftNumber("test")));
            MessageBox.Show("getPJINVHDRByID: " + ctStandardLib.ctHelper.serializeObject(myIAMService.getPJINVHDRByID("test")));
            try { MessageBox.Show("getPJINVHDRByExactID: " + ctStandardLib.ctHelper.serializeObject(myIAMService.getPJINVHDRByExactID("test"))); } catch { }
            MessageBox.Show("getDraftNumbersByProject: " + ctStandardLib.ctHelper.serializeObject(myIAMService.getDraftNumbersByProject("test", "")));
            MessageBox.Show("getPJInvDetByID: " + ctStandardLib.ctHelper.serializeObject(myIAMService.getPJInvDetByID("test")));
            MessageBox.Show("getPJInvDet_TRDByID: " + ctStandardLib.ctHelper.serializeObject(myIAMService.getPJInvDet_TRDByID("test")));
            try { MessageBox.Show("getPJInvDetByExactID: " + ctStandardLib.ctHelper.serializeObject(myIAMService.getPJInvDetByExactID(0))); } catch { }
            try { MessageBox.Show("getPJInvDet_TRDByExactID: " + ctStandardLib.ctHelper.serializeObject(myIAMService.getPJInvDet_TRDByExactID(0))); } catch { }
            MessageBox.Show("getProjectsByID: " + ctStandardLib.ctHelper.serializeObject(myIAMService.getProjectsByID("test")));
            MessageBox.Show("getInvoiceTypesByID: " + ctStandardLib.ctHelper.serializeObject(myIAMService.getInvoiceTypesByID("test")));
            MessageBox.Show("getSalespersonsByID: " + ctStandardLib.ctHelper.serializeObject(myIAMService.getSalespersonsByID("test")));
            MessageBox.Show("getCustomersByID: " + ctStandardLib.ctHelper.serializeObject(myIAMService.getCustomersByID("test")));
            MessageBox.Show("getRateTypesByID: " + ctStandardLib.ctHelper.serializeObject(myIAMService.getRateTypesByID("test")));
            MessageBox.Show("getTasks: " + ctStandardLib.ctHelper.serializeObject(myIAMService.getTasks("test", "test")));
            MessageBox.Show("getAccountCategoriesForProjectByAcct: " + ctStandardLib.ctHelper.serializeObject(myIAMService.getAccountCategoriesForProjectByAcct("test", "test")));
            MessageBox.Show("getEmployeesByID: " + ctStandardLib.ctHelper.serializeObject(myIAMService.getEmployeesByID("test")));
            MessageBox.Show("getVendorsByID: " + ctStandardLib.ctHelper.serializeObject(myIAMService.getVendorsByID("test")));
            MessageBox.Show("getLaborClassesByID: " + ctStandardLib.ctHelper.serializeObject(myIAMService.getLaborClassesByID("test")));
            MessageBox.Show("getTaxIDsByID: " + ctStandardLib.ctHelper.serializeObject(myIAMService.getTaxIDsByID("test")));
            MessageBox.Show("getSalesTaxCatsByID: " + ctStandardLib.ctHelper.serializeObject(myIAMService.getSalesTaxCatsByID("test")));
            MessageBox.Show("getBillTypesByID: " + ctStandardLib.ctHelper.serializeObject(myIAMService.getBillTypesByID("test")));
            MessageBox.Show("getSubAccountsByID: " + ctStandardLib.ctHelper.serializeObject(myIAMService.getSubAccountsByID("test")));
            MessageBox.Show("getTRDAccountCategoriesByAcct: " + ctStandardLib.ctHelper.serializeObject(myIAMService.getTRDAccountCategoriesByAcct("test")));
            MessageBox.Show("getNewPJINVHDR: " + ctStandardLib.ctHelper.serializeObject(myIAMService.getNewPJINVHDR(null)));
            MessageBox.Show("getNewPJInvDet: " + ctStandardLib.ctHelper.serializeObject(myIAMService.getNewPJInvDet(null)));
            MessageBox.Show("getNewPJInvDet_TRD: " + ctStandardLib.ctHelper.serializeObject(myIAMService.getNewPJInvDet_TRD(null)));
            MessageBox.Show("getNewscreen: " + ctStandardLib.ctHelper.serializeObject(myIAMService.getNewscreen(null)));
        }

        /// <summary>
        /// Reference to the projectInvoiceAndAdjustmentMaintenance web service.
        /// automatically creates the object if necessary
        /// </summary>
        public ctDynamicsSL.project.flexibleBillings.input.projectInvoiceAndAdjustmentMaintenance.projectInvoiceAndAdjustmentMaintenance myIAMService
        {
            get
            {
                if (myIAMServiceValue == null)
                {
                    //if we get here, then the object is not created
                    ctDynamicsSL.project.flexibleBillings.input.projectInvoiceAndAdjustmentMaintenance.ctDynamicsSLHeader Header = new ctDynamicsSL.project.flexibleBillings.input.projectInvoiceAndAdjustmentMaintenance.ctDynamicsSLHeader();
                    Header.siteID = System.Configuration.ConfigurationManager.AppSettings["SITEID"];
                    Header.cpnyID = System.Configuration.ConfigurationManager.AppSettings["CPNYID"];
                    Header.licenseKey = System.Configuration.ConfigurationManager.AppSettings["LICENSEKEY"];
                    Header.licenseName = System.Configuration.ConfigurationManager.AppSettings["LICENSENAME"];
                    Header.licenseExpiration = System.Configuration.ConfigurationManager.AppSettings["LICENSEEXPIRATION"];
                    Header.siteKey = System.Configuration.ConfigurationManager.AppSettings["SITEKEY"];
                    Header.softwareName = "CTAPI";
                    myIAMServiceValue = new ctDynamicsSL.project.flexibleBillings.input.projectInvoiceAndAdjustmentMaintenance.projectInvoiceAndAdjustmentMaintenance();
                    myIAMServiceValue.ctDynamicsSLHeaderValue = Header;
                    myIAMServiceValue.Timeout = 300000;
                }
                return myIAMServiceValue;
            }
            set
            {
                myIAMServiceValue = value;
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

        private void tbScreen_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
