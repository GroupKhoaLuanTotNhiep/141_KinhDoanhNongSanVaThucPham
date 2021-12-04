using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using DBConnect;
using NongSanThucPham;

namespace _141_KinhDoanhNongSanVaThucPham
{
    public partial class frmDangNhap : Form
    {
        NhanVien nv = new NhanVien();
        SqlConnection cn = new SqlConnection();
        Connection conn = new Connection();
        public static string maQ = "";
        public static string maNV = string.Empty;
        public static string maCV = "";
        public static string tenCV = "";
        public static string tenNV = "";
        public static string tenQ = "";
        public static string gt = "";
        public static string ns = "";
        public static string sdt = "";
        public static string email = "";
        public static string dc = "";
        public static string anh = "";
        public static string tenDN = "";
        public static string mk = "";
        public frmDangNhap()
        {
            InitializeComponent();
            txtTenDN.Text = "thanhly";
            txtMatKhau.Text = "12345";
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    conn.openConnect();
            //    int manv = nv.GetTenMaNVVien(txtTenDN.Text, txtMatKhau.Text);
            //    errorProvider1.Clear();
            //    if (manv != -1)
            //    {
            //        MessageBox.Show("Đăng nhập thành công!");
            //        if (Program.FrmTrangChu == null || Program.FrmTrangChu.IsDisposed)
            //        {
            //            Program.FrmTrangChu = new frmTrangChu();
            //        }
                    
            //        Program.FrmTrangChu.Manv = manv;
            //        Program.FrmTrangChu.Show();
            //        this.Hide();
            //    }

            //    else
            //        MessageBox.Show("Đăng nhập không thành công!!!");
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Lỗi kết nối!!!");
            //}

            try
            {
                bool loginSuccess = false;
                //bool loginSuccess1 = false;
                conn.openConnect();
                string strSQL = "Select * From Quyen_NhanVien Where TenDN = N'" + txtTenDN.Text + "' And MatKhau = '" + txtMatKhau.Text + "'";
                SqlCommand cmd = new SqlCommand(strSQL, conn.conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt != null)
                {
                    loginSuccess = dt.Rows.Count > 0;
                    foreach (DataRow dr in dt.Rows)
                    {
                        maQ = dr["MaQuyen"].ToString();
                        maNV = dr["MaNV"].ToString();
                    }
                    string abc = "select * from ChucVu, NhanVien, NhomQuyen, Quyen_NhanVien where ChucVu.MaChucVu = NhanVien.MaChucVu and Quyen_NhanVien.MaNV = NhanVien.MaNV and NhomQuyen.MaQuyen = Quyen_NhanVien.MaQuyen and Quyen_NhanVien.MaNV = '" + maNV + "' and Quyen_NhanVien.MaQuyen='" + maQ + "'";
                    SqlCommand cmd1 = new SqlCommand(abc, conn.conn);
                    SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
                    DataTable dt1 = new DataTable();
                    da1.Fill(dt1);
                    if (dt1 != null)
                    {
                        loginSuccess = dt1.Rows.Count > 0;
                        foreach (DataRow dr1 in dt1.Rows)
                        {
                            maQ = dr1["MaQuyen"].ToString();
                            maNV = dr1["MaNV"].ToString();
                            tenCV = dr1["TenChucVu"].ToString();
                            tenNV = dr1["TenNV"].ToString();
                            tenQ = dr1["TenQuyen"].ToString();
                            gt = dr1["GioiTinh"].ToString();
                            ns = dr1["NgaySinh"].ToString();
                            sdt = dr1["DienThoai"].ToString();
                            email = dr1["Email"].ToString();
                            dc = dr1["DiaChi"].ToString();
                            anh = dr1["HinhNV"].ToString();
                            tenDN = dr1["TenDN"].ToString();
                            mk = dr1["MatKhau"].ToString();
                        }
                    }
                }
                //var stringQuery = "select count(*) from Quyen_NhanVien where TenDN = N'" + txtTenDN.Text + "' and MatKhau = '" + txtMatKhau.Text + "'";
                //var count = conn.getCount(stringQuery);
                errorProvider1.Clear();
                if (loginSuccess)
                {
                    MessageBox.Show("Đăng nhập thành công!");
                    frmTrangChu frmTC = new frmTrangChu();
                    frmTC.Show();
                    this.Hide();

                }

                else
                    MessageBox.Show("Đăng nhập không thành công!!!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối!!!");
            }
        }

        private void txtTenDN_Leave(object sender, EventArgs e)
        {
            Control ctr = (Control)sender;
            if (ctr.Text.Trim().Length == 0)
            {
                this.errorProvider1.SetError(ctr, "Bạn phải nhập tên đăng nhập!!!");
                ctr.Focus();
            }
            else
                this.errorProvider1.Clear();    
        }

        private void chkHienThiMK_CheckedChanged(object sender, EventArgs e)
        {
            if (chkHienThiMK.Checked)
            {
                txtMatKhau.UseSystemPasswordChar = false;
                var checkBox = (CheckBox)sender;
                checkBox.Text = "Ẩn mật khẩu ?";      
            }
            else
            {
                txtMatKhau.UseSystemPasswordChar = true;
                var checkBox = (CheckBox)sender;
                checkBox.Text = "Hiển thị mật khẩu ?";
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult rs = MessageBox.Show("Bạn có muốn thoát chương trình này không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (rs == DialogResult.Yes)
                this.Hide();    
        }

        private void frmDangNhap_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult rs = MessageBox.Show("Bạn có muốn thoát chương trình này không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (rs == DialogResult.No)
                e.Cancel = true;
        }

    }
}
