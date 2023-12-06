using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace client.inventoryIssues
{
    public partial class Form1 : Form
    {
        private ctDynamicsSL.inventory.inventory.input.inventoryIssues.inventoryIssues myIIServiceValue = null;
        public ctDynamicsSL.inventory.inventory.input.inventoryIssues.screen myScreen = null;

        public Form1()
        {
            InitializeComponent();
        }

        public ctDynamicsSL.inventory.inventory.input.inventoryIssues.inventoryIssues myIIService
        {
            //used for access to the webservice.  automatically creates the object if necessary
            get
            {
                if (myIIServiceValue == null)
                {
                    //if we get here, then the object is not created
                    ctDynamicsSL.inventory.inventory.input.inventoryIssues.ctDynamicsSLHeader Header = new ctDynamicsSL.inventory.inventory.input.inventoryIssues.ctDynamicsSLHeader();
                    Header.siteID = System.Configuration.ConfigurationManager.AppSettings["SITEID"];
                    Header.cpnyID = System.Configuration.ConfigurationManager.AppSettings["CPNYID"];
                    Header.licenseKey = System.Configuration.ConfigurationManager.AppSettings["LICENSEKEY"];
                    Header.licenseName = System.Configuration.ConfigurationManager.AppSettings["LICENSENAME"];
                    Header.licenseExpiration = System.Configuration.ConfigurationManager.AppSettings["LICENSEEXPIRATION"];
                    Header.siteKey = System.Configuration.ConfigurationManager.AppSettings["SITEKEY"];
                    Header.softwareName = System.Configuration.ConfigurationManager.AppSettings["SOFTWARENAME"];
                    myIIServiceValue = new ctDynamicsSL.inventory.inventory.input.inventoryIssues.inventoryIssues();
                    myIIServiceValue.ctDynamicsSLHeaderValue = Header;
                    myIIServiceValue.Timeout = 300000;
                }
                return myIIServiceValue;
            }
            set
            {
                myIIServiceValue = value;
            }
        }

        //Button action to release a batch,  setup to automatically load the batch first
        private void btnRelease_Click(object sender, EventArgs e)
        {
            myScreen = myIIService.getScreenByBatNbr(tbBatNbr.Text);
            if (myScreen.errorMessage != "")
            {
                MessageBox.Show("Error: " + myScreen.errorMessage);
                return;
            }
            else
            {
                myScreen = myIIService.editScreen("RELEASENOW", myScreen);
                if (myScreen.errorMessage != "")
                {
                    MessageBox.Show("Error: " + myScreen.errorMessage);
                    return;
                }
                else
                {
                    tbScreen.Text = ctStandardLib.ctHelper.serializeObject(myScreen).Replace("><", ">" + Environment.NewLine + "<");
                }
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            myScreen = myIIService.getScreenByBatNbr(tbBatNbr.Text);
            if (myScreen.errorMessage != "")
            {
                MessageBox.Show("Error: " + myScreen.errorMessage);
                return;
            }
            if (myScreen.myBatch.Status.ToUpper() == "H")
            {
                btnRelease.Enabled = true;
            }
            else
            {
                btnRelease.Enabled = false;
            }
            btnUpdate.Enabled = true;
            tbScreen.Text = ctStandardLib.ctHelper.serializeObject(myScreen).Replace("><", ">" + Environment.NewLine + "<");
            gvINTran.DataSource = myScreen.myINTran;
        }

        //Used to save a batch that has been loaded
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (myScreen == null)
            {
                MessageBox.Show("You must load a batch first!");
                return;
            }
            ///get any updates to the grid
            myScreen.myINTran = (ctDynamicsSL.inventory.inventory.input.inventoryIssues.INTran[])gvINTran.DataSource;

            //MessageBox.Show(ctStandardLib.ctHelper.serializeObject(myScreen).Replace("><", ">" + Environment.NewLine + "<"));
            {
                var validate = myIIService.editScreen("VALIDATEONLY", myScreen);
                if (!String.IsNullOrWhiteSpace(validate.errorMessage))
                {
                    MessageBox.Show("Error in validating Screen: " + validate.errorMessage);
                    return;
                }
            }

            myScreen = myIIService.editScreen("UPDATE", myScreen);
            if (myScreen.errorMessage != "")
            {
                MessageBox.Show("Error: " + myScreen.errorMessage);
            }
            else
            {
                MessageBox.Show("Save Complete!");
            }
        }

        //Pulls up the batch list search box
        private void btnSearch_Click(object sender, EventArgs e)
        {
            batchesPopup newPopup = new batchesPopup(this, tbBatNbr.Text);
            newPopup.ShowDialog();
        }

        //Creates an empty new generic batch
        private void btnNew_Click(object sender, EventArgs e)
        {
            myScreen = myIIService.getNewscreen(null);
            myScreen.myBatch.CpnyID = System.Configuration.ConfigurationManager.AppSettings["CPNYID"];
            System.Collections.Generic.List<ctDynamicsSL.inventory.inventory.input.inventoryIssues.INTran> INTranList = new List<ctDynamicsSL.inventory.inventory.input.inventoryIssues.INTran>();
            for (System.Int16 i = 0; i < 5; i++)
            {
                ctDynamicsSL.inventory.inventory.input.inventoryIssues.INTran tmpLine = new ctDynamicsSL.inventory.inventory.input.inventoryIssues.INTran();
                tmpLine.CpnyID = myScreen.myBatch.CpnyID;
                tmpLine.InvtID = "108565714";
                tmpLine.SiteID = "SEA";
                tmpLine.UnitDesc = "EA";
                tmpLine = myIIService.getNewINTran(tmpLine);
                //tmpLine.Acct = myIIService.getAcctXrefsByAcct("", myScreen.myBatch.CpnyID)[0].Acct; //just pick first match
                tmpLine.LineNbr = i;
                {
                    var validate = myIIService.editINTran("VALIDATEONLY", tmpLine);
                    if (!String.IsNullOrWhiteSpace(validate.errorMessage))
                    {
                        MessageBox.Show("Error in validating INTran: " + validate.errorMessage);
                        return;
                    }
                }
                INTranList.Add(tmpLine);
            }

            myScreen.myINTran = INTranList.ToArray();

            {
                var validate = myIIService.editScreen("VALIDATEONLY", myScreen);
                if (!String.IsNullOrWhiteSpace(validate.errorMessage))
                {
                    MessageBox.Show("Error in validating Screen: " + validate.errorMessage);
                    return;
                }
            }

            myScreen = myIIService.editScreen("ADD", myScreen);

            if (myScreen.errorMessage != "")
            {
                btnRelease.Enabled = false;
                btnUpdate.Enabled = false;
                tbBatNbr.Text = "";
                gvINTran.DataSource = null;
                tbScreen.Text = ctStandardLib.ctHelper.serializeObject(myScreen).Replace("><", ">" + Environment.NewLine + "<");
                MessageBox.Show("Error: " + myScreen.errorMessage);
                return;
            }
            else
            {
                tbBatNbr.Text = myScreen.myBatch.BatNbr;
                btnLoad.PerformClick();
            }
        }

        /// <summary>
        /// for test purposes, calls all the gets/pvs/lookups in the system
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGets_Click(object sender, EventArgs e)
        {
            try { MessageBox.Show("about: " + ctStandardLib.ctHelper.serializeObject(myIIService.about())); } catch { }
            try { MessageBox.Show("getAcctXrefsByAcct: " + ctStandardLib.ctHelper.serializeObject(myIIService.getAcctXrefsByAcct("TEST"))); } catch { }
            try { MessageBox.Show("getSubXrefsBySub: " + ctStandardLib.ctHelper.serializeObject(myIIService.getSubXrefsBySub("TEST"))); } catch { }
            try { MessageBox.Show("getProjectsByID: " + ctStandardLib.ctHelper.serializeObject(myIIService.getProjectsByID("TEST"))); } catch { }
            try { MessageBox.Show("getTasks: " + ctStandardLib.ctHelper.serializeObject(myIIService.getTasks("TEST", "TEST"))); } catch { }
            try { MessageBox.Show("getSiteIDs: " + ctStandardLib.ctHelper.serializeObject(myIIService.getSiteIDs("TEST","TEST"))); } catch { }
            try { MessageBox.Show("getWarehouseBinLocations: " + ctStandardLib.ctHelper.serializeObject(myIIService.getWarehouseBinLocations("TEST", "TEST","TEST"))); } catch { }
            try { MessageBox.Show("getUOMs: " + ctStandardLib.ctHelper.serializeObject(myIIService.getUOMs("TEST", "TEST", "TEST", "TEST"))); } catch { }
            try { MessageBox.Show("getSpecificCostIDs: " + ctStandardLib.ctHelper.serializeObject(myIIService.getSpecificCostIDs("TEST","TEST"))); } catch { }
            try { MessageBox.Show("getLotSerials: " + ctStandardLib.ctHelper.serializeObject(myIIService.getLotSerials("TEST","TEST","TEST","TEST"))); } catch { }
            try { MessageBox.Show("getReasonCodesByID: " + ctStandardLib.ctHelper.serializeObject(myIIService.getReasonCodesByID("TEST"))); } catch { }
            try { MessageBox.Show("getInventoryByID: " + ctStandardLib.ctHelper.serializeObject(myIIService.getInventoryByID("TEST"))); } catch { }
            try { MessageBox.Show("getScreenByBatNbr: " + ctStandardLib.ctHelper.serializeObject(myIIService.getScreenByBatNbr("TEST"))); } catch { }
            try { MessageBox.Show("getBatchesByBatNbr: " + ctStandardLib.ctHelper.serializeObject(myIIService.getBatchesByBatNbr("TEST"))); } catch { }
            try { MessageBox.Show("getINTransByBatNbrAndRecordID: " + ctStandardLib.ctHelper.serializeObject(myIIService.getINTransByBatNbrAndRecordID("TEST","TEST"))); } catch { }
            //try { MessageBox.Show("getNewSnote: " + ctStandardLib.ctHelper.serializeObject(myIIService.getNewSnote(null))); } catch { }
            try { MessageBox.Show("getNewscreen: " + ctStandardLib.ctHelper.serializeObject(myIIService.getNewscreen(null))); } catch { }
            try { MessageBox.Show("getNewINTran: " + ctStandardLib.ctHelper.serializeObject(myIIService.getNewINTran(null))); } catch { }
            try { MessageBox.Show("getNewBatch: " + ctStandardLib.ctHelper.serializeObject(myIIService.getNewBatch(null))); } catch { }

        }
    }
}

