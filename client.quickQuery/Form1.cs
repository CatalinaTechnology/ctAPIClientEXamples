using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace client.ctDynamicsSL.quickQuery
{
    public partial class Form1 : Form
    {
        //Used to store an instance of the ctDynamicsSL.quickQuery webservice, do not call directly
        private ctDynamicsSL.quickQuery.quickQuery myQQObjValue = null;
		
		//Used to hold an instance of a quick query screen 
        private ctDynamicsSL.quickQuery.screen myScreen = null;

        public Form1()
        {
            InitializeComponent();
        }


        private void btnGetQuery_Click(object sender, EventArgs e)
        {
            if (tbQueryViewName.Text.Trim() == "")
            {
                MessageBox.Show("You must select a query view!");
                myScreen = null;
                return;
            }

            System.Collections.Generic.List<ctDynamicsSL.quickQuery.queryFilter> queryFilters = new System.Collections.Generic.List<ctDynamicsSL.quickQuery.queryFilter>();
            for(System.Int32 i=0; i<dgvFilters.Rows.Count; i++)
            {
                String tmpName = "";
                try
                {   //query view column to compare against
                    tmpName = dgvFilters.Rows[i].Cells["name"].Value.ToString().Trim();
                }
                catch { }
                if (tmpName != "")
                {
                    String tmpValue = "";
                    try
                    {   //value to compare against, for IN OR NOT IN, just comma deliminate
                        tmpValue = dgvFilters.Rows[i].Cells["value"].Value.ToString().Trim();
                    }
                    catch { }
                    String tmpComparisonType = "";
                    try
                    {
                        //any valid sql comparison operator (=,LIKE, <,>, IN, NOT IN)
                        tmpComparisonType = dgvFilters.Rows[i].Cells["comparisonType"].Value.ToString().Trim();
                    }
                    catch { }
                    var outFilter = new ctDynamicsSL.quickQuery.queryFilter();
                    outFilter.name = tmpName;
                    outFilter.value = tmpValue;
                    outFilter.comparisonType = tmpComparisonType;
                    queryFilters.Add(outFilter);
                }
            }
            myScreen = myQQObj.getScreen(tbQueryViewName.Text, queryFilters.ToArray());
            if (myScreen.errorMessage.Trim() != "")
            {
                MessageBox.Show(myScreen.errorMessage);
                tbScreen.Text = ctStandardLib.ctHelper.serializeObject(myScreen).Replace("><", ">" + System.Environment.NewLine + "<");
                myScreen = null;
                return;
            }
            else
            {
                dgvQueryResults.DataSource = myScreen.myQueryResults.Tables[0];
                tbScreen.Text = ctStandardLib.ctHelper.serializeObject(myScreen).Replace("><", ">" + System.Environment.NewLine + "<");
            }
        }
		
        //Used to reference an instance of the ctDynamicsSL.quickQuery web service.
        public ctDynamicsSL.quickQuery.quickQuery myQQObj
        {
            //used for access to the webservice.  automatically creates the object if necessary
            get
            {
                if (myQQObjValue == null)
                {
                    //if we get here, then the object is not created
                    ctDynamicsSL.quickQuery.ctDynamicsSLHeader Header = new ctDynamicsSL.quickQuery.ctDynamicsSLHeader();

                    //Set all standard CTAPI Header values, for example purposes we are pulling these values from the app.config
                    Header.siteID = System.Configuration.ConfigurationManager.AppSettings["SITEID"];
                    Header.cpnyID = System.Configuration.ConfigurationManager.AppSettings["CPNYID"];
                    Header.licenseKey = System.Configuration.ConfigurationManager.AppSettings["LICENSEKEY"];
                    Header.licenseName = System.Configuration.ConfigurationManager.AppSettings["LICENSENAME"];
                    Header.licenseExpiration = System.Configuration.ConfigurationManager.AppSettings["LICENSEEXPIRATION"];
                    Header.siteKey = System.Configuration.ConfigurationManager.AppSettings["SITEKEY"];
                    Header.softwareName = "CTAPI";
                    myQQObjValue = new ctDynamicsSL.quickQuery.quickQuery();
                    myQQObjValue.ctDynamicsSLHeaderValue = Header;
                    myQQObjValue.Timeout = System.Threading.Timeout.Infinite;
                }
                return myQQObjValue;
            }
            set
            {
                myQQObjValue = value;
            }
        }
		
        private void btnSearch_Click(object sender, EventArgs e)
        {
            var newPopup = new queryViewsPopup(this);
            newPopup.ShowDialog();
        }

    }
}
