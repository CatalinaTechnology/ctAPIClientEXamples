namespace client.purchaseOrders
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
            this.tbPONbr = new System.Windows.Forms.TextBox();
            this.lblOrdNbr = new System.Windows.Forms.Label();
            this.tbOrder = new System.Windows.Forms.TextBox();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.gvSOLine = new System.Windows.Forms.DataGridView();
            this.alternateIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.invtIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LINEREF = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.projectIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.promDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.qtyOrdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.s4Future04DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.s4Future05DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.siteIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.taskIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.user1DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.user2DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.user3DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.user4DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.user5DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.user6DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.user7DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.user8DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.poLineItemBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.lblScreen = new System.Windows.Forms.Label();
            this.lblLineItems = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnMoveLines = new System.Windows.Forms.Button();
            this.tbAltPONbr = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.gvSOLine)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.poLineItemBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(354, 8);
            this.btnLoad.Margin = new System.Windows.Forms.Padding(4);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(100, 28);
            this.btnLoad.TabIndex = 1;
            this.btnLoad.Text = "Load PO";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // tbPONbr
            // 
            this.tbPONbr.Location = new System.Drawing.Point(94, 12);
            this.tbPONbr.Margin = new System.Windows.Forms.Padding(4);
            this.tbPONbr.Name = "tbPONbr";
            this.tbPONbr.Size = new System.Drawing.Size(132, 22);
            this.tbPONbr.TabIndex = 2;
            // 
            // lblOrdNbr
            // 
            this.lblOrdNbr.AutoSize = true;
            this.lblOrdNbr.Location = new System.Drawing.Point(29, 16);
            this.lblOrdNbr.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblOrdNbr.Name = "lblOrdNbr";
            this.lblOrdNbr.Size = new System.Drawing.Size(51, 17);
            this.lblOrdNbr.TabIndex = 3;
            this.lblOrdNbr.Text = "PONbr";
            // 
            // tbOrder
            // 
            this.tbOrder.Location = new System.Drawing.Point(13, 424);
            this.tbOrder.Margin = new System.Windows.Forms.Padding(4);
            this.tbOrder.Multiline = true;
            this.tbOrder.Name = "tbOrder";
            this.tbOrder.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbOrder.Size = new System.Drawing.Size(700, 98);
            this.tbOrder.TabIndex = 4;
            this.tbOrder.WordWrap = false;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Enabled = false;
            this.btnUpdate.Location = new System.Drawing.Point(94, 42);
            this.btnUpdate.Margin = new System.Windows.Forms.Padding(4);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(100, 28);
            this.btnUpdate.TabIndex = 5;
            this.btnUpdate.Text = "Save";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // gvSOLine
            // 
            this.gvSOLine.AllowUserToOrderColumns = true;
            this.gvSOLine.AutoGenerateColumns = false;
            this.gvSOLine.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvSOLine.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.alternateIDDataGridViewTextBoxColumn,
            this.invtIDDataGridViewTextBoxColumn,
            this.LINEREF,
            this.projectIDDataGridViewTextBoxColumn,
            this.promDateDataGridViewTextBoxColumn,
            this.qtyOrdDataGridViewTextBoxColumn,
            this.s4Future04DataGridViewTextBoxColumn,
            this.s4Future05DataGridViewTextBoxColumn,
            this.siteIDDataGridViewTextBoxColumn,
            this.taskIDDataGridViewTextBoxColumn,
            this.user1DataGridViewTextBoxColumn,
            this.user2DataGridViewTextBoxColumn,
            this.user3DataGridViewTextBoxColumn,
            this.user4DataGridViewTextBoxColumn,
            this.user5DataGridViewTextBoxColumn,
            this.user6DataGridViewTextBoxColumn,
            this.user7DataGridViewTextBoxColumn,
            this.user8DataGridViewTextBoxColumn,
            this.dataGridViewTextBoxColumn3});
            this.gvSOLine.DataSource = this.poLineItemBindingSource;
            this.gvSOLine.Location = new System.Drawing.Point(13, 118);
            this.gvSOLine.Margin = new System.Windows.Forms.Padding(4);
            this.gvSOLine.Name = "gvSOLine";
            this.gvSOLine.Size = new System.Drawing.Size(701, 242);
            this.gvSOLine.TabIndex = 6;
            this.gvSOLine.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvSOLine_CellContentClick);
            // 
            // alternateIDDataGridViewTextBoxColumn
            // 
            this.alternateIDDataGridViewTextBoxColumn.DataPropertyName = "AlternateID";
            this.alternateIDDataGridViewTextBoxColumn.HeaderText = "AlternateID";
            this.alternateIDDataGridViewTextBoxColumn.Name = "alternateIDDataGridViewTextBoxColumn";
            // 
            // invtIDDataGridViewTextBoxColumn
            // 
            this.invtIDDataGridViewTextBoxColumn.DataPropertyName = "InvtID";
            this.invtIDDataGridViewTextBoxColumn.HeaderText = "InvtID";
            this.invtIDDataGridViewTextBoxColumn.Name = "invtIDDataGridViewTextBoxColumn";
            // 
            // LINEREF
            // 
            this.LINEREF.DataPropertyName = "LineRef";
            this.LINEREF.HeaderText = "LineRef";
            this.LINEREF.Name = "LINEREF";
            // 
            // projectIDDataGridViewTextBoxColumn
            // 
            this.projectIDDataGridViewTextBoxColumn.DataPropertyName = "ProjectID";
            this.projectIDDataGridViewTextBoxColumn.HeaderText = "ProjectID";
            this.projectIDDataGridViewTextBoxColumn.Name = "projectIDDataGridViewTextBoxColumn";
            // 
            // promDateDataGridViewTextBoxColumn
            // 
            this.promDateDataGridViewTextBoxColumn.DataPropertyName = "PromDate";
            this.promDateDataGridViewTextBoxColumn.HeaderText = "PromDate";
            this.promDateDataGridViewTextBoxColumn.Name = "promDateDataGridViewTextBoxColumn";
            // 
            // qtyOrdDataGridViewTextBoxColumn
            // 
            this.qtyOrdDataGridViewTextBoxColumn.DataPropertyName = "QtyOrd";
            this.qtyOrdDataGridViewTextBoxColumn.HeaderText = "QtyOrd";
            this.qtyOrdDataGridViewTextBoxColumn.Name = "qtyOrdDataGridViewTextBoxColumn";
            // 
            // s4Future04DataGridViewTextBoxColumn
            // 
            this.s4Future04DataGridViewTextBoxColumn.DataPropertyName = "S4Future04";
            this.s4Future04DataGridViewTextBoxColumn.HeaderText = "S4Future04";
            this.s4Future04DataGridViewTextBoxColumn.Name = "s4Future04DataGridViewTextBoxColumn";
            // 
            // s4Future05DataGridViewTextBoxColumn
            // 
            this.s4Future05DataGridViewTextBoxColumn.DataPropertyName = "S4Future05";
            this.s4Future05DataGridViewTextBoxColumn.HeaderText = "S4Future05";
            this.s4Future05DataGridViewTextBoxColumn.Name = "s4Future05DataGridViewTextBoxColumn";
            // 
            // siteIDDataGridViewTextBoxColumn
            // 
            this.siteIDDataGridViewTextBoxColumn.DataPropertyName = "SiteID";
            this.siteIDDataGridViewTextBoxColumn.HeaderText = "SiteID";
            this.siteIDDataGridViewTextBoxColumn.Name = "siteIDDataGridViewTextBoxColumn";
            // 
            // taskIDDataGridViewTextBoxColumn
            // 
            this.taskIDDataGridViewTextBoxColumn.DataPropertyName = "TaskID";
            this.taskIDDataGridViewTextBoxColumn.HeaderText = "TaskID";
            this.taskIDDataGridViewTextBoxColumn.Name = "taskIDDataGridViewTextBoxColumn";
            // 
            // user1DataGridViewTextBoxColumn
            // 
            this.user1DataGridViewTextBoxColumn.DataPropertyName = "User1";
            this.user1DataGridViewTextBoxColumn.HeaderText = "User1";
            this.user1DataGridViewTextBoxColumn.Name = "user1DataGridViewTextBoxColumn";
            // 
            // user2DataGridViewTextBoxColumn
            // 
            this.user2DataGridViewTextBoxColumn.DataPropertyName = "User2";
            this.user2DataGridViewTextBoxColumn.HeaderText = "User2";
            this.user2DataGridViewTextBoxColumn.Name = "user2DataGridViewTextBoxColumn";
            // 
            // user3DataGridViewTextBoxColumn
            // 
            this.user3DataGridViewTextBoxColumn.DataPropertyName = "User3";
            this.user3DataGridViewTextBoxColumn.HeaderText = "User3";
            this.user3DataGridViewTextBoxColumn.Name = "user3DataGridViewTextBoxColumn";
            // 
            // user4DataGridViewTextBoxColumn
            // 
            this.user4DataGridViewTextBoxColumn.DataPropertyName = "User4";
            this.user4DataGridViewTextBoxColumn.HeaderText = "User4";
            this.user4DataGridViewTextBoxColumn.Name = "user4DataGridViewTextBoxColumn";
            // 
            // user5DataGridViewTextBoxColumn
            // 
            this.user5DataGridViewTextBoxColumn.DataPropertyName = "User5";
            this.user5DataGridViewTextBoxColumn.HeaderText = "User5";
            this.user5DataGridViewTextBoxColumn.Name = "user5DataGridViewTextBoxColumn";
            // 
            // user6DataGridViewTextBoxColumn
            // 
            this.user6DataGridViewTextBoxColumn.DataPropertyName = "User6";
            this.user6DataGridViewTextBoxColumn.HeaderText = "User6";
            this.user6DataGridViewTextBoxColumn.Name = "user6DataGridViewTextBoxColumn";
            // 
            // user7DataGridViewTextBoxColumn
            // 
            this.user7DataGridViewTextBoxColumn.DataPropertyName = "User7";
            this.user7DataGridViewTextBoxColumn.HeaderText = "User7";
            this.user7DataGridViewTextBoxColumn.Name = "user7DataGridViewTextBoxColumn";
            // 
            // user8DataGridViewTextBoxColumn
            // 
            this.user8DataGridViewTextBoxColumn.DataPropertyName = "User8";
            this.user8DataGridViewTextBoxColumn.HeaderText = "User8";
            this.user8DataGridViewTextBoxColumn.Name = "user8DataGridViewTextBoxColumn";
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "Notes";
            this.dataGridViewTextBoxColumn3.HeaderText = "Notes";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // poLineItemBindingSource
            // 
            this.poLineItemBindingSource.DataSource = typeof(client.purchaseOrders.ctDynamicsSL.purchaseOrders.poLineItem);
            // 
            // lblScreen
            // 
            this.lblScreen.AutoSize = true;
            this.lblScreen.Location = new System.Drawing.Point(9, 405);
            this.lblScreen.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblScreen.Name = "lblScreen";
            this.lblScreen.Size = new System.Drawing.Size(169, 17);
            this.lblScreen.TabIndex = 7;
            this.lblScreen.Text = "myPurchaseOrder (XML):";
            // 
            // lblLineItems
            // 
            this.lblLineItems.AutoSize = true;
            this.lblLineItems.Location = new System.Drawing.Point(9, 98);
            this.lblLineItems.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLineItems.Name = "lblLineItems";
            this.lblLineItems.Size = new System.Drawing.Size(98, 17);
            this.lblLineItems.TabIndex = 8;
            this.lblLineItems.Text = "myLineItems[]:";
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(246, 8);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(4);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(100, 28);
            this.btnSearch.TabIndex = 9;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(202, 42);
            this.btnNew.Margin = new System.Windows.Forms.Padding(4);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(100, 28);
            this.btnNew.TabIndex = 10;
            this.btnNew.Text = "Create New";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnMoveLines
            // 
            this.btnMoveLines.Location = new System.Drawing.Point(614, 47);
            this.btnMoveLines.Margin = new System.Windows.Forms.Padding(4);
            this.btnMoveLines.Name = "btnMoveLines";
            this.btnMoveLines.Size = new System.Drawing.Size(100, 28);
            this.btnMoveLines.TabIndex = 11;
            this.btnMoveLines.Text = "Move Lines to:";
            this.btnMoveLines.UseVisualStyleBackColor = true;
            this.btnMoveLines.Click += new System.EventHandler(this.btnMoveLines_Click);
            // 
            // tbAltPONbr
            // 
            this.tbAltPONbr.Location = new System.Drawing.Point(479, 51);
            this.tbAltPONbr.Margin = new System.Windows.Forms.Padding(4);
            this.tbAltPONbr.Name = "tbAltPONbr";
            this.tbAltPONbr.Size = new System.Drawing.Size(127, 22);
            this.tbAltPONbr.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(381, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 17);
            this.label1.TabIndex = 13;
            this.label1.Text = "Move To PO:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(782, 553);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbAltPONbr);
            this.Controls.Add(this.btnMoveLines);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.lblLineItems);
            this.Controls.Add(this.lblScreen);
            this.Controls.Add(this.gvSOLine);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.tbOrder);
            this.Controls.Add(this.lblOrdNbr);
            this.Controls.Add(this.tbPONbr);
            this.Controls.Add(this.btnLoad);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "client.purchaseOrders";
            ((System.ComponentModel.ISupportInitialize)(this.gvSOLine)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.poLineItemBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Button btnLoad;
        public System.Windows.Forms.TextBox tbPONbr;
        private System.Windows.Forms.Label lblOrdNbr;
        private System.Windows.Forms.TextBox tbOrder;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.DataGridView gvSOLine;
        private System.Windows.Forms.Label lblScreen;
        private System.Windows.Forms.Label lblLineItems;

        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.DataGridViewTextBoxColumn basketIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn altIDTypeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn autoPODataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn autoPOVendIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn blktOrdLineRefDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn blktOrdQtyDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn bMICostDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn bMICuryIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn bMIEffDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn bMIExtPriceInvcDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn bMIMultDivDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn bMIRateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn bMIRtTpDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn bMISlsPriceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn boundToWODataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cancelDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn chainDiscDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cmmnPctDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cnvFactDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cOGSAcctDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cOGSSubDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn commCostDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn costDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cpnyIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn crtdDateTimeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn crtdProgDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn crtdUserDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn curyCommCostDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn curyCostDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn curyListPriceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn curySlsPriceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn curySlsPriceOrigDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn curyTotCommCostDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn curyTotCostDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn curyTotOrdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn descrDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn descrLangDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn discAcctDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn discPctDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn discPrcTypeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn discSubDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dispDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dropShipDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn inclForecastUsageClcDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn inspIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn inspNoteIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn invAcctDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn invSubDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn iRDemandDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn iRInvtIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn iRProcessedDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn iRSiteIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemGLClassIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn kitComponentDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn listPriceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lUpdDateTimeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lUpdProgDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lUpdUserDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn manualCostDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn manualPriceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn originPONbrDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn origInvcNbrDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn origInvtIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn origShipperIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn origShipperLineQtyDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn origShipperLineRefDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn pCStatusDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn qtyBODataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn qtyCloseShipDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn qtyFutureDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn qtyOpenShipDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn qtyShipDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn qtyToInvcDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn reasonCdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn rebateIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn reqDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn s4Future01DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn s4Future02DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn s4Future03DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn s4Future06DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn s4Future07DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn s4Future08DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn s4Future09DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn s4Future10DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn s4Future11DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn s4Future12DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn salesPriceIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sampleDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn schedCntrDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn serviceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn shipWghtDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn slsAcctDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn slsperIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn slsPriceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn slsPriceIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn slsPriceOrigDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn slsSubDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn splitLotsDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn statusDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn taxableDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn taxCatDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn totCommCostDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn totCostDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn totOrdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn totShipWghtDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn unitDescDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn unitMultDivDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn user10DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn user9DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn deleteFlagDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn userIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn productIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn quantityDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn priceClassIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource poLineItemBindingSource;
        private System.Windows.Forms.Button btnMoveLines;
        private System.Windows.Forms.DataGridViewTextBoxColumn alternateIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn invtIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn LINEREF;
        private System.Windows.Forms.DataGridViewTextBoxColumn projectIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn promDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn qtyOrdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn s4Future04DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn s4Future05DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn siteIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn taskIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn user1DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn user2DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn user3DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn user4DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn user5DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn user6DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn user7DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn user8DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.TextBox tbAltPONbr;
        private System.Windows.Forms.Label label1;
    }
}


