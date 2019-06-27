using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace client.purchaseOrders
{
    public partial class purchaseOrdersPopup : Form
    {
        private client.purchaseOrders.Form1 parentForm = null;

        public purchaseOrdersPopup(client.purchaseOrders.Form1 inParentForm, String inPONbr)
        {
            InitializeComponent();
            parentForm = inParentForm;
            
            ctDynamicsSL.purchaseOrders.nameValuePairs[] outParams = new ctDynamicsSL.purchaseOrders.nameValuePairs[1];
            outParams[0] = new ctDynamicsSL.purchaseOrders.nameValuePairs();
            outParams[0].name = "PONBR";
            outParams[0].value = inPONbr;

            this.gvPurchaseOrders.DataSource = parentForm.myPurchaseOrdersService.getPurchOrds(0, 0, outParams);
            this.gvPurchaseOrders.AutoGenerateColumns = true;
        }

        private void gvPurchaseOrders_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            String poNbr = "";
            try
            {
                poNbr = gvPurchaseOrders.Rows[e.RowIndex].Cells["PONBR"].Value.ToString();
            }
            catch { }
            if (poNbr != "")
            {
                parentForm.tbPONbr.Text = poNbr;
                parentForm.btnLoad.PerformClick();
            }
            this.Close();
        }
    }
}
