using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace client.inventoryReceipts
{
    public partial class inventoryPopup : Form
    {
        private client.inventoryReceipts.Form1 parentForm = null;

        public inventoryPopup(client.inventoryReceipts.Form1 inParentForm, String inInvtID)
        {
            InitializeComponent();
            parentForm = inParentForm;

            {
                var singleInvtID = parentForm.myIRService.getInventoryByExactID(inInvtID);
                if (singleInvtID != null)
                {
                    parentForm.addInventoryToBatch(singleInvtID);
                    this.Close();
                }
            }
            this.gvInventory.DataSource = parentForm.myIRService.getInventoryByID(inInvtID);
        }

        private void gvInventory_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            String invtID = "";
            try
            {
                invtID = gvInventory.Rows[e.RowIndex].Cells["INVTID"].Value.ToString();
            }
            catch { }
            if (invtID != "")
            {
                parentForm.tbInvtID.Text = invtID;
                var singleInvtID =
                    ((ctDynamicsSL.inventoryReceipts.Inventory[])gvInventory.DataSource)[e.RowIndex];

                parentForm.addInventoryToBatch(singleInvtID);
                this.Close();
            }
        }

    }
}
