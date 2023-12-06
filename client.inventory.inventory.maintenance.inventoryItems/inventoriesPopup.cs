using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace client.inventory.inventory.maintenance.inventoryItems
{
    public partial class inventoriesPopup : Form
    {
        private client.inventory.inventory.maintenance.inventoryItems.Form1 parentForm = null;

        public inventoriesPopup(client.inventory.inventory.maintenance.inventoryItems.Form1 inParentForm)
        {
            InitializeComponent();
            parentForm = inParentForm;

            ctDynamicsSL.inventory.inventory.maintenance.inventoryItems.Inventory[] myInventories = parentForm.myInventoryItemsService.getInventoryByID(parentForm.tbInvtID.Text);
            this.gvInventories.AutoGenerateColumns = true;
            this.gvInventories.DataSource = myInventories;
        }

        private void gvInventories_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            String invtID = "";
            try
            {
                invtID = gvInventories.Rows[e.RowIndex].Cells["INVTID"].Value.ToString();
            }
            catch { }
            if (invtID != "")
            {
                parentForm.tbInvtID.Text = invtID;
                parentForm.btnLoad.PerformClick();
            }
            this.Close();
        }
    }
}
