namespace client.fieldService.serviceDispatch.input.serviceCallEntry
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
            this.lblSOLine = new System.Windows.Forms.Label();
            this.lblScreen = new System.Windows.Forms.Label();
            this.gvSOLine = new System.Windows.Forms.DataGridView();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.tbOrder = new System.Windows.Forms.TextBox();
            this.lblServiceCallID = new System.Windows.Forms.Label();
            this.tbServiceCallID = new System.Windows.Forms.TextBox();
            this.btnLoad = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gvSOLine)).BeginInit();
            this.SuspendLayout();
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(316, 19);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(75, 23);
            this.btnNew.TabIndex = 20;
            this.btnNew.Text = "Create New";
            this.btnNew.UseVisualStyleBackColor = true;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(203, 18);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 19;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            // 
            // lblSOLine
            // 
            this.lblSOLine.AutoSize = true;
            this.lblSOLine.Location = new System.Drawing.Point(25, 91);
            this.lblSOLine.Name = "lblSOLine";
            this.lblSOLine.Size = new System.Drawing.Size(64, 13);
            this.lblSOLine.TabIndex = 18;
            this.lblSOLine.Text = "mySOLine[]:";
            // 
            // lblScreen
            // 
            this.lblScreen.AutoSize = true;
            this.lblScreen.Location = new System.Drawing.Point(25, 340);
            this.lblScreen.Name = "lblScreen";
            this.lblScreen.Size = new System.Drawing.Size(107, 13);
            this.lblScreen.TabIndex = 17;
            this.lblScreen.Text = "myServiceCall (XML):";
            // 
            // gvSOLine
            // 
            this.gvSOLine.AllowUserToOrderColumns = true;
            this.gvSOLine.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvSOLine.Location = new System.Drawing.Point(28, 107);
            this.gvSOLine.Name = "gvSOLine";
            this.gvSOLine.Size = new System.Drawing.Size(526, 197);
            this.gvSOLine.TabIndex = 16;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Enabled = false;
            this.btnUpdate.Location = new System.Drawing.Point(203, 64);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnUpdate.TabIndex = 15;
            this.btnUpdate.Text = "Save";
            this.btnUpdate.UseVisualStyleBackColor = true;
            // 
            // tbOrder
            // 
            this.tbOrder.Location = new System.Drawing.Point(28, 356);
            this.tbOrder.Multiline = true;
            this.tbOrder.Name = "tbOrder";
            this.tbOrder.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbOrder.Size = new System.Drawing.Size(526, 80);
            this.tbOrder.TabIndex = 14;
            this.tbOrder.WordWrap = false;
            // 
            // lblServiceCallID
            // 
            this.lblServiceCallID.AutoSize = true;
            this.lblServiceCallID.Location = new System.Drawing.Point(40, 24);
            this.lblServiceCallID.Name = "lblServiceCallID";
            this.lblServiceCallID.Size = new System.Drawing.Size(35, 13);
            this.lblServiceCallID.TabIndex = 13;
            this.lblServiceCallID.Text = "CallID";
            // 
            // tbServiceCallID
            // 
            this.tbServiceCallID.Location = new System.Drawing.Point(89, 21);
            this.tbServiceCallID.Name = "tbServiceCallID";
            this.tbServiceCallID.Size = new System.Drawing.Size(100, 20);
            this.tbServiceCallID.TabIndex = 12;
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(89, 64);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(75, 23);
            this.btnLoad.TabIndex = 11;
            this.btnLoad.Text = "Load Order";
            this.btnLoad.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(616, 502);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.lblSOLine);
            this.Controls.Add(this.lblScreen);
            this.Controls.Add(this.gvSOLine);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.tbOrder);
            this.Controls.Add(this.lblServiceCallID);
            this.Controls.Add(this.tbServiceCallID);
            this.Controls.Add(this.btnLoad);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.gvSOLine)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label lblSOLine;
        private System.Windows.Forms.Label lblScreen;
        private System.Windows.Forms.DataGridView gvSOLine;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.TextBox tbOrder;
        private System.Windows.Forms.Label lblServiceCallID;
        public System.Windows.Forms.TextBox tbServiceCallID;
        public System.Windows.Forms.Button btnLoad;
    }
}

