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
            Application.Run(new frmTrangChu());
            //Application.Run(new frmNhapKho());
            //Application.Run(new frmXuatKho());
            //Application.Run(new frmBanHang());
            //Application.Run(new frmGiaoHang());
            //Application.Run(new frmThanhLy());
<<<<<<< HEAD
            //Application.Run(new frmDanhMucQuyenNV());
=======
            Application.Run(new frmDangNhap());
>>>>>>> 647650fb822a68f58dbef12db88b8f76788537b3
            //Application.Run(new frmLichSuGia());
            //Application.Run(new frmQuanLyNhanVien());
        }
    }
}
