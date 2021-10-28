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

        private void btnThemQuyen_Click(object sender, EventArgs e)
        {
            try
            {
                string strMaQuyen = txtMaQuyen.Text.Trim();
                string strTenQuyen = txtTenQuyen.Text.Trim();
                if (strTenQuyen != string.Empty)
                {
                    if (conn.checkExist("NhomQuyen", "MaQuyen", strMaQuyen))
                    {
                        MessageBox.Show("Mã quyền " + strMaQuyen + " này đã tồn tại!", "Thông báo");
                        return;
                    }
                    string strSQL = "INSERT NhomQuyen VALUES(N'" + strTenQuyen + "')";
                    conn.updateToDatabase(strSQL);
                    loadLaiData();
                    MessageBox.Show("Thêm quyền thành công!");
                }
                else
                    MessageBox.Show("Bạn chưa nhập đủ thông tin yêu cầu");
            }
            catch
            {
                MessageBox.Show("Thêm quyền thất bại!");
            }
        }

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
    }
}
