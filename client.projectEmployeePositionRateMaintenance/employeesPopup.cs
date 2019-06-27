using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace client.project.timeAndExpense.maintenance.projectEmployeePositionRateMaintenance
{
    public partial class employeesPopup : Form
    {
        private client.project.timeAndExpense.maintenance.projectEmployeePositionRateMaintenance.Form1 parentForm = null;

        public employeesPopup(client.project.timeAndExpense.maintenance.projectEmployeePositionRateMaintenance.Form1 inParentForm)
        {
            InitializeComponent();
            parentForm = inParentForm;
            ctDynamicsSL.project.timeAndExpense.maintenance.projectEmployeePositionRateMaintenance.PJEMPLOY[] myEmployees = parentForm.myPEPRMService.getEmployeesByID(parentForm.tbEmployee.Text.Trim());
            this.gvEmployees.AutoGenerateColumns = true;
            this.gvEmployees.DataSource = myEmployees;
        }

        private void gvEmployees_CellContentClick(object sender, DataGridViewCellEventArgs e)
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
