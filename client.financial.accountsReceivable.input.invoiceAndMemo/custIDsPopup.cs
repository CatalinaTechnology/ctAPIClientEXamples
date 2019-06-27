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
    public partial class custIDsPopup : Form
    {
        private client.financial.accountsReceivable.input.invoiceAndMemo.Form1 parentForm = null;

        public custIDsPopup(client.financial.accountsReceivable.input.invoiceAndMemo.Form1 inParentForm, String inCustID)
        {
            InitializeComponent();
            parentForm = inParentForm;
            String tmpCustID = inCustID;
            if (tmpCustID.IndexOf("%") == -1)//older service, does not do like by default, only pulls back 20 records at a time
            {
                tmpCustID += "%";
            }
            this.gvCustIDs.DataSource = parentForm.myIMObj.getCustomersByCustID(tmpCustID);
        }

        private void gvCustIDs_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            String custID = "";
            try
            {
                custID = gvCustIDs.Rows[e.RowIndex].Cells["CUSTID"].Value.ToString();
            }
            catch { }
            if (custID != "")
            {
                parentForm.tbCustID.Text = custID;
                if (parentForm.myScreen != null)
                {
                    //attempt to load this customers payment batch and invoices
                    parentForm.btnLoadBatch.PerformClick();
                }
            }
            this.Close();
        }
    }
}
