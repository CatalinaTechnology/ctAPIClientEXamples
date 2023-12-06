using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace client.projectInvoiceAndAdjustmentMaintenance
{
    public partial class invoicesPopup : Form
    {
        private client.projectInvoiceAndAdjustmentMaintenance.Form1 parentForm = null;

        public invoicesPopup(client.projectInvoiceAndAdjustmentMaintenance.Form1 inParentForm)
        {
            InitializeComponent();
            parentForm = inParentForm;

            ctDynamicsSL.project.flexibleBillings.input.projectInvoiceAndAdjustmentMaintenance.PJINVHDR[] myInvoices = parentForm.myIAMService.getDraftNumbersByProject(parentForm.tbProjectID.Text.Trim(), parentForm.tbDraftNum.Text.Trim());
            this.gvInvoices.AutoGenerateColumns = true;
            this.gvInvoices.DataSource = myInvoices;
        }

        private void gvInvoices_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            String draft_num = "";
            try
            {
                draft_num = gvInvoices.Rows[e.RowIndex].Cells["DRAFT_NUM"].Value.ToString();
            }
            catch { }

            if (draft_num != "")
            {
                parentForm.tbDraftNum.Text = draft_num;

                parentForm.btnLoad.PerformClick();
            }
            this.Close();
        }
    }
}
