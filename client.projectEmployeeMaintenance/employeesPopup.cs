using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace client.project.projectController.maintenance.projectEmployeeMaintenance
{
    public partial class employeesPopup : Form
    {
        private client.project.projectController.maintenance.projectEmployeeMaintenance.Form1 parentForm = null;

        public employeesPopup(client.project.projectController.maintenance.projectEmployeeMaintenance.Form1 inParentForm)
        {
            InitializeComponent();
            parentForm = inParentForm;

            ctDynamicsSL.project.projectController.maintenance.projectEmployeeMaintenance.PJEMPLOY[] myEmployees = parentForm.myPEMService.getEmployeesByID(parentForm.tbEmployee.Text.Trim());
            this.gvEmployees.AutoGenerateColumns = true;
            this.gvEmployees.DataSource = myEmployees;
        }

        private void gvEmployees_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            String employee = "";
            try
            {
                employee = gvEmployees.Rows[e.RowIndex].Cells["EMPLOYEE"].Value.ToString();
            }
            catch { }

            if (employee != "")
            {
                parentForm.tbEmployee.Text = employee;

                parentForm.btnLoad.PerformClick();
            }
            this.Close();
        }
    }
}
