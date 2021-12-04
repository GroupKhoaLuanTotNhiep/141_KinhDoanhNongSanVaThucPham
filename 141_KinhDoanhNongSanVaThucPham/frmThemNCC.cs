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
    public partial class frmThemNCC : Form
    {
        NhaCungCap ncc = new NhaCungCap();
        Connection conn = new Connection();

        public frmThemNCC()
        {
            InitializeComponent();
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        void load()
        {
            txtMaNCC.Text = txtDiaChi.Text = txtDienThoai.Text = txtEmail.Text = txtSoTaiKhoan.Text = txtTenNCC.Text = "";
            txtMaNCC.Enabled = txtDiaChi.Enabled= txtDienThoai.Enabled= txtEmail.Enabled= txtSoTaiKhoan.Enabled= txtTenNCC.Enabled= btnLuuNCC.Enabled= false;
            
        }

        private void btnThemMoi_Click(object sender, EventArgs e)
        {
            txtMaNCC.Text = txtDiaChi.Text = txtDienThoai.Text = txtEmail.Text = txtSoTaiKhoan.Text = txtTenNCC.Text = "";
            txtMaNCC.Enabled = txtDiaChi.Enabled = txtDienThoai.Enabled = txtEmail.Enabled = txtSoTaiKhoan.Enabled = txtTenNCC.Enabled =btnLuuNCC.Enabled= true;
            txtMaNCC.Focus();
        }

        private void btnLuuNCC_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtCongNo.Text) || string.IsNullOrEmpty(txtDiaChi.Text) || string.IsNullOrEmpty(txtDienThoai.Text) || string.IsNullOrEmpty(txtEmail.Text) || string.IsNullOrEmpty(txtMaNCC.Text) || string.IsNullOrEmpty(txtSoTaiKhoan.Text) || string.IsNullOrEmpty(txtTenNCC.Text))
                {
                    MessageBox.Show("Vui lòng nhập đủ thông tin");
                }
                else
                {
                    string mancc = txtMaNCC.Text.Trim();
                    string tenncc = txtTenNCC.Text.Trim();
                    string dienthoai = txtDienThoai.Text.Trim();
                    string diachi = txtDiaChi.Text.Trim();
                    int congno = int.Parse(txtCongNo.Text.Trim());
                    string stk = txtSoTaiKhoan.Text.Trim();
                    string email = txtEmail.Text.Trim();
                    if(conn.checkExist("NhaCungCap", "MaNCC", mancc))
                    {
                        MessageBox.Show("Mã nhà cung cấp " + mancc + " đã tồn tại");
                        return;
                    }
                    if(conn.isEmail(email) == false)
                    {
                        MessageBox.Show("Email không hợp lệ");
                        return;
                    }
                    if (ncc.addNCC(mancc, tenncc, diachi, dienthoai, email, congno, stk))
                    {
                        MessageBox.Show("Thêm thành công");
                        load();
                    }
                    else
                    {
                        MessageBox.Show("Thêm thất bại");
                    }
                }
            }
            catch
            {
                MessageBox.Show("Thêm thất bại");
            }

        }

        private void frmThemNCC_Load(object sender, EventArgs e)
        {
            load();
        }

        private void txtCongNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }
    }
}
