using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace client.fieldService.serviceContracts.maintenance.serviceContractEntry
{
    public partial class contractsPopup : Form
    {
        private client.fieldService.serviceContracts.maintenance.serviceContractEntry.Form1 parentForm = null;

        public contractsPopup(client.fieldService.serviceContracts.maintenance.serviceContractEntry.Form1 inParentForm, String inBatNbr)
        {
            InitializeComponent();
            parentForm = inParentForm;
            this.gvContracts.AutoGenerateColumns = true;
            this.gvContracts.DataSource = parentForm.mySCEObj.getContractsByContractID(parentForm.tbContractID.Text.Trim());
        }

        private void gvContracts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            String contractID = "";
            try
            {
                contractID = gvContracts.Rows[e.RowIndex].Cells["CONTRACTID"].Value.ToString();
            }
            catch { }
            if (contractID != "")
            {
                parentForm.tbContractID.Text = contractID;
                parentForm.btnLoad.PerformClick();
            }
            this.Close();
        }
    }
}
