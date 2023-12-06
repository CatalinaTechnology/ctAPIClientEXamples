using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace client.routingMaintenance
{
    public partial class kitsPopup : Form
    {
        private client.routingMaintenance.Form1 parentForm = null;

        public kitsPopup(client.routingMaintenance.Form1 inParentForm)
        {
            InitializeComponent();
            parentForm = inParentForm;

            ctDynamicsSL.inventory.billOfMaterial.maintenance.routingMaintenance.Kit[] myKits = parentForm.myRoutingService.getKitsByID(parentForm.tbKitID.Text);
            gvKits.DataSource = myKits;
        }

        private void gvKits_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            String kitID = "";
            try
            {
                kitID = gvKits.Rows[e.RowIndex].Cells["KITID"].Value.ToString();
            }
            catch { }
            String siteID = "";
            try
            {
                siteID = gvKits.Rows[e.RowIndex].Cells["SITEID"].Value.ToString();
            }
            catch { }
            String status = "";
            try
            {
                status = gvKits.Rows[e.RowIndex].Cells["STATUS"].Value.ToString();
            }
            catch { }

            if (kitID != "")
            {
                parentForm.tbKitID.Text = kitID;
                parentForm.tbSiteID.Text = siteID;
                parentForm.tbStatus.Text = status;
                parentForm.btnLoad.PerformClick();
            }
            this.Close();
        }
    }
}
