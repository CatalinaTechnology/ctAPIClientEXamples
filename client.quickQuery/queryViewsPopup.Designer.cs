namespace client.ctDynamicsSL.quickQuery
{
    partial class queryViewsPopup
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
            this.gvQueries = new System.Windows.Forms.DataGridView();
            this.vsqvcatalogBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.QueryViewName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sQLViewDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.errorMessageDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.resultCodeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.baseQueryViewDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.moduleDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.viewDescriptionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.viewFilterDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.viewSortDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnsRemovedMovedDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.drillProgramsDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.visibilityTypeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.visibilityDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.systemDatabaseDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.companyColumnDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.companyParmsDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.noteColumnsDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.createdByDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gvQueries)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vsqvcatalogBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // gvQueries
            // 
            this.gvQueries.AllowUserToAddRows = false;
            this.gvQueries.AllowUserToDeleteRows = false;
            this.gvQueries.AllowUserToOrderColumns = true;
            this.gvQueries.AutoGenerateColumns = false;
            this.gvQueries.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvQueries.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.QueryViewName,
            this.sQLViewDataGridViewTextBoxColumn,
            this.errorMessageDataGridViewTextBoxColumn,
            this.resultCodeDataGridViewTextBoxColumn,
            this.baseQueryViewDataGridViewTextBoxColumn,
            this.moduleDataGridViewTextBoxColumn,
            this.numberDataGridViewTextBoxColumn,
            this.viewDescriptionDataGridViewTextBoxColumn,
            this.viewFilterDataGridViewTextBoxColumn,
            this.viewSortDataGridViewTextBoxColumn,
            this.columnsRemovedMovedDataGridViewTextBoxColumn,
            this.drillProgramsDataGridViewTextBoxColumn,
            this.visibilityTypeDataGridViewTextBoxColumn,
            this.visibilityDataGridViewTextBoxColumn,
            this.systemDatabaseDataGridViewTextBoxColumn,
            this.companyColumnDataGridViewTextBoxColumn,
            this.companyParmsDataGridViewTextBoxColumn,
            this.noteColumnsDataGridViewTextBoxColumn,
            this.createdByDataGridViewTextBoxColumn});
            this.gvQueries.DataSource = this.vsqvcatalogBindingSource;
            this.gvQueries.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gvQueries.Location = new System.Drawing.Point(0, 0);
            this.gvQueries.Name = "gvQueries";
            this.gvQueries.ReadOnly = true;
            this.gvQueries.RowTemplate.Height = 24;
            this.gvQueries.Size = new System.Drawing.Size(755, 421);
            this.gvQueries.TabIndex = 0;
            this.gvQueries.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvQueries_CellDoubleClick);
            // 
            // vsqvcatalogBindingSource
            // 
            this.vsqvcatalogBindingSource.DataSource = typeof(client.ctDynamicsSL.quickQuery.ctDynamicsSL.quickQuery.vs_qvcatalog);
            // 
            // QueryViewName
            // 
            this.QueryViewName.DataPropertyName = "QueryViewName";
            this.QueryViewName.HeaderText = "QueryViewName";
            this.QueryViewName.Name = "QueryViewName";
            this.QueryViewName.ReadOnly = true;
            // 
            // sQLViewDataGridViewTextBoxColumn
            // 
            this.sQLViewDataGridViewTextBoxColumn.DataPropertyName = "SQLView";
            this.sQLViewDataGridViewTextBoxColumn.HeaderText = "SQLView";
            this.sQLViewDataGridViewTextBoxColumn.Name = "sQLViewDataGridViewTextBoxColumn";
            this.sQLViewDataGridViewTextBoxColumn.ReadOnly = true;
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
            // baseQueryViewDataGridViewTextBoxColumn
            // 
            this.baseQueryViewDataGridViewTextBoxColumn.DataPropertyName = "BaseQueryView";
            this.baseQueryViewDataGridViewTextBoxColumn.HeaderText = "BaseQueryView";
            this.baseQueryViewDataGridViewTextBoxColumn.Name = "baseQueryViewDataGridViewTextBoxColumn";
            this.baseQueryViewDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // moduleDataGridViewTextBoxColumn
            // 
            this.moduleDataGridViewTextBoxColumn.DataPropertyName = "Module";
            this.moduleDataGridViewTextBoxColumn.HeaderText = "Module";
            this.moduleDataGridViewTextBoxColumn.Name = "moduleDataGridViewTextBoxColumn";
            this.moduleDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // numberDataGridViewTextBoxColumn
            // 
            this.numberDataGridViewTextBoxColumn.DataPropertyName = "Number";
            this.numberDataGridViewTextBoxColumn.HeaderText = "Number";
            this.numberDataGridViewTextBoxColumn.Name = "numberDataGridViewTextBoxColumn";
            this.numberDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // viewDescriptionDataGridViewTextBoxColumn
            // 
            this.viewDescriptionDataGridViewTextBoxColumn.DataPropertyName = "ViewDescription";
            this.viewDescriptionDataGridViewTextBoxColumn.HeaderText = "ViewDescription";
            this.viewDescriptionDataGridViewTextBoxColumn.Name = "viewDescriptionDataGridViewTextBoxColumn";
            this.viewDescriptionDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // viewFilterDataGridViewTextBoxColumn
            // 
            this.viewFilterDataGridViewTextBoxColumn.DataPropertyName = "ViewFilter";
            this.viewFilterDataGridViewTextBoxColumn.HeaderText = "ViewFilter";
            this.viewFilterDataGridViewTextBoxColumn.Name = "viewFilterDataGridViewTextBoxColumn";
            this.viewFilterDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // viewSortDataGridViewTextBoxColumn
            // 
            this.viewSortDataGridViewTextBoxColumn.DataPropertyName = "ViewSort";
            this.viewSortDataGridViewTextBoxColumn.HeaderText = "ViewSort";
            this.viewSortDataGridViewTextBoxColumn.Name = "viewSortDataGridViewTextBoxColumn";
            this.viewSortDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // columnsRemovedMovedDataGridViewTextBoxColumn
            // 
            this.columnsRemovedMovedDataGridViewTextBoxColumn.DataPropertyName = "ColumnsRemovedMoved";
            this.columnsRemovedMovedDataGridViewTextBoxColumn.HeaderText = "ColumnsRemovedMoved";
            this.columnsRemovedMovedDataGridViewTextBoxColumn.Name = "columnsRemovedMovedDataGridViewTextBoxColumn";
            this.columnsRemovedMovedDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // drillProgramsDataGridViewTextBoxColumn
            // 
            this.drillProgramsDataGridViewTextBoxColumn.DataPropertyName = "DrillPrograms";
            this.drillProgramsDataGridViewTextBoxColumn.HeaderText = "DrillPrograms";
            this.drillProgramsDataGridViewTextBoxColumn.Name = "drillProgramsDataGridViewTextBoxColumn";
            this.drillProgramsDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // visibilityTypeDataGridViewTextBoxColumn
            // 
            this.visibilityTypeDataGridViewTextBoxColumn.DataPropertyName = "VisibilityType";
            this.visibilityTypeDataGridViewTextBoxColumn.HeaderText = "VisibilityType";
            this.visibilityTypeDataGridViewTextBoxColumn.Name = "visibilityTypeDataGridViewTextBoxColumn";
            this.visibilityTypeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // visibilityDataGridViewTextBoxColumn
            // 
            this.visibilityDataGridViewTextBoxColumn.DataPropertyName = "Visibility";
            this.visibilityDataGridViewTextBoxColumn.HeaderText = "Visibility";
            this.visibilityDataGridViewTextBoxColumn.Name = "visibilityDataGridViewTextBoxColumn";
            this.visibilityDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // systemDatabaseDataGridViewTextBoxColumn
            // 
            this.systemDatabaseDataGridViewTextBoxColumn.DataPropertyName = "SystemDatabase";
            this.systemDatabaseDataGridViewTextBoxColumn.HeaderText = "SystemDatabase";
            this.systemDatabaseDataGridViewTextBoxColumn.Name = "systemDatabaseDataGridViewTextBoxColumn";
            this.systemDatabaseDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // companyColumnDataGridViewTextBoxColumn
            // 
            this.companyColumnDataGridViewTextBoxColumn.DataPropertyName = "CompanyColumn";
            this.companyColumnDataGridViewTextBoxColumn.HeaderText = "CompanyColumn";
            this.companyColumnDataGridViewTextBoxColumn.Name = "companyColumnDataGridViewTextBoxColumn";
            this.companyColumnDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // companyParmsDataGridViewTextBoxColumn
            // 
            this.companyParmsDataGridViewTextBoxColumn.DataPropertyName = "CompanyParms";
            this.companyParmsDataGridViewTextBoxColumn.HeaderText = "CompanyParms";
            this.companyParmsDataGridViewTextBoxColumn.Name = "companyParmsDataGridViewTextBoxColumn";
            this.companyParmsDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // noteColumnsDataGridViewTextBoxColumn
            // 
            this.noteColumnsDataGridViewTextBoxColumn.DataPropertyName = "NoteColumns";
            this.noteColumnsDataGridViewTextBoxColumn.HeaderText = "NoteColumns";
            this.noteColumnsDataGridViewTextBoxColumn.Name = "noteColumnsDataGridViewTextBoxColumn";
            this.noteColumnsDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // createdByDataGridViewTextBoxColumn
            // 
            this.createdByDataGridViewTextBoxColumn.DataPropertyName = "CreatedBy";
            this.createdByDataGridViewTextBoxColumn.HeaderText = "CreatedBy";
            this.createdByDataGridViewTextBoxColumn.Name = "createdByDataGridViewTextBoxColumn";
            this.createdByDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // queryViewsPopup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(755, 421);
            this.Controls.Add(this.gvQueries);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "queryViewsPopup";
            this.Text = "queryViewsPopup";
            ((System.ComponentModel.ISupportInitialize)(this.gvQueries)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vsqvcatalogBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView gvQueries;
        private System.Windows.Forms.DataGridViewTextBoxColumn QueryViewName;
        private System.Windows.Forms.DataGridViewTextBoxColumn sQLViewDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn errorMessageDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn resultCodeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn baseQueryViewDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn moduleDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn numberDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn viewDescriptionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn viewFilterDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn viewSortDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnsRemovedMovedDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn drillProgramsDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn visibilityTypeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn visibilityDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn systemDatabaseDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn companyColumnDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn companyParmsDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn noteColumnsDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn createdByDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource vsqvcatalogBindingSource;
    }
}