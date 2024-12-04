namespace INVENTORYSYSTEM_GROUP2
{
    partial class INVENTORY
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(INVENTORY));
            this.prodnum = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lv_products = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.reorder = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btn_dsc = new System.Windows.Forms.PictureBox();
            this.btn_asc = new System.Windows.Forms.PictureBox();
            this.btn_search = new System.Windows.Forms.PictureBox();
            this.sort = new System.Windows.Forms.ComboBox();
            this.Search = new System.Windows.Forms.TextBox();
            this.viewCategory = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.critprod_num = new System.Windows.Forms.Label();
            this.btn_crit = new System.Windows.Forms.Button();
            this.btn_reorder = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.sort_status = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.btn_dsc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_asc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_search)).BeginInit();
            this.SuspendLayout();
            // 
            // prodnum
            // 
            this.prodnum.AutoSize = true;
            this.prodnum.Font = new System.Drawing.Font("Perpetua Titling MT", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.prodnum.ForeColor = System.Drawing.Color.DimGray;
            this.prodnum.Location = new System.Drawing.Point(195, 33);
            this.prodnum.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.prodnum.Name = "prodnum";
            this.prodnum.Size = new System.Drawing.Size(17, 17);
            this.prodnum.TabIndex = 46;
            this.prodnum.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Perpetua Titling MT", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(40, 33);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(151, 17);
            this.label1.TabIndex = 45;
            this.label1.Text = "No. of products:";
            // 
            // lv_products
            // 
            this.lv_products.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7,
            this.reorder});
            this.lv_products.Font = new System.Drawing.Font("Perpetua Titling MT", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lv_products.FullRowSelect = true;
            this.lv_products.GridLines = true;
            this.lv_products.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lv_products.HideSelection = false;
            this.lv_products.Location = new System.Drawing.Point(40, 191);
            this.lv_products.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.lv_products.MultiSelect = false;
            this.lv_products.Name = "lv_products";
            this.lv_products.Size = new System.Drawing.Size(725, 348);
            this.lv_products.TabIndex = 44;
            this.lv_products.UseCompatibleStateImageBehavior = false;
            this.lv_products.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "ID";
            this.columnHeader1.Width = 50;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "PRODUCT NAME";
            this.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader2.Width = 250;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "CATEGORY";
            this.columnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader3.Width = 200;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "STOCK";
            this.columnHeader4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader4.Width = 80;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "STATUS";
            this.columnHeader5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader5.Width = 120;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "PRIORITY";
            this.columnHeader6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader6.Width = 110;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "PRICE";
            this.columnHeader7.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader7.Width = 150;
            // 
            // reorder
            // 
            this.reorder.Text = "Reorder";
            this.reorder.Width = 120;
            // 
            // btn_dsc
            // 
            this.btn_dsc.Image = ((System.Drawing.Image)(resources.GetObject("btn_dsc.Image")));
            this.btn_dsc.Location = new System.Drawing.Point(585, 162);
            this.btn_dsc.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btn_dsc.Name = "btn_dsc";
            this.btn_dsc.Size = new System.Drawing.Size(20, 20);
            this.btn_dsc.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btn_dsc.TabIndex = 43;
            this.btn_dsc.TabStop = false;
            this.btn_dsc.Click += new System.EventHandler(this.btn_dsc_Click);
            // 
            // btn_asc
            // 
            this.btn_asc.Image = ((System.Drawing.Image)(resources.GetObject("btn_asc.Image")));
            this.btn_asc.Location = new System.Drawing.Point(563, 162);
            this.btn_asc.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btn_asc.Name = "btn_asc";
            this.btn_asc.Size = new System.Drawing.Size(20, 20);
            this.btn_asc.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btn_asc.TabIndex = 42;
            this.btn_asc.TabStop = false;
            this.btn_asc.Click += new System.EventHandler(this.btn_asc_Click);
            // 
            // btn_search
            // 
            this.btn_search.Image = ((System.Drawing.Image)(resources.GetObject("btn_search.Image")));
            this.btn_search.Location = new System.Drawing.Point(356, 164);
            this.btn_search.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btn_search.Name = "btn_search";
            this.btn_search.Size = new System.Drawing.Size(20, 20);
            this.btn_search.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btn_search.TabIndex = 41;
            this.btn_search.TabStop = false;
            this.btn_search.Click += new System.EventHandler(this.btn_search_Click);
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
            this.sort.Location = new System.Drawing.Point(610, 160);
            this.sort.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.sort.Name = "sort";
            this.sort.Size = new System.Drawing.Size(155, 25);
            this.sort.TabIndex = 39;
            this.sort.Text = "ID";
            this.sort.SelectedIndexChanged += new System.EventHandler(this.cb_sort_SelectedIndexChanged);
            // 
            // Search
            // 
            this.Search.Font = new System.Drawing.Font("Perpetua Titling MT", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Search.Location = new System.Drawing.Point(188, 162);
            this.Search.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Search.Name = "Search";
            this.Search.Size = new System.Drawing.Size(164, 24);
            this.Search.TabIndex = 40;
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
            "RAM"});
            this.viewCategory.Location = new System.Drawing.Point(40, 162);
            this.viewCategory.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.viewCategory.Name = "viewCategory";
            this.viewCategory.Size = new System.Drawing.Size(139, 25);
            this.viewCategory.TabIndex = 38;
            this.viewCategory.Text = "ALL";
            this.viewCategory.SelectedIndexChanged += new System.EventHandler(this.cb_viewCategory_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Perpetua Titling MT", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(40, 69);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(137, 17);
            this.label2.TabIndex = 47;
            this.label2.Text = "VIEW PRODUCTS:";
            // 
            // critprod_num
            // 
            this.critprod_num.AutoSize = true;
            this.critprod_num.Font = new System.Drawing.Font("Perpetua Titling MT", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.critprod_num.ForeColor = System.Drawing.Color.DimGray;
            this.critprod_num.Location = new System.Drawing.Point(270, 69);
            this.critprod_num.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.critprod_num.Name = "critprod_num";
            this.critprod_num.Size = new System.Drawing.Size(0, 17);
            this.critprod_num.TabIndex = 48;
            // 
            // btn_crit
            // 
            this.btn_crit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(29)))), ((int)(((byte)(61)))));
            this.btn_crit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_crit.Font = new System.Drawing.Font("Perpetua Titling MT", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_crit.ForeColor = System.Drawing.Color.White;
            this.btn_crit.Location = new System.Drawing.Point(40, 99);
            this.btn_crit.Margin = new System.Windows.Forms.Padding(2);
            this.btn_crit.Name = "btn_crit";
            this.btn_crit.Size = new System.Drawing.Size(88, 32);
            this.btn_crit.TabIndex = 49;
            this.btn_crit.Text = "CRITICAL";
            this.btn_crit.UseVisualStyleBackColor = false;
            this.btn_crit.Click += new System.EventHandler(this.btn_crit_Click);
            // 
            // btn_reorder
            // 
            this.btn_reorder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(29)))), ((int)(((byte)(61)))));
            this.btn_reorder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_reorder.Font = new System.Drawing.Font("Perpetua Titling MT", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_reorder.ForeColor = System.Drawing.Color.White;
            this.btn_reorder.Location = new System.Drawing.Point(143, 99);
            this.btn_reorder.Margin = new System.Windows.Forms.Padding(2);
            this.btn_reorder.Name = "btn_reorder";
            this.btn_reorder.Size = new System.Drawing.Size(94, 32);
            this.btn_reorder.TabIndex = 50;
            this.btn_reorder.Text = "REORDER";
            this.btn_reorder.UseVisualStyleBackColor = false;
            this.btn_reorder.Click += new System.EventHandler(this.btn_reorder_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Perpetua Titling MT", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(483, 33);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 17);
            this.label3.TabIndex = 51;
            this.label3.Text = "SORT:";
            // 
            // sort_status
            // 
            this.sort_status.Font = new System.Drawing.Font("Perpetua Titling MT", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sort_status.FormattingEnabled = true;
            this.sort_status.Items.AddRange(new object[] {
            "OPTIMAL",
            "OVERSTOCK"});
            this.sort_status.Location = new System.Drawing.Point(550, 30);
            this.sort_status.Margin = new System.Windows.Forms.Padding(2);
            this.sort_status.Name = "sort_status";
            this.sort_status.Size = new System.Drawing.Size(155, 25);
            this.sort_status.TabIndex = 52;
            this.sort_status.Text = "STATUS";
            // 
            // INVENTORY
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(803, 574);
            this.Controls.Add(this.sort_status);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btn_reorder);
            this.Controls.Add(this.btn_crit);
            this.Controls.Add(this.critprod_num);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.prodnum);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lv_products);
            this.Controls.Add(this.btn_dsc);
            this.Controls.Add(this.btn_asc);
            this.Controls.Add(this.btn_search);
            this.Controls.Add(this.sort);
            this.Controls.Add(this.Search);
            this.Controls.Add(this.viewCategory);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "INVENTORY";
            this.Text = "Form2";
            ((System.ComponentModel.ISupportInitialize)(this.btn_dsc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_asc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_search)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label prodnum;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView lv_products;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.PictureBox btn_dsc;
        private System.Windows.Forms.PictureBox btn_asc;
        private System.Windows.Forms.PictureBox btn_search;
        private System.Windows.Forms.ComboBox sort;
        private System.Windows.Forms.TextBox Search;
        private System.Windows.Forms.ComboBox viewCategory;
        private System.Windows.Forms.ColumnHeader reorder;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label critprod_num;
        private System.Windows.Forms.Button btn_crit;
        private System.Windows.Forms.Button btn_reorder;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox sort_status;
    }
}