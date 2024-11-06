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
    public partial class AddProductForm : Form
    {
        bool slidebarExpand;
        public AddProductForm()
        {
            InitializeComponent();
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
        private void pictureBox4_MouseHover(object sender, EventArgs e)
        {
            slidebarTimer.Start();

        }

        private void pictureBox4_MouseLeave(object sender, EventArgs e)
        {
            slidebarTimer.Start();


        }

    }
}
