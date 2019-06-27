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
    public partial class apDocsPopup : Form
    {
        private client.financial.accountsPayable.input.voucherAndAdjustmentEntry.Form1 parentForm = null;
        private ctDynamicsSL.financial.accountsPayable.input.voucherAndAdjustmentEntry.APDoc[] myAPDocs = null;
        public apDocsPopup(client.financial.accountsPayable.input.voucherAndAdjustmentEntry.Form1 inParentForm, String inRefNbr)
        {
            InitializeComponent();
            parentForm = inParentForm;
            myAPDocs = parentForm.myVAObj.getAPDocsByBatNbrAndRefNbr(parentForm.tbBatNbr.Text, inRefNbr);
            this.gvapDocs.DataSource = myAPDocs;
        }

        private void gvapDocs_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            String refNbr = "";
            try
            {
                refNbr = gvapDocs.Rows[e.RowIndex].Cells["REFNBR"].Value.ToString();
            }
            catch { }
            parentForm.tbRefNbr.Text = refNbr;

            String vendID = "";
            try
            {
                vendID = gvapDocs.Rows[e.RowIndex].Cells["VENDID"].Value.ToString();
            }
            catch { }
            parentForm.tbVendID.Text = vendID;

            if (refNbr != "")
            {
                parentForm.myScreen.myAPDoc = parentForm.myVAObj.getAPDocsByBatNbrAndRefNbr(parentForm.tbBatNbr.Text, refNbr)[0];
                parentForm.loadAPTrans();
            }
            this.Close();
        }
    }
}
