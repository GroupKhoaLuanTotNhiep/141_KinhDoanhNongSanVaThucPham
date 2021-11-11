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

namespace _141_KinhDoanhNongSanVaThucPham
{
    
    public partial class frmThemKhachHang : Form
    {
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
            txtDiaChi.Text = txtDienThoai.Text = txtEmail.Text = txtMatKhau.Text = txtTenKH.Text = "";
            txtTenKH.Focus();
        }

        private void btnLuuKH_Click(object sender, EventArgs e)
        {
            try
            {

                if (string.IsNullOrEmpty(txtDiaChi.Text) || string.IsNullOrEmpty(txtDienThoai.Text) || string.IsNullOrEmpty(txtEmail.Text) || string.IsNullOrEmpty(txtMatKhau.Text) || string.IsNullOrEmpty(txtTenKH.Text) || string.IsNullOrEmpty(txtTichDiem.Text) )
                {
                    MessageBox.Show("Vui lòng nhập đủ thông tin");
                }
                else
                {
                    string tenkh = txtTenKH.Text;
                    string dienthoai = txtDienThoai.Text;
                    string diachi = txtDiaChi.Text;
                    int tichdiem = int.Parse(txtTichDiem.Text);
                    string matkhau = txtMatKhau.Text;
                    string email = txtEmail.Text;

                    //if (kh.addNCC(mancc, tenncc, diachi, dienthoai, email, congno, stk))
                    //{

                    //    MessageBox.Show("Thêm thành công");
                    //    btnThemMoi_Click(sender, e);
                    //}
                    //else
                    //{
                    //    MessageBox.Show("Thêm thất bại");
                    //}
                }
            }
            catch { }
        }
    }
}
