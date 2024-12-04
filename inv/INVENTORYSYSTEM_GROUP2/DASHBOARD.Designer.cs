namespace INVENTORYSYSTEM_GROUP2
{
    partial class DASHBOARD
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DASHBOARD));
            this.btn_dsc = new System.Windows.Forms.PictureBox();
            this.btn_asc = new System.Windows.Forms.PictureBox();
            this.btn_search = new System.Windows.Forms.PictureBox();
            this.sort = new System.Windows.Forms.ComboBox();
            this.Search = new System.Windows.Forms.TextBox();
            this.viewCategory = new System.Windows.Forms.ComboBox();
            this.lv_products = new System.Windows.Forms.ListView();
            this.ID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ProductName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.category = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.stock = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.status = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.priority = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.price = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lblTotalProducts = new System.Windows.Forms.Label();
            this.lblTotalSales = new System.Windows.Forms.Label();
            this.label1_TotalProducts = new System.Windows.Forms.Label();
            this.label2_TotalSales = new System.Windows.Forms.Label();
            this.btn_daily = new System.Windows.Forms.Button();
            this.btn_weekly = new System.Windows.Forms.Button();
            this.btn_monthly = new System.Windows.Forms.Button();
            this.btn_yearly = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.btn_dsc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_asc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_search)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_dsc
            // 
            this.btn_dsc.Image = ((System.Drawing.Image)(resources.GetObject("btn_dsc.Image")));
            this.btn_dsc.Location = new System.Drawing.Point(830, 226);
            this.btn_dsc.Name = "btn_dsc";
            this.btn_dsc.Size = new System.Drawing.Size(31, 27);
            this.btn_dsc.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btn_dsc.TabIndex = 27;
            this.btn_dsc.TabStop = false;
            this.btn_dsc.Click += new System.EventHandler(this.btn_dsc_Click_1);
            // 
            // btn_asc
            // 
            this.btn_asc.Image = ((System.Drawing.Image)(resources.GetObject("btn_asc.Image")));
            this.btn_asc.Location = new System.Drawing.Point(790, 226);
            this.btn_asc.Name = "btn_asc";
            this.btn_asc.Size = new System.Drawing.Size(34, 27);
            this.btn_asc.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btn_asc.TabIndex = 26;
            this.btn_asc.TabStop = false;
            this.btn_asc.Click += new System.EventHandler(this.btn_asc_Click_1);
            // 
            // btn_search
            // 
            this.btn_search.Image = ((System.Drawing.Image)(resources.GetObject("btn_search.Image")));
            this.btn_search.Location = new System.Drawing.Point(464, 225);
            this.btn_search.Name = "btn_search";
            this.btn_search.Size = new System.Drawing.Size(39, 28);
            this.btn_search.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btn_search.TabIndex = 25;
            this.btn_search.TabStop = false;
            this.btn_search.Click += new System.EventHandler(this.btn_search_Click_1);
            // 
            // sort
            // 
            this.sort.Font = new System.Drawing.Font("Perpetua Titling MT", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sort.FormattingEnabled = true;
            this.sort.Items.AddRange(new object[] {
            "ID",
            "STOCK",
            "PRODUCT NAME",
            "PRICE"});
            this.sort.Location = new System.Drawing.Point(867, 224);
            this.sort.Name = "sort";
            this.sort.Size = new System.Drawing.Size(100, 29);
            this.sort.TabIndex = 23;
            this.sort.Text = "ID";
            this.sort.SelectedIndexChanged += new System.EventHandler(this.sort_SelectedIndexChanged);
            // 
            // Search
            // 
            this.Search.Font = new System.Drawing.Font("Perpetua Titling MT", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Search.Location = new System.Drawing.Point(252, 225);
            this.Search.Name = "Search";
            this.Search.Size = new System.Drawing.Size(206, 28);
            this.Search.TabIndex = 24;
            // 
            // viewCategory
            // 
            this.viewCategory.Font = new System.Drawing.Font("Perpetua Titling MT", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.viewCategory.FormattingEnabled = true;
            this.viewCategory.Items.AddRange(new object[] {
            "ALL",
            "CPU",
            "GPU",
            "MOTHERBOARD",
            "GPU",
            "RAM"});
            this.viewCategory.Location = new System.Drawing.Point(54, 225);
            this.viewCategory.Name = "viewCategory";
            this.viewCategory.Size = new System.Drawing.Size(192, 29);
            this.viewCategory.TabIndex = 22;
            this.viewCategory.Text = "ALL";
            this.viewCategory.SelectedIndexChanged += new System.EventHandler(this.viewCategory_SelectedIndexChanged);
            // 
            // lv_products
            // 
            this.lv_products.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ID,
            this.ProductName,
            this.category,
            this.stock,
            this.status,
            this.priority,
            this.price});
            this.lv_products.Font = new System.Drawing.Font("Perpetua Titling MT", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lv_products.FullRowSelect = true;
            this.lv_products.GridLines = true;
            this.lv_products.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lv_products.HideSelection = false;
            this.lv_products.Location = new System.Drawing.Point(54, 260);
            this.lv_products.MultiSelect = false;
            this.lv_products.Name = "lv_products";
            this.lv_products.Size = new System.Drawing.Size(913, 296);
            this.lv_products.TabIndex = 21;
            this.lv_products.UseCompatibleStateImageBehavior = false;
            this.lv_products.View = System.Windows.Forms.View.Details;
            // 
            // ID
            // 
            this.ID.Text = "ID";
            this.ID.Width = 50;
            // 
            // ProductName
            // 
            this.ProductName.Text = "PRODUCT NAME";
            this.ProductName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ProductName.Width = 250;
            // 
            // category
            // 
            this.category.Text = "CATEGORY";
            this.category.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.category.Width = 150;
            // 
            // stock
            // 
            this.stock.Text = "STOCK";
            this.stock.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.stock.Width = 80;
            // 
            // status
            // 
            this.status.Text = "STATUS";
            this.status.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.status.Width = 120;
            // 
            // priority
            // 
            this.priority.Text = "PRIORITY";
            this.priority.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.priority.Width = 110;
            // 
            // price
            // 
            this.price.Text = "PRICE";
            this.price.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.price.Width = 150;
            // 
            // lblTotalProducts
            // 
            this.lblTotalProducts.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblTotalProducts.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.lblTotalProducts.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblTotalProducts.Font = new System.Drawing.Font("Perpetua Titling MT", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalProducts.Location = new System.Drawing.Point(249, 101);
            this.lblTotalProducts.Name = "lblTotalProducts";
            this.lblTotalProducts.Size = new System.Drawing.Size(101, 78);
            this.lblTotalProducts.TabIndex = 28;
            // 
            // lblTotalSales
            // 
            this.lblTotalSales.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblTotalSales.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.lblTotalSales.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblTotalSales.Font = new System.Drawing.Font("Perpetua Titling MT", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalSales.Location = new System.Drawing.Point(531, 101);
            this.lblTotalSales.Name = "lblTotalSales";
            this.lblTotalSales.Size = new System.Drawing.Size(117, 78);
            this.lblTotalSales.TabIndex = 29;
            // 
            // label1_TotalProducts
            // 
            this.label1_TotalProducts.AutoSize = true;
            this.label1_TotalProducts.Font = new System.Drawing.Font("Perpetua Titling MT", 10.2F, System.Drawing.FontStyle.Bold);
            this.label1_TotalProducts.Location = new System.Drawing.Point(47, 101);
            this.label1_TotalProducts.Name = "label1_TotalProducts";
            this.label1_TotalProducts.Size = new System.Drawing.Size(181, 21);
            this.label1_TotalProducts.TabIndex = 30;
            this.label1_TotalProducts.Text = "TOTAL PRODUCTS:";
            // 
            // label2_TotalSales
            // 
            this.label2_TotalSales.AutoSize = true;
            this.label2_TotalSales.Font = new System.Drawing.Font("Perpetua Titling MT", 10.2F, System.Drawing.FontStyle.Bold);
            this.label2_TotalSales.Location = new System.Drawing.Point(383, 101);
            this.label2_TotalSales.Name = "label2_TotalSales";
            this.label2_TotalSales.Size = new System.Drawing.Size(132, 21);
            this.label2_TotalSales.TabIndex = 31;
            this.label2_TotalSales.Text = "TOTAL SALES:";
            // 
            // btn_daily
            // 
            this.btn_daily.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(29)))), ((int)(((byte)(61)))));
            this.btn_daily.Font = new System.Drawing.Font("Perpetua Titling MT", 10.2F, System.Drawing.FontStyle.Bold);
            this.btn_daily.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_daily.Location = new System.Drawing.Point(54, 16);
            this.btn_daily.Name = "btn_daily";
            this.btn_daily.Size = new System.Drawing.Size(225, 55);
            this.btn_daily.TabIndex = 32;
            this.btn_daily.Text = "DAILY";
            this.btn_daily.UseVisualStyleBackColor = false;
            this.btn_daily.Click += new System.EventHandler(this.btn_daily_Click);
            // 
            // btn_weekly
            // 
            this.btn_weekly.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(29)))), ((int)(((byte)(61)))));
            this.btn_weekly.Font = new System.Drawing.Font("Perpetua Titling MT", 10.2F, System.Drawing.FontStyle.Bold);
            this.btn_weekly.ForeColor = System.Drawing.Color.White;
            this.btn_weekly.Location = new System.Drawing.Point(285, 16);
            this.btn_weekly.Name = "btn_weekly";
            this.btn_weekly.Size = new System.Drawing.Size(218, 55);
            this.btn_weekly.TabIndex = 33;
            this.btn_weekly.Text = "WEEKLY";
            this.btn_weekly.UseVisualStyleBackColor = false;
            this.btn_weekly.Click += new System.EventHandler(this.btn_weekly_Click);
            // 
            // btn_monthly
            // 
            this.btn_monthly.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(29)))), ((int)(((byte)(61)))));
            this.btn_monthly.Font = new System.Drawing.Font("Perpetua Titling MT", 10.2F, System.Drawing.FontStyle.Bold);
            this.btn_monthly.ForeColor = System.Drawing.Color.White;
            this.btn_monthly.Location = new System.Drawing.Point(509, 16);
            this.btn_monthly.Name = "btn_monthly";
            this.btn_monthly.Size = new System.Drawing.Size(232, 55);
            this.btn_monthly.TabIndex = 34;
            this.btn_monthly.Text = "MONTHLY";
            this.btn_monthly.UseVisualStyleBackColor = false;
            this.btn_monthly.Click += new System.EventHandler(this.btn_monthly_Click);
            // 
            // btn_yearly
            // 
            this.btn_yearly.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(29)))), ((int)(((byte)(61)))));
            this.btn_yearly.Font = new System.Drawing.Font("Perpetua Titling MT", 10.2F, System.Drawing.FontStyle.Bold);
            this.btn_yearly.ForeColor = System.Drawing.Color.White;
            this.btn_yearly.Location = new System.Drawing.Point(747, 16);
            this.btn_yearly.Name = "btn_yearly";
            this.btn_yearly.Size = new System.Drawing.Size(220, 55);
            this.btn_yearly.TabIndex = 35;
            this.btn_yearly.Text = "YEARLY";
            this.btn_yearly.UseVisualStyleBackColor = false;
            this.btn_yearly.Click += new System.EventHandler(this.btn_yearly_Click);
            // 
            // DASHBOARD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1023, 625);
            this.Controls.Add(this.btn_yearly);
            this.Controls.Add(this.btn_monthly);
            this.Controls.Add(this.btn_weekly);
            this.Controls.Add(this.btn_daily);
            this.Controls.Add(this.label2_TotalSales);
            this.Controls.Add(this.label1_TotalProducts);
            this.Controls.Add(this.lblTotalSales);
            this.Controls.Add(this.lblTotalProducts);
            this.Controls.Add(this.btn_dsc);
            this.Controls.Add(this.btn_asc);
            this.Controls.Add(this.btn_search);
            this.Controls.Add(this.sort);
            this.Controls.Add(this.Search);
            this.Controls.Add(this.viewCategory);
            this.Controls.Add(this.lv_products);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "DASHBOARD";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.DASHBOARD_Load);
            ((System.ComponentModel.ISupportInitialize)(this.btn_dsc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_asc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_search)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox btn_dsc;
        private System.Windows.Forms.PictureBox btn_asc;
        private System.Windows.Forms.PictureBox btn_search;
        private System.Windows.Forms.ComboBox sort;
        private System.Windows.Forms.TextBox Search;
        private System.Windows.Forms.ComboBox viewCategory;
        private System.Windows.Forms.ListView lv_products;
        private System.Windows.Forms.ColumnHeader ID;
        private System.Windows.Forms.ColumnHeader ProductName;
        private System.Windows.Forms.ColumnHeader category;
        private System.Windows.Forms.ColumnHeader stock;
        private System.Windows.Forms.ColumnHeader status;
        private System.Windows.Forms.ColumnHeader priority;
        private System.Windows.Forms.ColumnHeader price;
        private System.Windows.Forms.Label lblTotalProducts;
        private System.Windows.Forms.Label lblTotalSales;
        private System.Windows.Forms.Label label1_TotalProducts;
        private System.Windows.Forms.Label label2_TotalSales;
        private System.Windows.Forms.Button btn_daily;
        private System.Windows.Forms.Button btn_weekly;
        private System.Windows.Forms.Button btn_monthly;
        private System.Windows.Forms.Button btn_yearly;
    }
}