using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace client.inventoryReceipts
{
    public partial class Form1 : Form
    {
        private ctDynamicsSL.inventoryReceipts.inventoryReceipts myIRServiceValue = null;

        //hold reference to the batch we are working with.
        public ctDynamicsSL.inventoryReceipts.screen myScreen = null;

        public Form1()
        {
            InitializeComponent();
            System.Net.ServicePointManager.ServerCertificateValidationCallback = new System.Net.Security.RemoteCertificateValidationCallback(doApproveCertificate);
            System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls12 | System.Net.SecurityProtocolType.Tls11 | System.Net.SecurityProtocolType.Tls;

        }

        //loads an existing batch from SL
        private void btnLoad_Click(object sender, EventArgs e)
        {
            gvINTran.DataSource = null;

            myScreen = myIRService.getScreenByBatNbr(tbBatNbr.Text);
            if (myScreen.errorMessage != "")
            {
                MessageBox.Show("Error: " + myScreen.errorMessage);
                return;
            }
            btnUpdate.Enabled = true;
            tbScreen.Text = ctStandardLib.ctHelper.serializeObject(myScreen).Replace("><", ">" + Environment.NewLine + "<");
            gvINTran.DataSource = myScreen.myINTran;

            populateGVLotSerTs(myScreen.myINTran);
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
            myScreen.myINTran = (ctDynamicsSL.inventoryReceipts.INTran[])gvINTran.DataSource;

            {
                var validate = myIRService.editScreen("VALIDATEONLY", myScreen);
                if (!String.IsNullOrWhiteSpace(validate.errorMessage))
                {
                    MessageBox.Show("Error in validating Screen: " + validate.errorMessage);
                    return;
                }
            }

            myScreen = myIRService.editScreen("UPDATE", myScreen);
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
            myScreen = myIRService.getNewscreen(null);
            myScreen.myBatch.CpnyID = System.Configuration.ConfigurationManager.AppSettings["CPNYID"];
            System.Collections.Generic.List<ctDynamicsSL.inventoryReceipts.INTran> INTranList = new List<ctDynamicsSL.inventoryReceipts.INTran>();
            for (System.Int16 i = 0; i < 5; i++)
            {
                ctDynamicsSL.inventoryReceipts.INTran tmpLine = new ctDynamicsSL.inventoryReceipts.INTran();
                tmpLine.CpnyID = myScreen.myBatch.CpnyID;
                tmpLine.InvtID = myIRService.getInventoryByID("")[i].InvtID;//selecting first for example
                tmpLine.Qty = 2;
                tmpLine = myIRService.getNewINTran(tmpLine);
                tmpLine.RefNbr = System.Guid.NewGuid().ToString().Substring(0, 6);


                {
                    var validate = myIRService.editINTran("VALIDATEONLY", tmpLine);
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
                var validate = myIRService.editScreen("VALIDATEONLY", myScreen);
                if (!String.IsNullOrWhiteSpace(validate.errorMessage))
                {
                    MessageBox.Show("Error in validating Screen: " + validate.errorMessage);
                    return;
                }
            }

            myScreen = myIRService.editScreen("ADD", myScreen);

            if (myScreen.errorMessage != "")
            {
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
            try { MessageBox.Show("getLotSerials: " + ctStandardLib.ctHelper.serializeObject(myIRService.getLotSerials("TEST", "TEST", "TEST", "TEST"))); } catch { }
            try { MessageBox.Show("about: " + ctStandardLib.ctHelper.serializeObject(myIRService.about())); } catch { }
            try { MessageBox.Show("getSiteIDs: " + ctStandardLib.ctHelper.serializeObject(myIRService.getSiteIDs("TEST", "TEST"))); } catch { }
            try { MessageBox.Show("getReasonCodesByID: " + ctStandardLib.ctHelper.serializeObject(myIRService.getReasonCodesByID("TEST"))); } catch { }
            try { MessageBox.Show("getInventoryByID: " + ctStandardLib.ctHelper.serializeObject(myIRService.getInventoryByID("TEST"))); } catch { }
            try { MessageBox.Show("getScreenByBatNbr: " + ctStandardLib.ctHelper.serializeObject(myIRService.getScreenByBatNbr("TEST"))); } catch { }
            try { MessageBox.Show("getBatchesByBatNbr: " + ctStandardLib.ctHelper.serializeObject(myIRService.getBatchesByBatNbr("TEST"))); } catch { }
            //try { MessageBox.Show("getNewSnote: " + ctStandardLib.ctHelper.serializeObject(myIRService.getNewSnote(null))); } catch { }
            try { MessageBox.Show("getNewscreen: " + ctStandardLib.ctHelper.serializeObject(myIRService.getNewscreen(null))); } catch { }
            try { MessageBox.Show("getNewINTran: " + ctStandardLib.ctHelper.serializeObject(myIRService.getNewINTran(null))); } catch { }
            try { MessageBox.Show("getNewBatch: " + ctStandardLib.ctHelper.serializeObject(myIRService.getNewBatch(null))); } catch { }
        }

        public ctDynamicsSL.inventoryReceipts.inventoryReceipts myIRService
        {
            //used for access to the webservice.  automatically creates the object if necessary
            get
            {
                if (myIRServiceValue == null)
                {
                    //if we get here, then the object is not created
                    ctDynamicsSL.inventoryReceipts.ctDynamicsSLHeader Header = new ctDynamicsSL.inventoryReceipts.ctDynamicsSLHeader();
                    Header.siteID = System.Configuration.ConfigurationManager.AppSettings["SITEID"];
                    Header.cpnyID = System.Configuration.ConfigurationManager.AppSettings["CPNYID"];
                    Header.licenseKey = System.Configuration.ConfigurationManager.AppSettings["LICENSEKEY"];
                    Header.licenseName = System.Configuration.ConfigurationManager.AppSettings["LICENSENAME"];
                    Header.licenseExpiration = System.Configuration.ConfigurationManager.AppSettings["LICENSEEXPIRATION"];
                    Header.siteKey = System.Configuration.ConfigurationManager.AppSettings["SITEKEY"];
                    Header.softwareName = System.Configuration.ConfigurationManager.AppSettings["SOFTWARENAME"];
                    myIRServiceValue = new ctDynamicsSL.inventoryReceipts.inventoryReceipts();
                    myIRServiceValue.ctDynamicsSLHeaderValue = Header;
                    myIRServiceValue.Timeout = 300000;
                }
                return myIRServiceValue;
            }
            set
            {
                myIRServiceValue = value;
            }
        }



        //Used to search for invventory itemss to add to a batch
        private void btnGetInventory_Click(object sender, EventArgs e)
        {
            /*poppup window to search for invtDs, after selecting it is added to an existing batch*/
            if (myScreen == null)
            {
                MessageBox.Show("You must load a batch first.");
            }
            else
            {
                inventoryPopup newPopup = new inventoryPopup(this, tbInvtID.Text);
                try { newPopup.ShowDialog(); } catch { }
            }
        }

        //Addss a new INTran entry to a batch
        public void addInventoryToBatch(ctDynamicsSL.inventoryReceipts.Inventory inItem)
        {
            //add a new INTran record to the batch
            var newINTran = new ctDynamicsSL.inventoryReceipts.INTran();
            newINTran.CpnyID = myScreen.myBatch.CpnyID;
            newINTran.InvtID = inItem.InvtID;
            newINTran = myIRService.getNewINTran(newINTran);
            newINTran.Qty = 5;
            newINTran.RefNbr = System.Guid.NewGuid().ToString().Substring(0, 4); //refnbr required

            var tmpINTrans = new System.Collections.Generic.List<ctDynamicsSL.inventoryReceipts.INTran>();
            tmpINTrans.AddRange((ctDynamicsSL.inventoryReceipts.INTran[])gvINTran.DataSource);

            tmpINTrans.Add(newINTran);
            gvINTran.DataSource = tmpINTrans.ToArray();
            //MessageBox.Show(ctStandardLib.ctHelper.serializeObject(newINTran));
        }


        //REturns an INTran record from the datagridview for INTran lines in the batch
        public ctDynamicsSL.inventoryReceipts.INTran getINTranByRecordID(System.Int32 inRecordID)
        {
            ///find our record in the intrans list
            var tmpALLINTrans = new System.Collections.Generic.List<ctDynamicsSL.inventoryReceipts.INTran>();
            tmpALLINTrans.AddRange((ctDynamicsSL.inventoryReceipts.INTran[])gvINTran.DataSource);
            var myINTran =
                (
                    from r in tmpALLINTrans
                    where r.RecordID == inRecordID
                    select r
                   ).First();

            if (myINTran == null)
            {
                throw new Exception("RecordID not found!");
            }
            return myINTran;
        }

        //This is used to populate the datagrid view of All the LotSert entries in a batch
        public void populateGVLotSerTs(ctDynamicsSL.inventoryReceipts.INTran[] myINTran)
        {
        }

        //Button action to release a batch,  setup to automatically load the batch first
        private void btnRelease_Click(object sender, EventArgs e)
        {
            myScreen = myIRService.getScreenByBatNbr(tbBatNbr.Text);
            if (myScreen.errorMessage != "")
            {
                MessageBox.Show("Error: " + myScreen.errorMessage);
                return;
            }
            else
            {
                myScreen = myIRService.editScreen("RELEASENOW", myScreen);
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

        public bool doApproveCertificate(object sender, System.Security.Cryptography.X509Certificates.X509Certificate c, System.Security.Cryptography.X509Certificates.X509Chain chain, System.Net.Security.SslPolicyErrors sllPolicyErrors)
        {
            return true;
        }

    }
}