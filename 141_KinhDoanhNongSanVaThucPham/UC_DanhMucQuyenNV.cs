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
    public partial class UC_DanhMucQuyenNV : UserControl
    {
        Connection conn = new Connection();
        NhomQuyen quyen = new NhomQuyen();
        //SqlDataAdapter da_Quyen, da_NhanVien;
        //DataSet ds_Quyen;
        //DataSet ds;

        public UC_DanhMucQuyenNV()
        {
            InitializeComponent();
            createTable_Quyen();
            btnXoaQuyen.Enabled = btnSuaQuyen.Enabled = false;
        }

        void createTable_Quyen()
        {
            //da_Quyen = new SqlDataAdapter("Select * From NhomQuyen", conn.conn);
            //ds_Quyen = new DataSet();
            //da_Quyen.Fill(ds_Quyen, "NhomQuyen");
            //DataColumn[] key = new DataColumn[1];
            //key[0] = ds_Quyen.Tables["NhomQuyen"].Columns[0];
            //ds_Quyen.Tables["NhomQuyen"].PrimaryKey = key;
            //dataGV_DMQuyen.DataSource = ds_Quyen.Tables["NhomQuyen"];
            dataGV_DMQuyen.DataSource = quyen.loadDataGV_Quyen();
        }

        void createTable_NhanVien()
        {
            //string strSQL = "Select NhanVien.MaNV, TenNV, GioiTinh, NgaySinh, DiaChi, DienThoai, Email, TenDN, MatKhau, NhomQuyen.MaQuyen From NhanVien, Quyen_NhanVien, NhomQuyen Where NhanVien.MaNV = Quyen_NhanVien.MaNV And NhomQuyen.MaQuyen = Quyen_NhanVien.MaQuyen";
            //da_NhanVien = new SqlDataAdapter(strSQL, conn.conn);
            //ds = new DataSet();
            //da_NhanVien.Fill(ds, "NhanVien, Quyen_NhanVien, NhomQuyen");
            //dataGV_DSNhanVien.DataSource = ds.Tables["NhanVien, Quyen_NhanVien, NhomQuyen"];
            dataGV_DSNhanVien.DataSource = quyen.loadDataGV_NhanVien();
        }

        //public DataTable GetNhanVien(string ma)
        //{
        //    string lenh = string.Format("Select NhanVien.MaNV, TenNV, GioiTinh, NgaySinh, DiaChi, DienThoai, Email, TenDN, MatKhau, NhomQuyen.MaQuyen From NhanVien, Quyen_NhanVien, NhomQuyen Where NhanVien.MaNV = Quyen_NhanVien.MaNV And NhomQuyen.MaQuyen = Quyen_NhanVien.MaQuyen And NhomQuyen.MaQuyen='" + ma + "'");
        //    DataTable table = new DataTable();
        //    SqlDataAdapter adt = new SqlDataAdapter(lenh, conn.conn);
        //    adt.Fill(table);
        //    return table;
        //}

        //public DataTable layNhanVien(string ma)
        //{
        //    return GetNhanVien(ma);
        //}

        private void loadLaiData()
        {
            string loadLaiDuLieu = "Select * From NhomQuyen";
            dataGV_DMQuyen.DataSource = conn.LoadData(loadLaiDuLieu);
        }

        private void dataGV_DMQuyen_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            if (e.RowIndex == -1) return;
            txtMaQuyen.Text = dataGV_DMQuyen.Rows[index].Cells[0].Value.ToString();
            txtTenQuyen.Text = dataGV_DMQuyen.Rows[index].Cells[1].Value.ToString();
            string a = dataGV_DMQuyen.Rows[index].Cells[0].Value.ToString().Trim();
            dataGV_DSNhanVien.DataSource = quyen.layNhanVien(a);
            btnXoaQuyen.Enabled = btnSuaQuyen.Enabled = true;
        }

        //private void btnThemQuyen_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        string strMaQuyen = txtMaQuyen.Text.Trim();
        //        string strTenQuyen = txtTenQuyen.Text.Trim();
        //        if (strMaQuyen != string.Empty && strTenQuyen != string.Empty)
        //        {
        //            if (conn.checkExist("NhomQuyen", "MaQuyen", strMaQuyen))
        //            {
        //                MessageBox.Show("Mã quyền " + strMaQuyen + " này đã tồn tại!", "Thông báo");
        //                return;
        //            }
        //            if (conn.checkExist("NhomQuyen", "TenQuyen", strTenQuyen))
        //            {
        //                MessageBox.Show("Tên quyền không được trùng nhau!", "Thông báo");
        //                return;
        //            }
        //            string strSQL = "INSERT NhomQuyen VALUES('" + strMaQuyen + "', N'" + strTenQuyen + "')";
        //            conn.updateToDatabase(strSQL);
        //            loadLaiData();
        //            MessageBox.Show("Thêm quyền thành công!");
        //        }
        //        else
        //            MessageBox.Show("Bạn chưa nhập đủ thông tin yêu cầu");
        //    }
        //    catch
        //    {
        //        MessageBox.Show("Thêm quyền thất bại!");
        //    }
        //}

        private void btnSuaQuyen_Click(object sender, EventArgs e)
        {
            try
            {
                string strMaQuyen = txtMaQuyen.Text.Trim();
                string strTenQuyen = txtTenQuyen.Text.Trim();
                if (strMaQuyen != string.Empty && strTenQuyen != string.Empty)
                {
                    if (!conn.checkExist("NhomQuyen", "MaQuyen", strMaQuyen))
                    {
                        MessageBox.Show("Mã quyền " + strMaQuyen + " này chưa tồn tại!", "Thông báo");
                        return;
                    }
                    string strSQL = "UPDATE NhomQuyen SET TenQuyen=N'" + strTenQuyen + "' WHERE MaQuyen='" + strMaQuyen + "'";
                    conn.updateToDatabase(strSQL);
                    loadLaiData();
                    MessageBox.Show("Cập nhật quyền thành công!");
                }
                else
                    MessageBox.Show("Bạn chưa nhập đủ thông tin yêu cầu");
            }
            catch
            {
                MessageBox.Show("Cập nhật quyền thất bại!");
            }
        }

        private void btnXoaQuyen_Click(object sender, EventArgs e)
        {
            try
            {
                string strMaQuyen = txtMaQuyen.Text.Trim();
                if (strMaQuyen != string.Empty)
                {
                    if (!conn.checkExist("NhomQuyen", "MaQuyen", strMaQuyen))
                    {
                        MessageBox.Show("Mã quyền " + strMaQuyen + " này chưa tồn tại!", "Thông báo");
                        return;
                    }
                    if (conn.checkExist("Quyen_NhanVien", "MaQuyen", strMaQuyen))
                    {
                        MessageBox.Show("Mã quyền " + strMaQuyen + " đã có trong bảng Quyền_Nhân viên nên không thể xóa!");
                        return;
                    }
                    if (MessageBox.Show("Bạn có thực sự muốn xóa quyền này không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.No)
                        return;
                    string strSQL = "DELETE NhomQuyen WHERE MaQuyen='" + strMaQuyen + "'";
                    conn.updateToDatabase(strSQL);
                    MessageBox.Show("Xóa quyền thành công");
                    loadLaiData();
                }
                else
                    MessageBox.Show("Bạn chưa nhập mã quyền cần xóa");
            }
            catch
            {
                MessageBox.Show("Xóa quyền thất bại");
            }
        }

        private void btnInDanhSach_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                exportExcel_Quyen(dataGV_DSNhanVien, saveFileDialog1.FileName); 
        }
        private void exportExcel_Quyen(DataGridView dv, string fileName)
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
                worksheet.Name = "Danh mục quyền";

                worksheet.Cells[2, 2] = "DANH MỤC QUYỀN";
                worksheet.Cells[4, 2] = "Mã quyền: ";
                worksheet.Cells[4, 3] = txtMaQuyen.Text;
                worksheet.Cells[5, 2] = "Quyền: ";
                worksheet.Cells[5, 3] = txtTenQuyen.Text;

                for (int i = 0; i < dataGV_DSNhanVien.ColumnCount; i++)
                {
                    worksheet.Cells[7, i + 1] = dataGV_DSNhanVien.Columns[i].HeaderText;
                }

                for (int i = 0; i < dataGV_DSNhanVien.RowCount; i++)
                {
                    for (int j = 0; j < dataGV_DSNhanVien.ColumnCount; j++)
                    {
                        worksheet.Cells[i + 8, j + 1] = dataGV_DSNhanVien.Rows[i].Cells[j].Value.ToString();
                    }
                }
                int dmQ = dataGV_DSNhanVien.RowCount;

                //Định dạng trang
                worksheet.PageSetup.Orientation = Microsoft.Office.Interop.Excel.XlPageOrientation.xlLandscape;
                worksheet.PageSetup.PaperSize = Microsoft.Office.Interop.Excel.XlPaperSize.xlPaperA4;
                worksheet.PageSetup.LeftMargin = 0;
                worksheet.PageSetup.RightMargin = 0;
                worksheet.PageSetup.TopMargin = 0;
                worksheet.PageSetup.BottomMargin = 0;

                //Định dạng cột
                worksheet.Range["A1"].ColumnWidth = 7.89;
                worksheet.Range["B1"].ColumnWidth = 20.22;
                worksheet.Range["C1"].ColumnWidth = 9.33;
                worksheet.Range["D1"].ColumnWidth = 15.56;
                worksheet.Range["E1"].ColumnWidth = 25.67;
                worksheet.Range["F1"].ColumnWidth = 12;
                worksheet.Range["G1"].ColumnWidth = 21.89;
                worksheet.Range["H1"].ColumnWidth = 9.22;
                worksheet.Range["I1"].ColumnWidth = 10.33;
                worksheet.Range["J1"].ColumnWidth = 8;

                //Định dạng fone chữ
                worksheet.Range["A1", "J100"].Font.Name = "Times New Roman";
                worksheet.Range["A1", "J100"].Font.Size = 13;
                worksheet.Range["A2", "J2"].MergeCells = true;
                worksheet.Range["A2", "J2"].Font.Bold = true;
                worksheet.Range["A2", "J2"].Font.Size = 15;


                worksheet.Range["A7", "J7"].Font.Bold = true;

                //Kẻ bảng
                worksheet.Range["A7", "J" + (dmQ + 7)].Borders.LineStyle = 1;

                //Định dạng các dòng text
                worksheet.Range["A2", "J2"].HorizontalAlignment = 3;
                worksheet.Range["A7", "J7"].HorizontalAlignment = 3;
                worksheet.Range["A8", "D" + (dmQ + 8)].HorizontalAlignment = 3;
                worksheet.Range["F8", "J" + (dmQ + 8)].HorizontalAlignment = 3;

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
