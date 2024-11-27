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
using System.IO;

namespace CafeShopMangement
{
    public partial class MenuForm : Form
    {
        bool slidebarExpand;
        private string userRole;

        string strCon = @"Data Source=DUC;Initial Catalog=QLCafe;Integrated Security=True;";

        SqlConnection sqlCon = null;
        SqlDataAdapter adapter = null;
        DataSet ds = null;

        private void MoKetNoi()
        {
            if (sqlCon == null) sqlCon = new SqlConnection(strCon);
            if (sqlCon.State == ConnectionState.Closed) sqlCon.Open();
        }

        private void HienThiDSSanPham()
        {
            MoKetNoi();

            string query = "select * from dssSanPham";
            adapter = new SqlDataAdapter(query, sqlCon);
            SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
            ds = new DataSet();
            adapter.Fill(ds, "dssSanPham");
            dgvDanhSachSP.DataSource = ds.Tables["dssSanPham"];
            if (sqlCon.State == ConnectionState.Open)
                sqlCon.Close();
        }

        private void HienThiDSGioHang()
        {
            MoKetNoi();
            string query = "select * from GioHang";

            adapter = new SqlDataAdapter(query, sqlCon);
            SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
            ds = new DataSet();
            adapter.Fill(ds, "GioHang");
            dgvGioHang.DataSource = ds.Tables["GioHang"];
        }
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
            else if (userRole == "cashier") // Cashier
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
            HienThiDSSanPham();
            HienThiDSGioHang();
            cbLoai.Items.Clear();
            cbLoai.Items.Add("Đồ ăn");
            cbLoai.Items.Add("Đô uống");
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

        private void btnCustomer_Click(object sender, EventArgs e)
        {
            CustomerForm customerForm = new CustomerForm();
            customerForm.Show();
            this.Close();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            for(int i = 0; i < 100; i++)
            {
                dupSoLuong.Items.Add(i);
            }         
            string maSp = txtMaSp.Text.Trim();
            string tenSp = txtTenSP.Text.Trim();
            string gia = txtGIa.Text.Trim();
            string loai = "";
            if (cbLoai.SelectedIndex == 0) loai = "Đồ ăn";
            if (cbLoai.SelectedIndex == 1) loai = "Nước uống";
            int soLuong = Convert.ToInt32(dupSoLuong.Text.Trim());

            DataRow row = ds.Tables["GioHang"].NewRow();
            row["MaSp"] = maSp;
            row["TenSp"] = tenSp;
            row["GiaSp"] = gia;
            row["LoaiSp"] = loai;
            row["SoLuong"] = soLuong;

            ds.Tables["GioHang"].Rows.Add(row);
            int kq = adapter.Update(ds.Tables["GioHang"]);
            if (kq > 0)
            {
                MessageBox.Show("Them thanh cong", "Hop thoai", MessageBoxButtons.OK, MessageBoxIcon.Information);
                HienThiDSGioHang();
            }
            else
            {
                MessageBox.Show("Them that bai", "HopThoai", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

        }
        private void XoaDuLieuForm()
        {
            txtGIa.Clear();
            txtMaSp.Clear();
            txtTenSP.Clear();
            txtTongTien.Clear();
            txtTraLai.Clear();
            cbLoai.SelectedIndex = 0;
        }
       int vt = -1;
        private void btnXoa_Click(object sender, EventArgs e)
        {
            
            DataRow row = ds.Tables["GioHang"].Rows[vt];

            //xoa dong da chon
            row.Delete();
            int kq = adapter.Update(ds.Tables["GioHang"]);
            if (kq > 0)
            {
                MessageBox.Show("xoa San Pham thanh cong!");
                HienThiDSGioHang();
                XoaDuLieuForm();
            }
            else
            {
                MessageBox.Show("xoa San Pham that bai");
                return;
            }
        }

        private void dgvGioHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            vt = e.RowIndex;
            if(vt == -1) return;

            DataRow row = ds.Tables["GioHang"].Rows[vt];
            txtMaSp.Text = row["MaSp"].ToString().Trim();
            txtTenSP.Text = row["TenSp"].ToString().Trim();
            txtGIa.Text = row["GiaSp"].ToString().Trim();
            txtGia2.Text = row["GiaSp"].ToString().Trim();
            if (row["LoaiSp"].ToString().Trim() == "0") cbLoai.SelectedIndex = 0;
            else cbLoai.SelectedIndex = 1;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            XoaDuLieuForm();
        }

        private void dgvDanhSachSP_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            vt = e.RowIndex;
            if (vt == -1) return;

            try
            {
                vt = e.RowIndex;
                if (vt == -1) return;

                // Lấy dữ liệu trực tiếp từ DataGridView
                if (dgvDanhSachSP.Rows[vt].Cells != null)
                {
                    txtMaSp.Text = dgvDanhSachSP.Rows[vt].Cells["MaSp"].Value?.ToString().Trim() ?? "";
                    txtTenSP.Text = dgvDanhSachSP.Rows[vt].Cells["TenSp"].Value?.ToString().Trim() ?? "";
                    txtGIa.Text = dgvDanhSachSP.Rows[vt].Cells["Gia"].Value?.ToString().Trim() ?? "";

                    string loaiSp = dgvDanhSachSP.Rows[vt].Cells["LoaiSp"].Value?.ToString().Trim() ?? "";
                    cbLoai.SelectedIndex = (loaiSp == "Đồ ăn") ? 0 : 1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}");
            }

            //DataRow row = ds.Tables["dssSanPham"].Rows[vt];

            //txtMaSp.Text = row["MaSp"].ToString().Trim();
            //txtTenSP.Text = row["TenSp"].ToString().Trim();
            //txtGIa.Text = row["GiaSp"].ToString().Trim();
            //if (row["LoaiSp"].ToString().Trim() == "Đồ ăn") cbLoai.SelectedIndex = 0;
            //else cbLoai.SelectedIndex = 1;

        }
    }
}