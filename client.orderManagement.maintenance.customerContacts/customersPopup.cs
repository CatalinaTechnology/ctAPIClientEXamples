using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace client.orderManagement.maintenance.customerContacts
{
    public partial class customersPopup : Form
    {
        private client.orderManagement.maintenance.customerContacts.Form1 parentForm = null;

        public customersPopup(client.orderManagement.maintenance.customerContacts.Form1 inParentForm, String inBatNbr)
        {
            InitializeComponent();
            parentForm = inParentForm;

            ctDynamicsSL.financial.accountsReceivable.maintenance.customerMaintenance.CustomerV2[] myCustomers = null;
            myCustomers = parentForm.myCustomersService.getCustomersByID(parentForm.tbCustID.Text.Trim());

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
