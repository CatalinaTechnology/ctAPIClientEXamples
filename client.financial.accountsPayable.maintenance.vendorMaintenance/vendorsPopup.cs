using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace client.financial.accountsPayable.maintenance.vendorMaintenance
{
    public partial class vendorsPopup : Form
    {
        private client.financial.accountsPayable.maintenance.vendorMaintenance.Form1 parentForm = null;

        public vendorsPopup(client.financial.accountsPayable.maintenance.vendorMaintenance.Form1 inParentForm)
        {
            InitializeComponent();
            parentForm = inParentForm;

            ctDynamicsSL.financial.accountsPayable.maintenance.vendorMaintenance.Vendor[] myVendors = parentForm.myVendorsService.getVendorsByID(parentForm.tbVendID.Text);
            this.gvVendors.AutoGenerateColumns = true;
            this.gvVendors.DataSource = myVendors;
        }

        private void gvVendors_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            String vendID = "";
            try
            {
                vendID = gvVendors.Rows[e.RowIndex].Cells["VENDID"].Value.ToString();
            }
            catch { }
            if (vendID != "")
            {
                parentForm.tbVendID.Text = vendID;
                parentForm.btnLoad.PerformClick();
            }
            this.Close();
        }
    }
}
