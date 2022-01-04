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
    public partial class UC_ThongKeKHTiemNang : UserControl
    {
        Connection cn = new Connection();
        SanPham sp = new SanPham();
        public UC_ThongKeKHTiemNang()
        {
            InitializeComponent();
        }

        private void btnXemTK_KHTiemNang_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            var fromDate = txtNgayBD.Value;
            var toDate = txtNgayKT.Value;
            dt = sp.loadThongKe_KHTiemNang(fromDate, toDate);
            dataGV_KHTiemNang.DataSource = dt;
        }

        private void btnInExcel_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                exportExcel_KHTiemNang(dataGV_KHTiemNang, saveFileDialog1.FileName);
        }
        private void exportExcel_KHTiemNang(DataGridView dv, string fileName)
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
                worksheet.Name = "Thống kê KH tiềm năng";

                worksheet.Cells[2, 2] = "BÁO CÁO THỐNG KÊ KHÁCH HÀNG TIỀM NĂNG";
                worksheet.Cells[3, 2] = "Từ " + txtNgayBD.Text + " đến " + txtNgayKT.Text;

                for (int i = 0; i < dataGV_KHTiemNang.ColumnCount; i++)
                {
                    worksheet.Cells[5, i + 1] = dataGV_KHTiemNang.Columns[i].HeaderText;
                }

                int tkshh = dataGV_KHTiemNang.RowCount;

                for (int i = 0; i < dataGV_KHTiemNang.RowCount; i++)
                {
                    for (int j = 0; j < dataGV_KHTiemNang.ColumnCount; j++)
                    {
                        worksheet.Cells[i + 6, j + 1] = dataGV_KHTiemNang.Rows[i].Cells[j].Value.ToString();
                        worksheet.Range["E6", "E" + (tkshh + 6)].NumberFormat = "@";
                    }
                }

                //Định dạng trang
                worksheet.PageSetup.Orientation = Microsoft.Office.Interop.Excel.XlPageOrientation.xlPortrait;
                worksheet.PageSetup.PaperSize = Microsoft.Office.Interop.Excel.XlPaperSize.xlPaperA4;
                worksheet.PageSetup.LeftMargin = 0;
                worksheet.PageSetup.RightMargin = 0;
                worksheet.PageSetup.TopMargin = 0;
                worksheet.PageSetup.BottomMargin = 0;

                //Định dạng cột
                worksheet.Range["A1"].ColumnWidth = 4.89;
                worksheet.Range["B1"].ColumnWidth = 16.89;
                worksheet.Range["C1"].ColumnWidth = 21.56;
                worksheet.Range["D1"].ColumnWidth = 33.78;
                worksheet.Range["E1"].ColumnWidth = 12.56;
                worksheet.Range["F1"].ColumnWidth = 10.67;

                //Định dạng fone chữ
                worksheet.Range["A1", "F100"].Font.Name = "Times New Roman";
                worksheet.Range["A1", "F100"].Font.Size = 13;
                worksheet.Range["A2", "F2"].MergeCells = true;
                worksheet.Range["A2", "F2"].Font.Bold = true;
                worksheet.Range["A2", "F2"].Font.Size = 15;

                worksheet.Range["A3", "F3"].MergeCells = true;
                worksheet.Range["A3", "F3"].Font.Italic = true;

                worksheet.Range["A5", "F5"].Font.Bold = true;

                //Kẻ bảng
                worksheet.Range["A5", "F" + (tkshh + 5)].Borders.LineStyle = 1;

                //Định dạng các dòng text
                worksheet.Range["A2", "F2"].HorizontalAlignment = 3;
                worksheet.Range["A3", "D3"].HorizontalAlignment = 3;
                worksheet.Range["A5", "F5"].HorizontalAlignment = 3;
                worksheet.Range["A6", "A" + (tkshh + 6)].HorizontalAlignment = 3;
                worksheet.Range["B6", "B" + (tkshh + 6)].HorizontalAlignment = 3;
                worksheet.Range["E6", "E" + (tkshh + 6)].HorizontalAlignment = 3;
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
    }
}
