using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace client.project.projectController.maintenance.projectMaintenance
{
    public partial class projectsPopup : Form
    {
        private client.project.projectController.maintenance.projectMaintenance.Form1 parentForm = null;

        public projectsPopup(client.project.projectController.maintenance.projectMaintenance.Form1 inParentForm, String inShipperID)
        {
            InitializeComponent();
            parentForm = inParentForm;

            ctDynamicsSL.project.projectController.maintenance.projectMaintenance.PJPROJ[] myProjects = parentForm.myPMService.getProjectsByID(parentForm.tbProject.Text.Trim());
            this.gvProjects.AutoGenerateColumns = true;
            this.gvProjects.DataSource = myProjects;
        }

        private void gvProjects_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            String projectID = "";
            try
            {
                projectID = gvProjects.Rows[e.RowIndex].Cells["PROJECTID"].Value.ToString();
            }
            catch { }

            if (projectID != "")
            {
                parentForm.tbProject.Text = projectID;

                parentForm.btnLoad.PerformClick();
            }
            this.Close();
        }
    }
}
