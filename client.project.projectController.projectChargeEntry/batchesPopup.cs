using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace client.project.projectController.projectChargeEntry
{
    public partial class batchesPopup : Form
    {
        private client.project.projectController.projectChargeEntry.Form1 parentForm = null;

        public batchesPopup(client.project.projectController.projectChargeEntry.Form1 inParentForm, String inBatNbr)
        {
            InitializeComponent();
            parentForm = inParentForm;
            this.gvBatches.DataSource = parentForm.myPCEObj.getProjectsByBatNbr(parentForm.tbBatch_id.Text.Trim());
        }

        private void gvBatches_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            String batch_id = "";
            try
            {
                batch_id = gvBatches.Rows[e.RowIndex].Cells["BATCH_ID"].Value.ToString();
            }
            catch { }
            if (batch_id != "")
            {
                parentForm.tbBatch_id.Text = batch_id;
                parentForm.btnLoad.PerformClick();
            }
            this.Close();
        }
    }
}
