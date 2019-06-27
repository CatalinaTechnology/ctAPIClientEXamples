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
    public partial class shippersPopup : Form
    {
        private client.orderManagement.input.shippers.Form1 parentForm = null;

        public shippersPopup(client.orderManagement.input.shippers.Form1 inParentForm, String inShipperID)
        {
            InitializeComponent();
            parentForm = inParentForm;

            ctDynamicsSL.orderManagement.input.shippers.SOShipHeader[] myShippers = parentForm.myShippersService.getSOShipHeaders(inShipperID);
            this.gvShippers.AutoGenerateColumns = true;
            this.gvShippers.DataSource = myShippers;
        }

        private void gvShippers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            String shipperID = "";
            try
            {
                shipperID = gvShippers.Rows[e.RowIndex].Cells["SHIPPERID"].Value.ToString();
            }
            catch { }
            String custID = "";
            try
            {
                custID = gvShippers.Rows[e.RowIndex].Cells["CUSTID"].Value.ToString();
            }
            catch { }
            String ordNbr = "";
            try
            {
                ordNbr = gvShippers.Rows[e.RowIndex].Cells["ORDNBR"].Value.ToString();
            }
            catch { }
            String custOrdNbr = "";
            try
            {
                custOrdNbr = gvShippers.Rows[e.RowIndex].Cells["CUSTORDNBR"].Value.ToString();
            }
            catch { }
            String invcNbr = "";
            try
            {
                invcNbr = gvShippers.Rows[e.RowIndex].Cells["INVCNBR"].Value.ToString();
            }
            catch { }
            if (shipperID != "")
            {
                parentForm.tbShipperID.Text = shipperID;
                parentForm.tbOrdNbr.Text = ordNbr;
                parentForm.tbCustOrdNbr.Text = custOrdNbr;
                parentForm.tbCustID.Text = custID;

                parentForm.btnLoad.PerformClick();
            }
            this.Close();
        }
    }
}
