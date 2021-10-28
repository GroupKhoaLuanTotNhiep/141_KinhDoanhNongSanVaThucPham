using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using NongSanThucPham;
using DBConnect;

namespace _141_KinhDoanhNongSanVaThucPham
{
    public partial class UC_QuanLyNhanVien : UserControl
    {
        Connection conn = new Connection();
        NhanVien nhanVien = new NhanVien();
        //SqlDataAdapter da_NhanVien;
        //DataSet ds_NhanVien;

        public UC_QuanLyNhanVien()
        {
            InitializeComponent();
        }

        private void btnThemTK_Click(object sender, EventArgs e)
        {
            frmThemTaiKhoanNhanVien themTaiKhoan = new frmThemTaiKhoanNhanVien();
            themTaiKhoan.ShowDialog();
        }

        private void btnChamCong_Click(object sender, EventArgs e)
        {
            frmChamCong chamCong = new frmChamCong();
            chamCong.ShowDialog();
        }

        private void btnTinhLuong_Click(object sender, EventArgs e)
        {
            frmTinhLuong tinhLuong = new frmTinhLuong();
            tinhLuong.ShowDialog();
        }

        void createTable_NhanVien()
        {
            //da_NhanVien = new SqlDataAdapter("Select * From NhanVien", conn.conn);
            //ds_NhanVien = new DataSet();
            //da_NhanVien.Fill(ds_NhanVien, "NhanVien");
            //DataColumn[] key = new DataColumn[1];
            //key[0] = ds_NhanVien.Tables["NhanVien"].Columns[0];
            //ds_NhanVien.Tables["NhanVien"].PrimaryKey = key;
            //dataGV_NhanVien.DataSource = ds_NhanVien.Tables["NhanVien"];
            //dataGV_NhanVien.Columns[3].DefaultCellStyle.Format = "dd/MM/yyyy";
            dataGV_NhanVien.DataSource = nhanVien.loadDataGV_NhanVien();
            dataGV_NhanVien.Columns[3].DefaultCellStyle.Format = "dd/MM/yyyy";
        }

        void loadComboBoxChucVu()
        {
            cboChucVu.DataSource = nhanVien.loadChucVu();
            cboChucVu.DisplayMember = "TenChucVu";
            cboChucVu.ValueMember = "MaChucVu";
        }

        private void loadLaiData()
        {
            string loadLaiDuLieu = "Select * From NhanVien";
            dataGV_NhanVien.DataSource = conn.LoadData(loadLaiDuLieu);
        }

        private void dataGV_NhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            if (e.RowIndex == -1) return;
            txtMaNV.Text = dataGV_NhanVien.Rows[index].Cells[0].Value.ToString();
            txtTenNV.Text = dataGV_NhanVien.Rows[index].Cells[1].Value.ToString();
            if (dataGV_NhanVien.Rows[index].Cells[2].Value.ToString() == "Nam")
            {
                radNam.Checked = true;
                radNu.Checked = false;
            }
            else
            {
                radNam.Checked = false;
                radNu.Checked = true;
            }
            txtNgaySinh.Text = DateTime.Parse(dataGV_NhanVien.CurrentRow.Cells[3].Value.ToString()).ToString("MM/dd/yyyy");
            txtDiaChi.Text = dataGV_NhanVien.Rows[index].Cells[4].Value.ToString();
            txtDienThoai.Text = dataGV_NhanVien.Rows[index].Cells[5].Value.ToString();
            txtEmail.Text = dataGV_NhanVien.Rows[index].Cells[6].Value.ToString();
            cboChucVu.Text = dataGV_NhanVien.Rows[index].Cells[7].Value.ToString();
            txtHinhNV.Text = dataGV_NhanVien.Rows[index].Cells[8].Value.ToString();
        }

        private void UC_QuanLyNhanVien_Load(object sender, EventArgs e)
        {
            createTable_NhanVien();
            loadComboBoxChucVu();
            radNam.Checked = true;
            btnLuuNV.Enabled = btnSuaNV.Enabled = btnXoaNV.Enabled = false;
        }

        private void btnThemMoi_Click(object sender, EventArgs e)
        {
            txtMaNV.Clear();
            txtTenNV.Clear();
            cboChucVu.Text = "";
            radNam.Checked = true;
            txtNgaySinh.Text = "";
            txtDiaChi.Clear();
            txtDienThoai.Clear();
            txtEmail.Clear();
            txtHinhNV.Clear();
            btnLuuNV.Enabled = true;
        }
    }
}
