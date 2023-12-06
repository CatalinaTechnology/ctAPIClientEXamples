namespace client.fieldService.serviceDispatch.input.serviceCallEntry
{
    partial class serviceCallsPopup
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
            this.gvServiceCalls = new System.Windows.Forms.DataGridView();
            this.smServFaultBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.errorMessageDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.resultCodeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contractIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.crtdDateTimeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.crtdProgDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.crtdUserDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.durationDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.endDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.endTimeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lupdDateTimeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lupdProgDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lupdUserDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.noteIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.notesDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pMCodeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.startDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.startTimeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.user5DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.user6DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.user7DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.user8DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.user9DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.smServCallBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.gvServiceCalls)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.smServFaultBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.smServCallBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // gvServiceCalls
            // 
            this.gvServiceCalls.AllowUserToAddRows = false;
            this.gvServiceCalls.AllowUserToDeleteRows = false;
            this.gvServiceCalls.AllowUserToOrderColumns = true;
            this.gvServiceCalls.AutoGenerateColumns = false;
            this.gvServiceCalls.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvServiceCalls.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.errorMessageDataGridViewTextBoxColumn,
            this.resultCodeDataGridViewTextBoxColumn,
            this.contractIDDataGridViewTextBoxColumn,
            this.crtdDateTimeDataGridViewTextBoxColumn,
            this.crtdProgDataGridViewTextBoxColumn,
            this.crtdUserDataGridViewTextBoxColumn,
            this.durationDataGridViewTextBoxColumn,
            this.endDateDataGridViewTextBoxColumn,
            this.endTimeDataGridViewTextBoxColumn,
            this.lupdDateTimeDataGridViewTextBoxColumn,
            this.lupdProgDataGridViewTextBoxColumn,
            this.lupdUserDataGridViewTextBoxColumn,
            this.noteIDDataGridViewTextBoxColumn,
            this.notesDataGridViewTextBoxColumn,
            this.pMCodeDataGridViewTextBoxColumn,
            this.startDateDataGridViewTextBoxColumn,
            this.startTimeDataGridViewTextBoxColumn,
            this.user5DataGridViewTextBoxColumn,
            this.user6DataGridViewTextBoxColumn,
            this.user7DataGridViewTextBoxColumn,
            this.user8DataGridViewTextBoxColumn,
            this.user9DataGridViewTextBoxColumn});
            this.gvServiceCalls.DataSource = this.smServCallBindingSource;
            this.gvServiceCalls.Location = new System.Drawing.Point(32, 38);
            this.gvServiceCalls.Name = "gvServiceCalls";
            this.gvServiceCalls.ReadOnly = true;
            this.gvServiceCalls.Size = new System.Drawing.Size(505, 279);
            this.gvServiceCalls.TabIndex = 0;
            this.gvServiceCalls.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvServiceCalls_CellContentClick);
            // 
            // smServFaultBindingSource
            // 
            this.smServFaultBindingSource.DataSource = typeof(client.fieldService.serviceDispatch.input.serviceCallEntry.ctDynamicsSL.fieldService.serviceDispatch.input.serviceCallEntry.smServFault);
            // 
            // errorMessageDataGridViewTextBoxColumn
            // 
            this.errorMessageDataGridViewTextBoxColumn.DataPropertyName = "errorMessage";
            this.errorMessageDataGridViewTextBoxColumn.HeaderText = "errorMessage";
            this.errorMessageDataGridViewTextBoxColumn.Name = "errorMessageDataGridViewTextBoxColumn";
            this.errorMessageDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // resultCodeDataGridViewTextBoxColumn
            // 
            this.resultCodeDataGridViewTextBoxColumn.DataPropertyName = "resultCode";
            this.resultCodeDataGridViewTextBoxColumn.HeaderText = "resultCode";
            this.resultCodeDataGridViewTextBoxColumn.Name = "resultCodeDataGridViewTextBoxColumn";
            this.resultCodeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // contractIDDataGridViewTextBoxColumn
            // 
            this.contractIDDataGridViewTextBoxColumn.DataPropertyName = "ContractID";
            this.contractIDDataGridViewTextBoxColumn.HeaderText = "ContractID";
            this.contractIDDataGridViewTextBoxColumn.Name = "contractIDDataGridViewTextBoxColumn";
            this.contractIDDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // crtdDateTimeDataGridViewTextBoxColumn
            // 
            this.crtdDateTimeDataGridViewTextBoxColumn.DataPropertyName = "Crtd_DateTime";
            this.crtdDateTimeDataGridViewTextBoxColumn.HeaderText = "Crtd_DateTime";
            this.crtdDateTimeDataGridViewTextBoxColumn.Name = "crtdDateTimeDataGridViewTextBoxColumn";
            this.crtdDateTimeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // crtdProgDataGridViewTextBoxColumn
            // 
            this.crtdProgDataGridViewTextBoxColumn.DataPropertyName = "Crtd_Prog";
            this.crtdProgDataGridViewTextBoxColumn.HeaderText = "Crtd_Prog";
            this.crtdProgDataGridViewTextBoxColumn.Name = "crtdProgDataGridViewTextBoxColumn";
            this.crtdProgDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // crtdUserDataGridViewTextBoxColumn
            // 
            this.crtdUserDataGridViewTextBoxColumn.DataPropertyName = "Crtd_User";
            this.crtdUserDataGridViewTextBoxColumn.HeaderText = "Crtd_User";
            this.crtdUserDataGridViewTextBoxColumn.Name = "crtdUserDataGridViewTextBoxColumn";
            this.crtdUserDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // durationDataGridViewTextBoxColumn
            // 
            this.durationDataGridViewTextBoxColumn.DataPropertyName = "Duration";
            this.durationDataGridViewTextBoxColumn.HeaderText = "Duration";
            this.durationDataGridViewTextBoxColumn.Name = "durationDataGridViewTextBoxColumn";
            this.durationDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // endDateDataGridViewTextBoxColumn
            // 
            this.endDateDataGridViewTextBoxColumn.DataPropertyName = "EndDate";
            this.endDateDataGridViewTextBoxColumn.HeaderText = "EndDate";
            this.endDateDataGridViewTextBoxColumn.Name = "endDateDataGridViewTextBoxColumn";
            this.endDateDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // endTimeDataGridViewTextBoxColumn
            // 
            this.endTimeDataGridViewTextBoxColumn.DataPropertyName = "EndTime";
            this.endTimeDataGridViewTextBoxColumn.HeaderText = "EndTime";
            this.endTimeDataGridViewTextBoxColumn.Name = "endTimeDataGridViewTextBoxColumn";
            this.endTimeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // lupdDateTimeDataGridViewTextBoxColumn
            // 
            this.lupdDateTimeDataGridViewTextBoxColumn.DataPropertyName = "Lupd_DateTime";
            this.lupdDateTimeDataGridViewTextBoxColumn.HeaderText = "Lupd_DateTime";
            this.lupdDateTimeDataGridViewTextBoxColumn.Name = "lupdDateTimeDataGridViewTextBoxColumn";
            this.lupdDateTimeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // lupdProgDataGridViewTextBoxColumn
            // 
            this.lupdProgDataGridViewTextBoxColumn.DataPropertyName = "Lupd_Prog";
            this.lupdProgDataGridViewTextBoxColumn.HeaderText = "Lupd_Prog";
            this.lupdProgDataGridViewTextBoxColumn.Name = "lupdProgDataGridViewTextBoxColumn";
            this.lupdProgDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // lupdUserDataGridViewTextBoxColumn
            // 
            this.lupdUserDataGridViewTextBoxColumn.DataPropertyName = "Lupd_User";
            this.lupdUserDataGridViewTextBoxColumn.HeaderText = "Lupd_User";
            this.lupdUserDataGridViewTextBoxColumn.Name = "lupdUserDataGridViewTextBoxColumn";
            this.lupdUserDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // noteIDDataGridViewTextBoxColumn
            // 
            this.noteIDDataGridViewTextBoxColumn.DataPropertyName = "NoteID";
            this.noteIDDataGridViewTextBoxColumn.HeaderText = "NoteID";
            this.noteIDDataGridViewTextBoxColumn.Name = "noteIDDataGridViewTextBoxColumn";
            this.noteIDDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // notesDataGridViewTextBoxColumn
            // 
            this.notesDataGridViewTextBoxColumn.DataPropertyName = "Notes";
            this.notesDataGridViewTextBoxColumn.HeaderText = "Notes";
            this.notesDataGridViewTextBoxColumn.Name = "notesDataGridViewTextBoxColumn";
            this.notesDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // pMCodeDataGridViewTextBoxColumn
            // 
            this.pMCodeDataGridViewTextBoxColumn.DataPropertyName = "PMCode";
            this.pMCodeDataGridViewTextBoxColumn.HeaderText = "PMCode";
            this.pMCodeDataGridViewTextBoxColumn.Name = "pMCodeDataGridViewTextBoxColumn";
            this.pMCodeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // startDateDataGridViewTextBoxColumn
            // 
            this.startDateDataGridViewTextBoxColumn.DataPropertyName = "StartDate";
            this.startDateDataGridViewTextBoxColumn.HeaderText = "StartDate";
            this.startDateDataGridViewTextBoxColumn.Name = "startDateDataGridViewTextBoxColumn";
            this.startDateDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // startTimeDataGridViewTextBoxColumn
            // 
            this.startTimeDataGridViewTextBoxColumn.DataPropertyName = "StartTime";
            this.startTimeDataGridViewTextBoxColumn.HeaderText = "StartTime";
            this.startTimeDataGridViewTextBoxColumn.Name = "startTimeDataGridViewTextBoxColumn";
            this.startTimeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // user5DataGridViewTextBoxColumn
            // 
            this.user5DataGridViewTextBoxColumn.DataPropertyName = "User5";
            this.user5DataGridViewTextBoxColumn.HeaderText = "User5";
            this.user5DataGridViewTextBoxColumn.Name = "user5DataGridViewTextBoxColumn";
            this.user5DataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // user6DataGridViewTextBoxColumn
            // 
            this.user6DataGridViewTextBoxColumn.DataPropertyName = "User6";
            this.user6DataGridViewTextBoxColumn.HeaderText = "User6";
            this.user6DataGridViewTextBoxColumn.Name = "user6DataGridViewTextBoxColumn";
            this.user6DataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // user7DataGridViewTextBoxColumn
            // 
            this.user7DataGridViewTextBoxColumn.DataPropertyName = "User7";
            this.user7DataGridViewTextBoxColumn.HeaderText = "User7";
            this.user7DataGridViewTextBoxColumn.Name = "user7DataGridViewTextBoxColumn";
            this.user7DataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // user8DataGridViewTextBoxColumn
            // 
            this.user8DataGridViewTextBoxColumn.DataPropertyName = "User8";
            this.user8DataGridViewTextBoxColumn.HeaderText = "User8";
            this.user8DataGridViewTextBoxColumn.Name = "user8DataGridViewTextBoxColumn";
            this.user8DataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // user9DataGridViewTextBoxColumn
            // 
            this.user9DataGridViewTextBoxColumn.DataPropertyName = "User9";
            this.user9DataGridViewTextBoxColumn.HeaderText = "User9";
            this.user9DataGridViewTextBoxColumn.Name = "user9DataGridViewTextBoxColumn";
            this.user9DataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // smServCallBindingSource
            // 
            this.smServCallBindingSource.DataSource = typeof(client.fieldService.serviceDispatch.input.serviceCallEntry.ctDynamicsSL.fieldService.serviceDispatch.input.serviceCallEntry.smServCall);
            // 
            // serviceCallsPopup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(566, 342);
            this.Controls.Add(this.gvServiceCalls);
            this.Name = "serviceCallsPopup";
            this.Text = "serviceCallsPopup";
            ((System.ComponentModel.ISupportInitialize)(this.gvServiceCalls)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.smServFaultBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.smServCallBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView gvServiceCalls;
        private System.Windows.Forms.DataGridViewTextBoxColumn errorMessageDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn resultCodeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn contractIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn crtdDateTimeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn crtdProgDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn crtdUserDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn durationDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn endDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn endTimeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lupdDateTimeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lupdProgDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lupdUserDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn noteIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn notesDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn pMCodeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn startDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn startTimeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn user5DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn user6DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn user7DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn user8DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn user9DataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource smServCallBindingSource;
        private System.Windows.Forms.BindingSource smServFaultBindingSource;
    }
}