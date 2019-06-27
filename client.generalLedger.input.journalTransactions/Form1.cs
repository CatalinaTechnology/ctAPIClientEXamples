using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace client.generalLedger.input.journalTransactions
{
    public partial class Form1 : Form
    {
        private ctDynamicsSL.financial.generalLedger.input.journalTransactions.journalTransactions myJTObjValue = null;
        public ctDynamicsSL.financial.generalLedger.input.journalTransactions.screen myScreen = null;

        public Form1()
        {
            InitializeComponent();
        }

        public ctDynamicsSL.financial.generalLedger.input.journalTransactions.journalTransactions myJTObj
        {
            //used for access to the webservice.  automatically creates the object if necessary
            get
            {
                if (myJTObjValue == null)
                {
                    //if we get here, then the object is not created
                    ctDynamicsSL.financial.generalLedger.input.journalTransactions.ctDynamicsSLHeader Header = new ctDynamicsSL.financial.generalLedger.input.journalTransactions.ctDynamicsSLHeader();
                    Header.siteID = System.Configuration.ConfigurationManager.AppSettings["SITEID"];
                    Header.cpnyID = System.Configuration.ConfigurationManager.AppSettings["CPNYID"];
                    Header.licenseKey = System.Configuration.ConfigurationManager.AppSettings["LICENSEKEY"];
                    Header.licenseName = System.Configuration.ConfigurationManager.AppSettings["LICENSENAME"];
                    Header.licenseExpiration = System.Configuration.ConfigurationManager.AppSettings["LICENSEEXPIRATION"];
                    Header.siteKey = System.Configuration.ConfigurationManager.AppSettings["SITEKEY"];
                    Header.softwareName = "CTAPI";
                    myJTObjValue = new ctDynamicsSL.financial.generalLedger.input.journalTransactions.journalTransactions();
                    myJTObjValue.ctDynamicsSLHeaderValue = Header;
                    myJTObjValue.Timeout = 300000;
                }
                return myJTObjValue;
            }
            set
            {
                myJTObjValue = value;
            }
        }

        //Button action to release a batch,  setup to automatically load the batch first
        private void btnRelease_Click(object sender, EventArgs e)
        {
            myScreen = myJTObj.getScreenByBatNbr(tbBatNbr.Text);
            if (myScreen.errorMessage != "")
            {
                MessageBox.Show("Error: " + myScreen.errorMessage);
                return;
            }
            else
            {
                myScreen = myJTObj.editScreen("RELEASENOW", myScreen);
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
            myScreen = myJTObj.getScreenByBatNbr(tbBatNbr.Text);
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
            gvGLTran.DataSource = myScreen.myGLTran;
        }

        //Used to save a batch that has been loaded
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (myScreen == null)
            {
                MessageBox.Show("You must load a batch first!");
                return;
            }

            MessageBox.Show(ctStandardLib.ctHelper.serializeObject(myScreen).Replace("><", ">" + Environment.NewLine + "<"));
            myScreen = myJTObj.editScreen("UPDATE", myScreen);
            if (myScreen.errorMessage != "")
            {
                MessageBox.Show("Error: " + myScreen.errorMessage);
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
            myScreen = myJTObj.getNewscreen(null);
            myScreen = myJTObj.editScreen("ADD", myScreen);
            if (myScreen.errorMessage != "")
            {
                btnRelease.Enabled = false;
                btnUpdate.Enabled = false;
                tbBatNbr.Text = "";
                gvGLTran.DataSource = null;
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
    }
}

