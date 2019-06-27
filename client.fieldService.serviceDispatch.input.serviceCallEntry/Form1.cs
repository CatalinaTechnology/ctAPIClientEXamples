using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace client.fieldService.serviceDispatch.input.serviceCallEntry
{
    public partial class Form1 : Form
    {
        private ctDynamicsSL.fieldService.serviceDispatch.input.serviceCallEntry.serviceCallEntry mySCEObjValue = null;
        public ctDynamicsSL.fieldService.serviceDispatch.input.serviceCallEntry.screen myScreen = null;

        public ctDynamicsSL.fieldService.serviceDispatch.input.serviceCallEntry.serviceCallEntry mySCEObj
        {
            //used for access to the webservice.  automatically creates the object if necessary
            get
            {
                if (mySCEObjValue == null)
                {
                    //if we get here, then the object is not created
                    ctDynamicsSL.fieldService.serviceDispatch.input.serviceCallEntry.ctDynamicsSLHeader Header = new ctDynamicsSL.fieldService.serviceDispatch.input.serviceCallEntry.ctDynamicsSLHeader();
                    Header.siteID = System.Configuration.ConfigurationManager.AppSettings["SITEID"];
                    Header.cpnyID = System.Configuration.ConfigurationManager.AppSettings["CPNYID"];
                    Header.licenseKey = System.Configuration.ConfigurationManager.AppSettings["LICENSEKEY"];
                    Header.licenseName = System.Configuration.ConfigurationManager.AppSettings["LICENSENAME"];
                    Header.licenseExpiration = System.Configuration.ConfigurationManager.AppSettings["LICENSEEXPIRATION"];
                    Header.siteKey = System.Configuration.ConfigurationManager.AppSettings["SITEKEY"];
                    Header.softwareName = "CTAPI";
                    mySCEObjValue = new ctDynamicsSL.fieldService.serviceDispatch.input.serviceCallEntry.serviceCallEntry();
                    mySCEObjValue.ctDynamicsSLHeaderValue = Header;
                    mySCEObjValue.Timeout = 300000;
                }
                return mySCEObjValue;
            }
            set
            {
                mySCEObjValue = value;
            }
        }
        public Form1()
        {
            InitializeComponent();
        }
    }
}
