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
    public partial class frmThemTaiKhoanNhanVien : Form
    {
        Connection conn = new Connection();
        NhanVien nhanVien = new NhanVien();
        NhomQuyen quyen = new NhomQuyen();

        public frmThemTaiKhoanNhanVien()
        {
            InitializeComponent();
        }

        void createTable_NhanVienChuaCoTK()
        {
            dataGV_NhanVienTK.DataSource = nhanVien.loadBangNhanVienChuaCoTaiKhoan();
        }

        void createTable_NhanVienDaCoTK()
        {
            dataGV_QuyenNhanVien.DataSource = nhanVien.loadBangNhanVienDaCoTaiKhoan();
        }

        void loadComboBoxQuyen()
        {
            cbbQuyen.DataSource = quyen.loadQuyen();
            cbbQuyen.DisplayMember = "TenQuyen";
            cbbQuyen.ValueMember = "MaQuyen";
        }

        void loadComboBoxQuyenHan()
        {
            cbbQuyenHan.DataSource = quyen.loadQuyen();
            cbbQuyenHan.DisplayMember = "TenQuyen";
            cbbQuyenHan.ValueMember = "MaQuyen";
        }

        private void dataGV_NhanVienTK_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            if (e.RowIndex == -1) return;
            txtMaNV.Text = dataGV_NhanVienTK.Rows[index].Cells[0].Value.ToString();
        }

        private void dataGV_QuyenNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            if (e.RowIndex == -1) return;
            txtMaNhanVien.Text = dataGV_QuyenNhanVien.Rows[index].Cells[0].Value.ToString();
            cbbQuyenHan.Text = dataGV_QuyenNhanVien.Rows[index].Cells[2].Value.ToString();
            txtTenDangNhap.Text = dataGV_QuyenNhanVien.Rows[index].Cells[3].Value.ToString();
            txtPassWord.Text = dataGV_QuyenNhanVien.Rows[index].Cells[4].Value.ToString();
            txtHDTG.Text = dataGV_QuyenNhanVien.Rows[index].Cells[5].Value.ToString();
            btnCapNhatTK.Enabled = btnXoaTK.Enabled = btnThemTK.Enabled = true;
            btnLuuTK.Enabled = false;
        }

        private void frmThemTaiKhoanNhanVien_Load(object sender, EventArgs e)
        {
            createTable_NhanVienChuaCoTK();
            createTable_NhanVienDaCoTK();
            loadComboBoxQuyen();
            loadComboBoxQuyenHan();
            txtMaNV.Enabled = txtMaNhanVien.Enabled = false;
            btnLuuTK.Enabled = btnCapNhatTK.Enabled = btnXoaTK.Enabled = btnThemTK.Enabled = false;
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtMaNV.Clear();
            txtTenDN.Clear();
            txtMatKhau.Clear();
            cbbQuyen.SelectedIndex = 0;
            txtHoatDong.Clear();
            btnLuuTK.Enabled = true;
            btnCapNhatTK.Enabled = btnXoaTK.Enabled = btnThemTK.Enabled = false;
        }

        private void btnLuuTK_Click(object sender, EventArgs e)
        {
            try
            {
                string strMaNV = txtMaNV.Text.Trim();
                string strTenDN = txtTenDN.Text.Trim();
                string strMatKhau = txtMatKhau.Text.Trim();
                string strQuyen = cbbQuyen.SelectedValue.ToString().Trim();
                string strHoatDong = txtHoatDong.Text.Trim();
                if (strMaNV != string.Empty && strTenDN != string.Empty && strMatKhau != string.Empty && strQuyen != string.Empty)
                {
                    if (!conn.checkExist("NhanVien", "MaNV", strMaNV))
                    {
                        MessageBox.Show("Nhân viên có mã '" + strMaNV + "' này chưa tồn tại!");
                        return;
                    }
                    if (!conn.checkExist("NhomQuyen", "MaQuyen", strQuyen))
                    {
                        MessageBox.Show("Nhóm quyền '" + strQuyen + "' này chưa tồn tại!");
                        return;
                    }
                    if (conn.checkExistTwoKey("Quyen_NhanVien", "MaNV", "MaQuyen", strMaNV, strQuyen))
                    {
                        MessageBox.Show("Trùng khóa chính (" + strMaNV + ", " + strQuyen + ")!");
                        return;
                    }
                    if (conn.checkExist("Quyen_NhanVien", "TenDN", strTenDN))
                    {
                        MessageBox.Show("Tên đăng nhập '" + strTenDN + "' bị trùng!");
                        return;
                    }
                    string strSQL = "INSERT Quyen_NhanVien VALUES('" + strMaNV + "', '" + strQuyen + "', N'" + strHoatDong + "', '" + strTenDN + "', '" + strMatKhau + "')";
                    conn.updateToDatabase(strSQL);
                    createTable_NhanVienChuaCoTK();
                    createTable_NhanVienDaCoTK();
                    MessageBox.Show("Lưu tài khoản thành công!");
                }
                else
                    MessageBox.Show("Bạn chưa nhập đủ thông tin yêu cầu");
            }
            catch
            {
                MessageBox.Show("Lưu tài khoản thất bại!");
            }
        }

        private void btnCapNhatTK_Click(object sender, EventArgs e)
        {
            try
            {
                string strMaNhanVien = txtMaNhanVien.Text.Trim();
                string strTenDangNhap = txtTenDangNhap.Text.Trim();
                string strPassWord = txtPassWord.Text.Trim();
                string strQuyenHan = cbbQuyenHan.SelectedValue.ToString().Trim();
                string strHDTG = txtHDTG.Text.Trim();
                if (strMaNhanVien != string.Empty && strTenDangNhap != string.Empty && strPassWord != string.Empty && strQuyenHan != string.Empty)
                {
                    if (!conn.checkExist("Quyen_NhanVien", "MaNV", strMaNhanVien))
                    {
                        MessageBox.Show("Nhân viên có mã '" + strMaNhanVien + "' chưa tồn tại trong bảng này!");
                        return;
                    }
                    if (!conn.checkExist("Quyen_NhanVien", "MaQuyen", strQuyenHan))
                    {
                        MessageBox.Show("Nhóm quyền '" + strQuyenHan + "' chưa tồn tại trong bảng này!");
                        return;
                    }
                    if (conn.checkExistTwoKey("Quyen_NhanVien", "MaNV", "MaQuyen", strMaNhanVien, strQuyenHan))
                    {
                        DialogResult rs = MessageBox.Show("Trùng khóa chính (" + strMaNhanVien + ", " + strQuyenHan + ")!", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                        if (rs == DialogResult.No)
                            return;
                    }
                    if (conn.checkExist("Quyen_NhanVien", "TenDN", strTenDangNhap))
                    {
                        DialogResult rs = MessageBox.Show("Tên đăng nhập '" + strTenDangNhap + "' bị trùng!", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                        if (rs == DialogResult.No)
                            return;
                    }
                    //string strSQL = "UPDATE Quyen_NhanVien SET MaQuyen='" + strQuyenHan + "', HoatDong=N'" + strHDTG + "', TenDN='" + strTenDangNhap + "', MatKhau='" + strPassWord + "' WHERE MaNV='" + strMaNhanVien + "'";
                    //conn.updateToDatabase(strSQL);
                    string strSql = "UPDATE Quyen_NhanVien SET HoatDong=N'" + strHDTG + "', TenDN='" + strTenDangNhap + "', MatKhau='" + strPassWord + "' WHERE MaNV='" + strMaNhanVien + "' AND MaQuyen='" + strQuyenHan + "'";
                    conn.updateToDatabase(strSql);
                    createTable_NhanVienDaCoTK();
                    MessageBox.Show("Cập nhật tài khoản thành công!");
                }
                else
                    MessageBox.Show("Bạn chưa nhập đủ thông tin yêu cầu");
            }
            catch
            {
                MessageBox.Show("Cập nhật tài khoản thất bại!");
            }
        }

        private void btnXoaTK_Click(object sender, EventArgs e)
        {
            try
            {
                string strMaNhanVien = txtMaNhanVien.Text.Trim();
                string strQuyenHan = cbbQuyenHan.SelectedValue.ToString().Trim();
                if (strMaNhanVien != string.Empty && strQuyenHan != string.Empty)
                {
                    if (!conn.checkExist("Quyen_NhanVien", "MaNV", strMaNhanVien))
                    {
                        MessageBox.Show("Nhân viên có mã '" + strMaNhanVien + "' chưa tồn tại trong bảng này!");
                        return;
                    }
                    if (!conn.checkExist("Quyen_NhanVien", "MaQuyen", strQuyenHan))
                    {
                        MessageBox.Show("Nhóm quyền '" + strQuyenHan + "' chưa tồn tại trong bảng này!");
                        return;
                    }
                    if (!conn.checkExistTwoKey("Quyen_NhanVien", "MaNV", "MaQuyen", strMaNhanVien, strQuyenHan))
                    {
                        MessageBox.Show("Chưa tồn tại khóa chính (" + strMaNhanVien + ", " + strQuyenHan + ")!");
                        return;
                    }
                    if (MessageBox.Show("Bạn có thật sự muốn xóa tài khoản này không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.No)
                        return;
                    string strSQL = "DELETE Quyen_NhanVien WHERE MaNV ='" + strMaNhanVien + "' AND MaQuyen='" + strQuyenHan + "'";
                    conn.updateToDatabase(strSQL);
                    MessageBox.Show("Xóa tài khoản thành công!");
                    createTable_NhanVienChuaCoTK();
                    createTable_NhanVienDaCoTK();
                }
                else
                    MessageBox.Show("Bạn chưa nhập đủ khóa chính");
            }
            catch
            {
                MessageBox.Show("Xóa tài khoản thất bại!");
            }
        }

        private void btnThemTK_Click(object sender, EventArgs e)
        {
            try
            {
                string strMaNhanVien = txtMaNhanVien.Text.Trim();
                string strTenDangNhap = txtTenDangNhap.Text.Trim();
                string strPassWord = txtPassWord.Text.Trim();
                string strQuyenHan = cbbQuyenHan.SelectedValue.ToString().Trim();
                string strHDTG = txtHDTG.Text.Trim();
                if (strMaNhanVien != string.Empty && strTenDangNhap != string.Empty && strPassWord != string.Empty && strQuyenHan != string.Empty)
                {
                    if (!conn.checkExist("Quyen_NhanVien", "MaNV", strMaNhanVien))
                    {
                        MessageBox.Show("Nhân viên có mã '" + strMaNhanVien + "' chưa tồn tại trong bảng này!");
                        return;
                    }
                    if (!conn.checkExist("Quyen_NhanVien", "MaQuyen", strQuyenHan))
                    {
                        MessageBox.Show("Nhóm quyền '" + strQuyenHan + "' chưa tồn tại trong bảng này!");
                        return;
                    }
                    if (conn.checkExistTwoKey("Quyen_NhanVien", "MaNV", "MaQuyen", strMaNhanVien, strQuyenHan))
                    {
                        MessageBox.Show("Trùng khóa chính (" + strMaNhanVien + ", " + strQuyenHan + ")!");
                        return;
                    }
                    if (conn.checkExist("Quyen_NhanVien", "TenDN", strTenDangNhap))
                    {
                        MessageBox.Show("Tên đăng nhập '" + strTenDangNhap + "' bị trùng!");
                        return;
                    }
                    string strSQL = "INSERT Quyen_NhanVien VALUES('" + strMaNhanVien + "', '" + strQuyenHan + "', N'" + strHDTG + "', '" + strTenDangNhap + "', '" + strPassWord + "')";
                    conn.updateToDatabase(strSQL);
                    createTable_NhanVienDaCoTK();
                    MessageBox.Show("Thêm tài khoản thành công!");
                }
                else
                    MessageBox.Show("Bạn chưa nhập đủ thông tin yêu cầu");
            }
            catch
            {
                MessageBox.Show("Thêm tài khoản thất bại!");
            }
        }
    }
}
