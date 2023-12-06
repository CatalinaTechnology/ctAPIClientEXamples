using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace client.orders
{
    public partial class ordersPopup : Form
    {
        private client.orders.Form1 parentForm = null;

        public ordersPopup(client.orders.Form1 inParentForm, String inBatNbr)
        {
            InitializeComponent();
            parentForm = inParentForm;
            //ordersParams:  ORDNBR|value;CUSTID|value;STATUS|value;BEGINDATE|value;ENDDATE|value;
            System.Data.DataSet dsOrders = parentForm.myOrdersService.getOrders("SEARCH", "1", "100", "ORDNBR|" + parentForm.tbOrdNbr.Text.Trim()+";", "ordNbr");
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
            if (ordNbr != "")
            {
                parentForm.tbOrdNbr.Text = ordNbr;
                parentForm.btnLoad.PerformClick();
            }
            this.Close();
        }
    }
}
