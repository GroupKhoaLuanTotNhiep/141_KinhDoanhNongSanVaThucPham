using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _141_KinhDoanhNongSanVaThucPham
{
    public partial class UC_QuanLyNhanVien : UserControl
    {
        public UC_QuanLyNhanVien()
        {
            InitializeComponent();
        }

        private void btnThemTK_Click(object sender, EventArgs e)
        {
            frmThemTaiKhoanNhanVien themTaiKhoan = new frmThemTaiKhoanNhanVien();
            themTaiKhoan.ShowDialog();
        }

        private void btnChamCong_Click(object sender, EventArgs e)
        {
            frmChamCong chamCong = new frmChamCong();
            chamCong.ShowDialog();
        }

        private void btnTinhLuong_Click(object sender, EventArgs e)
        {
            frmTinhLuong tinhLuong = new frmTinhLuong();
            tinhLuong.ShowDialog();
        }
    }
}
