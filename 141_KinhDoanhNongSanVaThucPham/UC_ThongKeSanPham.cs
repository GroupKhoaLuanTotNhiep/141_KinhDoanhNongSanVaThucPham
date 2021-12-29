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
    public partial class UC_ThongKeSanPham : UserControl
    {
        Connection cn = new Connection();
        SanPham sp = new SanPham();
        public UC_ThongKeSanPham()
        {
            InitializeComponent();
        }

        private void btnXemTK_SapHetHang_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = sp.loadThongKeSPHetHang();
            dataGV_SapHetHang.DataSource = dt;
        }

        private void btnInExcel_SapHetHang_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                exportExcel_SapHetHang(dataGV_SapHetHang, saveFileDialog1.FileName);
        }

        private void btnXemTK_SapHetHanSD_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = sp.loadThongKeSPSapHetHan();
            dataGV_SapHetHanSD.DataSource = dt;
        }

        private void btnInExcel_SapHetHan_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                exportExcel_sapHetHan(dataGV_SapHetHanSD, saveFileDialog1.FileName);
        }

        private void btnXemTK_HetHanSD_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = sp.loadThongKeSPHetHan();
            dataGV_HetHanSD.DataSource = dt;
        }

        private void btnInExcel_HetHan_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                exportExcel_HetHan(dataGV_HetHanSD, saveFileDialog1.FileName);
        }
        private void exportExcel_HetHan(DataGridView dv, string fileName)
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
                worksheet.Name = "Thống kê SP hết hạn SD";

                worksheet.Cells[2, 2] = "BÁO CÁO THỐNG KÊ SẢN PHẨM";
                worksheet.Cells[3, 2] = "Hết hạn sử dụng";

                for (int i = 0; i < dataGV_HetHanSD.ColumnCount; i++)
                {
                    worksheet.Cells[5, i + 1] = dataGV_HetHanSD.Columns[i].HeaderText;
                }

                for (int i = 0; i < dataGV_HetHanSD.RowCount; i++)
                {
                    for (int j = 0; j < dataGV_HetHanSD.ColumnCount; j++)
                    {
                        worksheet.Cells[i + 6, j + 1] = dataGV_HetHanSD.Rows[i].Cells[j].Value.ToString();
                    }
                }
                int tkshh = dataGV_HetHanSD.RowCount;

                //Định dạng trang
                worksheet.PageSetup.Orientation = Microsoft.Office.Interop.Excel.XlPageOrientation.xlPortrait;
                worksheet.PageSetup.PaperSize = Microsoft.Office.Interop.Excel.XlPaperSize.xlPaperA4;
                worksheet.PageSetup.LeftMargin = 0;
                worksheet.PageSetup.RightMargin = 0;
                worksheet.PageSetup.TopMargin = 0;
                worksheet.PageSetup.BottomMargin = 0;

                //Định dạng cột
                worksheet.Range["A1"].ColumnWidth = 6;
                worksheet.Range["B1"].ColumnWidth = 10.78;
                worksheet.Range["C1"].ColumnWidth = 14.11;
                worksheet.Range["D1"].ColumnWidth = 43.56;
                worksheet.Range["E1"].ColumnWidth = 16.67;
                worksheet.Range["F1"].ColumnWidth = 9.22;

                //Định dạng fone chữ
                worksheet.Range["A1", "F100"].Font.Name = "Times New Roman";
                worksheet.Range["A1", "F100"].Font.Size = 13;
                worksheet.Range["A2", "F2"].MergeCells = true;
                worksheet.Range["A2", "F2"].Font.Bold = true;
                worksheet.Range["A2", "F2"].Font.Size = 15;

                worksheet.Range["A3", "F3"].MergeCells = true;
                worksheet.Range["A3", "F3"].Font.Italic = true;
                worksheet.Range["A3", "F3"].Font.Size = 15;

                worksheet.Range["A5", "F5"].Font.Bold = true;

                //Kẻ bảng
                worksheet.Range["A5", "F" + (tkshh + 5)].Borders.LineStyle = 1;

                //Định dạng các dòng text
                worksheet.Range["A2", "F2"].HorizontalAlignment = 3;
                worksheet.Range["A3", "F3"].HorizontalAlignment = 3;
                worksheet.Range["A5", "F5"].HorizontalAlignment = 3;
                worksheet.Range["A6", "A" + (tkshh + 5)].HorizontalAlignment = 3;
                worksheet.Range["F6", "F" + (tkshh + 5)].HorizontalAlignment = 3;

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
        private void exportExcel_sapHetHan(DataGridView dv, string fileName)
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
                worksheet.Name = "Thống kê SP sắp hết hạn SD";

                worksheet.Cells[2, 2] = "BÁO CÁO THỐNG KÊ SẢN PHẨM";
                worksheet.Cells[3, 2] = "Sắp hết hạn sử dụng";

                for (int i = 0; i < dataGV_SapHetHanSD.ColumnCount; i++)
                {
                    worksheet.Cells[5, i + 1] = dataGV_SapHetHanSD.Columns[i].HeaderText;
                }

                for (int i = 0; i < dataGV_SapHetHanSD.RowCount; i++)
                {
                    for (int j = 0; j < dataGV_SapHetHanSD.ColumnCount; j++)
                    {
                        worksheet.Cells[i + 6, j + 1] = dataGV_SapHetHanSD.Rows[i].Cells[j].Value.ToString();
                    }
                }
                int tkshh = dataGV_SapHetHanSD.RowCount;

                //Định dạng trang
                worksheet.PageSetup.Orientation = Microsoft.Office.Interop.Excel.XlPageOrientation.xlPortrait;
                worksheet.PageSetup.PaperSize = Microsoft.Office.Interop.Excel.XlPaperSize.xlPaperA4;
                worksheet.PageSetup.LeftMargin = 0;
                worksheet.PageSetup.RightMargin = 0;
                worksheet.PageSetup.TopMargin = 0;
                worksheet.PageSetup.BottomMargin = 0;

                //Định dạng cột
                worksheet.Range["A1"].ColumnWidth = 4.89;
                worksheet.Range["B1"].ColumnWidth = 11.33;
                worksheet.Range["C1"].ColumnWidth = 14.11;
                worksheet.Range["D1"].ColumnWidth = 48;
                worksheet.Range["E1"].ColumnWidth = 14.56;
                worksheet.Range["F1"].ColumnWidth = 6.33;

                //Định dạng fone chữ
                worksheet.Range["A1", "F100"].Font.Name = "Times New Roman";
                worksheet.Range["A1", "F100"].Font.Size = 13;
                worksheet.Range["A2", "F2"].MergeCells = true;
                worksheet.Range["A2", "F2"].Font.Bold = true;
                worksheet.Range["A2", "F2"].Font.Size = 15;

                worksheet.Range["A3", "F3"].MergeCells = true;
                worksheet.Range["A3", "F3"].Font.Bold = true;
                worksheet.Range["A3", "F3"].Font.Size = 12;

                worksheet.Range["A5", "F5"].Font.Bold = true;

                //Kẻ bảng
                worksheet.Range["A5", "F" + (tkshh + 5)].Borders.LineStyle = 1;

                //Định dạng các dòng text
                worksheet.Range["A2", "F2"].HorizontalAlignment = 3;
                worksheet.Range["A3", "F3"].HorizontalAlignment = 3;
                worksheet.Range["A5", "F5"].HorizontalAlignment = 3;
                worksheet.Range["A6", "A" + (tkshh + 6)].HorizontalAlignment = 3;
                worksheet.Range["F6", "F" + (tkshh + 6)].HorizontalAlignment = 3;


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
        private void exportExcel_SapHetHang(DataGridView dv, string fileName)
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
                worksheet.Name = "Thống kê SP sắp hết hàng";

                worksheet.Cells[2, 2] = "BÁO CÁO THỐNG KÊ SẢN PHẨM";
                worksheet.Cells[3, 2] = "Sắp hết hàng";

                for (int i = 0; i < dataGV_SapHetHang.ColumnCount; i++)
                {
                    worksheet.Cells[5, i + 1] = dataGV_SapHetHang.Columns[i].HeaderText;
                }

                for (int i = 0; i < dataGV_SapHetHang.RowCount; i++)
                {
                    for (int j = 0; j < dataGV_SapHetHang.ColumnCount; j++)
                    {
                        worksheet.Cells[i + 6, j + 1] = dataGV_SapHetHang.Rows[i].Cells[j].Value.ToString();
                    }
                }
                int tkshh = dataGV_SapHetHang.RowCount;

                //Định dạng trang
                worksheet.PageSetup.Orientation = Microsoft.Office.Interop.Excel.XlPageOrientation.xlPortrait;
                worksheet.PageSetup.PaperSize = Microsoft.Office.Interop.Excel.XlPaperSize.xlPaperA4;
                worksheet.PageSetup.LeftMargin = 0;
                worksheet.PageSetup.RightMargin = 0;
                worksheet.PageSetup.TopMargin = 0;
                worksheet.PageSetup.BottomMargin = 0;

                //Định dạng cột
                worksheet.Range["A1"].ColumnWidth = 7.44;
                worksheet.Range["B1"].ColumnWidth = 16.11;
                worksheet.Range["C1"].ColumnWidth = 56.67;
                worksheet.Range["D1"].ColumnWidth = 7.89;
                worksheet.Range["E1"].ColumnWidth = 13;

                //Định dạng fone chữ
                worksheet.Range["A1", "E100"].Font.Name = "Times New Roman";
                worksheet.Range["A1", "E100"].Font.Size = 13;
                worksheet.Range["A2", "E2"].MergeCells = true;
                worksheet.Range["A2", "E2"].Font.Bold = true;
                worksheet.Range["A2", "E2"].Font.Size = 15;

                worksheet.Range["A3", "E3"].MergeCells = true;
                worksheet.Range["A3", "E3"].Font.Italic = true;
                worksheet.Range["A3", "E3"].Font.Size = 15;

                worksheet.Range["A5", "E5"].Font.Bold = true;

                //Kẻ bảng
                worksheet.Range["A5", "E" + (tkshh + 5)].Borders.LineStyle = 1;

                //Định dạng các dòng text
                worksheet.Range["A2", "E2"].HorizontalAlignment = 3;
                worksheet.Range["A3", "E3"].HorizontalAlignment = 3;
                worksheet.Range["A5", "E5"].HorizontalAlignment = 3;
                worksheet.Range["A6", "A" + (tkshh + 6)].HorizontalAlignment = 3;
                worksheet.Range["D6", "D" + (tkshh + 6)].HorizontalAlignment = 3;
                worksheet.Range["E6", "E" + (tkshh + 6)].HorizontalAlignment = 3;

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
