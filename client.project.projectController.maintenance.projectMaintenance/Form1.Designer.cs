namespace client.project.projectController.maintenance.projectMaintenance
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
            this.lblScreen = new System.Windows.Forms.Label();
            this.tbScreen = new System.Windows.Forms.TextBox();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.lblProject = new System.Windows.Forms.Label();
            this.btnLoad = new System.Windows.Forms.Button();
            this.tbProject = new System.Windows.Forms.TextBox();
            this.btnPVs = new System.Windows.Forms.Button();
            this.btnAddAddress = new System.Windows.Forms.Button();
            this.btnAddBillingInfo = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblScreen
            // 
            this.lblScreen.AutoSize = true;
            this.lblScreen.Location = new System.Drawing.Point(9, 88);
            this.lblScreen.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblScreen.Name = "lblScreen";
            this.lblScreen.Size = new System.Drawing.Size(117, 17);
            this.lblScreen.TabIndex = 26;
            this.lblScreen.Text = "myScreen (XML):";
            // 
            // tbScreen
            // 
            this.tbScreen.Location = new System.Drawing.Point(13, 107);
            this.tbScreen.Margin = new System.Windows.Forms.Padding(4);
            this.tbScreen.Multiline = true;
            this.tbScreen.Name = "tbScreen";
            this.tbScreen.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbScreen.Size = new System.Drawing.Size(830, 423);
            this.tbScreen.TabIndex = 25;
            this.tbScreen.WordWrap = false;
            this.tbScreen.TextChanged += new System.EventHandler(this.tbScreen_TextChanged);
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(575, 12);
            this.btnNew.Margin = new System.Windows.Forms.Padding(4);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(100, 28);
            this.btnNew.TabIndex = 24;
            this.btnNew.Text = "Create New";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(251, 12);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(4);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(100, 28);
            this.btnSearch.TabIndex = 23;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Enabled = false;
            this.btnUpdate.Location = new System.Drawing.Point(467, 12);
            this.btnUpdate.Margin = new System.Windows.Forms.Padding(4);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(100, 28);
            this.btnUpdate.TabIndex = 22;
            this.btnUpdate.Text = "Save";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // lblProject
            // 
            this.lblProject.AutoSize = true;
            this.lblProject.Location = new System.Drawing.Point(6, 18);
            this.lblProject.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblProject.Name = "lblProject";
            this.lblProject.Size = new System.Drawing.Size(56, 17);
            this.lblProject.TabIndex = 21;
            this.lblProject.Text = "Project:";
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(359, 12);
            this.btnLoad.Margin = new System.Windows.Forms.Padding(4);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(100, 28);
            this.btnLoad.TabIndex = 20;
            this.btnLoad.Text = "Load Project";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // tbProject
            // 
            this.tbProject.Location = new System.Drawing.Point(87, 15);
            this.tbProject.Name = "tbProject";
            this.tbProject.Size = new System.Drawing.Size(157, 22);
            this.tbProject.TabIndex = 19;
            // 
            // btnPVs
            // 
            this.btnPVs.Location = new System.Drawing.Point(698, 12);
            this.btnPVs.Name = "btnPVs";
            this.btnPVs.Size = new System.Drawing.Size(132, 28);
            this.btnPVs.TabIndex = 18;
            this.btnPVs.Text = "Test all PVs";
            this.btnPVs.UseVisualStyleBackColor = true;
            this.btnPVs.Click += new System.EventHandler(this.btnPVs_Click);
            // 
            // btnAddAddress
            // 
            this.btnAddAddress.Location = new System.Drawing.Point(251, 47);
            this.btnAddAddress.Name = "btnAddAddress";
            this.btnAddAddress.Size = new System.Drawing.Size(132, 30);
            this.btnAddAddress.TabIndex = 27;
            this.btnAddAddress.Text = "Add Address";
            this.btnAddAddress.UseVisualStyleBackColor = true;
            this.btnAddAddress.Click += new System.EventHandler(this.btnAddAddress_Click);
            // 
            // btnAddBillingInfo
            // 
            this.btnAddBillingInfo.Location = new System.Drawing.Point(389, 47);
            this.btnAddBillingInfo.Name = "btnAddBillingInfo";
            this.btnAddBillingInfo.Size = new System.Drawing.Size(117, 30);
            this.btnAddBillingInfo.TabIndex = 28;
            this.btnAddBillingInfo.Text = "Add Billing Info";
            this.btnAddBillingInfo.UseVisualStyleBackColor = true;
            this.btnAddBillingInfo.Click += new System.EventHandler(this.btnAddBillingInfo_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(892, 565);
            this.Controls.Add(this.btnAddBillingInfo);
            this.Controls.Add(this.btnAddAddress);
            this.Controls.Add(this.lblScreen);
            this.Controls.Add(this.tbScreen);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.lblProject);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.tbProject);
            this.Controls.Add(this.btnPVs);
            this.Name = "Form1";
            this.Text = "client.project.projectController.maintenance.projectMaintenance";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblScreen;
        private System.Windows.Forms.TextBox tbScreen;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Label lblProject;
        public System.Windows.Forms.Button btnLoad;
        public System.Windows.Forms.TextBox tbProject;
        private System.Windows.Forms.Button btnPVs;
        private System.Windows.Forms.Button btnAddAddress;
        private System.Windows.Forms.Button btnAddBillingInfo;
    }
}

