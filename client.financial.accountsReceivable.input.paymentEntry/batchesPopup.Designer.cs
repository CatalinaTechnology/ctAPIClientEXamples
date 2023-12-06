namespace client.financial.accountsReceivable.input.paymentEntry
{
    partial class batchesPopup
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
            this.gvBatches = new System.Windows.Forms.DataGridView();
            this.batchBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.BatNbr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CpnyID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Crtd_DateTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CrTot = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gvBatches)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.batchBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // gvBatches
            // 
            this.gvBatches.AllowUserToAddRows = false;
            this.gvBatches.AllowUserToDeleteRows = false;
            this.gvBatches.AutoGenerateColumns = false;
            this.gvBatches.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvBatches.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.BatNbr,
            this.CpnyID,
            this.Crtd_DateTime,
            this.CrTot,
            this.Status});
            this.gvBatches.DataSource = this.batchBindingSource;
            this.gvBatches.Location = new System.Drawing.Point(32, 38);
            this.gvBatches.Name = "gvBatches";
            this.gvBatches.ReadOnly = true;
            this.gvBatches.Size = new System.Drawing.Size(505, 279);
            this.gvBatches.TabIndex = 0;
            this.gvBatches.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvBatches_CellContentClick);
            // 
            // batchBindingSource
            // 
            this.batchBindingSource.DataSource = typeof(client.financial.accountsReceivable.input.paymentEntry.ctDynamicsSL.financial.accountsReceivable.input.paymentEntry.Batch);
            // 
            // BatNbr
            // 
            this.BatNbr.DataPropertyName = "BatNbr";
            this.BatNbr.HeaderText = "BatNbr";
            this.BatNbr.Name = "BatNbr";
            this.BatNbr.ReadOnly = true;
            // 
            // CpnyID
            // 
            this.CpnyID.DataPropertyName = "CpnyID";
            this.CpnyID.HeaderText = "CpnyID";
            this.CpnyID.Name = "CpnyID";
            this.CpnyID.ReadOnly = true;
            // 
            // Crtd_DateTime
            // 
            this.Crtd_DateTime.DataPropertyName = "Crtd_DateTime";
            this.Crtd_DateTime.HeaderText = "Crtd_DateTime";
            this.Crtd_DateTime.Name = "Crtd_DateTime";
            this.Crtd_DateTime.ReadOnly = true;
            // 
            // CrTot
            // 
            this.CrTot.DataPropertyName = "CrTot";
            this.CrTot.HeaderText = "CrTot";
            this.CrTot.Name = "CrTot";
            this.CrTot.ReadOnly = true;
            // 
            // Status
            // 
            this.Status.DataPropertyName = "Status";
            this.Status.HeaderText = "Status";
            this.Status.Name = "Status";
            this.Status.ReadOnly = true;
            // 
            // batchesPopup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(566, 342);
            this.Controls.Add(this.gvBatches);
            this.Name = "batchesPopup";
            this.Text = "batchesPopup";
            ((System.ComponentModel.ISupportInitialize)(this.gvBatches)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.batchBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView gvBatches;
        private System.Windows.Forms.DataGridViewTextBoxColumn BatNbr;
        private System.Windows.Forms.DataGridViewTextBoxColumn CpnyID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Crtd_DateTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn CrTot;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status;
        private System.Windows.Forms.BindingSource batchBindingSource;
    }
}