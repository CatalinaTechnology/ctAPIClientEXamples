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
    public partial class timecardsPopup : Form
    {
        private client.project.timeAndExpense.input.projectTimecardWithRateAmtEntry.Form1 parentForm = null;

        public timecardsPopup(client.project.timeAndExpense.input.projectTimecardWithRateAmtEntry.Form1 inParentForm, String inEmployee, String inDocNbr)
        {
            InitializeComponent();
            parentForm = inParentForm;

            ctDynamicsSL.project.timeAndExpense.input.projectTimecardWithRateAmtEntry.PJLABHDR[] myTimecards = parentForm.myPTCService.getTimecardEntriesByID(inEmployee, inDocNbr);
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
