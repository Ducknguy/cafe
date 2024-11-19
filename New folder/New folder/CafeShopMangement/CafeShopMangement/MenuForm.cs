using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CafeShopMangement
{
    public partial class MenuForm : Form
    {
        bool slidebarExpand;
        private string userRole;

        // Constructor nhận role từ form đăng nhập
        public MenuForm(string role)
        {
            InitializeComponent();
            userRole = role;
            SetupMenuVisibility();
        }
        private void SetupMenuVisibility()
        {
            if (userRole == "admin") // Admin
            {
                // Hiển thị tất cả chức năng
                btnAddCashier.Visible = true;
                btnAddProduct.Visible = true;
                btnDashboard.Visible = true;
                btnCustomer.Visible = true;
                btnOrder.Visible = true;
            }
            else if(userRole=="cashier") // Cashier
            {
                // Chỉ hiển thị chức năng Customer và Order
                btnAddCashier.Visible = false;
                btnAddProduct.Visible = false;
                btnDashboard.Visible = false;
                btnCustomer.Visible = false;
                btnOrder.Visible = true;
            }
        }
        
        
        private void MenuForm_Load(object sender, EventArgs e)
        {


        }
       
        private void slidebarTimer_Tick(object sender, EventArgs e)
        {
            if (slidebarExpand)
            {
                slidebar.Width -= 10;
                if (slidebar.Width == slidebar.MinimumSize.Width)
                {
                    slidebarExpand = false;
                    slidebarTimer.Stop();
                    btnLogout.Hide();
                    btnAddCashier.Hide();
                    btnAddProduct.Hide();
                    btnCustomer.Hide();
                    btnDashboard.Hide();
                    btnOrder.Hide();
                }
            }
            else
            {
                slidebar.Width += 10;
                if (slidebar.Width == slidebar.MaximumSize.Width)
                {
                    slidebarExpand = true;
                    slidebarTimer.Stop();
                    btnLogout.Show();
                    btnAddCashier.Show();
                    btnAddProduct.Show();
                    btnCustomer.Show();
                    btnDashboard.Show();
                    btnOrder.Show();
                }
            }
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            slidebarTimer.Start();

        }

        private void btnLogout_MouseHover(object sender, EventArgs e)
        {
            btnLogout.BackColor = Color.FromArgb(178, 139, 98);
        }

        private void btnLogout_MouseLeave(object sender, EventArgs e)
        {
            btnLogout.BackColor = Color.FromArgb(221, 180, 134);

        }


        private void pictureBox4_MouseHover(object sender, EventArgs e)
        {
            slidebarTimer.Start();

        }

        private void pictureBox4_MouseLeave(object sender, EventArgs e)
        {
            slidebarTimer.Start();


        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn thoát! ", "Hộp thoại", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                LoginForm loginForm = new LoginForm();
                loginForm.Show();
                this.Close();
            }
            
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            AddProductForm addProductForm = new AddProductForm();
            addProductForm.Show();
            this.Close();
        }

        private void btnAddCashier_Click(object sender, EventArgs e)
        {
            AddCashier addCashier = new AddCashier();
            addCashier.Show();
            this.Close();
        }
    }
   
}