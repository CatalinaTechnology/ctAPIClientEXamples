using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace client.ctDynamicsSL.quickQuery
{
    public partial class queryViewsPopup : Form
    {
        private client.ctDynamicsSL.quickQuery.Form1 parentForm = null;

        public queryViewsPopup(client.ctDynamicsSL.quickQuery.Form1 inParentForm)
        {
            InitializeComponent();
            parentForm = inParentForm;

            var myQueries = parentForm.myQQObj.getQueryViewsByID(parentForm.tbQueryViewName.Text);
            this.gvQueries.AutoGenerateColumns = true;
            this.gvQueries.DataSource = myQueries;
        }

        private void gvQueries_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            String queryViewName = "";
            try
            {
                ///get the selected view name
                queryViewName = gvQueries.Rows[e.RowIndex].Cells["QueryViewName"].Value.ToString();
            }
            catch { }

            if (queryViewName != "")
            {
                //set the selected view name back on the parent form textbox
                parentForm.tbQueryViewName.Text = queryViewName;
            }
            this.Close();
        }

    }
}
