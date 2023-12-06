using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace client.financial.accountsReceivable.input.paymentApplication
{
    public partial class arDocsPopup : Form
    {
        private client.financial.accountsReceivable.input.paymentApplication.Form1 parentForm = null;
        private ctDynamicsSL.financial.accountsReceivable.input.paymentApplication.ARDoc[] myARDocsList = null;
        private System.Boolean openInvoiceLookup = false;
        public arDocsPopup(client.financial.accountsReceivable.input.paymentApplication.Form1 inParentForm, String inCustID)
        {
            InitializeComponent();
            parentForm = inParentForm;
            //Gets a list of Es
            myARDocsList = parentForm.myPAObj.getReleasedARDocsByCustIDAndDocType(parentForm.tbCustID.Text.Trim(), "PA", parentForm.tbRefNbr.Text.Trim());
            this.gvARDocs.DataSource = myARDocsList;

        }

        public arDocsPopup(client.financial.accountsReceivable.input.paymentApplication.Form1 inParentForm, System.Boolean inOpenInvoiceLookup)
        {
            InitializeComponent();
            parentForm = inParentForm;
            openInvoiceLookup = inOpenInvoiceLookup;
            //Gets a list of open invoices
            myARDocsList = parentForm.myPAObj.getOpenInvoices("", "IN", inParentForm.tbQPRefNbr.Text);
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
                if (!openInvoiceLookup)
                {
                    parentForm.tbRefNbr.Text = refNbr;
                    parentForm.myScreen.myARDoc = myARDocsList[e.RowIndex];
                    parentForm.tbCustID.Text = parentForm.myScreen.myARDoc.CustId;
                    if (parentForm.myScreen != null)
                    {
                        //parentForm.btnLoadBatch.PerformClick();
                    }
                }
                else
                {
                    parentForm.tbQPRefNbr.Text = refNbr;
                    parentForm.qpInvoice = myARDocsList[e.RowIndex];
                }
            }
            this.Close();
        }
    }
}
