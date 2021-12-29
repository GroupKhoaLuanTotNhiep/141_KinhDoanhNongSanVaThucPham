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
    public partial class frmXemChiTietTheoHangHoa : Form
    {
        HoaDon hoaDon = new HoaDon();

        public frmXemChiTietTheoHangHoa()
        {
            InitializeComponent();
        }

        private void frmXemChiTietTheoHangHoa_Load(object sender, EventArgs e)
        {
            txtMaSP.Text = UC_ThongKeDoanhThu.maSP;
            txtTenSP.Text = UC_ThongKeDoanhThu.tenSP;
            txtTongTienHang.Text = UC_ThongKeDoanhThu.tongTien;
            dataGV_HoaDon.DataSource = hoaDon.loadGVHoaDonHangHoa(txtMaSP.Text);
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
