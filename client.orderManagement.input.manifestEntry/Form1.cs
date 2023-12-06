using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace client.orderManagement.input.manifestEntry
{
    public partial class Form1 : Form
    {
        private ctDynamicsSL.orderManagement.input.manifestEntry.manifestEntry myMEServiceValue = null;
        private ctDynamicsSL.common.common myCommonServiceValue = null;
        public ctDynamicsSL.orderManagement.input.manifestEntry.screen myScreen = null;
        
        private void btnLoad_Click(object sender, EventArgs e)
        {
            myScreen = myMEService.getScreenByShipperID(tbShipperID.Text);
            if (myScreen.errorMessage != "")
            {
                MessageBox.Show("Error: " + myScreen.errorMessage);
                return;
            }
            btnUpdate.Enabled = true;
            btnNew.Enabled = true;
            tbScreen.Text = ctStandardLib.ctHelper.serializeObject(myScreen).Replace("><", ">" + Environment.NewLine + "<");
            gvSOShipPack.DataSource = myScreen.mySOShipPack;
            MessageBox.Show("Load complete!");
        }

        //Used to save a batch that has been loaded
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (myScreen == null)
            {
                MessageBox.Show("You must load a shipper first!");
                return;
            }

            myScreen.mySOShipHeader.ShipDateAct = System.DateTime.Now;
            myScreen.mySOShipHeader.ShipViaID = myMEService.getShipViaIDsByID("")[0].ShipViaID;//just pickin first entry for example purposes
            //myScreen.mySOShipHeader.FrtTermsID = myMEService.getFrtTermsByID("")[0].FrtTermsID;//just pickin first entry for example purposes

            myScreen = myMEService.editScreen("UPDATE", myScreen);
            if (myScreen.errorMessage != "")
            {
                MessageBox.Show("Error: " + myScreen.errorMessage);
            }
            else
            {
                btnUpdate.Enabled = true;
                btnNew.Enabled = true;
                tbScreen.Text = ctStandardLib.ctHelper.serializeObject(myScreen).Replace("><", ">" + Environment.NewLine + "<");
                gvSOShipPack.DataSource = myScreen.mySOShipPack;
                MessageBox.Show("Save complete!");
            }
        }

        //Pulls up the batch list search box
        private void btnSearch_Click(object sender, EventArgs e)
        {
            shippersPopup newPopup = new shippersPopup(this, tbShipperID.Text);
            newPopup.ShowDialog();
        }

        //Creates an empty new generic batch
        private void btnNew_Click(object sender, EventArgs e)
        {
            if (myScreen == null)
            {
                MessageBox.Show("You must load a shipper first!");
                return;
            }

            System.Collections.Generic.List<ctDynamicsSL.orderManagement.input.manifestEntry.SOShipPack> myPacks = new List<ctDynamicsSL.orderManagement.input.manifestEntry.SOShipPack>();
            myPacks.AddRange(((ctDynamicsSL.orderManagement.input.manifestEntry.SOShipPack[])gvSOShipPack.DataSource));

            {
                ctDynamicsSL.orderManagement.input.manifestEntry.SOShipPack tmpItem = new ctDynamicsSL.orderManagement.input.manifestEntry.SOShipPack();
                tmpItem.CpnyID = myScreen.mySOShipHeader.CpnyID;
                tmpItem.ShipperID = myScreen.mySOShipHeader.ShipperID;
                tmpItem = myMEService.getNewSOShipPack(tmpItem);
                tmpItem.Wght = 1.5;
                tmpItem.TrackingNbr = "1235667890";
                tmpItem.CuryFrtInvc = 1;
                tmpItem.CuryFrtCost = 1;
                myPacks.Add(tmpItem);
            }

            myScreen.mySOShipPack = myPacks.ToArray();

            myScreen = myMEService.editScreen("UPDATE", myScreen);
            if (myScreen.errorMessage != "")
            {
                MessageBox.Show("Error: " + myScreen.errorMessage);
                return;
            }
            else
            {
                MessageBox.Show("Save complete!");
                tbShipperID.Text = myScreen.mySOShipHeader.ShipperID;
                btnLoad.PerformClick();
            }
        }

        
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        public ctDynamicsSL.orderManagement.input.manifestEntry.manifestEntry myMEService
        {
            //used for access to the webservice.  automatically creates the object if necessary
            get
            {
                if (myMEServiceValue == null)
                {
                    //if we get here, then the object is not created
                    ctDynamicsSL.orderManagement.input.manifestEntry.ctDynamicsSLHeader Header = new ctDynamicsSL.orderManagement.input.manifestEntry.ctDynamicsSLHeader();
                    Header.siteID = System.Configuration.ConfigurationManager.AppSettings["SITEID"];
                    Header.cpnyID = System.Configuration.ConfigurationManager.AppSettings["CPNYID"];
                    Header.licenseKey = System.Configuration.ConfigurationManager.AppSettings["LICENSEKEY"];
                    Header.licenseName = System.Configuration.ConfigurationManager.AppSettings["LICENSENAME"];
                    Header.licenseExpiration = System.Configuration.ConfigurationManager.AppSettings["LICENSEEXPIRATION"];
                    Header.siteKey = System.Configuration.ConfigurationManager.AppSettings["SITEKEY"];
                    Header.softwareName = "CTAPI";
                    myMEServiceValue = new ctDynamicsSL.orderManagement.input.manifestEntry.manifestEntry();
                    myMEServiceValue.ctDynamicsSLHeaderValue = Header;
                    myMEServiceValue.Timeout = 300000;
                }
                return myMEServiceValue;
            }
            set
            {
                myMEServiceValue = value;
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

    }
}
