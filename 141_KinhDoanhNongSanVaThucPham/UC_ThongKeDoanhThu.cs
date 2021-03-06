using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using DBConnect;
using NongSanThucPham;

namespace _141_KinhDoanhNongSanVaThucPham
{
    public partial class UC_ThongKeDoanhThu : UserControl
    {
        Connection cn = new Connection();
        HoaDon hd = new HoaDon();
        int index = -1;
        public static string maNV = "";
        public static string tenNV = "";
        public static string maKH = "";
        public static string tenKH = "";
        public static string ngayLap = "";
        public static string tongTien = "";
        public static string maSP = "";
        public static string tenSP = "";

        public UC_ThongKeDoanhThu()
        {
            InitializeComponent();
        }

        private void exportExcel_Thang(DataGridView dv, string fileName)
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
                worksheet.Name = "TK doanh thu theo tháng";

                worksheet.Cells[2, 2] = "BÁO CÁO THỐNG KÊ DOANH THU THEO THÁNG";
                worksheet.Cells[3, 2] = "Từ " + txtNgayBD.Text + " đến " + txtNgayKT.Text;

                for (int i = 0; i < dataGV_DTTheoThang.ColumnCount; i++)
                {
                    worksheet.Cells[5, i + 1] = dataGV_DTTheoThang.Columns[i].HeaderText;
                }

                int tkThang = dataGV_DTTheoThang.RowCount;

                for (int i = 0; i < dataGV_DTTheoThang.RowCount; i++)
                {
                    for (int j = 0; j < dataGV_DTTheoThang.ColumnCount; j++)
                    {
                        worksheet.Cells[i + 6, j + 1] = dataGV_DTTheoThang.Rows[i].Cells[j].Value.ToString();
                        worksheet.Cells[tkThang + 6, 3] = (dataGV_DTTheoThang.DataSource as DataTable).Compute("Sum(SoDonHang_tt)", "");
                        worksheet.Cells[tkThang + 6, 4] = (dataGV_DTTheoThang.DataSource as DataTable).Compute("Sum(TienHang_tt)", "");
                    }
                }

                worksheet.Cells[tkThang + 6, 1] = "Tổng";
                worksheet.Cells[tkThang + 8, 3] = "Liên Hiệp HTX TP Hồ Chí Minh";
                worksheet.Cells[tkThang + 9, 3] = "Kế toán trưởng";

                //Định dạng trang
                worksheet.PageSetup.Orientation = Microsoft.Office.Interop.Excel.XlPageOrientation.xlPortrait;
                worksheet.PageSetup.PaperSize = Microsoft.Office.Interop.Excel.XlPaperSize.xlPaperA4;
                worksheet.PageSetup.LeftMargin = 0;
                worksheet.PageSetup.RightMargin = 0;
                worksheet.PageSetup.TopMargin = 0;
                worksheet.PageSetup.BottomMargin = 0;

                //Định dạng cột
                worksheet.Range["A1"].ColumnWidth = 10.33;
                worksheet.Range["B1"].ColumnWidth = 33.89;
                worksheet.Range["C1"].ColumnWidth = 20;
                worksheet.Range["D1"].ColumnWidth = 37.78;

                //Định dạng fone chữ
                worksheet.Range["A1", "D100"].Font.Name = "Times New Roman";
                worksheet.Range["A1", "D100"].Font.Size = 13;
                worksheet.Range["A2", "D2"].MergeCells = true;
                worksheet.Range["A2", "D2"].Font.Bold = true;
                worksheet.Range["A2", "D2"].Font.Size = 15;

                worksheet.Range["A3", "D3"].MergeCells = true;
                worksheet.Range["A3", "D3"].Font.Italic = true;

                worksheet.Range["A5", "D5"].Font.Bold = true;

                //worksheet.Range["A" + (tkThang + 6), "B"].Font.Bold = true;

                worksheet.Range["C" + (tkThang + 8), "D" + (tkThang + 8)].MergeCells = true;
                worksheet.Range["C" + (tkThang + 8), "D" + (tkThang + 8)].Font.Bold = true;

                worksheet.Range["C" + (tkThang + 9), "D" + (tkThang + 9)].MergeCells = true;
                worksheet.Range["C" + (tkThang + 9), "D" + (tkThang + 9)].Font.Bold = true;

