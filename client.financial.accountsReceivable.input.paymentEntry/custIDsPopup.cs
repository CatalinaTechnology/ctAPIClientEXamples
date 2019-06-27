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
    public partial class custIDsPopup : Form
    {
        private client.financial.accountsReceivable.input.paymentEntry.Form1 parentForm = null;

        public custIDsPopup(client.financial.accountsReceivable.input.paymentEntry.Form1 inParentForm, String inCustID)
        {
            InitializeComponent();
            parentForm = inParentForm;
            this.gvCustIDs.DataSource = parentForm.myPEObj.getCustomersByCustID(inCustID);
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
                    parentForm.btnLoadBatch.PerformClick();
                }
            }
            this.Close();
        }
    }
}
