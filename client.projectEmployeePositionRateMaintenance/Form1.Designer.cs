namespace client.project.timeAndExpense.maintenance.projectEmployeePositionRateMaintenance
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
            this.lblScreen = new System.Windows.Forms.Label();
            this.tbScreen = new System.Windows.Forms.TextBox();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.lblEmployee = new System.Windows.Forms.Label();
            this.btnLoad = new System.Windows.Forms.Button();
            this.tbEmployee = new System.Windows.Forms.TextBox();
            this.btnPVs = new System.Windows.Forms.Button();
            this.lblPJEMPPJT = new System.Windows.Forms.Label();
            this.gvPJEMPPJT = new System.Windows.Forms.DataGridView();
            this.pJEMPPJTBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.employeeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.projectDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.effectdateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.laborclasscdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.laborrateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.notesDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.crtddatetimeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.crtdprogDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.crtduserDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.epid01DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.epid02DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.epid03DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.epid04DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.epid05DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.epid06DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.epid07DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.epid08DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.epid09DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.epid10DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lupddatetimeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lupdprogDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lupduserDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.noteidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.user1DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.user2DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.user3DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.user4DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.errorMessageDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.resultCodeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gvPJEMPPJT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pJEMPPJTBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // lblScreen
            // 
            this.lblScreen.AutoSize = true;
            this.lblScreen.Location = new System.Drawing.Point(10, 379);
            this.lblScreen.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblScreen.Name = "lblScreen";
            this.lblScreen.Size = new System.Drawing.Size(117, 17);
            this.lblScreen.TabIndex = 26;
            this.lblScreen.Text = "myScreen (XML):";
            // 
            // tbScreen
            // 
            this.tbScreen.Location = new System.Drawing.Point(13, 400);
            this.tbScreen.Margin = new System.Windows.Forms.Padding(4);
            this.tbScreen.Multiline = true;
            this.tbScreen.Name = "tbScreen";
            this.tbScreen.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbScreen.Size = new System.Drawing.Size(830, 134);
            this.tbScreen.TabIndex = 25;
            this.tbScreen.WordWrap = false;
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(575, 19);
            this.btnNew.Margin = new System.Windows.Forms.Padding(4);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(100, 25);
            this.btnNew.TabIndex = 24;
            this.btnNew.Text = "Create New";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(251, 19);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(4);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(100, 25);
            this.btnSearch.TabIndex = 23;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Enabled = false;
            this.btnUpdate.Location = new System.Drawing.Point(467, 19);
            this.btnUpdate.Margin = new System.Windows.Forms.Padding(4);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(100, 25);
            this.btnUpdate.TabIndex = 22;
            this.btnUpdate.Text = "Save";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // lblEmployee
            // 
            this.lblEmployee.AutoSize = true;
            this.lblEmployee.Location = new System.Drawing.Point(6, 22);
            this.lblEmployee.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblEmployee.Name = "lblEmployee";
            this.lblEmployee.Size = new System.Drawing.Size(74, 17);
            this.lblEmployee.TabIndex = 21;
            this.lblEmployee.Text = "Employee:";
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(359, 19);
            this.btnLoad.Margin = new System.Windows.Forms.Padding(4);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(100, 25);
            this.btnLoad.TabIndex = 20;
            this.btnLoad.Text = "Load";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // tbEmployee
            // 
            this.tbEmployee.Location = new System.Drawing.Point(87, 19);
            this.tbEmployee.Name = "tbEmployee";
            this.tbEmployee.Size = new System.Drawing.Size(157, 22);
            this.tbEmployee.TabIndex = 19;
            // 
            // btnPVs
            // 
            this.btnPVs.Location = new System.Drawing.Point(698, 19);
            this.btnPVs.Name = "btnPVs";
            this.btnPVs.Size = new System.Drawing.Size(132, 25);
            this.btnPVs.TabIndex = 18;
            this.btnPVs.Text = "Test all PVs";
            this.btnPVs.UseVisualStyleBackColor = true;
            this.btnPVs.Click += new System.EventHandler(this.btnPVs_Click);
            // 
            // lblPJEMPPJT
            // 
            this.lblPJEMPPJT.AutoSize = true;
            this.lblPJEMPPJT.Location = new System.Drawing.Point(9, 73);
            this.lblPJEMPPJT.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPJEMPPJT.Name = "lblPJEMPPJT";
            this.lblPJEMPPJT.Size = new System.Drawing.Size(104, 17);
            this.lblPJEMPPJT.TabIndex = 30;
            this.lblPJEMPPJT.Text = "myPJEMPPJT[]";
            // 
            // gvPJEMPPJT
            // 
            this.gvPJEMPPJT.AllowUserToDeleteRows = false;
            this.gvPJEMPPJT.AllowUserToOrderColumns = true;
            this.gvPJEMPPJT.AutoGenerateColumns = false;
            this.gvPJEMPPJT.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvPJEMPPJT.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.employeeDataGridViewTextBoxColumn,
            this.projectDataGridViewTextBoxColumn,
            this.effectdateDataGridViewTextBoxColumn,
            this.laborclasscdDataGridViewTextBoxColumn,
            this.laborrateDataGridViewTextBoxColumn,
            this.notesDataGridViewTextBoxColumn,
            this.crtddatetimeDataGridViewTextBoxColumn,
            this.crtdprogDataGridViewTextBoxColumn,
            this.crtduserDataGridViewTextBoxColumn,
            this.epid01DataGridViewTextBoxColumn,
            this.epid02DataGridViewTextBoxColumn,
            this.epid03DataGridViewTextBoxColumn,
            this.epid04DataGridViewTextBoxColumn,
            this.epid05DataGridViewTextBoxColumn,
            this.epid06DataGridViewTextBoxColumn,
            this.epid07DataGridViewTextBoxColumn,
            this.epid08DataGridViewTextBoxColumn,
            this.epid09DataGridViewTextBoxColumn,
            this.epid10DataGridViewTextBoxColumn,
            this.lupddatetimeDataGridViewTextBoxColumn,
            this.lupdprogDataGridViewTextBoxColumn,
            this.lupduserDataGridViewTextBoxColumn,
            this.noteidDataGridViewTextBoxColumn,
            this.user1DataGridViewTextBoxColumn,
            this.user2DataGridViewTextBoxColumn,
            this.user3DataGridViewTextBoxColumn,
            this.user4DataGridViewTextBoxColumn,
            this.errorMessageDataGridViewTextBoxColumn,
            this.resultCodeDataGridViewTextBoxColumn});
            this.gvPJEMPPJT.DataSource = this.pJEMPPJTBindingSource;
            this.gvPJEMPPJT.Location = new System.Drawing.Point(13, 93);
            this.gvPJEMPPJT.Margin = new System.Windows.Forms.Padding(4);
            this.gvPJEMPPJT.Name = "gvPJEMPPJT";
            this.gvPJEMPPJT.Size = new System.Drawing.Size(830, 242);
            this.gvPJEMPPJT.TabIndex = 29;
            // 
            // pJEMPPJTBindingSource
            // 
            this.pJEMPPJTBindingSource.DataSource = typeof(client.project.timeAndExpense.maintenance.projectEmployeePositionRateMaintenance.ctDynamicsSL.project.timeAndExpense.maintenance.projectEmployeePositionRateMaintenance.PJEMPPJT);
            // 
            // employeeDataGridViewTextBoxColumn
            // 
            this.employeeDataGridViewTextBoxColumn.DataPropertyName = "employee";
            this.employeeDataGridViewTextBoxColumn.HeaderText = "employee";
            this.employeeDataGridViewTextBoxColumn.Name = "employeeDataGridViewTextBoxColumn";
            // 
            // projectDataGridViewTextBoxColumn
            // 
            this.projectDataGridViewTextBoxColumn.DataPropertyName = "project";
            this.projectDataGridViewTextBoxColumn.HeaderText = "project";
            this.projectDataGridViewTextBoxColumn.Name = "projectDataGridViewTextBoxColumn";
            // 
            // effectdateDataGridViewTextBoxColumn
            // 
            this.effectdateDataGridViewTextBoxColumn.DataPropertyName = "effect_date";
            this.effectdateDataGridViewTextBoxColumn.HeaderText = "effect_date";
            this.effectdateDataGridViewTextBoxColumn.Name = "effectdateDataGridViewTextBoxColumn";
            // 
            // laborclasscdDataGridViewTextBoxColumn
            // 
            this.laborclasscdDataGridViewTextBoxColumn.DataPropertyName = "labor_class_cd";
            this.laborclasscdDataGridViewTextBoxColumn.HeaderText = "labor_class_cd";
            this.laborclasscdDataGridViewTextBoxColumn.Name = "laborclasscdDataGridViewTextBoxColumn";
            // 
            // laborrateDataGridViewTextBoxColumn
            // 
            this.laborrateDataGridViewTextBoxColumn.DataPropertyName = "labor_rate";
            this.laborrateDataGridViewTextBoxColumn.HeaderText = "labor_rate";
            this.laborrateDataGridViewTextBoxColumn.Name = "laborrateDataGridViewTextBoxColumn";
            // 
            // notesDataGridViewTextBoxColumn
            // 
            this.notesDataGridViewTextBoxColumn.DataPropertyName = "notes";
            this.notesDataGridViewTextBoxColumn.HeaderText = "notes";
            this.notesDataGridViewTextBoxColumn.Name = "notesDataGridViewTextBoxColumn";
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
            // epid01DataGridViewTextBoxColumn
            // 
            this.epid01DataGridViewTextBoxColumn.DataPropertyName = "ep_id01";
            this.epid01DataGridViewTextBoxColumn.HeaderText = "ep_id01";
            this.epid01DataGridViewTextBoxColumn.Name = "epid01DataGridViewTextBoxColumn";
            // 
            // epid02DataGridViewTextBoxColumn
            // 
            this.epid02DataGridViewTextBoxColumn.DataPropertyName = "ep_id02";
            this.epid02DataGridViewTextBoxColumn.HeaderText = "ep_id02";
            this.epid02DataGridViewTextBoxColumn.Name = "epid02DataGridViewTextBoxColumn";
            // 
            // epid03DataGridViewTextBoxColumn
            // 
            this.epid03DataGridViewTextBoxColumn.DataPropertyName = "ep_id03";
            this.epid03DataGridViewTextBoxColumn.HeaderText = "ep_id03";
            this.epid03DataGridViewTextBoxColumn.Name = "epid03DataGridViewTextBoxColumn";
            // 
            // epid04DataGridViewTextBoxColumn
            // 
            this.epid04DataGridViewTextBoxColumn.DataPropertyName = "ep_id04";
            this.epid04DataGridViewTextBoxColumn.HeaderText = "ep_id04";
            this.epid04DataGridViewTextBoxColumn.Name = "epid04DataGridViewTextBoxColumn";
            // 
            // epid05DataGridViewTextBoxColumn
            // 
            this.epid05DataGridViewTextBoxColumn.DataPropertyName = "ep_id05";
            this.epid05DataGridViewTextBoxColumn.HeaderText = "ep_id05";
            this.epid05DataGridViewTextBoxColumn.Name = "epid05DataGridViewTextBoxColumn";
            // 
            // epid06DataGridViewTextBoxColumn
            // 
            this.epid06DataGridViewTextBoxColumn.DataPropertyName = "ep_id06";
            this.epid06DataGridViewTextBoxColumn.HeaderText = "ep_id06";
            this.epid06DataGridViewTextBoxColumn.Name = "epid06DataGridViewTextBoxColumn";
            // 
            // epid07DataGridViewTextBoxColumn
            // 
            this.epid07DataGridViewTextBoxColumn.DataPropertyName = "ep_id07";
            this.epid07DataGridViewTextBoxColumn.HeaderText = "ep_id07";
            this.epid07DataGridViewTextBoxColumn.Name = "epid07DataGridViewTextBoxColumn";
            // 
            // epid08DataGridViewTextBoxColumn
            // 
            this.epid08DataGridViewTextBoxColumn.DataPropertyName = "ep_id08";
            this.epid08DataGridViewTextBoxColumn.HeaderText = "ep_id08";
            this.epid08DataGridViewTextBoxColumn.Name = "epid08DataGridViewTextBoxColumn";
            // 
            // epid09DataGridViewTextBoxColumn
            // 
            this.epid09DataGridViewTextBoxColumn.DataPropertyName = "ep_id09";
            this.epid09DataGridViewTextBoxColumn.HeaderText = "ep_id09";
            this.epid09DataGridViewTextBoxColumn.Name = "epid09DataGridViewTextBoxColumn";
            // 
            // epid10DataGridViewTextBoxColumn
            // 
            this.epid10DataGridViewTextBoxColumn.DataPropertyName = "ep_id10";
            this.epid10DataGridViewTextBoxColumn.HeaderText = "ep_id10";
            this.epid10DataGridViewTextBoxColumn.Name = "epid10DataGridViewTextBoxColumn";
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
            // noteidDataGridViewTextBoxColumn
            // 
            this.noteidDataGridViewTextBoxColumn.DataPropertyName = "noteid";
            this.noteidDataGridViewTextBoxColumn.HeaderText = "noteid";
            this.noteidDataGridViewTextBoxColumn.Name = "noteidDataGridViewTextBoxColumn";
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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(864, 598);
            this.Controls.Add(this.lblPJEMPPJT);
            this.Controls.Add(this.gvPJEMPPJT);
            this.Controls.Add(this.lblScreen);
            this.Controls.Add(this.tbScreen);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.lblEmployee);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.tbEmployee);
            this.Controls.Add(this.btnPVs);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.gvPJEMPPJT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pJEMPPJTBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblScreen;
        private System.Windows.Forms.TextBox tbScreen;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Label lblEmployee;
        public System.Windows.Forms.Button btnLoad;
        public System.Windows.Forms.TextBox tbEmployee;
        private System.Windows.Forms.Button btnPVs;
        private System.Windows.Forms.Label lblPJEMPPJT;
        private System.Windows.Forms.DataGridView gvPJEMPPJT;
        private System.Windows.Forms.BindingSource pJEMPPJTBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn employeeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn projectDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn effectdateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn laborclasscdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn laborrateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn notesDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn crtddatetimeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn crtdprogDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn crtduserDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn epid01DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn epid02DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn epid03DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn epid04DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn epid05DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn epid06DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn epid07DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn epid08DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn epid09DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn epid10DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lupddatetimeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lupdprogDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lupduserDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn noteidDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn user1DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn user2DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn user3DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn user4DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn errorMessageDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn resultCodeDataGridViewTextBoxColumn;
    }
}

