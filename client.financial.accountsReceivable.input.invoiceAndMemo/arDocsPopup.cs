using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace client.financial.accountsReceivable.input.invoiceAndMemo
{
    public partial class arDocsPopup : Form
    {
        private client.financial.accountsReceivable.input.invoiceAndMemo.Form1 parentForm = null;
        private ctDynamicsSL.financial.accountsReceivable.input.invoiceAndMemo.ARDoc[] myARDocsList = null;
        public arDocsPopup(client.financial.accountsReceivable.input.invoiceAndMemo.Form1 inParentForm, String inCustID)
        {
            InitializeComponent();
            parentForm = inParentForm;
            //Gets a list of Es
            myARDocsList = parentForm.myIMObj.getARDocsByBatNbrAndRefNbr(parentForm.tbBatNbr.Text.Trim(), parentForm.tbRefNbr.Text.Trim());
            this.gvARDocs.DataSource = myARDocsList;

        }

        private void gvARDocs_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            String refNbr = "";
            try
            {
                refNbr = gvARDocs.Rows[e.RowIndex].Cells["REFNBR"].Value.ToString();
            }
            catch { }
            if (refNbr != "")
            {
                parentForm.tbRefNbr.Text = refNbr;
                parentForm.myScreen.myARDoc = myARDocsList[e.RowIndex];
                parentForm.tbCustID.Text = parentForm.myScreen.myARDoc.CustId;
                if (parentForm.myScreen != null)
                {
                    //parentForm.btnLoadBatch.PerformClick();
                }
            }
            this.Close();
        }
    }
}
