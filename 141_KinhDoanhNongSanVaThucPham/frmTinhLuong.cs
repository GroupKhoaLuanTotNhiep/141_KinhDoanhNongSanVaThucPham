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
        int index = -1;

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
            if (nam < 0 || (thang < 0 && nam == 0) || ((ngay < 0 || ngay > 0) && thang == 0 && nam == 0))
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
                    MessageBox.Show("Ngày tính lương phải là Ngày hiện tại!");
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
                for (int i = 0; i < dataGV_LuongNhanVien.RowCount; i++)
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
                if (e.RowIndex != -1)
                    index = e.RowIndex;
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
                float hsl = float.Parse(dataGV_LuongNhanVien.Rows[index].Cells[2].Value.ToString().Trim());
                int lcb = int.Parse(dataGV_LuongNhanVien.Rows[index].Cells[3].Value.ToString().Trim());
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

        private void btnInExcel_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                exportExcel_TinhLuong(dataGV_LuongNhanVien, saveFileDialog1.FileName);
        }

        private void exportExcel_TinhLuong(DataGridView dv, string fileName)
        {
            Microsoft.Office.Interop.Excel.Application excel;
            Microsoft.Office.Interop.Excel.Workbook workbook;
            Microsoft.Office.Interop.Excel.Worksheet worksheet;

            try
            {
                excel = new Microsoft.Office.Interop.Excel.Application();
                excel.Visible = false;
                excel.DisplayAlerts = false;

                workbook = excel.Workbooks.Add(Type.Missing);

                worksheet = (Microsoft.Office.Interop.Excel.Worksheet)workbook.Sheets["Sheet1"];
                worksheet.Name = "Lương NV";

                worksheet.Cells[2, 2] = "BÁO CÁO LƯƠNG NHÂN VIÊN";
                worksheet.Cells[3, 2] = "Từ " + txtTuNgay.Text + " đến " + txtDenNgay.Text;


                for (int i = 0; i < dataGV_LuongNhanVien.ColumnCount; i++)
                {
                    worksheet.Cells[5, i + 1] = dataGV_LuongNhanVien.Columns[i].HeaderText;
                }

                int tkTHH = dataGV_LuongNhanVien.RowCount;

                for (int i = 0; i < dataGV_LuongNhanVien.RowCount; i++)
                {
                    for (int j = 0; j < dataGV_LuongNhanVien.ColumnCount; j++)
                    {
                        worksheet.Cells[i + 6, j + 1] = dataGV_LuongNhanVien.Rows[i].Cells[j].Value.ToString();
                    }
                }

                //Định dạng trang
                worksheet.PageSetup.Orientation = Microsoft.Office.Interop.Excel.XlPageOrientation.xlLandscape;
                worksheet.PageSetup.PaperSize = Microsoft.Office.Interop.Excel.XlPaperSize.xlPaperA4;
                worksheet.PageSetup.LeftMargin = 0;
                worksheet.PageSetup.RightMargin = 0;
                worksheet.PageSetup.TopMargin = 0;
                worksheet.PageSetup.BottomMargin = 0;

                //Định dạng cột
                worksheet.Range["A1"].ColumnWidth = 8.33;
                worksheet.Range["B1"].ColumnWidth = 24.22;
                worksheet.Range["C1"].ColumnWidth = 12.56;
                worksheet.Range["D1"].ColumnWidth = 11.56;
                worksheet.Range["E1"].ColumnWidth = 13;
                worksheet.Range["F1"].ColumnWidth = 10.44;
                worksheet.Range["G1"].ColumnWidth = 13;
                worksheet.Range["H1"].ColumnWidth = 10.44;
                worksheet.Range["I1"].ColumnWidth = 18.22;
                worksheet.Range["J1"].ColumnWidth = 19.22;

                //Định dạng fone chữ
                worksheet.Range["A1", "J100"].Font.Name = "Times New Roman";
                worksheet.Range["A1", "J100"].Font.Size = 13;
                worksheet.Range["A2", "J2"].MergeCells = true;
                worksheet.Range["A2", "J2"].Font.Bold = true;
                worksheet.Range["A2", "J2"].Font.Size = 15;

                worksheet.Range["A3", "J3"].MergeCells = true;
                worksheet.Range["A3", "J3"].Font.Italic = true;

                worksheet.Range["A5", "J5"].Font.Bold = true;

                //Kẻ bảng
                worksheet.Range["A5", "J" + (tkTHH + 5)].Borders.LineStyle = 1;

                //Định dạng các dòng text
                worksheet.Range["A2", "J2"].HorizontalAlignment = 3;
                worksheet.Range["A3", "J3"].HorizontalAlignment = 3;
                worksheet.Range["A5", "J5"].HorizontalAlignment = 3;
                worksheet.Range["A6", "A" + (tkTHH + 6)].HorizontalAlignment = 3;
                worksheet.Range["D6", "D" + (tkTHH + 6)].HorizontalAlignment = 3;
                worksheet.Range["E6", "E" + (tkTHH + 6)].HorizontalAlignment = 3;

                workbook.SaveAs(fileName);
                workbook.Close();
                excel.Quit();
                MessageBox.Show("Xuất excel thành công!!!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                workbook = null;
                worksheet = null;
            }
        }
    }
}
