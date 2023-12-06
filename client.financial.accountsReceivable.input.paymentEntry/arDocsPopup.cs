using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace client.financial.accountsReceivable.input.paymentEntry
{
    public partial class arDocsPopup : Form
    {
        private client.financial.accountsReceivable.input.paymentEntry.Form1 parentForm = null;
        private ctDynamicsSL.financial.accountsReceivable.input.paymentEntry.ARDoc[] myARDocs = null;
        public arDocsPopup(client.financial.accountsReceivable.input.paymentEntry.Form1 inParentForm, String inRefNbr)
        {
            InitializeComponent();
            parentForm = inParentForm;
            myARDocs = parentForm.myPEObj.getARDocsByBatNbrAndRefNbr(parentForm.tbBatNbr.Text, inRefNbr);
            this.gvARDocs.DataSource = myARDocs;
        }

        private void gvARDocs_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            String custID = "";
            try
            {
                custID = gvARDocs.Rows[e.RowIndex].Cells["CUSTID"].Value.ToString();
            }
            catch { }
            parentForm.tbCustID.Text = custID;

            String refNbr = "";
            try
            {
                refNbr = gvARDocs.Rows[e.RowIndex].Cells["REFNBR"].Value.ToString();
            }
            catch { }
            if (refNbr != "")
            {
                parentForm.myScreen.myARDoc = myARDocs[e.RowIndex];
                parentForm.tbRefNbr.Text = refNbr;
                parentForm.loadARTrans();
            }
            this.Close();
        }
    }
}
