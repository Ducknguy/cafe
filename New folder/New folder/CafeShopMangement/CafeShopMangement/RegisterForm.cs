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
        SqlConnection connect = new SqlConnection(@"Data Source=DUC;Initial Catalog=QLCafe;Integrated Security=True");
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
            if (register_email.Text == "" || register_username.Text == ""
                || register_password.Text == "")
            {
                MessageBox.Show("Điền vào chỗ trống", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (connect.State != ConnectionState.Open)
                {
                    try
                    {
                        connect.Open();
                        String checkUsername = "SELECT * FROM UserLogin WHERE username = '"
                            + register_username.Text.Trim() + "'";

                        using (SqlCommand checkUser = new SqlCommand(checkUsername, connect))
                        {
                            SqlDataAdapter adapter = new SqlDataAdapter(checkUser);
                            DataTable table = new DataTable();
                            adapter.Fill(table);

                            if (table.Rows.Count >= 1)
                            {
                                MessageBox.Show(register_username.Text + " Tài khoản đã tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else
                            {
                                string insertData = "INSERT INTO UserLogin (email, username, password) " +
                                    "VALUES(@email, @username, @pass)";



                                using (SqlCommand cmd = new SqlCommand(insertData, connect))
                                {
                                    cmd.Parameters.AddWithValue("@email", register_email.Text.Trim());
                                    cmd.Parameters.AddWithValue("@username", register_username.Text.Trim());
                                    cmd.Parameters.AddWithValue("@pass", register_password.Text.Trim());


                                    cmd.ExecuteNonQuery();

                                    MessageBox.Show("Đăng ký thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                    // TO SWITCH THE FORM 
                                    LoginForm lForm = new LoginForm();
                                    lForm.Show();
                                    this.Hide();
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Kết nối database thất bại: " + ex, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
