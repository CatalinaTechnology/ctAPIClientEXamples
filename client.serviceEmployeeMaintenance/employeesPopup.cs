using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace client.fieldService.serviceDispatch.maintenance.serviceEmployeeMaintenance
{
    public partial class employeesPopup : Form
    {
        private client.fieldService.serviceDispatch.maintenance.serviceEmployeeMaintenance.Form1 parentForm = null;

        public employeesPopup(client.fieldService.serviceDispatch.maintenance.serviceEmployeeMaintenance.Form1 inParentForm)
        {
            InitializeComponent();
            parentForm = inParentForm;
            ctDynamicsSL.fieldService.serviceDispatch.maintenance.serviceEmployeeMaintenance.smEmp[] myEmployees = parentForm.mySEMService.getEmployeesByID(parentForm.tbEmployeeID.Text.Trim());
            this.gvEmployees.AutoGenerateColumns = true;
            this.gvEmployees.DataSource = myEmployees;
        }

        private void gvEmployees_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            String employeeID = "";
            try
            {
                employeeID = gvEmployees.Rows[e.RowIndex].Cells["EMPLOYEEID"].Value.ToString();
            }
            catch { }

            if (employeeID != "")
            {
                parentForm.tbEmployeeID.Text = employeeID;

                parentForm.btnLoad.PerformClick();
            }
            this.Close();
        }

    }
}