                //Kẻ bảng
                worksheet.Range["A5", "D" + (tkThang + 6)].Borders.LineStyle = 1;

                //Định dạng các dòng text
                worksheet.Range["A2", "D2"].HorizontalAlignment = 3;
                worksheet.Range["A3", "D3"].HorizontalAlignment = 3;
                worksheet.Range["A5", "E5"].HorizontalAlignment = 3;
                worksheet.Range["A6", "A" + (tkThang + 6)].HorizontalAlignment = 3;
                worksheet.Range["B6", "B" + (tkThang + 6)].HorizontalAlignment = 3;
                worksheet.Range["C6", "C" + (tkThang + 6)].HorizontalAlignment = 3;

                worksheet.Range["C" + (tkThang + 8), "D" + (tkThang + 8)].HorizontalAlignment = 3;

                worksheet.Range["C" + (tkThang + 9), "D" + (tkThang + 9)].HorizontalAlignment = 3;

                workbook.SaveAs(fileName);
                workbook.Close();
                excel.Quit();
                MessageBox.Show("Xuất excel thành công!!!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            //catch (Exception)
            //{
            //    MessageBox.Show("Xuất excel không thành công!!!");
            //}
            finally
            {
                workbook = null;
                worksheet = null;
            }
        }
        private void exportExcel_NV(DataGridView dv, string fileName)
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
                worksheet.Name = "Thống kê doanh thu theo NV";
                //worksheet = workbook.ActiveSheet;
                //excel.Visible = true;

                worksheet.Cells[2, 2] = "BÁO CÁO THỐNG KÊ DOANH THU THEO NHÂN VIÊN";
                worksheet.Cells[3, 2] = "Từ " + txtNgayBD_NV.Text + " đến " + txtNgayKT_NV.Text;


                for (int i = 0; i < dataGV_DTTheoNhanVien.ColumnCount; i++)
                {
                    worksheet.Cells[5, i + 1] = dataGV_DTTheoNhanVien.Columns[i].HeaderText;
                }

                int tkTNV = dataGV_DTTheoNhanVien.RowCount;

                for (int i = 0; i < dataGV_DTTheoNhanVien.RowCount; i++)
                {
                    for (int j = 0; j < dataGV_DTTheoNhanVien.ColumnCount; j++)
                    {
                        //var row = dataGV_DTTheoNhanVien.Rows[i];
                        //if (row == null) continue;
                        //var cell = row.Cells[j];
                        //if (cell == null) continue;
                        //worksheet.Cells[i + 6, j + 1] = cell.Value == null ? string.Empty : cell.Value.ToString();
                        worksheet.Cells[i + 6, j + 1] = dataGV_DTTheoNhanVien.Rows[i].Cells[j].Value.ToString();
                        worksheet.Cells[tkTNV + 6, 4] = (dataGV_DTTheoNhanVien.DataSource as DataTable).Compute("Sum(SoDonHang_nv)", "");
                        worksheet.Cells[tkTNV + 6, 5] = (dataGV_DTTheoNhanVien.DataSource as DataTable).Compute("Sum(TienHang_nv)", "");
                    }
                }

                worksheet.Cells[tkTNV + 6, 1] = "Tổng";
                worksheet.Cells[tkTNV + 8, 5] = "Liên Hiệp HTX TP Hồ Chí Minh";
                worksheet.Cells[tkTNV + 9, 5] = "Kế toán trưởng";


                //Định dạng trang
                worksheet.PageSetup.Orientation = Microsoft.Office.Interop.Excel.XlPageOrientation.xlPortrait;
                worksheet.PageSetup.PaperSize = Microsoft.Office.Interop.Excel.XlPaperSize.xlPaperA4;
                worksheet.PageSetup.LeftMargin = 0;
                worksheet.PageSetup.RightMargin = 0;
                worksheet.PageSetup.TopMargin = 0;
                worksheet.PageSetup.BottomMargin = 0;

                //Định dạng cột
                worksheet.Range["A1"].ColumnWidth = 6;
                worksheet.Range["B1"].ColumnWidth = 20.22;
                worksheet.Range["C1"].ColumnWidth = 32;
                worksheet.Range["D1"].ColumnWidth = 13.67;
                //worksheet.Range["E1"].ColumnWidth = 10.33;
                worksheet.Range["E1"].ColumnWidth = 30;

