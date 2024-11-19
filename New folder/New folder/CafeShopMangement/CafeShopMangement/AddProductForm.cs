using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace CafeShopMangement
{
    public partial class AddProductForm : Form
    {
        bool slidebarExpand;
        public AddProductForm()
        {
            InitializeComponent();
        }

        //Chuoi ket noi
        string strCon = @"Data Source=DUC;Initial Catalog=QLCafe;Integrated Security=True";

        //Doi tuong ket noi
        SqlConnection sqlCon = null; 
        SqlDataAdapter adapter = null;

        DataSet ds = null;

        //Ham mo ket noi
        private void Moketnoi()
        {
            if (sqlCon == null) sqlCon = new SqlConnection(strCon);
            if (sqlCon.State == ConnectionState.Closed) sqlCon.Open();

        }
        //ham hien thi danh sach san pham
        private void HienThiDsSanPham()
        {
            Moketnoi();

            string query = "Select * from dssSanPham";

            adapter = new SqlDataAdapter(query, sqlCon);
            SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
            ds = new DataSet();
            adapter.Fill(ds, "dssSanPham");
            dgvDanhSach.DataSource = ds.Tables["dssSanPham"];
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

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtMaSp.Clear();
            txtTenSp.Clear();
            txtSoLuong.Clear();
            txtGia.Clear();
            cbLoaiSp.SelectedIndex = 0;

        }

        private void AddProductForm_Load(object sender, EventArgs e)
        {
            cbLoaiSp.Items.Clear();
            cbLoaiSp.Items.Add("Đồ ăn");
            cbLoaiSp.Items.Add("Nước uống");
            HienThiDsSanPham();

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            ThemSanPham();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            SuaSanPham();
        }

        private byte[] getPhoto()
        {
            MemoryStream stream = new MemoryStream();
            pictureBox1.Image.Save(stream,pictureBox1.Image.RawFormat);
            return stream.GetBuffer();
        }
        private void ThemSanPham()
        {
            //Lay du lieu tu giao dien
            string maSp = txtMaSp.Text.Trim();
            string tenSp = txtTenSp.Text.Trim();
            string loai = "";
            if (cbLoaiSp.SelectedIndex == 0) loai = "Đồ ăn";
            else if (cbLoaiSp.SelectedIndex == 1) loai = "Nước uống";
            string soLuong = txtSoLuong.Text.Trim();
            string gia = txtGia.Text.Trim();
             

            //tao dong moi tren dgv
            DataRow row = ds.Tables["dssSanPham"].NewRow();
            row["MaSp"] = maSp;
            row["TenSp"] = tenSp;
            row["LoaiSp"] = loai;
            row["SoLuong"] = soLuong;
            row["Gia"] = gia;
            row["Anh"] = getPhoto();

            //them dong moi vao dgv
            ds.Tables["dssSanPham"].Rows.Add(row);

            //update vao csdl
            int kq = adapter.Update(ds.Tables["dssSanPham"]);

            //kiem tra ket qua
            if (kq > 0)
            {
                MessageBox.Show("Them San Pham thanh cong!");
                HienThiDsSanPham();

                XoaDuLieuForm();

            }
            else
            {
                MessageBox.Show("Them San Pham that bai");
                return;
            }
        }
        private void SuaSanPham()
        {
            if (vt == -1) return;

            //Lay du lieu tu giao dien
            string maSp = txtMaSp.Text.Trim();
            string tenSp = txtTenSp.Text.Trim();
            string loai = "";
            if (cbLoaiSp.SelectedIndex == 0) loai = "Đồ ăn";
            else if (cbLoaiSp.SelectedIndex == 1) loai = "Nước uống";
            string soLuong = txtSoLuong.Text.Trim();
            string gia = txtGia.Text.Trim();

            //xac dinh doi tuong dong da chon
            DataRow row = ds.Tables["dssSanPham"].Rows[vt];

            //bat dau chinh sua
            row.BeginEdit();
            row["MaSp"] = maSp;
            row["TenSp"] = tenSp;
            row["LoaiSp"] = loai;
            row["SoLuong"] = soLuong;
            row["Gia"] = gia;
            row["Anh"] = getPhoto();



            //ket thuc chinh sua

            row.EndEdit();
            //update vao csdl
            int kq = adapter.Update(ds.Tables["dssSanPham"]);
            if (kq > 0)
            {
                MessageBox.Show("Sua San Pham thanh cong!");
                HienThiDsSanPham();

                XoaDuLieuForm();
                
            }
            else
            {
                MessageBox.Show("Chinh sua San Pham that bai");
                return;
            }
          
        }

        private void XoaDuLieuForm()
        {
            txtGia.Clear();
            txtMaSp.Clear();
            txtSoLuong.Clear();
            txtTenSp.Clear();
            cbLoaiSp.SelectedIndex = 0;
        }

        int vt = -1;
        private void dgvSanPham(object sender, DataGridViewCellEventArgs e)
        {
            vt = e.RowIndex;
            if (vt == -1) return;

            //xac dinh doi tuong da chon
            DataRow row = ds.Tables["dssSanPham"].Rows[vt];

            //fill du lieu tu ben trai sang phai
            txtMaSp.Text = row["MaSp"].ToString().Trim();
            txtTenSp.Text = row["TenSp"].ToString().Trim();
            if (row["LoaiSp"].ToString().Trim() == "Đồ ăn") cbLoaiSp.SelectedIndex = 0;
            else cbLoaiSp.SelectedIndex = 1;
            txtSoLuong.Text = row["SoLuong"].ToString().Trim();
            txtGia.Text = row["Gia"].ToString().Trim();
            if (row["Anh"] != DBNull.Value)
            {
                byte[] imageBytes = (byte[])row["Anh"];
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

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (vt == -1) return;
            DialogResult result = MessageBox.Show("Ban co thuc su muon xoa san pham nay khong?",
                "Hop thoai",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
                );
            if (result == DialogResult.Yes)
            {
                {
                    XoaSanPham();
                }
            }
        }
        private void XoaSanPham()
        {
            //xac dinh doi tuong dong da chon
            DataRow row = ds.Tables["dssSanPham"].Rows[vt];

            //xoa dong da chon
            row.Delete();
            int kq = adapter.Update(ds.Tables["dssSanPham"]);
            if (kq > 0)
            {
                MessageBox.Show("xoa San Pham thanh cong!");
                HienThiDsSanPham();

                XoaDuLieuForm();
               
            }
            else
            {
                MessageBox.Show("xoa San Pham that bai");
                return;
            }
           
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
           
        }

        private void btnTaiAnh_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if(openFileDialog.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = new Bitmap(openFileDialog.FileName);
            }

        }

        private void btnAddCashier_Click(object sender, EventArgs e)
        {
            AddCashier addCashier = new AddCashier();
            addCashier.Show();
            this.Close();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn thoát", "Hộp thoại", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                LoginForm loginForm = new LoginForm();
                loginForm.Show();
                this.Close();
            }
            }
    }
    }

