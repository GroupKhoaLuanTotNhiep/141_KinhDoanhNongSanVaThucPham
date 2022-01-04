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
using NongSanThucPham;
using DBConnect;

namespace _141_KinhDoanhNongSanVaThucPham
{
    public partial class frmChamCong : Form
    {
        Connection conn = new Connection();
        NhanVien nhanVien = new NhanVien();

        public frmChamCong()
        {
            InitializeComponent();
        }

        void createTable_NhanVien()
        {
            dataGV_ChamCong.DataSource = nhanVien.loadNhanVienLenBangChamCong();
        }

        void createTable_ChamCong()
        {
            dataGV_ChamCong.DataSource = nhanVien.loadBangChamCong();
        }

        void loadComboBoxTinhTrang()
        {
            string[] tinhTrang = { "Đi làm", "Không đi làm" };
            foreach (string s in tinhTrang)
                cbbTinhTrang.Items.Add(s);
            cbbTinhTrang.SelectedIndex = 0;
        }

        void loadComboBoxNhanVien()
        {
            cbbNhanVien.DataSource = nhanVien.loadNhanVien();
            cbbNhanVien.DisplayMember = "MaNV";
            cbbNhanVien.ValueMember = "MaNV";
        }

        private void frmChamCong_Load(object sender, EventArgs e)
        {
            txtMaNV.Enabled = txtTenNV.Enabled = false;
            btnSuaTinhTrang.Enabled = btnXoaThongTin.Enabled = btnThemThongTin.Enabled = false;
            createTable_NhanVien();
            loadComboBoxTinhTrang();
            loadComboBoxNhanVien();
        }

        public bool kiemTraNgayLamVaNgayHT()
        {
            string ngayHienTai = DateTime.Now.Year.ToString() + "/" + DateTime.Now.Month.ToString() + "/" + DateTime.Now.Day.ToString();
            string strNgayLam = DateTime.ParseExact(txtNgayLam.Text, "dd/MM/yyyy", null).ToString("yyyy/MM/dd");
            string strNgayHienTai = ngayHienTai;
            int ngay = DateTime.Parse(ngayHienTai).Day - DateTime.Parse(strNgayLam).Day;
            int thang = DateTime.Parse(ngayHienTai).Month - DateTime.Parse(strNgayLam).Month;
            int nam = DateTime.Parse(ngayHienTai).Year - DateTime.Parse(strNgayLam).Year;
            if (nam < 0 || (thang < 0 && nam == 0) || ((ngay < 0) && thang == 0 && nam == 0))
                return false;
            return true;
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            try
            {
                if(kiemTraNgayLamVaNgayHT() == false)
                {
                    MessageBox.Show("Ngày làm phải nhỏ hơn hoặc bằng Ngày hiện tại!");
                    return;
                }
                for (int i = 0; i < dataGV_ChamCong.RowCount; i++)
                {
                    string manv = dataGV_ChamCong.Rows[i].Cells["MaNV"].Value.ToString().Trim();
                    string ngaylam = DateTime.ParseExact(txtNgayLam.Text, "dd/MM/yyyy", null).ToString("yyyy/MM/dd");
                    string tinhtrang = cbbTinhTrang.Text.Trim();
                    if (!conn.checkExistTwoKey("ChamCong", "MaNV", "NgayLam", manv, ngaylam))
                    {
                        string strSQL = "Insert ChamCong Values(" + manv + ", '" + ngaylam + "', N'" + tinhtrang + "')";
                        conn.updateToDatabase(strSQL);
                    }
                }
                createTable_ChamCong();
                MessageBox.Show("Cập nhật thành công!");
            }
            catch
            {
                MessageBox.Show("Cập nhật thất bại!");
                createTable_ChamCong();
            }
        }

