using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace client.projectTravelAndExpenseEntry
{
    public partial class expenseReportsPopup : Form
    {
        private client.projectTravelAndExpenseEntry.Form1 parentForm = null;

        public expenseReportsPopup(client.projectTravelAndExpenseEntry.Form1 inParentForm, String inEmployee, String inDocNbr)
        {
            InitializeComponent();
            parentForm = inParentForm;

            ctDynamicsSL.project.timeAndExpense.input.projectTravelAndExpenseEntry.PJEXPHDR[] myTimecards = parentForm.myPTEService.getExpenseReportsByID(inEmployee, inDocNbr);
            this.gvTimecards.AutoGenerateColumns = true;
            this.gvTimecards.DataSource = myTimecards;
        }

        private void gvTimecards_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            String docNbr = "";
            try
            {
                docNbr = gvTimecards.Rows[e.RowIndex].Cells["DOCNBR"].Value.ToString();
            }
            catch { }
            String employee = "";
            try
            {
                employee = gvTimecards.Rows[e.RowIndex].Cells["EMPLOYEE"].Value.ToString();
            }
            catch { }
            if ((docNbr != "") && (employee != ""))
            {
                parentForm.tbEmployee.Text = employee;
                parentForm.tbDocNbr.Text = docNbr;
                parentForm.btnLoad.PerformClick();
            }
            this.Close();
        }

    }
}
