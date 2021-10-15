using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _141_KinhDoanhNongSanVaThucPham
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new frmDangNhap());
            //Application.Run(new frmNhapKho());
            //Application.Run(new frmXuatKho());
            //Application.Run(new frmBanHang());
            //Application.Run(new frmGiaoHang());
            //Application.Run(new frmThanhLy());
            Application.Run(new frmDanhMucKhuyenMai());
            //Application.Run(new frmLichSuGia());
        }
    }
}
