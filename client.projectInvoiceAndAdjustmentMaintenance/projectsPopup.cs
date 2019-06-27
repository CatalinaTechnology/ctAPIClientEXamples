using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace client.projectInvoiceAndAdjustmentMaintenance
{
    public partial class projectsPopup : Form
    {
        private client.projectInvoiceAndAdjustmentMaintenance.Form1 parentForm = null;

        public projectsPopup(client.projectInvoiceAndAdjustmentMaintenance.Form1 inParentForm)
        {
            InitializeComponent();
            parentForm = inParentForm;

            ctDynamicsSL.project.flexibleBillings.input.projectInvoiceAndAdjustmentMaintenance.PJPROJ[] myProjects = parentForm.myIAMService.getProjectsByID(parentForm.tbProjectID.Text.Trim());
            this.gvProjects.AutoGenerateColumns = true;
            this.gvProjects.DataSource = myProjects;
        }

        private void gvProjects_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            String project = "";
            try
            {
                project = gvProjects.Rows[e.RowIndex].Cells["PROJECT"].Value.ToString();
            }
            catch { }

            if (project != "")
            {
                parentForm.tbProjectID.Text = project;

                parentForm.tbDraftNum.Text = "";
                parentForm.myScreen = null;
                parentForm.dgvRegular.DataSource = null;
                parentForm.dgvTRD.DataSource = null;
            }
            this.Close();
        }
    }
}
