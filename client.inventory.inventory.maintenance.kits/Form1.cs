using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace client.inventory.inventory.maintenance.kits
{
    public partial class Form1 : Form
    {
        private ctDynamicsSL.inventory.inventory.maintenance.inventoryItems.inventoryItems myInventoryItemsServiceValue = null;
        private ctDynamicsSL.inventory.inventory.maintenance.kits.kits myKitsServiceValue = null;
        public ctDynamicsSL.inventory.inventory.maintenance.kits.screen myScreen = null;

        public Form1()
        {
            InitializeComponent();
        }

        public ctDynamicsSL.inventory.inventory.maintenance.kits.kits myKitsService
        {
            //used for access to the webservice.  automatically creates the object if necessary
            get
            {
                if (myKitsServiceValue == null)
                {
                    //if we get here, then the object is not created
                    ctDynamicsSL.inventory.inventory.maintenance.kits.ctDynamicsSLHeader Header = new ctDynamicsSL.inventory.inventory.maintenance.kits.ctDynamicsSLHeader();
                    Header.siteID = System.Configuration.ConfigurationManager.AppSettings["SITEID"];
                    Header.cpnyID = System.Configuration.ConfigurationManager.AppSettings["CPNYID"];
                    Header.licenseKey = System.Configuration.ConfigurationManager.AppSettings["LICENSEKEY"];
                    Header.licenseName = System.Configuration.ConfigurationManager.AppSettings["LICENSENAME"];
                    Header.licenseExpiration = System.Configuration.ConfigurationManager.AppSettings["LICENSEEXPIRATION"];
                    Header.siteKey = System.Configuration.ConfigurationManager.AppSettings["SITEKEY"];
                    Header.softwareName = "CTAPI";
                    myKitsServiceValue = new ctDynamicsSL.inventory.inventory.maintenance.kits.kits();
                    myKitsServiceValue.ctDynamicsSLHeaderValue = Header;
                    myKitsServiceValue.Timeout = 300000;
                }
                return myKitsServiceValue;
            }
            set
            {
                myKitsServiceValue = value;
            }
        }

        public ctDynamicsSL.inventory.inventory.maintenance.inventoryItems.inventoryItems myInventoryItemsService
        {
            //used for access to the webservice.  automatically creates the object if necessary
            get
            {
                if (myInventoryItemsServiceValue == null)
                {
                    //if we get here, then the object is not created
                    ctDynamicsSL.inventory.inventory.maintenance.inventoryItems.ctDynamicsSLHeader Header = new ctDynamicsSL.inventory.inventory.maintenance.inventoryItems.ctDynamicsSLHeader();
                    Header.siteID = System.Configuration.ConfigurationManager.AppSettings["SITEID"];
                    Header.cpnyID = System.Configuration.ConfigurationManager.AppSettings["CPNYID"];
                    Header.licenseKey = System.Configuration.ConfigurationManager.AppSettings["LICENSEKEY"];
                    Header.licenseName = System.Configuration.ConfigurationManager.AppSettings["LICENSENAME"];
                    Header.licenseExpiration = System.Configuration.ConfigurationManager.AppSettings["LICENSEEXPIRATION"];
                    Header.siteKey = System.Configuration.ConfigurationManager.AppSettings["SITEKEY"];
                    Header.softwareName = "CTAPI";
                    myInventoryItemsServiceValue = new ctDynamicsSL.inventory.inventory.maintenance.inventoryItems.inventoryItems();
                    myInventoryItemsServiceValue.ctDynamicsSLHeaderValue = Header;
                    myInventoryItemsServiceValue.Timeout = 300000;
                }
                return myInventoryItemsServiceValue;
            }
            set
            {
                myInventoryItemsServiceValue = value;
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            kitsPopup newPopup = new kitsPopup(this);
            newPopup.ShowDialog();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            myScreen = myKitsService.getScreenByKitID(tbKitID.Text);
            if (myScreen.errorMessage != "")
            {
                MessageBox.Show("Error: " + myScreen.errorMessage);
                return;
            }
            gvComponents.DataSource = myScreen.myComponents;
            btnUpdate.Enabled = true;
            tbScreen.Text = ctStandardLib.ctHelper.serializeObject(myScreen).Replace("><", ">" + Environment.NewLine + "<");
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
                ctDynamicsSL.inventory.inventory.maintenance.kits.screen validateScreen = myKitsService.editScreen("VALIDATEONLY", myScreen);
                if (validateScreen.errorMessage != "")
                {
                    MessageBox.Show("Error: " + validateScreen.errorMessage);
                    return;
                }
            }
            catch { }

            MessageBox.Show(ctStandardLib.ctHelper.serializeObject(myScreen).Replace("><", ">" + Environment.NewLine + "<"));
            
            var tmpScreen = myKitsService.editScreen("UPDATE", myScreen);
            if (tmpScreen.errorMessage != "")
            {
                MessageBox.Show("Error: " + tmpScreen.errorMessage);
            }
            else
            {
                myScreen = tmpScreen;
                gvComponents.DataSource = myScreen.myComponents;
                MessageBox.Show("Save complete!");
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            myScreen = myKitsService.getNewscreen(null);
            myScreen.myKit.KitID = tbKitID.Text.Trim();
            myScreen.myKit.Descr = "TEST Kit: " + myScreen.myKit.KitID;

            try
            {
                ctDynamicsSL.inventory.inventory.maintenance.kits.Snote myNote = new ctDynamicsSL.inventory.inventory.maintenance.kits.Snote();
                myNote.sNoteText = "My test kit note";
                myScreen.kitNote = myNote;
            }
            catch { }

            myScreen.myComponents = new ctDynamicsSL.inventory.inventory.maintenance.kits.Component[3];
            {
                ctDynamicsSL.inventory.inventory.maintenance.kits.Component tmpComponent = myKitsService.getNewComponent(null);
                tmpComponent.KitID = myScreen.myKit.KitID;
                tmpComponent.CmpnentQty = 1;
                tmpComponent.CmpnentID = myInventoryItemsService.getInventoryByID("")[0].InvtID.Trim();
                myScreen.myComponents[0] = tmpComponent;
            }

            {
                ctDynamicsSL.inventory.inventory.maintenance.kits.Component tmpComponent = myKitsService.getNewComponent(null);
                tmpComponent.KitID = myScreen.myKit.KitID;
                tmpComponent.CmpnentQty = 2;
                tmpComponent.CmpnentID = myInventoryItemsService.getInventoryByID("")[1].InvtID.Trim();
                myScreen.myComponents[1] = tmpComponent;
            }

            {
                ctDynamicsSL.inventory.inventory.maintenance.kits.Component tmpComponent = myKitsService.getNewComponent(null);
                tmpComponent.KitID = myScreen.myKit.KitID;
                tmpComponent.CmpnentQty = 3;
                tmpComponent.CmpnentID = myInventoryItemsService.getInventoryByID("")[2].InvtID.Trim();
                myScreen.myComponents[2] = tmpComponent;
            }

            myScreen.errorMessage = "";
            try
            {
                ctDynamicsSL.inventory.inventory.maintenance.kits.screen validateScreen = myKitsService.editScreen("VALIDATEONLY", myScreen);
                if (validateScreen.errorMessage != "")
                {
                    MessageBox.Show("Error: " + validateScreen.errorMessage);
                    return;
                }
            }
            catch { }

            myScreen = myKitsService.editScreen("ADD", myScreen);
            if (myScreen.errorMessage != "")
            {
                btnUpdate.Enabled = false;
                tbKitID.Text = "";
                tbScreen.Text = ctStandardLib.ctHelper.serializeObject(myScreen).Replace("><", ">" + Environment.NewLine + "<");
                MessageBox.Show("Error: " + myScreen.errorMessage);
                return;
            }
            else
            {
                tbKitID.Text = myScreen.myKit.KitID;
                gvComponents.DataSource = myScreen.myComponents;
                btnLoad.PerformClick();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void lblScreen_Click(object sender, EventArgs e)
        {

        }
    }
}
