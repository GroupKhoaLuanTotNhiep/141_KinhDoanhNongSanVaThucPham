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
    public partial class frmTrangChu : Form
    {
        public frmTrangChu()
        {
            InitializeComponent();
            UC_Background hinhNen = new UC_Background();
            showUserControl(hinhNen);
        }

        private void showUserControl(UserControl user)
        {
            panelCenter.Controls.Add(user);
            user.Dock = DockStyle.Fill;
            user.BringToFront();
        }

        private void loạiSảnPhẩmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UC_DanhMucLoaiSanPham loaiSP = new UC_DanhMucLoaiSanPham();
            showUserControl(loaiSP);
        }

        private void sảnPhẩmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UC_DanhMucHangHoa hangHoa = new UC_DanhMucHangHoa();
            showUserControl(hangHoa);
        }

        private void đơnVịTínhToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UC_DanhMucDonViTinh dvt = new UC_DanhMucDonViTinh();
            showUserControl(dvt);
        }

        private void lôSảnPhẩmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UC_DanhMucLoHang loSP = new UC_DanhMucLoHang();
            showUserControl(loSP);
        }

        private void nhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UC_QuanLyNhanVien nhanVien = new UC_QuanLyNhanVien();
            showUserControl(nhanVien);
        }

        private void chứcVụToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UC_DanhMucChucVu chucVu = new UC_DanhMucChucVu();
            showUserControl(chucVu);
        }

        private void quyềnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UC_DanhMucQuyenNV quyenNV = new UC_DanhMucQuyenNV();
            showUserControl(quyenNV);
        }

        private void nhàCungCấpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UC_DanhMucNCC ncc = new UC_DanhMucNCC();
            showUserControl(ncc);
        }

        private void chiNhánhToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UC_DanhMucChiNhanh chiNhanh = new UC_DanhMucChiNhanh();
            showUserControl(chiNhanh);
        }

        private void quầyHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UC_DanhMucQuayHang quayHang = new UC_DanhMucQuayHang();
            showUserControl(quayHang);
        }

        private void hìnhThứcThanhToánToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UC_DanhMucHT_ThanhToan htThanhToan = new UC_DanhMucHT_ThanhToan();
            showUserControl(htThanhToan);
        }

        private void khuyếnMãiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UC_DanhMucKhuyenMai khuyenMai = new UC_DanhMucKhuyenMai();
            showUserControl(khuyenMai);
        }

        private void kháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UC_DanhMucKhachHang khachHang = new UC_DanhMucKhachHang();
            showUserControl(khachHang);
        }

        private void lậpPhiếuNhậpHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UC_NhapKho nhapKho = new UC_NhapKho();
            showUserControl(nhapKho);
        }

        private void lậpPhiếuXuấtHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UC_XuatKho xuatKho = new UC_XuatKho();
            showUserControl(xuatKho);
        }

        private void lậpHóaĐơnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UC_BanHang banHang = new UC_BanHang();
            showUserControl(banHang);
        }

        private void lậpPhiếuGiaoHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UC_GiaoHang giaoHang = new UC_GiaoHang();
            showUserControl(giaoHang);
        }

        private void lậpPhiếuThanhLýToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UC_ThanhLy thanhLy = new UC_ThanhLy();
            showUserControl(thanhLy);
        }

        private void doanhThuBánHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UC_ThongKeDoanhThu doanhThu = new UC_ThongKeDoanhThu();
            showUserControl(doanhThu);
        }

        private void lịchSửGiáToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UC_LichSuGia gia = new UC_LichSuGia();
            showUserControl(gia);
        }
    }
}
