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
    public partial class frmHoatDongChiNhanh : Form
    {
        ChiNhanh chiNhanh = new ChiNhanh();
        NhapKho nhapKho = new NhapKho();
        XuatHang xuatHang = new XuatHang();
        ThanhLy thanhLy = new ThanhLy();
        GiaoHang giaoHang = new GiaoHang();

        public frmHoatDongChiNhanh(string macn)
        {
            InitializeComponent();
            dataGV_PhieuNhap.DataSource = chiNhanh.layPhieuNhap(macn);
            dataGV_PhieuXuat.DataSource = chiNhanh.layPhieuXuat(macn);
            dataGV_PhieuThanhLy.DataSource = chiNhanh.layPhieuThanhLy(macn);
            dataGV_PhieuGiaoHang.DataSource = chiNhanh.layPhieuGiao(macn);
        }

        private void dataGV_PhieuNhap_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            if (e.RowIndex == -1) return;
            string a = dataGV_PhieuNhap.Rows[index].Cells[0].Value.ToString();
            dataGV_CTPhieuNhap.DataSource = nhapKho.layCTPN(a);
        }

        private void dataGV_PhieuXuat_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            if (e.RowIndex == -1) return;
            string a = dataGV_PhieuXuat.Rows[index].Cells[0].Value.ToString();
            dataGV_CTHangHoaXuat.DataSource = xuatHang.layChiTietPhieuXuatHang(a);
        }

        private void dataGV_PhieuThanhLy_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            if (e.RowIndex == -1) return;
            string a = dataGV_PhieuThanhLy.Rows[index].Cells[0].Value.ToString();
            dataGV_CTHangHoaThanhLy.DataSource = thanhLy.layChiTietPhieuThanhLy(a);
        }

        private void dataGV_PhieuGiaoHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            if (e.RowIndex == -1) return;
            string a = dataGV_PhieuGiaoHang.Rows[index].Cells[0].Value.ToString();
            dataGV_CTGiaoHang.DataSource = giaoHang.layChiTietPhieuGiaoHang(a);
        }
    }
}
