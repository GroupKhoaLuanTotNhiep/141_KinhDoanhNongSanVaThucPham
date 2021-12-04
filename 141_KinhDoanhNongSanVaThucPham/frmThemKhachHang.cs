using NongSanThucPham;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DBConnect;

namespace _141_KinhDoanhNongSanVaThucPham
{
    public partial class frmThemKhachHang : Form
    {
        Connection conn = new Connection();
        KhachHang kh = new KhachHang();

        public frmThemKhachHang()
        {
            InitializeComponent();
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnThemMoi_Click(object sender, EventArgs e)
        {
            txtDiaChi.Text = txtDienThoai.Text = txtEmail.Text = txtTenKH.Text = "";
            txtTenKH.Focus();
        }

        private void btnLuuKH_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtDiaChi.Text) || string.IsNullOrEmpty(txtDienThoai.Text) || string.IsNullOrEmpty(txtEmail.Text) || string.IsNullOrEmpty(txtCongNo.Text) || string.IsNullOrEmpty(txtTenKH.Text) || string.IsNullOrEmpty(txtTichDiem.Text))
                {
                    MessageBox.Show("Vui lòng nhập đủ thông tin");
                    return;
                }
                else
                {
                    string tenkh = txtTenKH.Text;
                    string dienthoai = txtDienThoai.Text;
                    string diachi = txtDiaChi.Text;
                    int tichdiem = int.Parse(txtTichDiem.Text);
                    int congno = int.Parse(txtCongNo.Text);
                    string email = txtEmail.Text;

                    if(!conn.isEmail(email))
                    {
                        MessageBox.Show("Email " + email + " không hợp lệ");
                        return;
                    }
                    if (conn.checkExist("KhachHang", "Email", email))
                    {
                        MessageBox.Show("Email này đã tồn tại");
                        return;
                    }
                    if(conn.checkExist("KhachHang", "DienThoai", dienthoai))
                    {
                        MessageBox.Show("Điện thoại này đã tồn tại");
                        return;
                    }
                    if (kh.addKH(tenkh, diachi, dienthoai, email, congno, tichdiem))
                    {
                        MessageBox.Show("Thêm thành công");
                        btnThemMoi_Click(sender, e);
                    }
                    else
                    {
                        MessageBox.Show("Thêm thất bại");
                    }
                }
            }
            catch {
                MessageBox.Show("Thêm thất bại");
            }
        }

        private void txtDienThoai_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }
    
    }
}
