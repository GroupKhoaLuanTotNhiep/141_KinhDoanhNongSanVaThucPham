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
using NongSanThucPham;

namespace _141_KinhDoanhNongSanVaThucPham
{
    public partial class frmXemChiTietTheoThang : Form
    {
        HoaDon hoaDon = new HoaDon();

        public frmXemChiTietTheoThang()
        {
            InitializeComponent();
        }

        private void frmXemChiTietTheoThang_Load(object sender, EventArgs e)
        {
            txtNgayLap.Text = DateTime.Parse(UC_ThongKeDoanhThu.ngayLap).ToString("MM/dd/yyyy");
            txtTongTienHang.Text = UC_ThongKeDoanhThu.tongTien;
            dataGV_HoaDon.DataSource = hoaDon.loadGVHoaDonTheoNgay(txtNgayLap.Text);
            dataGV_HoaDon.Columns[3].DefaultCellStyle.Format = "MM/dd/yyyy";
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
