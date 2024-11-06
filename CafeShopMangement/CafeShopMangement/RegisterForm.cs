using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace CafeShopMangement
{
    public partial class RegisterForm : Form
    {
        SqlConnection connect = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\duc67\Documents\cafe.mdf;Integrated Security=True;Connect Timeout=30;Encrypt=True");
        public RegisterForm()
        {
            InitializeComponent();
        }
        //Chuyển đổi sang form Login

        private void switchForm(object sender, EventArgs e)
        {
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
            this.Hide();
            
        }
        public bool emptyFields()
        {
            if (register_password.Text == "" || register_username.Text == "")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private void onClickRegister(object sender, EventArgs e)
        {
            if (emptyFields())
            {
                MessageBox.Show("Ban chua nhap tai khoan hoac mat khau!", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                string selectUsername = "SELECT * FROM users WHERE username = @usern";

                using (SqlCommand checkUsername = new SqlCommand(selectUsername, connect))
                {
                    checkUsername.Parameters.AddWithValue("@usern", register_username.Text.Trim());
                }
            }
        }
    }
}