                //Định dạng fone chữ
                worksheet.Range["A1", "E100"].Font.Name = "Times New Roman";
                worksheet.Range["A1", "E100"].Font.Size = 13;
                worksheet.Range["A2", "E2"].MergeCells = true;
                worksheet.Range["A2", "E2"].Font.Bold = true;
                worksheet.Range["A2", "E2"].Font.Size = 15;

                worksheet.Range["A3", "E3"].MergeCells = true;
                worksheet.Range["A3", "E3"].Font.Italic = true;

                worksheet.Range["A5", "E5"].Font.Bold = true;

                worksheet.Range["D" + (tkTNV + 9), "E" + (tkTNV + 9)].MergeCells = true;
                worksheet.Range["D" + (tkTNV + 9), "E" + (tkTNV + 9)].Font.Bold = true;

                worksheet.Range["D" + (tkTNV + 8), "E" + (tkTNV + 8)].MergeCells = true;
                worksheet.Range["D" + (tkTNV + 8), "E" + (tkTNV + 8)].Font.Bold = true;

                //Kẻ bảng
                worksheet.Range["A5", "E" + (tkTNV + 6)].Borders.LineStyle = 1;

                //Định dạng các dòng text
                worksheet.Range["A2", "E2"].HorizontalAlignment = 3;
                worksheet.Range["A3", "E3"].HorizontalAlignment = 3;
                worksheet.Range["A5", "E5"].HorizontalAlignment = 3;
                worksheet.Range["B6", "B" + (tkTNV + 6)].HorizontalAlignment = 3;
                worksheet.Range["C6", "C" + (tkTNV + 6)].HorizontalAlignment = 3;
                worksheet.Range["D6", "D" + (tkTNV + 6)].HorizontalAlignment = 3;
                worksheet.Range["E6", "E" + (tkTNV + 6)].HorizontalAlignment = 3;

                worksheet.Range["D" + (tkTNV + 9), "E" + (tkTNV + 9)].HorizontalAlignment = 3;

                worksheet.Range["D" + (tkTNV + 8), "E" + (tkTNV + 8)].HorizontalAlignment = 3;

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
        private void exportExcel_KH(DataGridView dv, string fileName)
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
                worksheet.Name = "Thống kê doanh thu theo KH";
                //worksheet = workbook.ActiveSheet;
                //excel.Visible = true;

                worksheet.Cells[2, 2] = "BÁO CÁO THỐNG KÊ DOANH THU THEO KHÁCH HÀNG";
                worksheet.Cells[3, 2] = "Từ " + txtNgayBD_KH.Text + " đến " + txtNgayKT_KH.Text;


                for (int i = 0; i < dataGV_DTTheoKhachHang.ColumnCount; i++)
                {
                    worksheet.Cells[5, i + 1] = dataGV_DTTheoKhachHang.Columns[i].HeaderText;
                }

                int tkTKH = dataGV_DTTheoKhachHang.RowCount;

                for (int i = 0; i < dataGV_DTTheoKhachHang.RowCount; i++)
                {
                    for (int j = 0; j < dataGV_DTTheoKhachHang.ColumnCount; j++)
                    {
                        //var row = dataGV_DTTheoNhanVien.Rows[i];
                        //if (row == null) continue;
                        //var cell = row.Cells[j];
                        //if (cell == null) continue;
                        //worksheet.Cells[i + 6, j + 1] = cell.Value == null ? string.Empty : cell.Value.ToString();
                        worksheet.Cells[i + 6, j + 1] = dataGV_DTTheoKhachHang.Rows[i].Cells[j].Value.ToString();
                        worksheet.Cells[tkTKH + 6, 4] = (dataGV_DTTheoKhachHang.DataSource as DataTable).Compute("Sum(SoDonHang_kh)", "");
                        worksheet.Cells[tkTKH + 6, 5] = (dataGV_DTTheoKhachHang.DataSource as DataTable).Compute("Sum(TienHang_kh)", "");
                    }
                }

                worksheet.Cells[tkTKH + 6, 1] = "Tổng";
                worksheet.Cells[tkTKH + 8, 5] = "Liên Hiệp HTX TP Hồ Chí Minh";
                worksheet.Cells[tkTKH + 9, 5] = "Kế toán trưởng";


