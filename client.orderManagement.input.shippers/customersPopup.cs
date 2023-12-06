using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace client.orderManagement.input.shippers
{
    public partial class customersPopup : Form
    {
        private client.orderManagement.input.shippers.Form1 parentForm = null;

        public customersPopup(client.orderManagement.input.shippers.Form1 inParentForm, String inBatNbr)
        {
            InitializeComponent();
            parentForm = inParentForm;

            //customersParams: CUSTID|value;NAME|value;BILLADDR1|value;BILLCITY|value;BILLSTATE|value;BILLZIP|value;PHONE|value;STATUS|value;
            System.Data.DataSet dsCustomers = parentForm.myCustomersService.getCustomers("SEARCH", "1", "100", "CUSTID|" + parentForm.tbCustID.Text.Trim() + ";", "custID");
            this.gvCustomers.AutoGenerateColumns = true;
            this.gvCustomers.DataSource = dsCustomers.Tables[0];

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