        private void dataGV_ChamCong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int index = e.RowIndex;
                if (e.RowIndex == -1) return;
                txtMaNV.Text = dataGV_ChamCong.Rows[index].Cells[0].Value.ToString();
                txtTenNV.Text = dataGV_ChamCong.Rows[index].Cells[1].Value.ToString();
                txtNgayLam.Text = dataGV_ChamCong.Rows[index].Cells[2].Value.ToString();
                cbbTinhTrang.Text = dataGV_ChamCong.Rows[index].Cells[3].Value.ToString();
                btnSuaTinhTrang.Enabled = btnXoaThongTin.Enabled = btnThemThongTin.Enabled = true;
            }
            catch { }
        }

        private void btnSuaTinhTrang_Click(object sender, EventArgs e)
        {
            try
            {
                string manv = txtMaNV.Text.Trim();
                string ngaylam = DateTime.ParseExact(txtNgayLam.Text, "dd/MM/yyyy", null).ToString("yyyy/MM/dd");
                string tinhtrang = cbbTinhTrang.Text.Trim();
                if (tinhtrang == string.Empty)
                {
                    MessageBox.Show("Tình trạng không được để trống!");
                    return;
                }
                if (!conn.checkExistTwoKey("ChamCong", "MaNV", "NgayLam", manv, ngaylam))
                {
                    MessageBox.Show("Chưa tồn tại nên không thể sửa!");
                    return;
                }
                string strSQL = "UPDATE ChamCong SET TinhTrang=N'" + tinhtrang + "' WHERE MaNV=" + manv + " AND NgayLam='" + ngaylam + "'";
                conn.updateToDatabase(strSQL);
                createTable_ChamCong();
                MessageBox.Show("Cập nhật thành công!");
            }
            catch
            {
                MessageBox.Show("Cập nhật thất bại!");
            }
        }

        private void btnXoaThongTin_Click(object sender, EventArgs e)
        {
            try
            {
                string manv = txtMaNV.Text.Trim();
                string ngaylam = DateTime.ParseExact(txtNgayLam.Text, "dd/MM/yyyy", null).ToString("yyyy/MM/dd");
                if (!conn.checkExistTwoKey("ChamCong", "MaNV", "NgayLam", manv, ngaylam))
                {
                    MessageBox.Show("Chưa tồn tại nên không thể xóa!");
                    return;
                }
                if (MessageBox.Show("Bạn có muốn xóa ngày công này không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.No)
                    return;
                string strSQL = "DELETE ChamCong WHERE MaNV=" + manv + " AND NgayLam='" + ngaylam + "'";
                conn.updateToDatabase(strSQL);
                createTable_ChamCong();
                MessageBox.Show("Xóa thành công!");
            }
            catch
            {
                MessageBox.Show("Xóa thất bại!");
            }
        }

        private void btnThemThongTin_Click(object sender, EventArgs e)
        {
            try
            {
                string manv = txtMaNV.Text.Trim();
                string ngaylam = DateTime.ParseExact(txtNgayLam.Text, "dd/MM/yyyy", null).ToString("yyyy/MM/dd");
                string tinhtrang = cbbTinhTrang.Text.Trim();
                if (tinhtrang == string.Empty)
                {
                    MessageBox.Show("Tình trạng không được để trống!");
                    return;
                }
                if (conn.checkExistTwoKey("ChamCong", "MaNV", "NgayLam", manv, ngaylam))
                {
                    MessageBox.Show("Đã tồn tại thông tin này!");
                    return;
                }
                if (kiemTraNgayLamVaNgayHT() == false)
                {
                    MessageBox.Show("Ngày làm phải nhỏ hơn hoặc bằng Ngày hiện tại!");
                    return;
                }
                string strSQL = "INSERT ChamCong Values(" + manv + ", '" + ngaylam + "', N'" + tinhtrang + "')";
                conn.updateToDatabase(strSQL);
                createTable_ChamCong();
                MessageBox.Show("Thêm thành công!");
            }
            catch
            {
                MessageBox.Show("Thêm thất bại!");
            }
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            string strNgay = DateTime.ParseExact(txtChonNgay.Text, "dd/MM/yyyy", null).ToString("yyyy/MM/dd");
            if (conn.checkExist("ChamCong", "NgayLam", strNgay))
                dataGV_ChamCong.DataSource = nhanVien.searchNgayCongTheoNgayLam(strNgay);
            else
            {
                MessageBox.Show("Không thông tin của ngày này!");
                createTable_ChamCong();
            }
        }

        private void cbbNhanVien_SelectedIndexChanged(object sender, EventArgs e)
        {
            //dataGV_ChamCong.DataSource = nhanVien.searchNgayCongTheoMaNV(cbbNhanVien.Text.Trim());
        }

        private void cbbNhanVien_SelectionChangeCommitted(object sender, EventArgs e)
        {
            dataGV_ChamCong.DataSource = nhanVien.searchNgayCongTheoMaNV(cbbNhanVien.Text.Trim());
        }

        private void btnInExel_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                exportExcel_ChamCong(dataGV_ChamCong, saveFileDialog1.FileName);
        }
        private void exportExcel_ChamCong(DataGridView dv, string fileName)
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
                worksheet.Name = "Chấm công NV";

                worksheet.Cells[2, 2] = "BÁO CÁO CHẤM CÔNG NHÂN VIÊN";
                worksheet.Cells[3, 2] = "Ngày " + txtChonNgay.Text;


                for (int i = 0; i < dataGV_ChamCong.ColumnCount; i++)
                {
                    worksheet.Cells[5, i + 2] = dataGV_ChamCong.Columns[i].HeaderText;
                }

                int tkTHH = dataGV_ChamCong.RowCount;

                for (int i = 0; i < dataGV_ChamCong.RowCount; i++)
                {
                    for (int j = 0; j < dataGV_ChamCong.ColumnCount; j++)
                    {
                        worksheet.Cells[i + 6, j + 2] = dataGV_ChamCong.Rows[i].Cells[j].Value.ToString();
                        worksheet.Cells[tkTHH + 7, 3] = "Số nhân viên đi làm: " + (dataGV_ChamCong.DataSource as DataTable).Compute("Count(MaNV)", "");
                    }
                }

                worksheet.Range["B" + (tkTHH + 7), "E" + (tkTHH + 7)].Font.Bold = true;

                //Định dạng trang
                worksheet.PageSetup.Orientation = Microsoft.Office.Interop.Excel.XlPageOrientation.xlPortrait;
                worksheet.PageSetup.PaperSize = Microsoft.Office.Interop.Excel.XlPaperSize.xlPaperA4;
                worksheet.PageSetup.LeftMargin = 0;
                worksheet.PageSetup.RightMargin = 0;
                worksheet.PageSetup.TopMargin = 0;
                worksheet.PageSetup.BottomMargin = 0;

                //Định dạng cột
                worksheet.Range["B1"].ColumnWidth = 15.89;
                worksheet.Range["C1"].ColumnWidth = 29.67;
                worksheet.Range["D1"].ColumnWidth = 17;
                worksheet.Range["E1"].ColumnWidth = 17;

                //Định dạng fone chữ
                worksheet.Range["B1", "E100"].Font.Name = "Times New Roman";
                worksheet.Range["B1", "E100"].Font.Size = 13;
                worksheet.Range["B2", "E2"].MergeCells = true;
                worksheet.Range["B2", "E2"].Font.Bold = true;
                worksheet.Range["B2", "E2"].Font.Size = 15;

                worksheet.Range["B3", "E3"].MergeCells = true;
                worksheet.Range["B3", "E3"].Font.Italic = true;

                worksheet.Range["B5", "E5"].Font.Bold = true;

                //Kẻ bảng
                worksheet.Range["B5", "E" + (tkTHH + 5)].Borders.LineStyle = 1;

                //Định dạng các dòng text
                worksheet.Range["B2", "E2"].HorizontalAlignment = 3;
                worksheet.Range["B3", "E3"].HorizontalAlignment = 3;
                worksheet.Range["B5", "E5"].HorizontalAlignment = 3;
                worksheet.Range["B6", "B" + (tkTHH + 6)].HorizontalAlignment = 3;
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
