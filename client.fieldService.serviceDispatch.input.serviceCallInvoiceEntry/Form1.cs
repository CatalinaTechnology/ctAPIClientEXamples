using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace client.fieldService.serviceDispatch.input.serviceCallInvoiceEntry
{
    public partial class Form1 : Form
    {
        private ctDynamicsSL.fieldService.serviceDispatch.input.serviceCallInvoiceEntry.serviceCallInvoiceEntry mySCIEObjValue = null;
        public ctDynamicsSL.fieldService.serviceDispatch.input.serviceCallInvoiceEntry.screen myScreen = null;

        public ctDynamicsSL.fieldService.serviceDispatch.input.serviceCallInvoiceEntry.serviceCallInvoiceEntry mySCIEObj
        {
            //used for access to the webservice.  automatically creates the object if necessary
            get
            {
                if (mySCIEObjValue == null)
                {
                    //if we get here, then the object is not created
                    ctDynamicsSL.fieldService.serviceDispatch.input.serviceCallInvoiceEntry.ctDynamicsSLHeader Header = new ctDynamicsSL.fieldService.serviceDispatch.input.serviceCallInvoiceEntry.ctDynamicsSLHeader();
                    Header.siteID = System.Configuration.ConfigurationManager.AppSettings["SITEID"];
                    Header.cpnyID = System.Configuration.ConfigurationManager.AppSettings["CPNYID"];
                    Header.licenseKey = System.Configuration.ConfigurationManager.AppSettings["LICENSEKEY"];
                    Header.licenseName = System.Configuration.ConfigurationManager.AppSettings["LICENSENAME"];
                    Header.licenseExpiration = System.Configuration.ConfigurationManager.AppSettings["LICENSEEXPIRATION"];
                    Header.siteKey = System.Configuration.ConfigurationManager.AppSettings["SITEKEY"];
                    Header.softwareName = "CTAPI";
                    mySCIEObjValue = new ctDynamicsSL.fieldService.serviceDispatch.input.serviceCallInvoiceEntry.serviceCallInvoiceEntry();
                    mySCIEObjValue.ctDynamicsSLHeaderValue = Header;
                    mySCIEObjValue.Timeout = 300000;
                }
                return mySCIEObjValue;
            }
            set
            {
                mySCIEObjValue = value;
            }
        }
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            serviceCallsPopup newPopup = new serviceCallsPopup(this, tbServiceCallID.Text);
            newPopup.ShowDialog();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            myScreen = mySCIEObj.getScreenByServiceCallID(tbServiceCallID.Text);

            if (myScreen.errorMessage != "")
            {
                MessageBox.Show("Error: " + myScreen.errorMessage);
                return;
            }
            this.gvSMServDetail.DataSource = myScreen.mySMServDetail;
            this.gvSMInvoice.DataSource = myScreen.mySMInvoice;
            btnUpdate.Enabled = true;
            tbScreen.Text = ctStandardLib.ctHelper.serializeObject(myScreen).Replace("><", ">" + Environment.NewLine + "<");

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (myScreen == null)
            {
                MessageBox.Show("You must load a service call first!");
                return;
            }

            MessageBox.Show(ctStandardLib.ctHelper.serializeObject(myScreen).Replace("><", ">" + Environment.NewLine + "<"));
            myScreen = mySCIEObj.editScreen("UPDATE", myScreen);
            if (myScreen.errorMessage != "")
            {
                MessageBox.Show("Error: " + myScreen.errorMessage);
                return;
            }
            this.gvSMServDetail.DataSource = myScreen.mySMServDetail;
            this.gvSMInvoice.DataSource = myScreen.mySMInvoice;
            btnUpdate.Enabled = true;
            tbScreen.Text = ctStandardLib.ctHelper.serializeObject(myScreen).Replace("><", ">" + Environment.NewLine + "<");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (myScreen == null)
            {
                MessageBox.Show("You must load a service call first!");
                return;
            }
            if (myScreen.mySMServDetail.Length == 0)
            {
                MessageBox.Show("No Detail lines!");
                return;
            }
            for (System.Int32 i = 0; i < myScreen.mySMServDetail.Length; i++)
            {
                ctDynamicsSL.fieldService.serviceDispatch.input.serviceCallInvoiceEntry.SMServDetail tmpDetailLine = mySCIEObj.editSMServDetail("CALCULATETAX", myScreen.mySMServDetail[i]);
                if (tmpDetailLine.errorMessage.Trim() != "")
                {
                    MessageBox.Show("Error: " + tmpDetailLine.errorMessage);
                    return;
                }
                else
                {
                    myScreen.mySMServDetail[i] = tmpDetailLine;
                }
            }
            MessageBox.Show("Done Calculating Tax!");
        }

    }
}
