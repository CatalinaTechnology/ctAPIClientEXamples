namespace client.receipts
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
            this.btnLoad = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.lblLineItems = new System.Windows.Forms.Label();
            this.lblScreen = new System.Windows.Forms.Label();
            this.poLineItemBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gvDocuments = new System.Windows.Forms.DataGridView();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.tbOrder = new System.Windows.Forms.TextBox();
            this.lblBatNbr = new System.Windows.Forms.Label();
            this.tbBatNbr = new System.Windows.Forms.TextBox();
            this.btnNew = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.poLineItemBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvDocuments)).BeginInit();
            this.SuspendLayout();
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(94, 69);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(75, 23);
            this.btnLoad.TabIndex = 11;
            this.btnLoad.Text = "Load Batch";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(208, 23);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 19;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // lblLineItems
            // 
            this.lblLineItems.AutoSize = true;
            this.lblLineItems.Location = new System.Drawing.Point(30, 96);
            this.lblLineItems.Name = "lblLineItems";
            this.lblLineItems.Size = new System.Drawing.Size(74, 13);
            this.lblLineItems.TabIndex = 18;
            this.lblLineItems.Text = "myLineItems[]:";
            // 
            // lblScreen
            // 
            this.lblScreen.AutoSize = true;
            this.lblScreen.Location = new System.Drawing.Point(30, 345);
            this.lblScreen.Name = "lblScreen";
            this.lblScreen.Size = new System.Drawing.Size(125, 13);
            this.lblScreen.TabIndex = 17;
            this.lblScreen.Text = "myPOBatch (XML):";
            // 
            // gvDocuments
            // 
            this.gvDocuments.AllowUserToOrderColumns = true;
            this.gvDocuments.AutoGenerateColumns = false;
            this.gvDocuments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvDocuments.DataSource = this.poLineItemBindingSource;
            this.gvDocuments.Location = new System.Drawing.Point(33, 112);
            this.gvDocuments.Name = "gvDocuments";
            this.gvDocuments.Size = new System.Drawing.Size(526, 197);
            this.gvDocuments.TabIndex = 16;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Enabled = false;
            this.btnUpdate.Location = new System.Drawing.Point(208, 69);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnUpdate.TabIndex = 15;
            this.btnUpdate.Text = "Save";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // tbOrder
            // 
            this.tbOrder.Location = new System.Drawing.Point(33, 361);
            this.tbOrder.Multiline = true;
            this.tbOrder.Name = "tbOrder";
            this.tbOrder.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbOrder.Size = new System.Drawing.Size(526, 80);
            this.tbOrder.TabIndex = 14;
            this.tbOrder.WordWrap = false;
            // 
            // lblBatNbr
            // 
            this.lblBatNbr.AutoSize = true;
            this.lblBatNbr.Location = new System.Drawing.Point(45, 29);
            this.lblBatNbr.Name = "lblBatNbr";
            this.lblBatNbr.Size = new System.Drawing.Size(43, 13);
            this.lblBatNbr.TabIndex = 13;
            this.lblBatNbr.Text = "BatNbr:";
            // 
            // tbBatNbr
            // 
            this.tbBatNbr.Location = new System.Drawing.Point(94, 26);
            this.tbBatNbr.Name = "tbBatNbr";
            this.tbBatNbr.Size = new System.Drawing.Size(100, 20);
            this.tbBatNbr.TabIndex = 12;
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(321, 24);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(75, 23);
            this.btnNew.TabIndex = 20;
            this.btnNew.Text = "Create New";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(680, 531);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.lblLineItems);
            this.Controls.Add(this.lblScreen);
            this.Controls.Add(this.gvDocuments);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.tbOrder);
            this.Controls.Add(this.lblBatNbr);
            this.Controls.Add(this.tbBatNbr);
            this.Controls.Add(this.btnNew);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.poLineItemBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvDocuments)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label lblLineItems;
        private System.Windows.Forms.Label lblScreen;
        private System.Windows.Forms.BindingSource poLineItemBindingSource;
        private System.Windows.Forms.DataGridView gvDocuments;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.TextBox tbOrder;
        private System.Windows.Forms.Label lblBatNbr;
        public System.Windows.Forms.TextBox tbBatNbr;
        private System.Windows.Forms.Button btnNew;
    }
}

