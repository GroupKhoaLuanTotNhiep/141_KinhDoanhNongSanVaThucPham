using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;
using DBConnect;
using NongSanThucPham;

namespace _141_KinhDoanhNongSanVaThucPham
{
    public partial class UC_ThongTinNguoiDung : UserControl
    {
        SqlConnection cn = new SqlConnection();
        Connection conn = new Connection();
        NhanVien nv = new NhanVien();
        string maNV = frmDangNhap.maNV;
        string maCV = frmDangNhap.maCV;
        string paths = Application.StartupPath.Substring(0, Application.StartupPath.Length - 10);

        public UC_ThongTinNguoiDung()
        {
            InitializeComponent();
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            conn.openConnect();
            var stringQuery = "select count(*) from Quyen_NhanVien where TenDN = N'" + txtTenDN1.Text + "' and MatKhau = '" + txtMKCu.Text + "'";
            var count = conn.getCount(stringQuery);
            errorProvider1.Clear();
            if (count == 1)
            {
                if (txtMKMoi.Text == txtNhapLai.Text)
                {
                    var queryUpdate = "update Quyen_NhanVien set MatKhau = '" + txtMKMoi.Text + "' where TenDN = '" + txtTenDN1.Text + "' and MatKhau = '" + txtMKCu.Text + "'";
                    conn.updateToDatabase(queryUpdate);
                    MessageBox.Show("Đổi mật khẩu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    errorProvider1.SetError(txtMKMoi, "Bạn chưa điền mật khẩu mới!!!");
                    errorProvider1.SetError(txtNhapLai, "Mật khẩu nhập lại không khớp!!!");
                }
            }
            else
            {
                errorProvider1.SetError(txtTenDN1, "Tên đăng nhập không đúng!!!");
                errorProvider1.SetError(txtMKCu, "Mật khẩu cũ không đúng!!!");
            }
            conn.closeConnect();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult rs = MessageBox.Show("Bạn có muốn đóng màn hình này không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (rs == DialogResult.Yes)
                this.Hide();   
        }

        private void UC_ThongTinNguoiDung_Load(object sender, EventArgs e)
        {
            txtMaNV.Enabled = txtTenNV.Enabled = txtCV.Enabled = txtQuyen.Enabled = txtGT.Enabled = txtNS.Enabled = txtSDT.Enabled = txtEmail.Enabled = txtDC.Enabled = txtTenDN.Enabled = txtTenDN1.Enabled = txtMK.Enabled = txtHinhNV.Enabled = false;
            //txtMaNV.Text = Program.FrmTrangChu.Manv.ToString();
            //txtTenNV.Text = nv.layTenNhanVien(txtMaNV.Text);
            txtMaNV.Text = frmDangNhap.maNV;
            txtTenNV.Text = frmDangNhap.tenNV;
            txtCV.Text = frmDangNhap.tenCV;
            txtQuyen.Text = frmDangNhap.tenQ;
            txtGT.Text = frmDangNhap.gt;
            txtNS.Text = DateTime.Parse(frmDangNhap.ns).ToString("dd/MM/yyyy");
            txtSDT.Text = frmDangNhap.sdt;
            txtEmail.Text = frmDangNhap.email;
            txtDC.Text = frmDangNhap.dc;
            txtTenDN.Text = frmDangNhap.tenDN;
            txtTenDN1.Text = frmDangNhap.tenDN;
            txtMK.Text = frmDangNhap.mk;
            txtHinhNV.Text = frmDangNhap.anh;
            try
            {
                if (txtHinhNV.Text != " " && txtHinhNV.Text != "" && txtHinhNV.Text != null)
                {
                    string url = paths + "\\image\\" + txtHinhNV.Text;
                    pictureBoxNhanVien.Image = System.Drawing.Image.FromFile(url);
                    FileStream fs = new FileStream(url, FileMode.Open, FileAccess.Read);
                    pictureBoxNhanVien.Image = System.Drawing.Image.FromStream(fs);
                    fs.Close();
                }
                else
                {
                    pictureBoxNhanVien.Image = System.Drawing.Image.FromFile(paths + "\\image\\anhavatar.png");
                }
            }
            catch
            {
                pictureBoxNhanVien.Image = System.Drawing.Image.FromFile(paths + "\\image\\anhavatar.png");
            }
        }

        private void btnDiemDanh_Click(object sender, EventArgs e)
        {
            try
            {
                if(conn.checkExistTwoKey("ChamCong", "MaNV", "NgayLam", txtMaNV.Text, DateTime.Now.ToString()))
                {
                    MessageBox.Show("Bạn đã điểm danh rồi!");
                    return;
                }
                string strSQL = "INSERT ChamCong VALUES('" + txtMaNV.Text + "', '" + DateTime.Now.ToString() + "', N'Đi làm')";
                conn.updateToDatabase(strSQL);
                MessageBox.Show("Điểm danh thành công!");
            }
            catch
            {
                MessageBox.Show("Điểm danh thất bại!");
            }
        }
    }
}
