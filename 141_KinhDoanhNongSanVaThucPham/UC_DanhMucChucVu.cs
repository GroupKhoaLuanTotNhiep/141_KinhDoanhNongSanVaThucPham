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
    public partial class UC_DanhMucChucVu : UserControl
    {
        Connection conn = new Connection();
        ChucVu chucVu = new ChucVu();
        //SqlDataAdapter da_ChucVu, da_NhanVien;
        //DataSet ds_ChucVu, ds_NhanVien;
        //DataTable dt_ChucVu;
        //DataView dtv_ChucVu;

        public UC_DanhMucChucVu()
        {
            InitializeComponent();
            createTable_ChucVu();
            //createTable_NhanVien();
            btnXoaCV.Enabled = btnSuaCV.Enabled = false;
        }

        void createTable_ChucVu()
        {
            //da_ChucVu = new SqlDataAdapter("Select * From ChucVu", conn.conn);
            //ds_ChucVu = new DataSet();
            //da_ChucVu.Fill(ds_ChucVu, "ChucVu");
            //DataColumn[] key = new DataColumn[1];
            //key[0] = ds_ChucVu.Tables["ChucVu"].Columns[0];
            //ds_ChucVu.Tables["ChucVu"].PrimaryKey = key;
            //dataGV_DMChucVu.DataSource = ds_ChucVu.Tables["NhanVien"];
            dataGV_DMChucVu.DataSource = chucVu.loadDataGV_ChucVu();
        }

        void createTable_NhanVien()
        {
            //da_NhanVien = new SqlDataAdapter("Select * From NhanVien", conn.conn);
            //ds_NhanVien = new DataSet();
            //da_NhanVien.Fill(ds_NhanVien, "NhanVien");
            //DataColumn[] key = new DataColumn[1];
            //key[0] = ds_NhanVien.Tables["NhanVien"].Columns[0];
            //ds_NhanVien.Tables["NhanVien"].PrimaryKey = key;
            //dataGV_DSNhanVien.DataSource = ds_NhanVien.Tables["NhanVien"];
            dataGV_DSNhanVien.DataSource = chucVu.loadDataGV_NhanVien();
        }

        //public DataTable GetNhanVien(string ma)
        //{
        //    string lenh = string.Format("Select * From NhanVien Where MaChucVu ='" + ma + "'");
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
            string loadLaiDuLieu = "Select * From ChucVu";
            dataGV_DMChucVu.DataSource = conn.LoadData(loadLaiDuLieu);
        }

        private void dataGV_DMChucVu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            if (e.RowIndex == -1) return;
            txtMaCV.Text = dataGV_DMChucVu.Rows[index].Cells[0].Value.ToString();
            txtTenCV.Text = dataGV_DMChucVu.Rows[index].Cells[1].Value.ToString();
            txtHeSoLuong.Text = dataGV_DMChucVu.Rows[index].Cells[2].Value.ToString();
            txtLuongCB.Text = dataGV_DMChucVu.Rows[index].Cells[3].Value.ToString();
            string a = dataGV_DMChucVu.Rows[index].Cells[0].Value.ToString().Trim();
            dataGV_DSNhanVien.DataSource = chucVu.layNhanVien(a);
            btnXoaCV.Enabled = btnSuaCV.Enabled = true;
        }

        private void btnThemCV_Click(object sender, EventArgs e)
        {
            try
            {
                string strMaCV = txtMaCV.Text.Trim();
                string strTenCV = txtTenCV.Text.Trim();
                string strHSL = txtHeSoLuong.Text.Trim();
                string strLuongCB = txtLuongCB.Text.Trim();
                if (strMaCV != string.Empty && strTenCV != string.Empty && strHSL != string.Empty && strLuongCB != string.Empty)
                {
                    if (conn.checkExist("ChucVu", "MaChucVu", strMaCV))
                    {
                        MessageBox.Show("Mã chức vụ " + strMaCV + " này đã tồn tại!", "Thông báo");
                        return;
                    }
                    if (conn.checkExist("ChucVu", "TenChucVu", strTenCV))
                    {
                        MessageBox.Show("Tên chức vụ không được trùng nhau!", "Thông báo");
                        return;
                    }
                    string strSQL = "INSERT ChucVu VALUES('" + strMaCV + "', N'" + strTenCV + "', " + strHSL + ", " + strLuongCB + ")";
                    conn.updateToDatabase(strSQL);
                    loadLaiData();
                    MessageBox.Show("Thêm chức vụ thành công!");
                }
                else
                    MessageBox.Show("Bạn chưa nhập đủ thông tin");
            }
            catch
            {
                MessageBox.Show("Thêm chức vụ thất bại!");
            }
        }

        private void btnSuaCV_Click(object sender, EventArgs e)
        {
            try
            {
                string strMaCV = txtMaCV.Text.Trim();
                string strTenCV = txtTenCV.Text.Trim();
                string strHSL = txtHeSoLuong.Text.Trim();
                string strLuongCB = txtLuongCB.Text.Trim();
                if (strMaCV != string.Empty && (strTenCV != string.Empty || strHSL != string.Empty || strLuongCB != string.Empty))
                {
                    if (!conn.checkExist("ChucVu", "MaChucVu", strMaCV))
                    {
                        MessageBox.Show("Mã chức vụ " + strMaCV + " này chưa tồn tại!", "Thông báo");
                        return;
                    }
                    string strSQL = "UPDATE ChucVu SET TenChucVu=N'" + strTenCV + "', HeSoLuong=" + strHSL + ", LuongCoBan=" + strLuongCB + " WHERE MaChucVu='" + strMaCV + "'";
                    conn.updateToDatabase(strSQL);
                    loadLaiData();
                    MessageBox.Show("Cập nhật chức vụ thành công!");
                }
                else
                    MessageBox.Show("Bạn chưa nhập đủ thông tin yêu cầu");
            }
            catch
            {
                MessageBox.Show("Cập nhật chức vụ thất bại!");
            }
        }

        private void btnXoaCV_Click(object sender, EventArgs e)
        {
            try
            {
                string strMaCV = txtMaCV.Text.Trim();
                if (strMaCV != string.Empty)
                {
                    if (!conn.checkExist("ChucVu", "MaChucVu", strMaCV))
                    {
                        MessageBox.Show("Mã chức vụ " + strMaCV + " này chưa tồn tại!", "Thông báo");
                        return;
                    }
                    if (conn.checkExist("NhanVien", "MaChucVu", strMaCV))
                    {
                        MessageBox.Show("Mã chức vụ " + strMaCV + " đã có trong bảng Nhân viên nên không thể xóa!");
                        return;
                    }
                    if (MessageBox.Show("Bạn có thực sự muốn xóa chức vụ này không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.No)
                        return;
                    string strSQL = "DELETE ChucVu WHERE MaChucVu='" + strMaCV + "'";
                    conn.updateToDatabase(strSQL);
                    MessageBox.Show("Xóa chức vụ thành công");
                    loadLaiData();
                }
                else
                    MessageBox.Show("Bạn chưa nhập mã chức vụ cần xóa");
            }
            catch
            {
                MessageBox.Show("Xóa chức vụ thất bại");
            }
        }

        private void txtHeSoLuong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
                e.Handled = true;
        }

        private void txtLuongCB_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }


    }
}
