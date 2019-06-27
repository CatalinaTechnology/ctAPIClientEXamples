namespace client.orderManagement.input.shippers
{
    partial class ordersPopup
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
            this.gvOrders = new System.Windows.Forms.DataGridView();
            this.orderBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.gvOrders)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.orderBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // gvOrders
            // 
            this.gvOrders.AllowUserToAddRows = false;
            this.gvOrders.AllowUserToDeleteRows = false;
            this.gvOrders.AllowUserToOrderColumns = true;
            this.gvOrders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvOrders.Location = new System.Drawing.Point(32, 38);
            this.gvOrders.Name = "gvOrders";
            this.gvOrders.ReadOnly = true;
            this.gvOrders.Size = new System.Drawing.Size(505, 279);
            this.gvOrders.TabIndex = 0;
            this.gvOrders.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvOrders_CellContentClick);
            // 
            // orderBindingSource
            // 
            this.orderBindingSource.DataSource = typeof(client.orderManagement.input.shippers.ctDynamicsSL.orders.order);
            // 
            // ordersPopup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(566, 342);
            this.Controls.Add(this.gvOrders);
            this.Name = "ordersPopup";
            this.Text = "ordersPopup";
            ((System.ComponentModel.ISupportInitialize)(this.gvOrders)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.orderBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView gvOrders;
        private System.Windows.Forms.BindingSource orderBindingSource;
    }
}