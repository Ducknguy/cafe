using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;
using System.Data.Common;
using System.IO;

namespace CafeShopMangement
{

    public partial class AddCashier : Form
    {
        bool slidebarExpand;
        public AddCashier()
        {
            InitializeComponent();
        }

        string strCon = @"Data Source=DUC;Initial Catalog=QLCafe;Integrated Security=True";

        SqlConnection sqlCon = null;
        SqlDataAdapter adapter = null;
        DataSet ds = null;

        private void Moketnoi()
        {
            if (sqlCon == null) sqlCon = new SqlConnection(strCon);
            if (sqlCon.State == ConnectionState.Closed) sqlCon.Open();

        }

        private void HienThiDsNhanVien()
        {
            Moketnoi();

            string query = "Select * from NhanVien";

            adapter = new SqlDataAdapter(query, sqlCon);
            SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
            ds = new DataSet();
            adapter.Fill(ds, "NhanVien");
            dgvAddCashier.DataSource = ds.Tables["NhanVien"];



        }

        private byte[] getPhoto()
        {
            MemoryStream stream = new MemoryStream();
            pictureBox1.Image.Save(stream, pictureBox1.Image.RawFormat);
            return stream.GetBuffer();
        }

        private void ThemNhanVien()
        {
            //Lay du lieu tu giao dien
            string maNv = txtMaNv.Text.Trim();
            string tenNv = txtTenNv.Text.Trim();
            string diaChi = txtDiaChi.Text.Trim();
            string soDt = txtSDT.Text.Trim();
            string email = txtEmail.Text.Trim();
            string role = "";
            if (cbRole.SelectedIndex == 0) role = "admin";
            if (cbRole.SelectedIndex == 1) role = "cashier";


            //tao dong moi tren dgv
            DataRow row = ds.Tables["NhanVien"].NewRow();
            row["maNV"] = maNv;
            row["tenNV"] = tenNv;
            row["diaChi"] = diaChi;
            row["soDT"] = soDt;
            row["email"] = email;
            row["role"] = role;
            row["image"] = getPhoto();

            //them dong moi vao dgv
            ds.Tables["NhanVien"].Rows.Add(row);

            //update vao csdl
             int kq = adapter.Update(ds.Tables["NhanVien"]);

            //kiem tra ket qua
            if (kq > 0)
            {
                MessageBox.Show("Them Nhan Vien thanh cong!");
                HienThiDsNhanVien();

                XoaDuLieuForm();

            }
            else
            {
                MessageBox.Show("Them Nhan Vien that bai");
                return;
            }
        }
        int vt = -1;
        

        
        private void XoaDuLieuForm()
        {
            txtMaNv.Clear();
            txtTenNv.Clear();
            txtEmail.Clear();
            txtDiaChi.Clear();
            txtSDT.Clear();
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

        private void btnLogout_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn thoát! ","Hộp thoại", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                LoginForm loginForm = new LoginForm();
                loginForm.Show();
                this.Close();
            }
        }

        private void AddCashier_Load(object sender, EventArgs e)
        {
            cbRole.Items.Clear();
            cbRole.Items.Add("admin");
            cbRole.Items.Add("cashier");
            HienThiDsNhanVien();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            ThemNhanVien();
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = new Bitmap(openFileDialog.FileName);
            }
        }
        private void XoaNhanVien()
        {
            //xac dinh doi tuong dong da chon
            DataRow row = ds.Tables["NhanVien"].Rows[vt];

            //xoa dong da chon
            row.Delete();
            int kq = adapter.Update(ds.Tables["NhanVien"]);
            if (kq > 0)
            {
                MessageBox.Show("sa thai Nhan Vien thanh cong!");
                HienThiDsNhanVien();

                XoaDuLieuForm();

            }
            else
            {
                MessageBox.Show("sa thai Nhan Vien that bai");
                return;
            }
        }
        private void SuaNhanVien()
        {
            if (vt == -1) return;

            //Lay du lieu tu giao dien
            string maNv = txtMaNv.Text.Trim();
            string tenNv = txtTenNv.Text.Trim();
            string soDt = txtSDT.Text.Trim();
            string email = txtEmail.Text.Trim();
            string diaChi = txtDiaChi.Text.Trim();
            string role = "";
            if (cbRole.SelectedIndex == 0) role = "admin";
            if (cbRole.SelectedIndex == 1) role = "cashier";

            //xac dinh doi tuong dong da chon
            DataRow row = ds.Tables["NhanVien"].Rows[vt];
            row.BeginEdit();
            //bat dau chinh sua
            row["maNV"] = maNv;
            row["tenNV"] = tenNv;
            row["soDT"] = soDt;
            row["email"] = email;
            row["diaChi"] = diaChi;
            row["role"] = role;
            row["image"] = getPhoto();


            //ket thuc chinh sua

            row.EndEdit();
            //update vao csdl
            int kq = adapter.Update(ds.Tables["NhanVien"]);
            if (kq > 0)
            {
                MessageBox.Show("Sua Nhan Vien thanh cong!");
                HienThiDsNhanVien();

                XoaDuLieuForm();

            }
            else
            {
                MessageBox.Show("Chinh sua Nhan Vien that bai");
                return;
            }
        }

       

        private void btnSua_Click(object sender, EventArgs e)
        {
            SuaNhanVien();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (vt == -1) return;
            DialogResult result = MessageBox.Show("Ban co thuc su muon sa thai Nhan Vien nay khong?",
                "Hop thoai",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
                );
            if (result == DialogResult.Yes)
            {
                {
                    XoaNhanVien();
                }
            }
        }

        private void dgvAddCashier_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            vt = e.RowIndex;
            if (vt == -1) return;

            //xac dinh doi tuong da chon
            DataRow row = ds.Tables["NhanVien"].Rows[vt];

            //fill du lieu tu ben trai sang phai
            txtMaNv.Text = row["maNV"].ToString().Trim();
            txtTenNv.Text = row["tenNV"].ToString().Trim();
            txtSDT.Text = row["soDT"].ToString().Trim();
            txtEmail.Text = row["email"].ToString().Trim();
            txtDiaChi.Text = row["diaChi"].ToString().Trim();
            if (row["role"].ToString().Trim() == "0") cbRole.SelectedIndex = 0;
            else cbRole.SelectedIndex = 1;
            if (row["image"] != DBNull.Value)
            {
                byte[] imageBytes = (byte[])row["image"];
                using (MemoryStream ms = new MemoryStream(imageBytes))
                {
                    pictureBox1.Image = Image.FromStream(ms);
                }
            }
            else
            {
                pictureBox1.Image = null;
            }
        }
    }
    }

