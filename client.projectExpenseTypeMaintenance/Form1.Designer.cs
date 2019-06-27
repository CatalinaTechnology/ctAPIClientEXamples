namespace client.project.timeAndExpense.maintenance.projectExpenseTypeMaintenance
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.btnNew = new System.Windows.Forms.Button();
            this.Screen = new System.Windows.Forms.Label();
            this.lblScreenXML = new System.Windows.Forms.Label();
            this.gvScreen = new System.Windows.Forms.DataGridView();
            this.EXP_TYPE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.defaultrateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descexpDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.crtddatetimeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.crtdprogDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.crtduserDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.exid01DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.exid02DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.exid03DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.exid04DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.exid05DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.exid06DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.exid07DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.exid08DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.exid09DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.exid10DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.glacctDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lupddatetimeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lupdprogDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lupduserDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.noteIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statusDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.taxflagDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.taxidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.unitsflagDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.user1DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.user2DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.user3DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.user4DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.errorMessageDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.resultCodeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pJEXPTYPBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btnUpdate = new System.Windows.Forms.Button();
            this.tbScreen = new System.Windows.Forms.TextBox();
            this.lblExpenseTypeID = new System.Windows.Forms.Label();
            this.tbExpenseTypeID = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.gvScreen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pJEXPTYPBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(224, 11);
            this.btnNew.Margin = new System.Windows.Forms.Padding(4);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(100, 28);
            this.btnNew.TabIndex = 30;
            this.btnNew.Text = "Create New";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // Screen
            // 
            this.Screen.AutoSize = true;
            this.Screen.Location = new System.Drawing.Point(20, 99);
            this.Screen.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Screen.Name = "Screen";
            this.Screen.Size = new System.Drawing.Size(57, 17);
            this.Screen.TabIndex = 28;
            this.Screen.Text = "Screen:";
            // 
            // lblScreenXML
            // 
            this.lblScreenXML.AutoSize = true;
            this.lblScreenXML.Location = new System.Drawing.Point(20, 405);
            this.lblScreenXML.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblScreenXML.Name = "lblScreenXML";
            this.lblScreenXML.Size = new System.Drawing.Size(99, 17);
            this.lblScreenXML.TabIndex = 27;
            this.lblScreenXML.Text = "Screen (XML):";
            // 
            // gvScreen
            // 
            this.gvScreen.AllowUserToDeleteRows = false;
            this.gvScreen.AllowUserToOrderColumns = true;
            this.gvScreen.AutoGenerateColumns = false;
            this.gvScreen.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvScreen.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.EXP_TYPE,
            this.defaultrateDataGridViewTextBoxColumn,
            this.descexpDataGridViewTextBoxColumn,
            this.crtddatetimeDataGridViewTextBoxColumn,
            this.crtdprogDataGridViewTextBoxColumn,
            this.crtduserDataGridViewTextBoxColumn,
            this.exid01DataGridViewTextBoxColumn,
            this.exid02DataGridViewTextBoxColumn,
            this.exid03DataGridViewTextBoxColumn,
            this.exid04DataGridViewTextBoxColumn,
            this.exid05DataGridViewTextBoxColumn,
            this.exid06DataGridViewTextBoxColumn,
            this.exid07DataGridViewTextBoxColumn,
            this.exid08DataGridViewTextBoxColumn,
            this.exid09DataGridViewTextBoxColumn,
            this.exid10DataGridViewTextBoxColumn,
            this.glacctDataGridViewTextBoxColumn,
            this.lupddatetimeDataGridViewTextBoxColumn,
            this.lupdprogDataGridViewTextBoxColumn,
            this.lupduserDataGridViewTextBoxColumn,
            this.noteIdDataGridViewTextBoxColumn,
            this.statusDataGridViewTextBoxColumn,
            this.taxflagDataGridViewTextBoxColumn,
            this.taxidDataGridViewTextBoxColumn,
            this.unitsflagDataGridViewTextBoxColumn,
            this.user1DataGridViewTextBoxColumn,
            this.user2DataGridViewTextBoxColumn,
            this.user3DataGridViewTextBoxColumn,
            this.user4DataGridViewTextBoxColumn,
            this.errorMessageDataGridViewTextBoxColumn,
            this.resultCodeDataGridViewTextBoxColumn});
            this.gvScreen.DataSource = this.pJEXPTYPBindingSource;
            this.gvScreen.Location = new System.Drawing.Point(24, 119);
            this.gvScreen.Margin = new System.Windows.Forms.Padding(4);
            this.gvScreen.Name = "gvScreen";
            this.gvScreen.Size = new System.Drawing.Size(701, 242);
            this.gvScreen.TabIndex = 26;
            // 
            // EXP_TYPE
            // 
            this.EXP_TYPE.DataPropertyName = "exp_type";
            this.EXP_TYPE.HeaderText = "exp_type";
            this.EXP_TYPE.Name = "EXP_TYPE";
            // 
            // defaultrateDataGridViewTextBoxColumn
            // 
            this.defaultrateDataGridViewTextBoxColumn.DataPropertyName = "default_rate";
            this.defaultrateDataGridViewTextBoxColumn.HeaderText = "default_rate";
            this.defaultrateDataGridViewTextBoxColumn.Name = "defaultrateDataGridViewTextBoxColumn";
            // 
            // descexpDataGridViewTextBoxColumn
            // 
            this.descexpDataGridViewTextBoxColumn.DataPropertyName = "desc_exp";
            this.descexpDataGridViewTextBoxColumn.HeaderText = "desc_exp";
            this.descexpDataGridViewTextBoxColumn.Name = "descexpDataGridViewTextBoxColumn";
            // 
            // crtddatetimeDataGridViewTextBoxColumn
            // 
            this.crtddatetimeDataGridViewTextBoxColumn.DataPropertyName = "crtd_datetime";
            this.crtddatetimeDataGridViewTextBoxColumn.HeaderText = "crtd_datetime";
            this.crtddatetimeDataGridViewTextBoxColumn.Name = "crtddatetimeDataGridViewTextBoxColumn";
            // 
            // crtdprogDataGridViewTextBoxColumn
            // 
            this.crtdprogDataGridViewTextBoxColumn.DataPropertyName = "crtd_prog";
            this.crtdprogDataGridViewTextBoxColumn.HeaderText = "crtd_prog";
            this.crtdprogDataGridViewTextBoxColumn.Name = "crtdprogDataGridViewTextBoxColumn";
            // 
            // crtduserDataGridViewTextBoxColumn
            // 
            this.crtduserDataGridViewTextBoxColumn.DataPropertyName = "crtd_user";
            this.crtduserDataGridViewTextBoxColumn.HeaderText = "crtd_user";
            this.crtduserDataGridViewTextBoxColumn.Name = "crtduserDataGridViewTextBoxColumn";
            // 
            // exid01DataGridViewTextBoxColumn
            // 
            this.exid01DataGridViewTextBoxColumn.DataPropertyName = "ex_id01";
            this.exid01DataGridViewTextBoxColumn.HeaderText = "ex_id01";
            this.exid01DataGridViewTextBoxColumn.Name = "exid01DataGridViewTextBoxColumn";
            // 
            // exid02DataGridViewTextBoxColumn
            // 
            this.exid02DataGridViewTextBoxColumn.DataPropertyName = "ex_id02";
            this.exid02DataGridViewTextBoxColumn.HeaderText = "ex_id02";
            this.exid02DataGridViewTextBoxColumn.Name = "exid02DataGridViewTextBoxColumn";
            // 
            // exid03DataGridViewTextBoxColumn
            // 
            this.exid03DataGridViewTextBoxColumn.DataPropertyName = "ex_id03";
            this.exid03DataGridViewTextBoxColumn.HeaderText = "ex_id03";
            this.exid03DataGridViewTextBoxColumn.Name = "exid03DataGridViewTextBoxColumn";
            // 
            // exid04DataGridViewTextBoxColumn
            // 
            this.exid04DataGridViewTextBoxColumn.DataPropertyName = "ex_id04";
            this.exid04DataGridViewTextBoxColumn.HeaderText = "ex_id04";
            this.exid04DataGridViewTextBoxColumn.Name = "exid04DataGridViewTextBoxColumn";
            // 
            // exid05DataGridViewTextBoxColumn
            // 
            this.exid05DataGridViewTextBoxColumn.DataPropertyName = "ex_id05";
            this.exid05DataGridViewTextBoxColumn.HeaderText = "ex_id05";
            this.exid05DataGridViewTextBoxColumn.Name = "exid05DataGridViewTextBoxColumn";
            // 
            // exid06DataGridViewTextBoxColumn
            // 
            this.exid06DataGridViewTextBoxColumn.DataPropertyName = "ex_id06";
            this.exid06DataGridViewTextBoxColumn.HeaderText = "ex_id06";
            this.exid06DataGridViewTextBoxColumn.Name = "exid06DataGridViewTextBoxColumn";
            // 
            // exid07DataGridViewTextBoxColumn
            // 
            this.exid07DataGridViewTextBoxColumn.DataPropertyName = "ex_id07";
            this.exid07DataGridViewTextBoxColumn.HeaderText = "ex_id07";
            this.exid07DataGridViewTextBoxColumn.Name = "exid07DataGridViewTextBoxColumn";
            // 
            // exid08DataGridViewTextBoxColumn
            // 
            this.exid08DataGridViewTextBoxColumn.DataPropertyName = "ex_id08";
            this.exid08DataGridViewTextBoxColumn.HeaderText = "ex_id08";
            this.exid08DataGridViewTextBoxColumn.Name = "exid08DataGridViewTextBoxColumn";
            // 
            // exid09DataGridViewTextBoxColumn
            // 
            this.exid09DataGridViewTextBoxColumn.DataPropertyName = "ex_id09";
            this.exid09DataGridViewTextBoxColumn.HeaderText = "ex_id09";
            this.exid09DataGridViewTextBoxColumn.Name = "exid09DataGridViewTextBoxColumn";
            // 
            // exid10DataGridViewTextBoxColumn
            // 
            this.exid10DataGridViewTextBoxColumn.DataPropertyName = "ex_id10";
            this.exid10DataGridViewTextBoxColumn.HeaderText = "ex_id10";
            this.exid10DataGridViewTextBoxColumn.Name = "exid10DataGridViewTextBoxColumn";
            // 
            // glacctDataGridViewTextBoxColumn
            // 
            this.glacctDataGridViewTextBoxColumn.DataPropertyName = "gl_acct";
            this.glacctDataGridViewTextBoxColumn.HeaderText = "gl_acct";
            this.glacctDataGridViewTextBoxColumn.Name = "glacctDataGridViewTextBoxColumn";
            // 
            // lupddatetimeDataGridViewTextBoxColumn
            // 
            this.lupddatetimeDataGridViewTextBoxColumn.DataPropertyName = "lupd_datetime";
            this.lupddatetimeDataGridViewTextBoxColumn.HeaderText = "lupd_datetime";
            this.lupddatetimeDataGridViewTextBoxColumn.Name = "lupddatetimeDataGridViewTextBoxColumn";
            // 
            // lupdprogDataGridViewTextBoxColumn
            // 
            this.lupdprogDataGridViewTextBoxColumn.DataPropertyName = "lupd_prog";
            this.lupdprogDataGridViewTextBoxColumn.HeaderText = "lupd_prog";
            this.lupdprogDataGridViewTextBoxColumn.Name = "lupdprogDataGridViewTextBoxColumn";
            // 
            // lupduserDataGridViewTextBoxColumn
            // 
            this.lupduserDataGridViewTextBoxColumn.DataPropertyName = "lupd_user";
            this.lupduserDataGridViewTextBoxColumn.HeaderText = "lupd_user";
            this.lupduserDataGridViewTextBoxColumn.Name = "lupduserDataGridViewTextBoxColumn";
            // 
            // noteIdDataGridViewTextBoxColumn
            // 
            this.noteIdDataGridViewTextBoxColumn.DataPropertyName = "NoteId";
            this.noteIdDataGridViewTextBoxColumn.HeaderText = "NoteId";
            this.noteIdDataGridViewTextBoxColumn.Name = "noteIdDataGridViewTextBoxColumn";
            // 
            // statusDataGridViewTextBoxColumn
            // 
            this.statusDataGridViewTextBoxColumn.DataPropertyName = "status";
            this.statusDataGridViewTextBoxColumn.HeaderText = "status";
            this.statusDataGridViewTextBoxColumn.Name = "statusDataGridViewTextBoxColumn";
            // 
            // taxflagDataGridViewTextBoxColumn
            // 
            this.taxflagDataGridViewTextBoxColumn.DataPropertyName = "tax_flag";
            this.taxflagDataGridViewTextBoxColumn.HeaderText = "tax_flag";
            this.taxflagDataGridViewTextBoxColumn.Name = "taxflagDataGridViewTextBoxColumn";
            // 
            // taxidDataGridViewTextBoxColumn
            // 
            this.taxidDataGridViewTextBoxColumn.DataPropertyName = "taxid";
            this.taxidDataGridViewTextBoxColumn.HeaderText = "taxid";
            this.taxidDataGridViewTextBoxColumn.Name = "taxidDataGridViewTextBoxColumn";
            // 
            // unitsflagDataGridViewTextBoxColumn
            // 
            this.unitsflagDataGridViewTextBoxColumn.DataPropertyName = "units_flag";
            this.unitsflagDataGridViewTextBoxColumn.HeaderText = "units_flag";
            this.unitsflagDataGridViewTextBoxColumn.Name = "unitsflagDataGridViewTextBoxColumn";
            // 
            // user1DataGridViewTextBoxColumn
            // 
            this.user1DataGridViewTextBoxColumn.DataPropertyName = "user1";
            this.user1DataGridViewTextBoxColumn.HeaderText = "user1";
            this.user1DataGridViewTextBoxColumn.Name = "user1DataGridViewTextBoxColumn";
            // 
            // user2DataGridViewTextBoxColumn
            // 
            this.user2DataGridViewTextBoxColumn.DataPropertyName = "user2";
            this.user2DataGridViewTextBoxColumn.HeaderText = "user2";
            this.user2DataGridViewTextBoxColumn.Name = "user2DataGridViewTextBoxColumn";
            // 
            // user3DataGridViewTextBoxColumn
            // 
            this.user3DataGridViewTextBoxColumn.DataPropertyName = "user3";
            this.user3DataGridViewTextBoxColumn.HeaderText = "user3";
            this.user3DataGridViewTextBoxColumn.Name = "user3DataGridViewTextBoxColumn";
            // 
            // user4DataGridViewTextBoxColumn
            // 
            this.user4DataGridViewTextBoxColumn.DataPropertyName = "user4";
            this.user4DataGridViewTextBoxColumn.HeaderText = "user4";
            this.user4DataGridViewTextBoxColumn.Name = "user4DataGridViewTextBoxColumn";
            // 
            // errorMessageDataGridViewTextBoxColumn
            // 
            this.errorMessageDataGridViewTextBoxColumn.DataPropertyName = "errorMessage";
            this.errorMessageDataGridViewTextBoxColumn.HeaderText = "errorMessage";
            this.errorMessageDataGridViewTextBoxColumn.Name = "errorMessageDataGridViewTextBoxColumn";
            // 
            // resultCodeDataGridViewTextBoxColumn
            // 
            this.resultCodeDataGridViewTextBoxColumn.DataPropertyName = "resultCode";
            this.resultCodeDataGridViewTextBoxColumn.HeaderText = "resultCode";
            this.resultCodeDataGridViewTextBoxColumn.Name = "resultCodeDataGridViewTextBoxColumn";
            // 
            // pJEXPTYPBindingSource
            // 
            this.pJEXPTYPBindingSource.DataSource = typeof(client.project.timeAndExpense.maintenance.projectExpenseTypeMaintenance.ctDynamicsSL.project.timeAndExpense.maintenance.projectExpenseTypeMaintenance.PJEXPTYP);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(224, 66);
            this.btnUpdate.Margin = new System.Windows.Forms.Padding(4);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(132, 28);
            this.btnUpdate.TabIndex = 25;
            this.btnUpdate.Text = "Save Screen";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // tbScreen
            // 
            this.tbScreen.Location = new System.Drawing.Point(24, 425);
            this.tbScreen.Margin = new System.Windows.Forms.Padding(4);
            this.tbScreen.Multiline = true;
            this.tbScreen.Name = "tbScreen";
            this.tbScreen.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbScreen.Size = new System.Drawing.Size(700, 98);
            this.tbScreen.TabIndex = 24;
            this.tbScreen.WordWrap = false;
            // 
            // lblExpenseTypeID
            // 
            this.lblExpenseTypeID.AutoSize = true;
            this.lblExpenseTypeID.Location = new System.Drawing.Point(21, 17);
            this.lblExpenseTypeID.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblExpenseTypeID.Name = "lblExpenseTypeID";
            this.lblExpenseTypeID.Size = new System.Drawing.Size(111, 17);
            this.lblExpenseTypeID.TabIndex = 23;
            this.lblExpenseTypeID.Text = "ExpenseTypeID:";
            // 
            // tbExpenseTypeID
            // 
            this.tbExpenseTypeID.Location = new System.Drawing.Point(140, 14);
            this.tbExpenseTypeID.Margin = new System.Windows.Forms.Padding(4);
            this.tbExpenseTypeID.Name = "tbExpenseTypeID";
            this.tbExpenseTypeID.Size = new System.Drawing.Size(76, 22);
            this.tbExpenseTypeID.TabIndex = 22;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(745, 532);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.Screen);
            this.Controls.Add(this.lblScreenXML);
            this.Controls.Add(this.gvScreen);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.tbScreen);
            this.Controls.Add(this.lblExpenseTypeID);
            this.Controls.Add(this.tbExpenseTypeID);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.gvScreen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pJEXPTYPBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Label Screen;
        private System.Windows.Forms.Label lblScreenXML;
        private System.Windows.Forms.DataGridView gvScreen;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.TextBox tbScreen;
        private System.Windows.Forms.Label lblExpenseTypeID;
        public System.Windows.Forms.TextBox tbExpenseTypeID;
        private System.Windows.Forms.BindingSource pJEXPTYPBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn EXP_TYPE;
        private System.Windows.Forms.DataGridViewTextBoxColumn defaultrateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn descexpDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn crtddatetimeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn crtdprogDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn crtduserDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn exid01DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn exid02DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn exid03DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn exid04DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn exid05DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn exid06DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn exid07DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn exid08DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn exid09DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn exid10DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn glacctDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lupddatetimeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lupdprogDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lupduserDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn noteIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn statusDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn taxflagDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn taxidDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn unitsflagDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn user1DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn user2DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn user3DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn user4DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn errorMessageDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn resultCodeDataGridViewTextBoxColumn;
    }
}

