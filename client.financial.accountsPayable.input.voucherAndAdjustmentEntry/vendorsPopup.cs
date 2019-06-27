using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace client.financial.accountsPayable.input.voucherAndAdjustmentEntry
{
    public partial class vendorsPopup : Form
    {
        private client.financial.accountsPayable.input.voucherAndAdjustmentEntry.Form1 parentForm = null;

        public vendorsPopup(client.financial.accountsPayable.input.voucherAndAdjustmentEntry.Form1 inParentForm, String inVendID)
        {
            InitializeComponent();
            parentForm = inParentForm;
            this.gvVendIDs.DataSource = parentForm.myVAObj.getVendorsByID(inVendID);
        }

        private void gvVendIDs_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            String vendID = "";
            try
            {
                vendID = gvVendIDs.Rows[e.RowIndex].Cells["VENDID"].Value.ToString();
            }
            catch { }
            if (vendID != "")
            {
                parentForm.tbVendID.Text = vendID;
            }
            this.Close();
        }
    }
}
