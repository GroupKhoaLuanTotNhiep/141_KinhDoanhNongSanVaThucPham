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
    public partial class UC_ThongKeThanhLy : UserControl
    {
        Connection cn = new Connection();
        SanPham sp = new SanPham();
        public UC_ThongKeThanhLy()
        {
            InitializeComponent();
        }

        private void btnXemTK_ChuaThanhLy_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = sp.loadThongKe_ChuaThanhLy();
            dataGV_ChuaThanhLy.DataSource = dt;
        }

        private void btnInExcel_ChuaTL_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                exportExcel_ChuaTL(dataGV_ChuaThanhLy, saveFileDialog1.FileName);
        }

        private void btnXemTK_DaThanhLy_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            var fromDate = txtNgayBD.Value;
            var toDate = txtNgayKT.Value;
            dt = sp.loadThongKe_DaThanhLy(fromDate, toDate);
            dataGV_DaThanhLy.DataSource = dt;
        }

        private void btnInExcel_DaTL_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                exportExcel_DaTL(dataGV_DaThanhLy, saveFileDialog1.FileName);
        }
        private void exportExcel_ChuaTL(DataGridView dv, string fileName)
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
                worksheet.Name = "Thống kê SP Phiếu TL (chưa)";

                worksheet.Cells[2, 2] = "BÁO CÁO THỐNG KÊ PHIẾU THANH LÝ";
                worksheet.Cells[3, 2] = "(Chưa thanh lý)";

                for (int i = 0; i < dataGV_ChuaThanhLy.ColumnCount; i++)
                {
                    worksheet.Cells[5, i + 1] = dataGV_ChuaThanhLy.Columns[i].HeaderText;
                }

                for (int i = 0; i < dataGV_ChuaThanhLy.RowCount; i++)
                {
                    for (int j = 0; j < dataGV_ChuaThanhLy.ColumnCount; j++)
                    {
                        worksheet.Cells[i + 6, j + 1] = dataGV_ChuaThanhLy.Rows[i].Cells[j].Value.ToString();
                    }
                }
                int tkshh = dataGV_ChuaThanhLy.RowCount;

                //Định dạng trang
                worksheet.PageSetup.Orientation = Microsoft.Office.Interop.Excel.XlPageOrientation.xlPortrait;
                worksheet.PageSetup.PaperSize = Microsoft.Office.Interop.Excel.XlPaperSize.xlPaperA4;
                worksheet.PageSetup.LeftMargin = 0;
                worksheet.PageSetup.RightMargin = 0;
                worksheet.PageSetup.TopMargin = 0;
                worksheet.PageSetup.BottomMargin = 0;

                //Định dạng cột
                worksheet.Range["A1"].ColumnWidth = 4.78;
                worksheet.Range["B1"].ColumnWidth = 14;
                worksheet.Range["C1"].ColumnWidth = 11.33;
                worksheet.Range["D1"].ColumnWidth = 9.22;
                worksheet.Range["E1"].ColumnWidth = 16.11;
                worksheet.Range["F1"].ColumnWidth = 10.78;
                worksheet.Range["G1"].ColumnWidth = 15.33;
                worksheet.Range["H1"].ColumnWidth = 17.11;

                //Định dạng fone chữ
                worksheet.Range["A1", "H100"].Font.Name = "Times New Roman";
                worksheet.Range["A1", "H100"].Font.Size = 13;
                worksheet.Range["A2", "H2"].MergeCells = true;
                worksheet.Range["A2", "H2"].Font.Bold = true;
                worksheet.Range["A2", "H2"].Font.Size = 15;

                //worksheet.Range["A3", "H3"].Font.Italic = true;
                worksheet.Range["A3", "H3"].Font.Bold = true;
                worksheet.Range["A3", "H3"].Font.Size = 12;
                worksheet.Range["A3", "H3"].MergeCells = true;

                worksheet.Range["A5", "H5"].Font.Bold = true;

                //Kẻ bảng
                worksheet.Range["A5", "H" + (tkshh + 5)].Borders.LineStyle = 1;

                //Định dạng các dòng text
                worksheet.Range["A2", "H2"].HorizontalAlignment = 3;
                worksheet.Range["A3", "H3"].HorizontalAlignment = 3;
                worksheet.Range["A5", "H5"].HorizontalAlignment = 3;
                worksheet.Range["A6", "A" + (tkshh + 6)].HorizontalAlignment = 3;
                worksheet.Range["B5", "B" + (tkshh + 6)].HorizontalAlignment = 3;
                worksheet.Range["D6", "D" + (tkshh + 6)].HorizontalAlignment = 3;
                //worksheet.Range["C5", "C" + (tkshh + 5)].HorizontalAlignment = 3;
                //worksheet.Range["E5", "E" + (tkshh + 5)].HorizontalAlignment = 3;


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
        private void exportExcel_DaTL(DataGridView dv, string fileName)
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
                worksheet.Name = "Thống kê SP Phiếu TL (đã)";

                worksheet.Cells[2, 2] = "BÁO CÁO THỐNG KÊ PHIẾU THANH LÝ";
                worksheet.Cells[3, 2] = "(Đã thanh lý)";

                worksheet.Cells[4, 2] = "Từ " + txtNgayBD.Text + " đến " + txtNgayKT.Text;

                for (int i = 0; i < dataGV_DaThanhLy.ColumnCount; i++)
                {
                    worksheet.Cells[6, i + 1] = dataGV_DaThanhLy.Columns[i].HeaderText;
                }

                for (int i = 0; i < dataGV_DaThanhLy.RowCount; i++)
                {
                    for (int j = 0; j < dataGV_DaThanhLy.ColumnCount; j++)
                    {
                        worksheet.Cells[i + 7, j + 1] = dataGV_DaThanhLy.Rows[i].Cells[j].Value.ToString();
                    }
                }
                int tkshh = dataGV_DaThanhLy.RowCount;

                //Định dạng trang
                worksheet.PageSetup.Orientation = Microsoft.Office.Interop.Excel.XlPageOrientation.xlPortrait;
                worksheet.PageSetup.PaperSize = Microsoft.Office.Interop.Excel.XlPaperSize.xlPaperA4;
                worksheet.PageSetup.LeftMargin = 0;
                worksheet.PageSetup.RightMargin = 0;
                worksheet.PageSetup.TopMargin = 0;
                worksheet.PageSetup.BottomMargin = 0;

                //Định dạng cột
                worksheet.Range["A1"].ColumnWidth = 4.78;
                worksheet.Range["B1"].ColumnWidth = 14;
                worksheet.Range["C1"].ColumnWidth = 11.33;
                worksheet.Range["D1"].ColumnWidth = 9.22;
                worksheet.Range["E1"].ColumnWidth = 16.11;
                worksheet.Range["F1"].ColumnWidth = 10.78;
                worksheet.Range["G1"].ColumnWidth = 15.33;
                worksheet.Range["H1"].ColumnWidth = 17.11;

                //Định dạng fone chữ
                worksheet.Range["A1", "H100"].Font.Name = "Times New Roman";
                worksheet.Range["A1", "H100"].Font.Size = 13;
                worksheet.Range["A2", "H2"].MergeCells = true;
                worksheet.Range["A2", "H2"].Font.Bold = true;
                worksheet.Range["A2", "H2"].Font.Size = 15;

                //worksheet.Range["A3", "H3"].Font.Italic = true;
                worksheet.Range["A3", "H3"].Font.Bold = true;
                worksheet.Range["A3", "H3"].Font.Size = 12;
                worksheet.Range["A3", "H3"].MergeCells = true;

                worksheet.Range["A4", "H4"].Font.Italic = true;
                worksheet.Range["A4", "H4"].Font.Size = 15;
                worksheet.Range["A4", "H4"].MergeCells = true;

                worksheet.Range["A6", "H6"].Font.Bold = true;

                //Kẻ bảng
                worksheet.Range["A6", "H" + (tkshh + 6)].Borders.LineStyle = 1;

                //Định dạng các dòng text
                worksheet.Range["A2", "H2"].HorizontalAlignment = 3;
                worksheet.Range["A3", "H3"].HorizontalAlignment = 3;
                worksheet.Range["A4", "H4"].HorizontalAlignment = 3;
                worksheet.Range["A6", "H6"].HorizontalAlignment = 3;
                worksheet.Range["A7", "A" + (tkshh + 7)].HorizontalAlignment = 3;
                worksheet.Range["B7", "B" + (tkshh + 7)].HorizontalAlignment = 3;
                worksheet.Range["D7", "D" + (tkshh + 7)].HorizontalAlignment = 3;
                //worksheet.Range["C5", "C" + (tkshh + 5)].HorizontalAlignment = 3;
                //worksheet.Range["E5", "E" + (tkshh + 5)].HorizontalAlignment = 3;


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