                //Định dạng trang
                worksheet.PageSetup.Orientation = Microsoft.Office.Interop.Excel.XlPageOrientation.xlPortrait;
                worksheet.PageSetup.PaperSize = Microsoft.Office.Interop.Excel.XlPaperSize.xlPaperA4;
                worksheet.PageSetup.LeftMargin = 0;
                worksheet.PageSetup.RightMargin = 0;
                worksheet.PageSetup.TopMargin = 0;
                worksheet.PageSetup.BottomMargin = 0;

                //Định dạng cột
                worksheet.Range["A1"].ColumnWidth = 6;
                worksheet.Range["B1"].ColumnWidth = 20.22;
                worksheet.Range["C1"].ColumnWidth = 32;
                worksheet.Range["D1"].ColumnWidth = 13.67;
                worksheet.Range["E1"].ColumnWidth = 30;

                //Định dạng fone chữ
                worksheet.Range["A1", "E100"].Font.Name = "Times New Roman";
                worksheet.Range["A1", "E100"].Font.Size = 13;
                worksheet.Range["A2", "E2"].MergeCells = true;
                worksheet.Range["A2", "E2"].Font.Bold = true;
                worksheet.Range["A2", "E2"].Font.Size = 15;

                worksheet.Range["A3", "E3"].MergeCells = true;
                worksheet.Range["A3", "E3"].Font.Italic = true;

                worksheet.Range["A5", "E5"].Font.Bold = true;

                worksheet.Range["D" + (tkTKH + 9), "E" + (tkTKH + 9)].MergeCells = true;
                worksheet.Range["D" + (tkTKH + 9), "E" + (tkTKH + 9)].Font.Bold = true;

                worksheet.Range["D" + (tkTKH + 8), "E" + (tkTKH + 8)].MergeCells = true;
                worksheet.Range["D" + (tkTKH + 8), "E" + (tkTKH + 8)].Font.Bold = true;

                //Kẻ bảng
                worksheet.Range["A5", "E" + (tkTKH + 6)].Borders.LineStyle = 1;

                //Định dạng các dòng text
                worksheet.Range["A2", "E2"].HorizontalAlignment = 3;
                worksheet.Range["A3", "E3"].HorizontalAlignment = 3;
                worksheet.Range["A5", "E5"].HorizontalAlignment = 3;
                worksheet.Range["B6", "B" + (tkTKH + 6)].HorizontalAlignment = 3;
                worksheet.Range["C6", "C" + (tkTKH + 6)].HorizontalAlignment = 3;
                worksheet.Range["D6", "D" + (tkTKH + 6)].HorizontalAlignment = 3;
                worksheet.Range["E6", "E" + (tkTKH + 6)].HorizontalAlignment = 3;

                worksheet.Range["D" + (tkTKH + 9), "E" + (tkTKH + 9)].HorizontalAlignment = 3;

                worksheet.Range["D" + (tkTKH + 8), "E" + (tkTKH + 8)].HorizontalAlignment = 3;

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
        private void exportExcel_MH(DataGridView dv, string fileName)
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
                worksheet.Name = "Thống kê doanh thu theo MH";
                //worksheet = workbook.ActiveSheet;
                //excel.Visible = true;

                worksheet.Cells[2, 2] = "BÁO CÁO THỐNG KÊ DOANH THU THEO MẶT HÀNG";
                worksheet.Cells[3, 2] = "Từ " + txtNgayBD_HH.Text + " đến " + txtNgayKT_HH.Text;


                for (int i = 0; i < dataGV_DTTheoHangHoa.ColumnCount; i++)
                {
                    worksheet.Cells[5, i + 1] = dataGV_DTTheoHangHoa.Columns[i].HeaderText;
                }

                int tkTHH = dataGV_DTTheoHangHoa.RowCount;

