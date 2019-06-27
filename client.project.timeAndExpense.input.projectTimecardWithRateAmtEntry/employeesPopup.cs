using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace client.project.timeAndExpense.input.projectTimecardWithRateAmtEntry
{
    public partial class employeesPopup : Form
    {
        private client.project.timeAndExpense.input.projectTimecardWithRateAmtEntry.Form1 parentForm = null;

        public employeesPopup(client.project.timeAndExpense.input.projectTimecardWithRateAmtEntry.Form1 inParentForm, String inEmployeeID)
        {
            InitializeComponent();
            parentForm = inParentForm;

            ctDynamicsSL.project.timeAndExpense.input.projectTimecardWithRateAmtEntry.PJEMPLOY[] myEmployees = parentForm.myPTCService.getEmployeesByID(inEmployeeID);
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
            }
            this.Close();
        }
    }
}
