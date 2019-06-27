namespace client.ctDynamicsSL.quickQuery
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
            this.btnGetQuery = new System.Windows.Forms.Button();
            this.tbQueryViewName = new System.Windows.Forms.TextBox();
            this.dgvQueryResults = new System.Windows.Forms.DataGridView();
            this.dgvFilters = new System.Windows.Forms.DataGridView();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.value = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.comparisonType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.queryFilterBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tbScreen = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvQueryResults)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFilters)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.queryFilterBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // btnGetQuery
            // 
            this.btnGetQuery.Location = new System.Drawing.Point(373, 9);
            this.btnGetQuery.Name = "btnGetQuery";
            this.btnGetQuery.Size = new System.Drawing.Size(97, 28);
            this.btnGetQuery.TabIndex = 0;
            this.btnGetQuery.Text = "Run Query";
            this.btnGetQuery.UseVisualStyleBackColor = true;
            this.btnGetQuery.Click += new System.EventHandler(this.btnGetQuery_Click);
            // 
            // tbQueryViewName
            // 
            this.tbQueryViewName.Location = new System.Drawing.Point(12, 12);
            this.tbQueryViewName.Name = "tbQueryViewName";
            this.tbQueryViewName.Size = new System.Drawing.Size(225, 22);
            this.tbQueryViewName.TabIndex = 1;
            // 
            // dgvQueryResults
            // 
            this.dgvQueryResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvQueryResults.Location = new System.Drawing.Point(12, 204);
            this.dgvQueryResults.Name = "dgvQueryResults";
            this.dgvQueryResults.RowTemplate.Height = 24;
            this.dgvQueryResults.Size = new System.Drawing.Size(758, 185);
            this.dgvQueryResults.TabIndex = 2;
            // 
            // dgvFilters
            // 
            this.dgvFilters.AutoGenerateColumns = false;
            this.dgvFilters.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFilters.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.name,
            this.value,
            this.comparisonType});
            this.dgvFilters.DataSource = this.queryFilterBindingSource;
            this.dgvFilters.Location = new System.Drawing.Point(12, 68);
            this.dgvFilters.Name = "dgvFilters";
            this.dgvFilters.RowTemplate.Height = 24;
            this.dgvFilters.Size = new System.Drawing.Size(758, 112);
            this.dgvFilters.TabIndex = 3;
            // 
            // name
            // 
            this.name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.name.DataPropertyName = "name";
            this.name.HeaderText = "name";
            this.name.MinimumWidth = 175;
            this.name.Name = "name";
            // 
            // value
            // 
            this.value.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.value.DataPropertyName = "value";
            this.value.HeaderText = "value";
            this.value.MinimumWidth = 175;
            this.value.Name = "value";
            // 
            // comparisonType
            // 
            this.comparisonType.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.comparisonType.DataPropertyName = "comparisonType";
            this.comparisonType.HeaderText = "comparisonType";
            this.comparisonType.MinimumWidth = 100;
            this.comparisonType.Name = "comparisonType";
            // 
            // queryFilterBindingSource
            // 
            this.queryFilterBindingSource.DataSource = typeof(client.ctDynamicsSL.quickQuery.ctDynamicsSL.quickQuery.queryFilter);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 184);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "Results:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "Filters:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 392);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "Screen:";
            // 
            // tbScreen
            // 
            this.tbScreen.Location = new System.Drawing.Point(12, 412);
            this.tbScreen.Multiline = true;
            this.tbScreen.Name = "tbScreen";
            this.tbScreen.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbScreen.Size = new System.Drawing.Size(758, 129);
            this.tbScreen.TabIndex = 7;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(243, 9);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(124, 28);
            this.btnSearch.TabIndex = 8;
            this.btnSearch.Text = "Get Query List";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(782, 553);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.tbScreen);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvFilters);
            this.Controls.Add(this.dgvQueryResults);
            this.Controls.Add(this.tbQueryViewName);
            this.Controls.Add(this.btnGetQuery);
            this.Name = "Form1";
            this.Text = "client.ctDynamicsSL.quickQuery";
            ((System.ComponentModel.ISupportInitialize)(this.dgvQueryResults)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFilters)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.queryFilterBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGetQuery;
        public System.Windows.Forms.TextBox tbQueryViewName;
        private System.Windows.Forms.DataGridView dgvQueryResults;
        private System.Windows.Forms.DataGridView dgvFilters;
        private System.Windows.Forms.BindingSource queryFilterBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewTextBoxColumn value;
        private System.Windows.Forms.DataGridViewTextBoxColumn comparisonType;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbScreen;
        private System.Windows.Forms.Button btnSearch;
    }
}

