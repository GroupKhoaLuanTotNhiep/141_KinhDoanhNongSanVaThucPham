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
using NongSanThucPham;
using DBConnect;

namespace _141_KinhDoanhNongSanVaThucPham
{
    public partial class frmTinhLuong : Form
    {
        Connection conn = new Connection();
        NhanVien nhanVien = new NhanVien();
        int index;

        public frmTinhLuong()
        {
            InitializeComponent();
        }

        private void btnChamCong_Click(object sender, EventArgs e)
        {
            frmChamCong chamCong = new frmChamCong();
            chamCong.ShowDialog();
        }

        void createTable_NhanVien()
        {
            dataGV_LuongNhanVien.DataSource = nhanVien.loadNhanVienLenBangTinhLuong();
        }

        void createTable_BangLuong()
        {
            dataGV_LuongNhanVien.DataSource = nhanVien.loadBangTinhLuong();
            dataGV_LuongNhanVien.Columns[9].DefaultCellStyle.Format = "dd/MM/yyyy";
        }

        private void frmTinhLuong_Load(object sender, EventArgs e)
        {
            txtMaNV.Enabled = txtTenNV.Enabled = false;
            btnSuaThongTin.Enabled = btnXoaThongTin.Enabled = false;
            createTable_NhanVien();
        }

        //Kiểm tra Ngày tính lương phải là ngày trước hoặc là Ngày hiện tại 
        public bool kiemTraNgayTinhLuongVaNgayHT()
        {
            string ngayHienTai = DateTime.Now.Year.ToString() + "/" + DateTime.Now.Month.ToString() + "/" + DateTime.Now.Day.ToString();
            string strNgayTinhLuong = DateTime.ParseExact(txtNgayTinhLuong.Text, "dd/MM/yyyy", null).ToString("yyyy/MM/dd");
            string strNgayHienTai = ngayHienTai;
            int ngay = DateTime.Parse(ngayHienTai).Day - DateTime.Parse(strNgayTinhLuong).Day;
            int thang = DateTime.Parse(ngayHienTai).Month - DateTime.Parse(strNgayTinhLuong).Month;
            int nam = DateTime.Parse(ngayHienTai).Year - DateTime.Parse(strNgayTinhLuong).Year;
            if (nam < 0 || (thang < 0 && nam == 0) || ((ngay < 0) && thang == 0 && nam == 0))
                return false;
            return true;
        }

        //Kiểm tra Tháng tính lương phải là tháng trước hoặc là Tháng hiện tại
        public bool kiemTraThangTinhLuongVaThangHT()
        {
            string ngayHienTai = DateTime.Now.Year.ToString() + "/" + DateTime.Now.Month.ToString() + "/" + DateTime.Now.Day.ToString();
            string strNgayTinhLuong = DateTime.ParseExact(txtNgayTinhLuong.Text, "dd/MM/yyyy", null).ToString("yyyy/MM/dd");
            string strNgayHienTai = ngayHienTai;
            int thang = DateTime.Parse(ngayHienTai).Month - DateTime.Parse(strNgayTinhLuong).Month;
            int nam = DateTime.Parse(ngayHienTai).Year - DateTime.Parse(strNgayTinhLuong).Year;
            if (nam < 0 || (thang < 0 && nam == 0))
                return false;
            return true;
        }

        //Kiểm tra Từ ngày phải là ngày trước Đến ngày
        public bool kiemTraNgayDauVaNgayCuoi()
        {
            string ngayDau = DateTime.ParseExact(txtTuNgay.Text, "dd/MM/yyyy", null).ToString("yyyy/MM/dd");
            string strNgayCuoi = DateTime.ParseExact(txtDenNgay.Text, "dd/MM/yyyy", null).ToString("yyyy/MM/dd");
            int ngay = DateTime.Parse(strNgayCuoi).Day - DateTime.Parse(ngayDau).Day;
            int thang = DateTime.Parse(strNgayCuoi).Month - DateTime.Parse(ngayDau).Month;
            int nam = DateTime.Parse(strNgayCuoi).Year - DateTime.Parse(ngayDau).Year;
            if (nam < 0 || (thang < 0 && nam == 0) || ((ngay < 0 || ngay == 0) && thang == 0 && nam == 0))
                return false;
            return true;
        }

