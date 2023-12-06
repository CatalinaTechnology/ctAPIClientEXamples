namespace client.fieldService.serviceDispatch.input.serviceCallInvoiceEntry
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
            this.btnSearch = new System.Windows.Forms.Button();
            this.lblSMServDetail = new System.Windows.Forms.Label();
            this.lblScreen = new System.Windows.Forms.Label();
            this.gvSMServDetail = new System.Windows.Forms.DataGridView();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.tbScreen = new System.Windows.Forms.TextBox();
            this.lblServiceCallID = new System.Windows.Forms.Label();
            this.tbServiceCallID = new System.Windows.Forms.TextBox();
            this.btnLoad = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.gvSMInvoice = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gvSMServDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvSMInvoice)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(235, 45);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 19;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // lblSMServDetail
            // 
            this.lblSMServDetail.AutoSize = true;
            this.lblSMServDetail.Location = new System.Drawing.Point(57, 118);
            this.lblSMServDetail.Name = "lblSMServDetail";
            this.lblSMServDetail.Size = new System.Drawing.Size(81, 13);
            this.lblSMServDetail.TabIndex = 18;
            this.lblSMServDetail.Text = "SMServDetail[]:";
            // 
            // lblScreen
            // 
            this.lblScreen.AutoSize = true;
            this.lblScreen.Location = new System.Drawing.Point(57, 336);
            this.lblScreen.Name = "lblScreen";
            this.lblScreen.Size = new System.Drawing.Size(142, 13);
            this.lblScreen.TabIndex = 17;
            this.lblScreen.Text = "myServiceCallInvoice (XML):";
            // 
            // gvSMServDetail
            // 
            this.gvSMServDetail.AllowUserToOrderColumns = true;
            this.gvSMServDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvSMServDetail.Location = new System.Drawing.Point(60, 134);
            this.gvSMServDetail.Name = "gvSMServDetail";
            this.gvSMServDetail.Size = new System.Drawing.Size(526, 77);
            this.gvSMServDetail.TabIndex = 16;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Enabled = false;
            this.btnUpdate.Location = new System.Drawing.Point(235, 74);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnUpdate.TabIndex = 15;
            this.btnUpdate.Text = "Save";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // tbScreen
            // 
            this.tbScreen.Location = new System.Drawing.Point(60, 363);
            this.tbScreen.Multiline = true;
            this.tbScreen.Name = "tbScreen";
            this.tbScreen.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbScreen.Size = new System.Drawing.Size(526, 80);
            this.tbScreen.TabIndex = 14;
            this.tbScreen.WordWrap = false;
            // 
            // lblServiceCallID
            // 
            this.lblServiceCallID.AutoSize = true;
            this.lblServiceCallID.Location = new System.Drawing.Point(72, 51);
            this.lblServiceCallID.Name = "lblServiceCallID";
            this.lblServiceCallID.Size = new System.Drawing.Size(35, 13);
            this.lblServiceCallID.TabIndex = 13;
            this.lblServiceCallID.Text = "CallID";
            // 
            // tbServiceCallID
            // 
            this.tbServiceCallID.Location = new System.Drawing.Point(121, 48);
            this.tbServiceCallID.Name = "tbServiceCallID";
            this.tbServiceCallID.Size = new System.Drawing.Size(100, 20);
            this.tbServiceCallID.TabIndex = 12;
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(316, 45);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(75, 23);
            this.btnLoad.TabIndex = 11;
            this.btnLoad.Text = "Load Call";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(57, 221);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 22;
            this.label1.Text = "SMInvoice[]:";
            // 
            // gvSMInvoice
            // 
            this.gvSMInvoice.AllowUserToOrderColumns = true;
            this.gvSMInvoice.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvSMInvoice.Location = new System.Drawing.Point(60, 237);
            this.gvSMInvoice.Name = "gvSMInvoice";
            this.gvSMInvoice.Size = new System.Drawing.Size(526, 77);
            this.gvSMInvoice.TabIndex = 21;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(121, 74);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 23;
            this.button1.Text = "Calc Tax";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(642, 508);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.gvSMInvoice);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.lblSMServDetail);
            this.Controls.Add(this.lblScreen);
            this.Controls.Add(this.gvSMServDetail);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.tbScreen);
            this.Controls.Add(this.lblServiceCallID);
            this.Controls.Add(this.tbServiceCallID);
            this.Controls.Add(this.btnLoad);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.gvSMServDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvSMInvoice)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label lblSMServDetail;
        private System.Windows.Forms.Label lblScreen;
        private System.Windows.Forms.DataGridView gvSMServDetail;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.TextBox tbScreen;
        private System.Windows.Forms.Label lblServiceCallID;
        public System.Windows.Forms.TextBox tbServiceCallID;
        public System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView gvSMInvoice;
        private System.Windows.Forms.Button button1;
    }
}

