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
    public partial class frmXemChiTietTheoNhanVien : Form
    {
        HoaDon hoaDon = new HoaDon();

        public frmXemChiTietTheoNhanVien()
        {
            InitializeComponent();
        }

        private void frmXemChiTietTheoNhanVien_Load(object sender, EventArgs e)
        {
            txtMaNV.Text = UC_ThongKeDoanhThu.maNV;
            txtTenNV.Text = UC_ThongKeDoanhThu.tenNV;
            txtTongTienHang.Text = UC_ThongKeDoanhThu.tongTien;
            dataGV_HoaDon.DataSource = hoaDon.loadGVHoaDonTheoNhanVien(txtMaNV.Text);
        }

        private void dataGV_HoaDon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            if (e.RowIndex == -1) return;
            string a = dataGV_HoaDon.Rows[index].Cells[0].Value.ToString();
            dataGV_CTHoaDon.DataSource = hoaDon.layChiTietHoaDon(a);
        }
    }
}
