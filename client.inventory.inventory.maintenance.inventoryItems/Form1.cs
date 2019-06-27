using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace client.inventory.inventory.maintenance.inventoryItems
{
    public partial class Form1 : Form
    {
        private ctDynamicsSL.common.common myCommonServiceValue = null;
        private ctDynamicsSL.inventory.inventory.maintenance.inventoryItems.inventoryItems myInventoryItemsServiceValue = null;
        public ctDynamicsSL.inventory.inventory.maintenance.inventoryItems.screen myInventoryScreen = null;
        public Form1()
        {
            InitializeComponent();
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

        public ctDynamicsSL.common.common myCommonsService
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

        private void btnLoad_Click(object sender, EventArgs e)
        {
            myInventoryScreen = myInventoryItemsService.getScreenByInvtID(tbInvtID.Text);
            if (myInventoryScreen.errorMessage != "")
            {
                MessageBox.Show("Error: " + myInventoryScreen.errorMessage);
                return;
            }
            btnUpdate.Enabled = true;
            tbScreen.Text = ctStandardLib.ctHelper.serializeObject(myInventoryScreen).Replace("><", ">" + Environment.NewLine + "<");
        }

        //Used to save a batch that has been loaded
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (myInventoryScreen == null)
            {
                MessageBox.Show("You must load a screen first!");
                return;
            }

            myInventoryScreen.errorMessage = "";
            MessageBox.Show(ctStandardLib.ctHelper.serializeObject(myInventoryScreen).Replace("><", ">" + Environment.NewLine + "<"));

            myInventoryScreen = myInventoryItemsService.editScreen("UPDATE", myInventoryScreen);
            if (myInventoryScreen.errorMessage != "")
            {
                MessageBox.Show("Error: " + myInventoryScreen.errorMessage);
            }
            else
            {
                MessageBox.Show("Save complete!");
            }

        }

        //Pulls up the customer list search box
        private void btnSearch_Click(object sender, EventArgs e)
        {
            inventoriesPopup newPopup = new inventoriesPopup(this);
            newPopup.ShowDialog();
        }

        //Creates an empty new generic batch
        private void btnNew_Click(object sender, EventArgs e)
        {
            myInventoryScreen = myInventoryItemsService.getNewscreen(null);
            //we need to generate an invtID, for example purposes we will just use our counter and a random string
            myInventoryScreen.myInventory.InvtID = "INV" + myCommonsService.getNextCounter("INVTID").Tables[0].Rows[0]["OUTAMT"].ToString().Trim();

            myInventoryScreen.myInventory.Descr = "TEST " + myInventoryScreen.myInventory.InvtID;
/*begin setting required fields*/
            myInventoryScreen.myInventory.ValMthd = "U"; //required
            myInventoryScreen.myInventory.InvtType = "F"; //required
            myInventoryScreen.myInventory.Kit = 0;//required
            myInventoryScreen.myInventory.TranStatusCode = "AC";//required
            myInventoryScreen.myInventory.LotSerTrack = "NN";//required
            myInventoryScreen.myInventory.Source = "M";//required
            myInventoryScreen.myInventory.CountStatus = "A";//required
            myInventoryScreen.myInventory.ClassID = myInventoryItemsService.getProductClassesByID("")[0].ClassID;//pick first entry
            myInventoryScreen.myInventory.TaxCat = myInventoryItemsService.getSalesTaxCatsByID("")[0].CatId;//pick first entry
            myInventoryScreen.myInventory.StkUnit = myInventoryItemsService.getStkUnits("", myInventoryScreen.myInventory.ClassID)[0].ToUnit;//pick first entry
            myInventoryScreen.myInventory.DfltPOUnit = myInventoryItemsService.getPOUnits("", myInventoryScreen.myInventory.ClassID, myInventoryScreen.myInventory.StkUnit)[0].FromUnit;//pick first entry
            myInventoryScreen.myInventory.DfltSOUnit = myInventoryItemsService.getSOUnits("", myInventoryScreen.myInventory.ClassID, myInventoryScreen.myInventory.StkUnit)[0].FromUnit;//pick first entry
            myInventoryScreen.myInventory.InvtAcct = myInventoryItemsService.getAccountsByID("")[0].Acct;//pick first entry
            myInventoryScreen.myInventory.InvtSub = myInventoryItemsService.getSubAccountsByID("")[0].Sub;//pick first entry
            myInventoryScreen.myInventory.COGSAcct = myInventoryItemsService.getAccountsByID("")[0].Acct;//pick first entry
            myInventoryScreen.myInventory.COGSSub = myInventoryItemsService.getSubAccountsByID("")[0].Sub;//pick first entry
            myInventoryScreen.myInventory.DfltSalesAcct = myInventoryItemsService.getAccountsByID("")[0].Acct;//pick first entry
            myInventoryScreen.myInventory.DfltSalesSub = myInventoryItemsService.getSubAccountsByID("")[0].Sub;//pick first entry
            myInventoryScreen.myInventory.PPVAcct = myInventoryItemsService.getAccountsByID("")[0].Acct;//pick first entry
            myInventoryScreen.myInventory.PPVSub = myInventoryItemsService.getSubAccountsByID("")[0].Sub;//pick first entry
            myInventoryScreen.myInventory.LCVarianceAcct = myInventoryItemsService.getAccountsByID("")[0].Acct;//pick first entry
            myInventoryScreen.myInventory.LCVarianceSub = myInventoryItemsService.getSubAccountsByID("")[0].Sub;//pick first entry

            myInventoryScreen.myINDfltSites.DfltSiteID = myInventoryItemsService.getSitesByID("")[0].SiteId;//pick first entry
            myInventoryScreen.myINDfltSites.DfltPutAwayBin = myInventoryItemsService.getBinsByID(myInventoryScreen.myINDfltSites.DfltSiteID,"")[0].WhseLoc;//pick first entry
            myInventoryScreen.myINDfltSites.DfltPickBin = myInventoryItemsService.getBinsByID(myInventoryScreen.myINDfltSites.DfltSiteID,"")[0].WhseLoc;//pick first entry
            /*end setting required fields*/

            try
            {
                ctDynamicsSL.inventory.inventory.maintenance.inventoryItems.Snote myInventoryNote = new ctDynamicsSL.inventory.inventory.maintenance.inventoryItems.Snote();
                myInventoryNote.sNoteText = "My test inventory note";
                myInventoryScreen.inventoryNote = myInventoryNote;
            }
            catch { }
            try
            {
                ctDynamicsSL.inventory.inventory.maintenance.inventoryItems.Snote myInventoryADGNote = new ctDynamicsSL.inventory.inventory.maintenance.inventoryItems.Snote();
                myInventoryADGNote.sNoteText = "My test inventoryADG note";
                myInventoryScreen.inventoryADGNote = myInventoryADGNote;
            }
            catch { }

            try
            {
                ctDynamicsSL.inventory.inventory.maintenance.inventoryItems.Snote myINDfltSitesNote = new ctDynamicsSL.inventory.inventory.maintenance.inventoryItems.Snote();
                myINDfltSitesNote.sNoteText = "My test INDfltSites note";
                myInventoryScreen.INDfltSitesNote = myINDfltSitesNote;
            }
            catch { }

            myInventoryScreen.errorMessage = "";
            try
            {
                ctDynamicsSL.inventory.inventory.maintenance.inventoryItems.screen validateScreen = myInventoryItemsService.editScreen("VALIDATEONLY", myInventoryScreen);
                if (validateScreen.errorMessage != "")
                {
                    MessageBox.Show("Error: " + validateScreen.errorMessage);
                    return;
                }
            }
            catch { }

            myInventoryScreen = myInventoryItemsService.editScreen("ADD", myInventoryScreen);
            if (myInventoryScreen.errorMessage != "")
            {
                btnUpdate.Enabled = false;
                tbInvtID.Text = "";
                tbScreen.Text = ctStandardLib.ctHelper.serializeObject(myInventoryScreen).Replace("><", ">" + Environment.NewLine + "<");
                MessageBox.Show("Error: " + myInventoryScreen.errorMessage);
                return;
            }
            else
            {
                tbInvtID.Text = myInventoryScreen.myInventory.InvtID;
                btnLoad.PerformClick();
            }
        }
    }
}

