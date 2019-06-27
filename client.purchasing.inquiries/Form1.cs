using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace client.purchasing.inquiries
{
    public partial class Form1 : Form
    {
        private ctDynamicsSL.purchasing.inquiries.itemVendorHistory.itemVendorHistory myItemVendorHistoryServiceValue = null;
        private ctDynamicsSL.purchasing.inquiries.poReceiptsInquiry.poReceiptsInquiry myPOReceiptsInquiryServiceValue = null;

        public ctDynamicsSL.purchasing.inquiries.poReceiptsInquiry.poReceiptsInquiry myPOReceiptsInquiryService
        {
            //used for access to the webservice.  automatically creates the object if necessary
            get
            {
                if (myPOReceiptsInquiryServiceValue == null)
                {
                    //if we get here, then the object is not created
                    ctDynamicsSL.purchasing.inquiries.poReceiptsInquiry.ctDynamicsSLHeader Header = new ctDynamicsSL.purchasing.inquiries.poReceiptsInquiry.ctDynamicsSLHeader();
                    Header.siteID = System.Configuration.ConfigurationManager.AppSettings["SITEID"];
                    Header.cpnyID = System.Configuration.ConfigurationManager.AppSettings["CPNYID"];
                    Header.licenseKey = System.Configuration.ConfigurationManager.AppSettings["LICENSEKEY"];
                    Header.licenseName = System.Configuration.ConfigurationManager.AppSettings["LICENSENAME"];
                    Header.licenseExpiration = System.Configuration.ConfigurationManager.AppSettings["LICENSEEXPIRATION"];
                    Header.siteKey = System.Configuration.ConfigurationManager.AppSettings["SITEKEY"];
                    Header.softwareName = "CTAPI";
                    myPOReceiptsInquiryServiceValue = new ctDynamicsSL.purchasing.inquiries.poReceiptsInquiry.poReceiptsInquiry();
                    myPOReceiptsInquiryServiceValue.ctDynamicsSLHeaderValue = Header;
                    myPOReceiptsInquiryServiceValue.Timeout = 300000;
                }
                return myPOReceiptsInquiryServiceValue;
            }
            set
            {
                myPOReceiptsInquiryServiceValue = value;
            }
        }

        public ctDynamicsSL.purchasing.inquiries.itemVendorHistory.itemVendorHistory myItemVendorHistoryService
        {
            //used for access to the webservice.  automatically creates the object if necessary
            get
            {
                if (myItemVendorHistoryServiceValue == null)
                {
                    //if we get here, then the object is not created
                    ctDynamicsSL.purchasing.inquiries.itemVendorHistory.ctDynamicsSLHeader Header = new ctDynamicsSL.purchasing.inquiries.itemVendorHistory.ctDynamicsSLHeader();
                    Header.siteID = System.Configuration.ConfigurationManager.AppSettings["SITEID"];
                    Header.cpnyID = System.Configuration.ConfigurationManager.AppSettings["CPNYID"];
                    Header.licenseKey = System.Configuration.ConfigurationManager.AppSettings["LICENSEKEY"];
                    Header.licenseName = System.Configuration.ConfigurationManager.AppSettings["LICENSENAME"];
                    Header.licenseExpiration = System.Configuration.ConfigurationManager.AppSettings["LICENSEEXPIRATION"];
                    Header.siteKey = System.Configuration.ConfigurationManager.AppSettings["SITEKEY"];
                    Header.softwareName = "CTAPI";
                    myItemVendorHistoryServiceValue = new ctDynamicsSL.purchasing.inquiries.itemVendorHistory.itemVendorHistory();
                    myItemVendorHistoryServiceValue.ctDynamicsSLHeaderValue = Header;
                    myItemVendorHistoryServiceValue.Timeout = 300000;
                }
                return myItemVendorHistoryServiceValue;
            }
            set
            {
                myItemVendorHistoryServiceValue = value;
            }
        }


        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            tbOutput.Text = "";
            var invtID = myItemVendorHistoryService.getInventoryByID("", false)[0].InvtID;
            var vendID = myItemVendorHistoryService.getVendorsByID(invtID, "")[0].VendId;
            var siteID = myItemVendorHistoryService.getSitesByID("", invtID, vendID, false)[0].SiteId;
            var alternateID = "";
            try
            {
                alternateID = myItemVendorHistoryService.getVendItemAlternateIDsByID("", siteID, invtID, vendID)[0].AlternateID;
            }
            catch { }
            var fiscYr = myItemVendorHistoryService.getVendItemFiscYrsByID("", siteID, invtID, vendID, alternateID)[0].FiscYr;

            var myScreen = myItemVendorHistoryService.getScreen(invtID, vendID, alternateID, siteID, fiscYr);

            if (myScreen.errorMessage != "")
            {
                MessageBox.Show(myScreen.errorMessage);
                return;
            }
            else
            {
                MessageBox.Show(ctStandardLib.ctHelper.serializeObject(myScreen));
                tbOutput.Text = ctStandardLib.ctHelper.serializeObject(myScreen);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            tbOutput.Text = "";            
            var myScreen = this.myPOReceiptsInquiryService.getScreenByPoNbr(tbPONbr.Text);

            if (myScreen.errorMessage != "")
            {
                MessageBox.Show(myScreen.errorMessage);
                return;
            }
            else
            {
                MessageBox.Show(ctStandardLib.ctHelper.serializeObject(myScreen));
                tbOutput.Text = ctStandardLib.ctHelper.serializeObject(myScreen);
            }
        }
    }
}
