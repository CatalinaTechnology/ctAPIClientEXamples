using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace client.financial.accountsReceivable.maintenance.customerMaintenance
{
    public partial class customersPopup : Form
    {
        private client.financial.accountsReceivable.maintenance.customerMaintenance.Form1 parentForm = null;

        public customersPopup(client.financial.accountsReceivable.maintenance.customerMaintenance.Form1 inParentForm, String inBatNbr)
        {
            InitializeComponent();
            parentForm = inParentForm;

            //customersParams: CUSTID|value;NAME|value;BILLADDR1|value;BILLCITY|value;BILLSTATE|value;BILLZIP|value;PHONE|value;STATUS|value;
            ctDynamicsSL.financial.accountsReceivable.maintenance.customerMaintenance.CustomerV2[] myCustomers = null;
            myCustomers = parentForm.myCMObj.getCustomersByID(parentForm.tbCustID.Text.Trim());

            this.gvCustomers.AutoGenerateColumns = true;
            this.gvCustomers.DataSource = myCustomers;

        }

        private void gvCustomers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            String custID = "";
            try
            {
                custID = gvCustomers.Rows[e.RowIndex].Cells["CUSTID"].Value.ToString();
            }
            catch { }
            if (custID != "")
            {
                parentForm.tbCustID.Text = custID;
                parentForm.btnLoad.PerformClick();
            }
            this.Close();
        }

    }
}