                for (int i = 0; i < dataGV_DTTheoHangHoa.RowCount; i++)
                {
                    for (int j = 0; j < dataGV_DTTheoHangHoa.ColumnCount; j++)
                    {
                        //var row = dataGV_DTTheoNhanVien.Rows[i];
                        //if (row == null) continue;
                        //var cell = row.Cells[j];
                        //if (cell == null) continue;
                        //worksheet.Cells[i + 6, j + 1] = cell.Value == null ? string.Empty : cell.Value.ToString();
                        worksheet.Cells[i + 6, j + 1] = dataGV_DTTheoHangHoa.Rows[i].Cells[j].Value.ToString();
                        worksheet.Cells[tkTHH + 6, 5] = (dataGV_DTTheoHangHoa.DataSource as DataTable).Compute("Sum(SoLuongBan_mh)", "");
                        worksheet.Cells[tkTHH + 6, 6] = (dataGV_DTTheoHangHoa.DataSource as DataTable).Compute("Sum(TienHang_mh)", "");
                    }
                }

                worksheet.Cells[tkTHH + 6, 1] = "Tổng";
                worksheet.Cells[tkTHH + 8, 5] = "Liên Hiệp HTX TP Hồ Chí Minh";
                worksheet.Cells[tkTHH + 9, 5] = "Kế toán trưởng";


                //Định dạng trang
                worksheet.PageSetup.Orientation = Microsoft.Office.Interop.Excel.XlPageOrientation.xlPortrait;
                worksheet.PageSetup.PaperSize = Microsoft.Office.Interop.Excel.XlPaperSize.xlPaperA4;
                worksheet.PageSetup.LeftMargin = 0;
                worksheet.PageSetup.RightMargin = 0;
                worksheet.PageSetup.TopMargin = 0;
                worksheet.PageSetup.BottomMargin = 0;

                //Định dạng cột
                worksheet.Range["A1"].ColumnWidth = 6;
                worksheet.Range["B1"].ColumnWidth = 20.22;
                worksheet.Range["C1"].ColumnWidth = 40;
                worksheet.Range["D1"].ColumnWidth = 12;
                worksheet.Range["E1"].ColumnWidth = 13.67;
                worksheet.Range["F1"].ColumnWidth = 30;

                //Định dạng fone chữ
                worksheet.Range["A1", "F100"].Font.Name = "Times New Roman";
                worksheet.Range["A1", "F100"].Font.Size = 13;
                worksheet.Range["A2", "F2"].MergeCells = true;
                worksheet.Range["A2", "F2"].Font.Bold = true;
                worksheet.Range["A2", "F2"].Font.Size = 15;

                worksheet.Range["A3", "F3"].MergeCells = true;
                worksheet.Range["A3", "F3"].Font.Italic = true;

                worksheet.Range["A5", "F5"].Font.Bold = true;

                worksheet.Range["E" + (tkTHH + 9), "F" + (tkTHH + 9)].MergeCells = true;
                worksheet.Range["E" + (tkTHH + 9), "F" + (tkTHH + 9)].Font.Bold = true;

                worksheet.Range["E" + (tkTHH + 8), "F" + (tkTHH + 8)].MergeCells = true;
                worksheet.Range["E" + (tkTHH + 8), "F" + (tkTHH + 8)].Font.Bold = true;

                //Kẻ bảng
                worksheet.Range["A5", "F" + (tkTHH + 6)].Borders.LineStyle = 1;

                //Định dạng các dòng text
                worksheet.Range["A2", "F2"].HorizontalAlignment = 3;
                worksheet.Range["A3", "F3"].HorizontalAlignment = 3;
                worksheet.Range["A5", "F5"].HorizontalAlignment = 3;
                worksheet.Range["B6", "B" + (tkTHH + 6)].HorizontalAlignment = 3;
                //worksheet.Range["C6", "C" + (tkTHH + 6)].HorizontalAlignment = 3;
                worksheet.Range["D6", "D" + (tkTHH + 6)].HorizontalAlignment = 3;
                worksheet.Range["E6", "E" + (tkTHH + 6)].HorizontalAlignment = 3;

                worksheet.Range["E" + (tkTHH + 9), "F" + (tkTHH + 9)].HorizontalAlignment = 3;

                worksheet.Range["E" + (tkTHH + 8), "F" + (tkTHH + 8)].HorizontalAlignment = 3;

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

        private void btnXemTKThang_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            var fromDate = txtNgayBD.Value;
            var toDate = txtNgayKT.Value;
            dt = hd.loadThongKeTheoThang(fromDate, toDate);
            dataGV_DTTheoThang.DataSource = dt;
        }

