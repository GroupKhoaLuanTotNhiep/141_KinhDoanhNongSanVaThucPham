using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NongSanThucPham;

namespace _141_KinhDoanhNongSanVaThucPham
{
    
    public partial class frmThemNCC : Form
    {
        NhaCungCap ncc = new NhaCungCap();
        public frmThemNCC()
        {
            InitializeComponent();
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnThemMoi_Click(object sender, EventArgs e)
        {
            txtMaNCC.Text  = txtDiaChi.Text = txtDienThoai.Text = txtEmail.Text = txtSoTaiKhoan.Text = txtTenNCC.Text = "";
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
                    
                    string mancc = txtMaNCC.Text;
                    string tenncc = txtTenNCC.Text;
                    string dienthoai = txtDienThoai.Text;
                    string diachi = txtDiaChi.Text;
                    int congno = int.Parse(txtCongNo.Text);
                    string stk = txtSoTaiKhoan.Text;
                    string email = txtEmail.Text;

                    if (ncc.addNCC(mancc, tenncc, diachi, dienthoai, email, congno, stk))
                    {
                        
                        MessageBox.Show("Thêm thành công");
                        btnThemMoi_Click(sender,e);
                    }
                    else
                    {
                        MessageBox.Show("Thêm thất bại");
                    }
                }
            }
            catch { }
            
        }
    }
}
