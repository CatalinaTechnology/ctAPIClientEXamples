using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace client.inventoryReceipts
{
    public partial class batchesPopup : Form
    {
        private client.inventoryReceipts.Form1 parentForm = null;

        public batchesPopup(client.inventoryReceipts.Form1 inParentForm, String inBatNbr)
        {
            InitializeComponent();
            parentForm = inParentForm;
            this.gvBatches.DataSource = parentForm.myIRService.getBatchesByBatNbr(inBatNbr);
        }

        private void gvBatches_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            String batNbr = "";
            try
            {
                batNbr = gvBatches.Rows[e.RowIndex].Cells["BATNBR"].Value.ToString();
            }
            catch { }
            if (batNbr != "")
            {
                parentForm.tbBatNbr.Text = batNbr;
                parentForm.btnLoad.PerformClick();
            }
            this.Close();
        }

    }
}
