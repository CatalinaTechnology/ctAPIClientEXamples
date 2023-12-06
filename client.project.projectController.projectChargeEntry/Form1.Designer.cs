namespace client.project.projectController.projectChargeEntry
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
            this.btnNew = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.lblPJCHARGD = new System.Windows.Forms.Label();
            this.lblScreen = new System.Windows.Forms.Label();
            this.gvPJCHARGD = new System.Windows.Forms.DataGridView();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.tbScreen = new System.Windows.Forms.TextBox();
            this.lblBatNbr = new System.Windows.Forms.Label();
            this.tbBatch_id = new System.Windows.Forms.TextBox();
            this.btnLoad = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gvPJCHARGD)).BeginInit();
            this.SuspendLayout();
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(312, 17);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(75, 23);
            this.btnNew.TabIndex = 30;
            this.btnNew.Text = "Create New";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(199, 16);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 29;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // lblPJCHARGD
            // 
            this.lblPJCHARGD.AutoSize = true;
            this.lblPJCHARGD.Location = new System.Drawing.Point(21, 89);
            this.lblPJCHARGD.Name = "lblPJCHARGD";
            this.lblPJCHARGD.Size = new System.Drawing.Size(87, 13);
            this.lblPJCHARGD.TabIndex = 28;
            this.lblPJCHARGD.Text = "myPJCHARGD[]:";
            // 
            // lblScreen
            // 
            this.lblScreen.AutoSize = true;
            this.lblScreen.Location = new System.Drawing.Point(21, 338);
            this.lblScreen.Name = "lblScreen";
            this.lblScreen.Size = new System.Drawing.Size(121, 13);
            this.lblScreen.TabIndex = 27;
            this.lblScreen.Text = "myProjectScreen (XML):";
            // 
            // gvPJCHARGD
            // 
            this.gvPJCHARGD.AllowUserToOrderColumns = true;
            this.gvPJCHARGD.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvPJCHARGD.Location = new System.Drawing.Point(24, 105);
            this.gvPJCHARGD.Name = "gvPJCHARGD";
            this.gvPJCHARGD.Size = new System.Drawing.Size(526, 197);
            this.gvPJCHARGD.TabIndex = 26;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Enabled = false;
            this.btnUpdate.Location = new System.Drawing.Point(199, 62);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnUpdate.TabIndex = 25;
            this.btnUpdate.Text = "Save";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // tbScreen
            // 
            this.tbScreen.Location = new System.Drawing.Point(24, 354);
            this.tbScreen.Multiline = true;
            this.tbScreen.Name = "tbScreen";
            this.tbScreen.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbScreen.Size = new System.Drawing.Size(526, 80);
            this.tbScreen.TabIndex = 24;
            this.tbScreen.WordWrap = false;
            // 
            // lblBatNbr
            // 
            this.lblBatNbr.AutoSize = true;
            this.lblBatNbr.Location = new System.Drawing.Point(24, 22);
            this.lblBatNbr.Name = "lblBatNbr";
            this.lblBatNbr.Size = new System.Drawing.Size(55, 13);
            this.lblBatNbr.TabIndex = 23;
            this.lblBatNbr.Text = "Batch Nbr";
            // 
            // tbBatch_id
            // 
            this.tbBatch_id.Location = new System.Drawing.Point(85, 19);
            this.tbBatch_id.Name = "tbBatch_id";
            this.tbBatch_id.Size = new System.Drawing.Size(100, 20);
            this.tbBatch_id.TabIndex = 22;
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(85, 62);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(75, 23);
            this.btnLoad.TabIndex = 21;
            this.btnLoad.Text = "Load Batch";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(673, 515);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.lblPJCHARGD);
            this.Controls.Add(this.lblScreen);
            this.Controls.Add(this.gvPJCHARGD);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.tbScreen);
            this.Controls.Add(this.lblBatNbr);
            this.Controls.Add(this.tbBatch_id);
            this.Controls.Add(this.btnLoad);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.gvPJCHARGD)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label lblPJCHARGD;
        private System.Windows.Forms.Label lblScreen;
        private System.Windows.Forms.DataGridView gvPJCHARGD;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.TextBox tbScreen;
        private System.Windows.Forms.Label lblBatNbr;
        public System.Windows.Forms.TextBox tbBatch_id;
        public System.Windows.Forms.Button btnLoad;
    }
}