        //Kiểm tra Ngày cuối phải là ngày trước hoặc là Ngày hiện tại
        public bool kiemTraNgayCuoiVaNgayHT()
        {
            string ngayHienTai = DateTime.Now.Year.ToString() + "/" + DateTime.Now.Month.ToString() + "/" + DateTime.Now.Day.ToString();
            string strNgayCuoi = DateTime.ParseExact(txtDenNgay.Text, "dd/MM/yyyy", null).ToString("yyyy/MM/dd");
            string strNgayHienTai = ngayHienTai;
            int ngay = DateTime.Parse(ngayHienTai).Day - DateTime.Parse(strNgayCuoi).Day;
            int thang = DateTime.Parse(ngayHienTai).Month - DateTime.Parse(strNgayCuoi).Month;
            int nam = DateTime.Parse(ngayHienTai).Year - DateTime.Parse(strNgayCuoi).Year;
            if (nam < 0 || (thang < 0 && nam == 0) || ((ngay < 0) && thang == 0 && nam == 0))
                return false;
            return true;
        }


        private void btnCapNhatLNV_Click(object sender, EventArgs e)
        {
            try
            {
                if (kiemTraNgayTinhLuongVaNgayHT() == false)
                {
                    MessageBox.Show("Ngày tính lương phải là ngày trước hoặc là Ngày hiện tại!");
                    return;
                }
                if (kiemTraThangTinhLuongVaThangHT() == false)
                {
                    MessageBox.Show("Phải nhập Tháng tính lương là tháng trước hoặc là Tháng hiện tại!");
                    return;
                }
                if (kiemTraNgayDauVaNgayCuoi() == false)
                {
                    MessageBox.Show("Từ ngày phải là ngày trước Đến ngày!");
                    return;
                }
                if (kiemTraNgayCuoiVaNgayHT() == false)
                {
                    MessageBox.Show("Ngày cuối phải là ngày trước hoặc là Ngày hiện tại!");
                    return;
                }
                for (int i = 0; i < dataGV_LuongNhanVien.RowCount - 1; i++)
                {
                    string ngaydau = DateTime.ParseExact(txtTuNgay.Text, "dd/MM/yyyy", null).ToString("yyyy/MM/dd");
                    string ngaycuoi = DateTime.ParseExact(txtDenNgay.Text, "dd/MM/yyyy", null).ToString("yyyy/MM/dd");
                    string ngaytinhluong = DateTime.ParseExact(txtNgayTinhLuong.Text, "dd/MM/yyyy", null).ToString("yyyy/MM/dd");
                    string manv = dataGV_LuongNhanVien.Rows[i].Cells["MaNV"].Value.ToString().Trim();
                    float hsl = float.Parse(dataGV_LuongNhanVien.Rows[i].Cells["HeSoLuong"].Value.ToString().Trim());
                    int lcb = int.Parse(dataGV_LuongNhanVien.Rows[i].Cells["LuongCoBan"].Value.ToString().Trim());
                    int songaylam = nhanVien.demSoNgayLam(manv, ngaydau, ngaycuoi);
                    int phucap = 0;
                    int tienthuong = 0;
                    int tienphat = 0;
                    int tongLuong = (int)(hsl * lcb * songaylam) + phucap + tienthuong - tienphat;
                    if (!nhanVien.kiemTraTonTaiThangLuong("BangLuong", "MaNV", "NgayTinhLuong", manv, ngaydau, ngaycuoi))
                    {
                        string strSQLIS = "INSERT BangLuong VALUES(" + manv + ", '" + ngaytinhluong + "', " + songaylam + ", " + phucap + ", " + tienthuong + ", " + tienphat + ", " + tongLuong + ")";
                        conn.updateToDatabase(strSQLIS);
                    }
                    else
                    {
                        string strSQLUD = "UPDATE BangLuong SET SoNgayLam=" + songaylam + ", PhuCap=" + phucap + ", TienThuong=" + tienthuong + ", TienPhat=" + tienphat + ", TongLuong=" + tongLuong + " WHERE MaNV=" + manv + " AND NgayTinhLuong='" + ngaytinhluong + "'";
                        conn.updateToDatabase(strSQLUD);
                    }
                }
                createTable_BangLuong();
                MessageBox.Show("Cập nhật thành công!");
            }
            catch
            {
                MessageBox.Show("Cập nhật thất bại!");
                createTable_BangLuong();
            }
        }

