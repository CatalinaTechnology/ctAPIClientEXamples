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
    public partial class ordersPopup : Form
    {
        private client.orderManagement.input.shippers.Form1 parentForm = null;

        public ordersPopup(client.orderManagement.input.shippers.Form1 inParentForm, String inOrdNbr)
        {
            InitializeComponent();
            parentForm = inParentForm;
            //ordersParams:  ORDNBR|value;CUSTID|value;STATUS|value;BEGINDATE|value;ENDDATE|value;
            System.Data.DataSet dsOrders = parentForm.myOrdersService.getOrders("SEARCH", "1", "100", "ORDNBR|" + parentForm.tbOrdNbr.Text.Trim() + ";" + "CUSTID|" + parentForm.tbCustID.Text.Trim() + ";", "ordNbr");
            this.gvOrders.AutoGenerateColumns = true;
            this.gvOrders.DataSource = dsOrders.Tables[0];
        }

        private void gvOrders_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            String ordNbr = "";
            try
            {
                ordNbr = gvOrders.Rows[e.RowIndex].Cells["ORDNBR"].Value.ToString();
            }
            catch { }
            String custID = "";
            try
            {
                custID = gvOrders.Rows[e.RowIndex].Cells["CUSTID"].Value.ToString();
            }
            catch { }
            String custOrdNbr = "";
            try
            {
                custOrdNbr = gvOrders.Rows[e.RowIndex].Cells["CUSTORDNBR"].Value.ToString();
            }
            catch { }

            if (ordNbr != "")
            {
                parentForm.tbOrdNbr.Text = ordNbr;
                parentForm.tbCustID.Text = custID;
                parentForm.tbCustOrdNbr.Text = custOrdNbr;
                parentForm.btnLoad.PerformClick();
            }
            this.Close();
        }
    }
}
