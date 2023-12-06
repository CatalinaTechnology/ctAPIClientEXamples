using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace client.orderManagement.input.manifestEntry
{
    public partial class shippersPopup : Form
    {
        private client.orderManagement.input.manifestEntry.Form1 parentForm = null;

        public shippersPopup(client.orderManagement.input.manifestEntry.Form1 inParentForm, String inShipperID)
        {
            InitializeComponent();
            parentForm = inParentForm;

            ctDynamicsSL.orderManagement.input.manifestEntry.SOShipHeader[] myShippers = parentForm.myMEService.getSOShipHeaders(inShipperID);
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
            if (shipperID != "")
            {
                parentForm.tbShipperID.Text = shipperID;
                parentForm.btnLoad.PerformClick();
            }
            this.Close();
        }
    }
}
