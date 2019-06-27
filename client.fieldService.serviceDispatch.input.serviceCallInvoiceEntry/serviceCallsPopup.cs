using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace client.fieldService.serviceDispatch.input.serviceCallInvoiceEntry
{
    public partial class serviceCallsPopup : Form
    {
        private client.fieldService.serviceDispatch.input.serviceCallInvoiceEntry.Form1 parentForm = null;

        public serviceCallsPopup(client.fieldService.serviceDispatch.input.serviceCallInvoiceEntry.Form1 inParentForm, String inBatNbr)
        {
            InitializeComponent();
            parentForm = inParentForm;
            this.gvServiceCalls.AutoGenerateColumns = true;
            this.gvServiceCalls.DataSource = parentForm.mySCIEObj.getServiceCalls(parentForm.tbServiceCallID.Text.Trim(), false);
        }

        private void gvServiceCalls_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            String serviceCallID = "";
            try
            {
                serviceCallID = gvServiceCalls.Rows[e.RowIndex].Cells["SERVICECALLID"].Value.ToString();
            }
            catch { }
            if (serviceCallID != "")
            {
                parentForm.tbServiceCallID.Text = serviceCallID;
                parentForm.btnLoad.PerformClick();
            }
            this.Close();
        }
    }
}
