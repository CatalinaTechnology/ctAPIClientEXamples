using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace client.routingMaintenance
{
    public partial class Form1 : Form
    {
        private ctDynamicsSL.inventory.billOfMaterial.maintenance.routingMaintenance.routingMaintenance myRoutingServiceValue = null;
        public ctDynamicsSL.inventory.billOfMaterial.maintenance.routingMaintenance.screen myScreen = null;

        public Form1()
        {
            InitializeComponent();
        }

        public ctDynamicsSL.inventory.billOfMaterial.maintenance.routingMaintenance.routingMaintenance myRoutingService
        {
            //used for access to the webservice.  automatically creates the object if necessary
            get
            {
                if (myRoutingServiceValue == null)
                {
                    //if we get here, then the object is not created
                    ctDynamicsSL.inventory.billOfMaterial.maintenance.routingMaintenance.ctDynamicsSLHeader Header = new ctDynamicsSL.inventory.billOfMaterial.maintenance.routingMaintenance.ctDynamicsSLHeader();
                    Header.siteID = System.Configuration.ConfigurationManager.AppSettings["SITEID"];
                    Header.cpnyID = System.Configuration.ConfigurationManager.AppSettings["CPNYID"];
                    Header.licenseKey = System.Configuration.ConfigurationManager.AppSettings["LICENSEKEY"];
                    Header.licenseName = System.Configuration.ConfigurationManager.AppSettings["LICENSENAME"];
                    Header.licenseExpiration = System.Configuration.ConfigurationManager.AppSettings["LICENSEEXPIRATION"];
                    Header.siteKey = System.Configuration.ConfigurationManager.AppSettings["SITEKEY"];
                    Header.softwareName = "CTAPI";
                    myRoutingServiceValue = new ctDynamicsSL.inventory.billOfMaterial.maintenance.routingMaintenance.routingMaintenance();
                    myRoutingServiceValue.ctDynamicsSLHeaderValue = Header;
                    myRoutingServiceValue.Timeout = 300000;
                }
                return myRoutingServiceValue;
            }
            set
            {
                myRoutingServiceValue = value;
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            myScreen = myRoutingService.getNewscreen(null);
            myScreen.myRouting.KitID = tbKitID.Text.TrimEnd();
            myScreen.myRouting.SiteID = tbSiteID.Text.TrimEnd();
            myScreen.myRouting.Status = tbStatus.Text.TrimEnd();
            myScreen.myRouting.Descr = "TEST route: " + myScreen.myRouting.KitID;

            try
            {
                var myNote = new ctDynamicsSL.inventory.billOfMaterial.maintenance.routingMaintenance.Snote();
                myNote.sNoteText = "My test route note";
                myScreen.routeNote = myNote;
            }
            catch { }

            System.Int16 lineNbr = -32768;
            var lRtgSteps = new System.Collections.Generic.List<ctDynamicsSL.inventory.billOfMaterial.maintenance.routingMaintenance.RtgStep>();
            {
                var tmpRtgStep = new ctDynamicsSL.inventory.billOfMaterial.maintenance.routingMaintenance.RtgStep();
                tmpRtgStep.KitID = myScreen.myRouting.KitID;
                tmpRtgStep.SiteID = myScreen.myRouting.SiteID;
                tmpRtgStep.OperationID = myRoutingService.getOperationsByID("")[0].OperationID;//required, picking first for example purposes
                tmpRtgStep.LaborClassID = myRoutingService.getLaborClassesByID("")[0].LbrClassID;//required, picking first for example purposes
                tmpRtgStep.WorkCenterID = myRoutingService.getWorkCentersByID("")[0].WorkCenterID;//required, picking first for example purposes

                //get defaults based on above settings
                tmpRtgStep = myRoutingService.getNewRtgStep(tmpRtgStep);

                tmpRtgStep.LineNbr = lineNbr;
                lRtgSteps.Add(tmpRtgStep);
            }

            {
                ctDynamicsSL.inventory.billOfMaterial.maintenance.routingMaintenance.RtgStep tmpRtgStep = myRoutingService.getNewRtgStep(null);
                tmpRtgStep.KitID = myScreen.myRouting.KitID;
                tmpRtgStep.OperationID = myRoutingService.getOperationsByID("")[0].OperationID;//required, pick first for example purposes
                tmpRtgStep.LaborClassID = myRoutingService.getLaborClassesByID("")[0].LbrClassID;//required, picking first for example purposes
                tmpRtgStep.WorkCenterID = myRoutingService.getWorkCentersByID("")[0].WorkCenterID;//required, picking first for example purposes

                //get defaults based on above settings
                tmpRtgStep = myRoutingService.getNewRtgStep(tmpRtgStep);

                tmpRtgStep.LineNbr = System.Convert.ToInt16(lRtgSteps.Max(x => x.LineNbr) + 1);
                lRtgSteps.Add(tmpRtgStep);
            }

            {
                ctDynamicsSL.inventory.billOfMaterial.maintenance.routingMaintenance.RtgStep tmpRtgStep = myRoutingService.getNewRtgStep(null);
                tmpRtgStep.KitID = myScreen.myRouting.KitID;
                tmpRtgStep.OperationID = myRoutingService.getOperationsByID("")[0].OperationID;//required, pick first for example purposes
                tmpRtgStep.LaborClassID = myRoutingService.getLaborClassesByID("")[0].LbrClassID;//required, picking first for example purposes
                tmpRtgStep.WorkCenterID = myRoutingService.getWorkCentersByID("")[0].WorkCenterID;//required, picking first for example purposes

                //get defaults based on above settings
                tmpRtgStep = myRoutingService.getNewRtgStep(tmpRtgStep);

                tmpRtgStep.LineNbr = System.Convert.ToInt16(lRtgSteps.Max(x => x.LineNbr) + 1);
                lRtgSteps.Add(tmpRtgStep);
            }

            myScreen.myRtgSteps = lRtgSteps.ToArray();

            myScreen.errorMessage = "";
            try
            {
                var validate = myRoutingService.editScreen("VALIDATEONLY", myScreen);
                if (!String.IsNullOrWhiteSpace(validate.errorMessage))
                {
                    MessageBox.Show("Error: " + validate.errorMessage);
                    return;
                }
            }
            catch { }

            myScreen = myRoutingService.editScreen("ADD", myScreen);
            if (!String.IsNullOrWhiteSpace(myScreen.errorMessage))
            {
                btnUpdate.Enabled = false;
                tbKitID.Text = "";
                tbScreen.Text = ctStandardLib.ctHelper.serializeObject(myScreen).Replace("><", ">" + Environment.NewLine + "<");
                MessageBox.Show("Error: " + myScreen.errorMessage);
                return;
            }
            else
            {
                tbKitID.Text = myScreen.myRouting.KitID;
                gvRtgSteps.DataSource = myScreen.myRtgSteps;
                btnLoad.PerformClick();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (myScreen == null)
            {
                MessageBox.Show("You must load a screen first!");
                return;
            }

            myScreen.errorMessage = "";
            try
            {
                var validateScreen = myRoutingService.editScreen("VALIDATEONLY", myScreen);
                if (validateScreen.errorMessage != "")
                {
                    MessageBox.Show("Error: " + validateScreen.errorMessage);
                    return;
                }
            }
            catch { }

            MessageBox.Show(ctStandardLib.ctHelper.serializeObject(myScreen).Replace("><", ">" + Environment.NewLine + "<"));

            var tmpScreen = myRoutingService.editScreen("UPDATE", myScreen);
            if (tmpScreen.errorMessage != "")
            {
                MessageBox.Show("Error: " + tmpScreen.errorMessage);
            }
            else
            {
                myScreen = tmpScreen;
                gvRtgSteps.DataSource = myScreen.myRtgSteps;
                MessageBox.Show("Save complete!");
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            myScreen = myRoutingService.getScreen(tbKitID.Text,tbSiteID.Text, tbStatus.Text);
            if (myScreen.errorMessage != "")
            {
                MessageBox.Show("Error: " + myScreen.errorMessage);
                return;
            }
            try
            {
                tbKitID.Text = myScreen.myRouting.KitID.TrimEnd();
                tbSiteID.Text = myScreen.myRouting.SiteID.TrimEnd();
                tbStatus.Text = myScreen.myRouting.Status.TrimEnd();
            }
            catch { }

            gvRtgSteps.DataSource = myScreen.myRtgSteps;
            btnUpdate.Enabled = true;
            tbScreen.Text = ctStandardLib.ctHelper.serializeObject(myScreen).Replace("><", ">" + Environment.NewLine + "<");
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            kitsPopup newPopup = new kitsPopup(this);
            newPopup.ShowDialog();
        }

        private void btnTestGets_Click(object sender, EventArgs e)
        {
            tbScreen.Text = "";
            try
            {
                tbScreen.Text += "getKitByExactID:" + ctStandardLib.ctHelper.serializeObject(myRoutingService.getKitByExactID("test", "test", "A")).Replace("><", ">" + System.Environment.NewLine + "<") + System.Environment.NewLine;
            }
            catch (Exception ex)
            {
                tbScreen.Text += "getKitByExactID:" + ex.Message + System.Environment.NewLine;
            }
            tbScreen.Text += "getKitsByID:" + ctStandardLib.ctHelper.serializeObject(myRoutingService.getKitsByID("test")).Replace("><", ">" + System.Environment.NewLine + "<") + System.Environment.NewLine;
            tbScreen.Text += "getLaborClassesByID:" + ctStandardLib.ctHelper.serializeObject(myRoutingService.getLaborClassesByID("test")).Replace("><", ">" + System.Environment.NewLine + "<") + System.Environment.NewLine;
            tbScreen.Text += "getMachinesByID:"+ctStandardLib.ctHelper.serializeObject(myRoutingService.getMachinesByID("test")).Replace("><", ">" + System.Environment.NewLine + "<") + System.Environment.NewLine;
            tbScreen.Text += "getNewRouting:"+ctStandardLib.ctHelper.serializeObject(myRoutingService.getNewRouting(null)).Replace(" ><", ">" + System.Environment.NewLine + "<") + System.Environment.NewLine;
            tbScreen.Text += "getNewRtgStep:"+ctStandardLib.ctHelper.serializeObject(myRoutingService.getNewRtgStep(null)).Replace(" ><", ">" + System.Environment.NewLine + "<") + System.Environment.NewLine;
            tbScreen.Text += "getNewscreen:"+ctStandardLib.ctHelper.serializeObject(myRoutingService.getNewscreen(null)).Replace(" ><", ">" + System.Environment.NewLine + "<") + System.Environment.NewLine;
            tbScreen.Text += "getOperationsByID:"+ctStandardLib.ctHelper.serializeObject(myRoutingService.getOperationsByID("test")).Replace("><", ">" + System.Environment.NewLine + "<") + System.Environment.NewLine;
            try
            {
                tbScreen.Text += "getRoutingByExactID:" + ctStandardLib.ctHelper.serializeObject(myRoutingService.getRoutingByExactID("test", "test", "A")).Replace("><", ">" + System.Environment.NewLine + "<") + System.Environment.NewLine;
            }
            catch (Exception ex)
            {
                tbScreen.Text += "getRoutingByExactID:" + ex.Message + System.Environment.NewLine;
            }
            tbScreen.Text += "getRoutingsByID:"+ctStandardLib.ctHelper.serializeObject(myRoutingService.getRoutingsByID("test", "test", "A")).Replace("><", ">" + System.Environment.NewLine + "<") + System.Environment.NewLine;

            try
            {
                tbScreen.Text += "getRtgStepsByExactID:" + ctStandardLib.ctHelper.serializeObject(myRoutingService.getRtgStepsByExactID("test", "test", "test", 0)).Replace("><", ">" + System.Environment.NewLine + "<") + System.Environment.NewLine;
            }
            catch (Exception ex)
            {
                tbScreen.Text += "getRtgStepsByExactID:" + ex.Message + System.Environment.NewLine;
            }
            tbScreen.Text += "getRtgStepsByID:"+ctStandardLib.ctHelper.serializeObject(myRoutingService.getRtgStepsByID("test", "test", "A")).Replace("><", ">" + System.Environment.NewLine + "<") + System.Environment.NewLine;
            tbScreen.Text += "getScreen:"+ctStandardLib.ctHelper.serializeObject(myRoutingService.getScreen("test", "test", "A")).Replace("><", ">" + System.Environment.NewLine + "<") + System.Environment.NewLine;
            tbScreen.Text += "getSitesByID:"+ctStandardLib.ctHelper.serializeObject(myRoutingService.getSitesByID("test")).Replace("><", ">" + System.Environment.NewLine + "<") + System.Environment.NewLine;
            tbScreen.Text += "getToolsByID:"+ctStandardLib.ctHelper.serializeObject(myRoutingService.getToolsByID("test")).Replace("><", ">" + System.Environment.NewLine + "<") + System.Environment.NewLine;
            tbScreen.Text += "getWorkCentersByID:"+ctStandardLib.ctHelper.serializeObject(myRoutingService.getWorkCentersByID("test")).Replace("><", ">" + System.Environment.NewLine + "<") + System.Environment.NewLine;
        }
    }
}
