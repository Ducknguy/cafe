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
    public partial class WelcomeForm : Form
    {
        public WelcomeForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        //Chuyển đổi sang form Login

        private void onClickLogin(object sender, EventArgs e)
        {
           LoginForm lgF = new LoginForm();
           lgF.Show();
         
            this.Hide();
        }
    }
}
