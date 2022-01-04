using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NongSanThucPham;
using DBConnect;

namespace _141_KinhDoanhNongSanVaThucPham
{
    public partial class UC_DanhMucKhachHang : UserControl
    {
        Connection conn = new Connection();
        KhachHang kh = new KhachHang();
        frmThemKhachHang frmKH = new frmThemKhachHang();
        int index = -1;

        public UC_DanhMucKhachHang()
        {
            InitializeComponent();
        }

        private void btnTK_Click(object sender, EventArgs e)
        {
            string tukhoa = txtTKKhach.Text;
            dataGV_KhachHang.DataSource = kh.searchKhachHang(tukhoa);
        }

        private void loadDTGV()
        {
            dataGV_KhachHang.DataSource = kh.loadDataGV_KhachHang();
        }

        private void btnTaoKhachHang_Click(object sender, EventArgs e)
        {
            if (frmKH.IsDisposed)
            {
                frmKH = new frmThemKhachHang();
            }
            frmKH.Show();
            frmKH.BringToFront();
            frmKH.Activate();
        }

        private void btnXoaKhachHang_Click(object sender, EventArgs e)
        {
            try
            {
                int makh = int.Parse(dataGV_KhachHang.Rows[index].Cells[0].Value.ToString());

                if(!conn.checkExist("KhachHang", "MaKH", makh.ToString()))
                {
                    MessageBox.Show("Mã khách hàng " + makh + " chưa tồn tại");
                    return;
                }
                if(conn.checkExist("HoaDon", "MaKH", makh.ToString()))
                {
                    MessageBox.Show("Mã khách hàng này đang được sử dụng trong bảng hóa đơn");
                    return;
                }
                if (MessageBox.Show("Bạn có thật sự muốn xóa khách hàng này không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.No)
                    return;
                kh.deleteKH(makh);
                index = -1;
                MessageBox.Show("Xóa thành công");
                UC_DanhMucKhachHang_Load(sender, e);
            }
            catch
            {
                MessageBox.Show("Xóa thất bại");
            }
        }

        private void btnSuaKhachHang_Click(object sender, EventArgs e)
        {
            try
            {
                int makh = int.Parse(dataGV_KhachHang.Rows[index].Cells[0].Value.ToString());
                string tenkh = dataGV_KhachHang.Rows[index].Cells[1].Value.ToString();
                string diachi = dataGV_KhachHang.Rows[index].Cells[2].Value.ToString();
                string dienthoai = dataGV_KhachHang.Rows[index].Cells[3].Value.ToString();
                string email = dataGV_KhachHang.Rows[index].Cells[4].Value.ToString();
                int tichdiem = int.Parse(dataGV_KhachHang.Rows[index].Cells[5].Value.ToString());
                int congno = int.Parse(dataGV_KhachHang.Rows[index].Cells[6].Value.ToString());
                if (!conn.checkExist("KhachHang", "MaKH", makh.ToString()))
                {
                    MessageBox.Show("Mã khách hàng " + makh + " chưa tồn tại");
                    return;
                }
                if (!conn.isEmail(email))
                {
                    MessageBox.Show("Email " + email + " không hợp lệ");
                    return;
                }
                //if (conn.checkExist("KhachHang", "Email", email))
                //{
                //    MessageBox.Show("Email này đã tồn tại");
                //    return;
                //}
                //if (conn.checkExist("KhachHang", "DienThoai", dienthoai))
                //{
                //    MessageBox.Show("Điện thoại này đã tồn tại");
                //    return;
                //}
                if (kh.updateKH(makh, tenkh, diachi, dienthoai, email, congno, tichdiem))
                {
                    index = -1;
                    MessageBox.Show("Sửa thành công");
                    UC_DanhMucKhachHang_Load(sender, e);
                }
                else
                {
                    MessageBox.Show("Sửa thất bại");
                }
            }
            catch
            {
                MessageBox.Show("Sửa thất bại");
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
                index = e.RowIndex;

            btnXoaKhachHang.Enabled = btnSuaKhachHang.Enabled = true;
        }

        private void UC_DanhMucKhachHang_Load(object sender, EventArgs e)
        {
            loadDTGV();
            btnSuaKhachHang.Enabled = btnXoaKhachHang.Enabled = false;
        }

        private void btnInExc_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                exportExcel_KH(dataGV_KhachHang, saveFileDialog1.FileName);
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
                worksheet.Name = "DM khách hàng";

                worksheet.Cells[2, 2] = "DANH MỤC KHÁCH HÀNG";

                for (int i = 0; i < dataGV_KhachHang.ColumnCount; i++)
                {
                    worksheet.Cells[4, i + 1] = dataGV_KhachHang.Columns[i].HeaderText;
                }

                int tkshh = dataGV_KhachHang.RowCount;

                for (int i = 0; i < dataGV_KhachHang.RowCount; i++)
                {
                    for (int j = 0; j < dataGV_KhachHang.ColumnCount; j++)
                    {
                        worksheet.Cells[i + 5, j + 1] = dataGV_KhachHang.Rows[i].Cells[j].Value.ToString();
                        worksheet.Range["D5", "D" + (tkshh + 6)].NumberFormat = "@";
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
                worksheet.Range["A1"].ColumnWidth = 16.44;
                worksheet.Range["B1"].ColumnWidth = 26.33;
                worksheet.Range["C1"].ColumnWidth = 37;
                worksheet.Range["D1"].ColumnWidth = 15.78;
                worksheet.Range["E1"].ColumnWidth = 27.33;
                worksheet.Range["F1"].ColumnWidth = 11.22;
                worksheet.Range["G1"].ColumnWidth = 9.22;

                //Định dạng fone chữ
                worksheet.Range["A1", "G100"].Font.Name = "Times New Roman";
                worksheet.Range["A1", "G100"].Font.Size = 13;
                worksheet.Range["A2", "G2"].MergeCells = true;
                worksheet.Range["A2", "G2"].Font.Bold = true;
                worksheet.Range["A2", "G2"].Font.Size = 15;

                worksheet.Range["A3", "G3"].MergeCells = true;
                worksheet.Range["A3", "G3"].Font.Italic = true;
                worksheet.Range["A3", "G3"].Font.Size = 15;

                worksheet.Range["A4", "G4"].Font.Bold = true;

                //Kẻ bảng
                worksheet.Range["A4", "G" + (tkshh + 4)].Borders.LineStyle = 1;

                //Định dạng các dòng text
                worksheet.Range["A2", "G2"].HorizontalAlignment = 3;
                worksheet.Range["A4", "G4"].HorizontalAlignment = 3;
                worksheet.Range["A5", "A" + (tkshh + 5)].HorizontalAlignment = 3;
                worksheet.Range["F5", "F" + (tkshh + 5)].HorizontalAlignment = 3;
                worksheet.Range["G5", "G" + (tkshh + 5)].HorizontalAlignment = 3;

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