        private void dataGV_LuongNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int index = e.RowIndex;
                if (e.RowIndex == -1) return;
                txtMaNV.Text = dataGV_LuongNhanVien.Rows[index].Cells[0].Value.ToString();
                txtTenNV.Text = dataGV_LuongNhanVien.Rows[index].Cells[1].Value.ToString();
                txtSoNgayLam.Text = dataGV_LuongNhanVien.Rows[index].Cells[4].Value.ToString();
                txtPhuCap.Text = dataGV_LuongNhanVien.Rows[index].Cells[5].Value.ToString();
                txtTienThuong.Text = dataGV_LuongNhanVien.Rows[index].Cells[6].Value.ToString();
                txtTienPhat.Text = dataGV_LuongNhanVien.Rows[index].Cells[7].Value.ToString();
                txtNgayTinhLuong.Text = dataGV_LuongNhanVien.Rows[index].Cells[9].Value.ToString();
                btnSuaThongTin.Enabled = btnXoaThongTin.Enabled = true;
            }
            catch { }
        }

        private void btnSuaThongTin_Click(object sender, EventArgs e)
        {
            try
            {
                string manv = txtMaNV.Text.Trim();
                string ngaytinhluong = DateTime.ParseExact(txtNgayTinhLuong.Text, "dd/MM/yyyy", null).ToString("yyyy/MM/dd");
                float hsl = float.Parse(dataGV_LuongNhanVien.Rows[index].Cells["HeSoLuong"].Value.ToString().Trim());
                int lcb = int.Parse(dataGV_LuongNhanVien.Rows[index].Cells["LuongCoBan"].Value.ToString().Trim());
                int songaylam = int.Parse(txtSoNgayLam.Text.Trim());
                int phucap = int.Parse(txtPhuCap.Text.Trim());
                int tienthuong = int.Parse(txtTienThuong.Text.Trim());
                int tienphat = int.Parse(txtTienPhat.Text.Trim());
                int tongLuong = (int)(hsl * lcb * songaylam) + phucap + tienthuong - tienphat;
                if (songaylam.ToString() == string.Empty || phucap.ToString() == string.Empty || tienthuong.ToString() == string.Empty || tienphat.ToString() == string.Empty)
                {
                    MessageBox.Show("Bạn chưa nhập đủ thông tin!");
                    return;
                }
                if (!conn.checkExistTwoKey("BangLuong", "MaNV", "NgayTinhLuong", manv, ngaytinhluong))
                {
                    MessageBox.Show("Chưa tồn tại nên không thể sửa!");
                    return;
                }
                string strSQL = "UPDATE BangLuong SET SoNgayLam=" + songaylam + ", PhuCap=" + phucap + ", TienThuong=" + tienthuong + ", TienPhat=" + tienphat + ", TongLuong=" + tongLuong + " WHERE MaNV=" + manv + " AND NgayTinhLuong='" + ngaytinhluong + "'";
                conn.updateToDatabase(strSQL);
                createTable_BangLuong();
                MessageBox.Show("Sửa thành công!");
            }
            catch
            {
                MessageBox.Show("Sửa thất bại!");
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                string manv = txtMaNV.Text.Trim();
                string ngaytinhluong = DateTime.ParseExact(txtNgayTinhLuong.Text, "dd/MM/yyyy", null).ToString("yyyy/MM/dd");
                if (!conn.checkExistTwoKey("BangLuong", "MaNV", "NgayTinhLuong", manv, ngaytinhluong))
                {
                    MessageBox.Show("Chưa tồn tại nên không thể xóa!");
                    return;
                }
                if (MessageBox.Show("Bạn có muốn xóa thông tin lương này không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.No)
                    return;
                string strSQL = "DELETE BangLuong WHERE MaNV=" + manv + " AND NgayTinhLuong='" + ngaytinhluong + "'";
                conn.updateToDatabase(strSQL);
                createTable_BangLuong();
                MessageBox.Show("Xóa thành công!");
            }
            catch
            {
                MessageBox.Show("Xóa thất bại!");
            }
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            string ngaydau = DateTime.ParseExact(txtTuNgay.Text, "dd/MM/yyyy", null).ToString("yyyy/MM/dd");
            string ngaycuoi = DateTime.ParseExact(txtDenNgay.Text, "dd/MM/yyyy", null).ToString("yyyy/MM/dd");
            dataGV_LuongNhanVien.DataSource = nhanVien.searchThongTinLuong(ngaydau, ngaycuoi);
        }
    }
}
