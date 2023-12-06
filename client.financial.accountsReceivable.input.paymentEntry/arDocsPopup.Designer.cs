namespace client.financial.accountsReceivable.input.paymentEntry
{
    partial class arDocsPopup
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
            this.gvARDocs = new System.Windows.Forms.DataGridView();
            this.batchBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.customerBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.aRDocBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.RefNbr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BatNbr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DocDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CustId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.notes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProjectID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gvARDocs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.batchBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.customerBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.aRDocBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // gvARDocs
            // 
            this.gvARDocs.AllowUserToAddRows = false;
            this.gvARDocs.AllowUserToDeleteRows = false;
            this.gvARDocs.AllowUserToOrderColumns = true;
            this.gvARDocs.AutoGenerateColumns = false;
            this.gvARDocs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvARDocs.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.RefNbr,
            this.BatNbr,
            this.DocDate,
            this.CustId,
            this.notes,
            this.ProjectID});
            this.gvARDocs.DataSource = this.aRDocBindingSource;
            this.gvARDocs.Location = new System.Drawing.Point(32, 38);
            this.gvARDocs.Name = "gvARDocs";
            this.gvARDocs.ReadOnly = true;
            this.gvARDocs.Size = new System.Drawing.Size(505, 279);
            this.gvARDocs.TabIndex = 0;
            this.gvARDocs.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvARDocs_CellContentClick);
            // 
            // batchBindingSource
            // 
            this.batchBindingSource.DataSource = typeof(client.financial.accountsReceivable.input.paymentEntry.ctDynamicsSL.financial.accountsReceivable.input.paymentEntry.Batch);
            // 
            // customerBindingSource
            // 
            this.customerBindingSource.DataSource = typeof(client.financial.accountsReceivable.input.paymentEntry.ctDynamicsSL.financial.accountsReceivable.input.paymentEntry.customer);
            // 
            // aRDocBindingSource
            // 
            this.aRDocBindingSource.DataSource = typeof(client.financial.accountsReceivable.input.paymentEntry.ctDynamicsSL.financial.accountsReceivable.input.paymentEntry.ARDoc);
            // 
            // RefNbr
            // 
            this.RefNbr.DataPropertyName = "RefNbr";
            this.RefNbr.HeaderText = "RefNbr";
            this.RefNbr.Name = "RefNbr";
            this.RefNbr.ReadOnly = true;
            // 
            // BatNbr
            // 
            this.BatNbr.DataPropertyName = "BatNbr";
            this.BatNbr.HeaderText = "BatNbr";
            this.BatNbr.Name = "BatNbr";
            this.BatNbr.ReadOnly = true;
            // 
            // DocDate
            // 
            this.DocDate.DataPropertyName = "DocDate";
            this.DocDate.HeaderText = "DocDate";
            this.DocDate.Name = "DocDate";
            this.DocDate.ReadOnly = true;
            // 
            // CustId
            // 
            this.CustId.DataPropertyName = "CustId";
            this.CustId.HeaderText = "CustId";
            this.CustId.Name = "CustId";
            this.CustId.ReadOnly = true;
            // 
            // notes
            // 
            this.notes.DataPropertyName = "notes";
            this.notes.HeaderText = "notes";
            this.notes.Name = "notes";
            this.notes.ReadOnly = true;
            // 
            // ProjectID
            // 
            this.ProjectID.DataPropertyName = "ProjectID";
            this.ProjectID.HeaderText = "ProjectID";
            this.ProjectID.Name = "ProjectID";
            this.ProjectID.ReadOnly = true;
            // 
            // arDocsPopup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(566, 342);
            this.Controls.Add(this.gvARDocs);
            this.Name = "arDocsPopup";
            this.Text = "arDocsPopup";
            ((System.ComponentModel.ISupportInitialize)(this.gvARDocs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.batchBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.customerBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.aRDocBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView gvARDocs;
        private System.Windows.Forms.BindingSource batchBindingSource;
        private System.Windows.Forms.BindingSource aRDocBindingSource;
        private System.Windows.Forms.BindingSource customerBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn RefNbr;
        private System.Windows.Forms.DataGridViewTextBoxColumn BatNbr;
        private System.Windows.Forms.DataGridViewTextBoxColumn DocDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn CustId;
        private System.Windows.Forms.DataGridViewTextBoxColumn notes;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProjectID;
    }
}