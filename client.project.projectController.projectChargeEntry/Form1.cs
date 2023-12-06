using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace client.project.projectController.projectChargeEntry
{
    public partial class Form1 : Form
    {
        private ctDynamicsSL.project.projectController.projectChargeEntry.projectChargeEntry myPCEObjValue = null;
        public ctDynamicsSL.project.projectController.projectChargeEntry.screen myScreen = null;

        public ctDynamicsSL.project.projectController.projectChargeEntry.projectChargeEntry myPCEObj
        {
            //used for access to the webservice.  automatically creates the object if necessary
            get
            {
                if (myPCEObjValue == null)
                {
                    //if we get here, then the object is not created
                    ctDynamicsSL.project.projectController.projectChargeEntry.ctDynamicsSLHeader Header = new ctDynamicsSL.project.projectController.projectChargeEntry.ctDynamicsSLHeader();
                    Header.siteID = System.Configuration.ConfigurationManager.AppSettings["SITEID"];
                    Header.cpnyID = System.Configuration.ConfigurationManager.AppSettings["CPNYID"];
                    Header.licenseKey = System.Configuration.ConfigurationManager.AppSettings["LICENSEKEY"];
                    Header.licenseName = System.Configuration.ConfigurationManager.AppSettings["LICENSENAME"];
                    Header.licenseExpiration = System.Configuration.ConfigurationManager.AppSettings["LICENSEEXPIRATION"];
                    Header.siteKey = System.Configuration.ConfigurationManager.AppSettings["SITEKEY"];
                    Header.softwareName = "CTAPI";
                    myPCEObjValue = new ctDynamicsSL.project.projectController.projectChargeEntry.projectChargeEntry();
                    myPCEObjValue.ctDynamicsSLHeaderValue = Header;
                    myPCEObjValue.Timeout = 300000;
                }
                return myPCEObjValue;
            }
            set
            {
                myPCEObjValue = value;
            }
        }

        public Form1()
        {
            InitializeComponent();
        }

        //Pulls up the batch list search box
        private void btnSearch_Click(object sender, EventArgs e)
        {
            batchesPopup newPopup = new batchesPopup(this, tbBatch_id.Text);
            newPopup.ShowDialog();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            myScreen = myPCEObj.getScreenByBatchNbr(tbBatch_id.Text);
            if (myScreen.errorMessage != "")
            {
                MessageBox.Show("Error: " + myScreen.errorMessage);
                return;
            }

            btnUpdate.Enabled = true;
            tbScreen.Text = ctStandardLib.ctHelper.serializeObject(myScreen).Replace("><", ">" + Environment.NewLine + "<");
            gvPJCHARGD.DataSource = myScreen.myPJCHARGD;
        }

        //Used to save a batch that has been loaded
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (myScreen == null)
            {
                MessageBox.Show("You must load a project batch first!");
                return;
            }

            MessageBox.Show(ctStandardLib.ctHelper.serializeObject(myScreen).Replace("><", ">" + Environment.NewLine + "<"));
            myScreen = myPCEObj.editScreen("UPDATE", myScreen);
            if (myScreen.errorMessage != "")
            {
                MessageBox.Show("Error: " + myScreen.errorMessage);
            }
            else
            {
                MessageBox.Show("Saved!");
            }
        }

        //Creates an empty new generic batch
        private void btnNew_Click(object sender, EventArgs e)
        {
            myScreen = myPCEObj.getNewscreen(null);
            //header
            myScreen.myPJCHARGH.cpnyId = "CON";
            myScreen.myPJCHARGH = myPCEObj.getNewPJCHARGH(myScreen.myPJCHARGH);//loads defaults
            myScreen.myPJCHARGH.batch_desc1 = "Test Batch: "+System.DateTime.Now.ToString();
            myScreen = myPCEObj.editScreen("ADD", myScreen);
            if (myScreen.errorMessage != "")
            {
                btnUpdate.Enabled = false;
                tbBatch_id.Text = "";
                gvPJCHARGD.DataSource = null;
                tbScreen.Text = ctStandardLib.ctHelper.serializeObject(myScreen).Replace("><", ">" + Environment.NewLine + "<");
                MessageBox.Show("Error: " + myScreen.errorMessage);
                return;
            }

            //header is created, lets create the line items
            //detail lines
            myScreen.myPJCHARGD = new ctDynamicsSL.project.projectController.projectChargeEntry.PJCHARGD[1];

            myScreen.myPJCHARGD[0] = new ctDynamicsSL.project.projectController.projectChargeEntry.PJCHARGD();
            myScreen.myPJCHARGD[0].batch_id = myScreen.myPJCHARGH.batch_id;
            myScreen.myPJCHARGD[0].cpnyId = myScreen.myPJCHARGH.cpnyId;
            myScreen.myPJCHARGD[0] = myPCEObj.getNewPJCHARGD(myScreen.myPJCHARGD[0]);//loads defaults

            //Create detail line number 1	
            myScreen.myPJCHARGD[0].project = myPCEObj.getProjectsByID("")[0].project;//just gets first active project
            myScreen.myPJCHARGD[0].employee = myPCEObj.getEmployeesByID("")[0].employee;//just gets first active employee

            myScreen.myPJCHARGD[0].pjt_entity = myPCEObj.getTasks(myScreen.myPJCHARGD[0].project, "")[0].pjt_entity;//just gets first task for this project
            myScreen.myPJCHARGD[0].tr_comment = "Test batch, line 1";
            myScreen.myPJCHARGD[0].trans_date = new DateTime(System.DateTime.Now.Year, System.DateTime.Now.Month, System.DateTime.Now.Day);
            //myScreen.myPJCHARGD[0].acct = "";
            //myScreen.myPJCHARGD[0].tr_id05 = "";//"This column stores the labor class.
            //myScreen.myPJCHARGD[0].units = 8;
            //myScreen.myPJCHARGD[0].voucher_num = "";

            myScreen = myPCEObj.editScreen("UPDATE", myScreen);

            if (myScreen.errorMessage != "")
            {
                btnUpdate.Enabled = false;
                tbBatch_id.Text = "";
                gvPJCHARGD.DataSource = null;
                tbScreen.Text = ctStandardLib.ctHelper.serializeObject(myScreen).Replace("><", ">" + Environment.NewLine + "<");
                MessageBox.Show("Error: " + myScreen.errorMessage);
                return;
            }
            else
            {
                tbBatch_id.Text = myScreen.myPJCHARGH.batch_id;
                btnLoad.PerformClick();
            }
        }

    }
}