        private void btnXemTKNhanVien_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            var fromDate = txtNgayBD_NV.Value;
            var toDate = txtNgayKT_NV.Value;
            dt = hd.loadThongKeTheoNhanVien(fromDate, toDate);
            dataGV_DTTheoNhanVien.DataSource = dt;
        }

        private void btnXemTKKhachHang_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            var fromDate = txtNgayBD_KH.Value;
            var toDate = txtNgayKT_KH.Value;
            dt = hd.loadThongKeTheoKhachHang(fromDate, toDate);
            dataGV_DTTheoKhachHang.DataSource = dt;
        }

        private void btnXemTKHangHoa_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            var fromDate = txtNgayBD_HH.Value;
            var toDate = txtNgayKT_HH.Value;
            dt = hd.loadThongKeTheoMatHang(fromDate, toDate);
            dataGV_DTTheoHangHoa.DataSource = dt;
        }

        private void btnXemChiTietThang_Click(object sender, EventArgs e)
        {
            try
            {
                ngayLap = dataGV_DTTheoThang.Rows[index].Cells[1].Value.ToString();
                tongTien = dataGV_DTTheoThang.Rows[index].Cells[3].Value.ToString();
                frmXemChiTietTheoThang ctThang = new frmXemChiTietTheoThang();
                ctThang.ShowDialog();
            }
            catch { }
        }

        private void dataGV_DTTheoThang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
                index = e.RowIndex;
        }

        private void btnXemChiTietNV_Click(object sender, EventArgs e)
        {
            try
            {
                maNV = dataGV_DTTheoNhanVien.Rows[index].Cells[1].Value.ToString();
                tenNV = dataGV_DTTheoNhanVien.Rows[index].Cells[2].Value.ToString();
                tongTien = dataGV_DTTheoNhanVien.Rows[index].Cells[4].Value.ToString();
                frmXemChiTietTheoNhanVien ctNhanVien = new frmXemChiTietTheoNhanVien();
                ctNhanVien.ShowDialog();
            }
            catch { }
        }

        private void dataGV_DTTheoNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
                index = e.RowIndex;
        }

        private void btnXemChiTietKH_Click(object sender, EventArgs e)
        {
            try
            {
                maKH = dataGV_DTTheoKhachHang.Rows[index].Cells[1].Value.ToString();
                tenKH = dataGV_DTTheoKhachHang.Rows[index].Cells[2].Value.ToString();
                tongTien = dataGV_DTTheoKhachHang.Rows[index].Cells[4].Value.ToString();
                frmXemChiTietTheoKhachHang ctKhachHang = new frmXemChiTietTheoKhachHang();
                ctKhachHang.ShowDialog();
            }
            catch { }
        }

        private void dataGV_DTTheoKhachHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
                index = e.RowIndex;
        }

        private void btnXemChiTietHH_Click(object sender, EventArgs e)
        {
            try
            {
                maSP = dataGV_DTTheoHangHoa.Rows[index].Cells[1].Value.ToString();
                tenSP = dataGV_DTTheoHangHoa.Rows[index].Cells[2].Value.ToString();
                tongTien = dataGV_DTTheoHangHoa.Rows[index].Cells[5].Value.ToString();
                frmXemChiTietTheoHangHoa ctHangHoa = new frmXemChiTietTheoHangHoa();
                ctHangHoa.ShowDialog();
            }
            catch { }
        }

        private void dataGV_DTTheoHangHoa_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
                index = e.RowIndex;
        }

        private void btnInExlThang_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                exportExcel_Thang(dataGV_DTTheoThang, saveFileDialog1.FileName);
        }

        private void btnInExlNV_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                exportExcel_NV(dataGV_DTTheoNhanVien, saveFileDialog1.FileName);
        }

        private void btnInExlKH_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                exportExcel_KH(dataGV_DTTheoKhachHang, saveFileDialog1.FileName);
        }

        private void btnInExlHH_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                exportExcel_MH(dataGV_DTTheoHangHoa, saveFileDialog1.FileName);
        }

        private void btnBieuDo_Click(object sender, EventArgs e)
        {
            frmBieuDoDoanhThu bd = new frmBieuDoDoanhThu();
            bd.dt = (DataTable)dataGV_DTTheoThang.DataSource;
            bd.Show();
        }

    }
}
