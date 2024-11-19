using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace CafeShopMangement
{
    public partial class LoginForm : Form
    {
        SqlConnection connect = new SqlConnection(@"Data Source=DUC;Initial Catalog=QLCafe;Integrated Security=True;");
        public LoginForm()
        {
            InitializeComponent();
        }
        //Chuyển đổi sang form Register
        private void switchForm(object sender, EventArgs e)
        {
            RegisterForm registerForm = new RegisterForm();
            registerForm.Show();
            this.Hide();

        }

        private void onClickLogin(object sender, EventArgs e)
        {
            if (username.Text == "" || password.Text == "")
            {
                MessageBox.Show("Điền vào ô còn trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {

                if (connect.State != ConnectionState.Open)
                {
                    try
                    {
                        connect.Open();
                        String selectData = "select * from NhanVien where username = @username and password = @pass";
                        using (SqlCommand cmd = new SqlCommand(selectData, connect))
                        {
                            cmd.Parameters.AddWithValue("@username", username.Text);
                            cmd.Parameters.AddWithValue("@pass", password.Text);

                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                if (reader.Read())
                                {

                                    string userRole = (string)reader["role"];

                                    MessageBox.Show("Đăng nhập thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                    // Mở MenuForm và truyền role
                                    MenuForm menuForm = new MenuForm(userRole);
                                    menuForm.Show();
                                    this.Hide();
                                }
                                else
                                {
                                    MessageBox.Show("Sai tài khoản/mật khẩu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi kết nối: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        connect.Close();
                    }
                }
            }
        }

        
        private void btnExit2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
