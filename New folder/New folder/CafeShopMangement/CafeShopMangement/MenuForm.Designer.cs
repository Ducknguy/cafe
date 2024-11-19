namespace CafeShopMangement
{
    partial class MenuForm
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
            this.slidebar = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.btnMenu = new System.Windows.Forms.PictureBox();
            this.btnAddCashier = new System.Windows.Forms.Button();
            this.btnCustomer = new System.Windows.Forms.Button();
            this.btnDashboard = new System.Windows.Forms.Button();
            this.btnAddProduct = new System.Windows.Forms.Button();
            this.btnOrder = new System.Windows.Forms.Button();
            this.panel8 = new System.Windows.Forms.Panel();
            this.btnLogout = new System.Windows.Forms.Button();
            this.slidebarTimer = new System.Windows.Forms.Timer(this.components);
            this.pcbmenu = new System.Windows.Forms.PictureBox();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.slidebar.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnMenu)).BeginInit();
            this.panel8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcbmenu)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // slidebar
            // 
            this.slidebar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(180)))), ((int)(((byte)(134)))));
            this.slidebar.CausesValidation = false;
            this.slidebar.Controls.Add(this.panel1);
            this.slidebar.Controls.Add(this.btnAddCashier);
            this.slidebar.Controls.Add(this.btnCustomer);
            this.slidebar.Controls.Add(this.btnDashboard);
            this.slidebar.Controls.Add(this.btnAddProduct);
            this.slidebar.Controls.Add(this.btnOrder);
            this.slidebar.Controls.Add(this.panel8);
            this.slidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.slidebar.Location = new System.Drawing.Point(0, 0);
            this.slidebar.MaximumSize = new System.Drawing.Size(235, 661);
            this.slidebar.MinimumSize = new System.Drawing.Size(90, 661);
            this.slidebar.Name = "slidebar";
            this.slidebar.Size = new System.Drawing.Size(235, 661);
            this.slidebar.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnMenu);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(232, 96);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(92, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 36);
            this.label1.TabIndex = 1;
            this.label1.Text = "Menu";
            // 
            // btnMenu
            // 
            this.btnMenu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMenu.Image = global::CafeShopMangement.Properties.Resources.icons8_menu_64;
            this.btnMenu.Location = new System.Drawing.Point(6, 1);
            this.btnMenu.Name = "btnMenu";
            this.btnMenu.Size = new System.Drawing.Size(64, 64);
            this.btnMenu.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.btnMenu.TabIndex = 1;
            this.btnMenu.TabStop = false;
            this.btnMenu.Click += new System.EventHandler(this.btnMenu_Click);
            // 
            // btnAddCashier
            // 
            this.btnAddCashier.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(180)))), ((int)(((byte)(134)))));
            this.btnAddCashier.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddCashier.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddCashier.Location = new System.Drawing.Point(3, 105);
            this.btnAddCashier.Name = "btnAddCashier";
            this.btnAddCashier.Size = new System.Drawing.Size(232, 79);
            this.btnAddCashier.TabIndex = 2;
            this.btnAddCashier.Text = "AddCashier";
            this.btnAddCashier.UseVisualStyleBackColor = false;
            this.btnAddCashier.Click += new System.EventHandler(this.btnAddCashier_Click);
            // 
            // btnCustomer
            // 
            this.btnCustomer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(180)))), ((int)(((byte)(134)))));
            this.btnCustomer.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCustomer.Location = new System.Drawing.Point(3, 190);
            this.btnCustomer.Name = "btnCustomer";
            this.btnCustomer.Size = new System.Drawing.Size(232, 73);
            this.btnCustomer.TabIndex = 2;
            this.btnCustomer.Text = "Customer";
            this.btnCustomer.UseVisualStyleBackColor = false;
            // 
            // btnDashboard
            // 
            this.btnDashboard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(180)))), ((int)(((byte)(134)))));
            this.btnDashboard.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDashboard.Location = new System.Drawing.Point(3, 269);
            this.btnDashboard.Name = "btnDashboard";
            this.btnDashboard.Size = new System.Drawing.Size(232, 78);
            this.btnDashboard.TabIndex = 2;
            this.btnDashboard.Text = "DashBoard";
            this.btnDashboard.UseVisualStyleBackColor = false;
            // 
            // btnAddProduct
            // 
            this.btnAddProduct.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(180)))), ((int)(((byte)(134)))));
            this.btnAddProduct.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddProduct.Location = new System.Drawing.Point(3, 353);
            this.btnAddProduct.Name = "btnAddProduct";
            this.btnAddProduct.Size = new System.Drawing.Size(232, 77);
            this.btnAddProduct.TabIndex = 2;
            this.btnAddProduct.Text = "AddProduct";
            this.btnAddProduct.UseVisualStyleBackColor = false;
            this.btnAddProduct.Click += new System.EventHandler(this.btnAddProduct_Click);
            // 
            // btnOrder
            // 
            this.btnOrder.BackColor = System.Drawing.Color.White;
            this.btnOrder.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOrder.Location = new System.Drawing.Point(3, 436);
            this.btnOrder.Name = "btnOrder";
            this.btnOrder.Size = new System.Drawing.Size(241, 61);
            this.btnOrder.TabIndex = 2;
            this.btnOrder.Text = "Order";
            this.btnOrder.UseVisualStyleBackColor = false;
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.btnLogout);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel8.Location = new System.Drawing.Point(3, 503);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(232, 113);
            this.panel8.TabIndex = 2;
            // 
            // btnLogout
            // 
            this.btnLogout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(180)))), ((int)(((byte)(134)))));
            this.btnLogout.CausesValidation = false;
            this.btnLogout.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLogout.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnLogout.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogout.Location = new System.Drawing.Point(62, 58);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(124, 55);
            this.btnLogout.TabIndex = 1;
            this.btnLogout.Text = "Logout!";
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            this.btnLogout.MouseLeave += new System.EventHandler(this.btnLogout_MouseLeave);
            this.btnLogout.MouseHover += new System.EventHandler(this.btnLogout_MouseHover);
            // 
            // slidebarTimer
            // 
            this.slidebarTimer.Interval = 5;
            this.slidebarTimer.Tick += new System.EventHandler(this.slidebarTimer_Tick);
            // 
            // pcbmenu
            // 
            this.pcbmenu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pcbmenu.Image = global::CafeShopMangement.Properties.Resources.icons8_menu_64;
            this.pcbmenu.Location = new System.Drawing.Point(9, 0);
            this.pcbmenu.Name = "pcbmenu";
            this.pcbmenu.Size = new System.Drawing.Size(64, 64);
            this.pcbmenu.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pcbmenu.TabIndex = 2;
            this.pcbmenu.TabStop = false;
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(235, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 661);
            this.splitter1.TabIndex = 3;
            this.splitter1.TabStop = false;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.dataGridView1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(235, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(897, 661);
            this.panel3.TabIndex = 2;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(897, 661);
            this.dataGridView1.TabIndex = 0;
            // 
            // MenuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.btnLogout;
            this.ClientSize = new System.Drawing.Size(1132, 661);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.slidebar);
            this.MaximizeBox = false;
            this.Name = "MenuForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "+-";
            this.Load += new System.EventHandler(this.MenuForm_Load);
            this.slidebar.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnMenu)).EndInit();
            this.panel8.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pcbmenu)).EndInit();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel slidebar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox btnMenu;
        private System.Windows.Forms.Timer slidebarTimer;
        private System.Windows.Forms.Button btnAddCashier;
        private System.Windows.Forms.Button btnAddProduct;
        private System.Windows.Forms.Button btnDashboard;
        private System.Windows.Forms.Button btnCustomer;
        private System.Windows.Forms.Button btnOrder;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.PictureBox pcbmenu;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}