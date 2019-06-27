using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace client.inventory.inventory.maintenance.kits
{
    public partial class kitsPopup : Form
    {
        private client.inventory.inventory.maintenance.kits.Form1 parentForm = null;

        public kitsPopup(client.inventory.inventory.maintenance.kits.Form1 inParentForm)
        {
            InitializeComponent();
            parentForm = inParentForm;

            ctDynamicsSL.inventory.inventory.maintenance.kits.Kit[] myKits = parentForm.myKitsService.getKitsByID(parentForm.tbKitID.Text);
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
            if (kitID != "")
            {
                parentForm.tbKitID.Text = kitID;
                parentForm.btnLoad.PerformClick();
            }
            this.Close();
        }
    }
}
