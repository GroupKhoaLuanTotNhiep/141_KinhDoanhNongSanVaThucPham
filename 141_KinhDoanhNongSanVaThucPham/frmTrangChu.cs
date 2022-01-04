using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using DBConnect;
using NongSanThucPham;

namespace _141_KinhDoanhNongSanVaThucPham
{
    public partial class frmTrangChu : Form
    {
        //private int manv;
        SqlConnection cn = new SqlConnection();
        Connection conn = new Connection();
        NhomQuyen quyen = new NhomQuyen();
        //List<string> list_detail;
        List<string> dsHoatDong = null;
        string maQ = frmDangNhap.maQ;
        string maNV = frmDangNhap.maNV;
        string tenNV = frmDangNhap.tenNV;
        //public int Manv
        //{
        //    get { return manv; }
        //    set { manv = value; }
        //}

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
        private List<string> ds_HoatDong()
        {
            if (string.IsNullOrEmpty(maQ)) return null;
            List<string> termsList = new List<string>();
            try
            {
                conn.openConnect();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Quyen_NhanVien WHERE MaNV='" + maNV + "' AND MaQuyen = '" + maQ + "'", conn.conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt != null)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        termsList.Add(dr["MaQuyen"].ToString());
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Lỗi kết nối!!!");
            }
            finally
            {
                conn.closeConnect();
            }
            return termsList;
        }
        private Boolean checkper(string code)
        {
            Boolean check = false;
            foreach (string item in dsHoatDong)
            {
                if (item == code)
                {
                    check = true;
                    break;
                }
                else
                    check = false;
            }
            return check;
        }

        private void loạiSảnPhẩmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (checkper("Admin") || checkper("User") || checkper("User_Kho"))
            {
                //MessageBox.Show("có quyền");
                UC_DanhMucLoaiSanPham loaiSP = new UC_DanhMucLoaiSanPham();
                showUserControl(loaiSP);
            }
            else
            {
                MessageBox.Show("Bạn không có quyền");
            }
        }

        private void sảnPhẩmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (checkper("Admin") || checkper("User") || checkper("User_Kho"))
            {
                //MessageBox.Show("có quyền");
                UC_DanhMucHangHoa hangHoa = new UC_DanhMucHangHoa();
                showUserControl(hangHoa);
            }
            else
            {
                MessageBox.Show("Bạn không có quyền");
            }
        }

        private void đơnVịTínhToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (checkper("Admin") || checkper("User") || checkper("User_Kho"))
            {
                //MessageBox.Show("có quyền");
                UC_DanhMucDonViTinh dvt = new UC_DanhMucDonViTinh();
                showUserControl(dvt);
            }
            else
            {
                MessageBox.Show("Bạn không có quyền");
            }
        }

        private void lôSảnPhẩmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (checkper("Admin") || checkper("User") || checkper("User_Kho"))
            {
                //MessageBox.Show("có quyền");
                UC_DanhMucLoHang loSP = new UC_DanhMucLoHang();
                showUserControl(loSP);
            }
            else
            {
                MessageBox.Show("Bạn không có quyền");
            }
        }

        private void nhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (checkper("Admin"))
            {
                //MessageBox.Show("có quyền");
                UC_QuanLyNhanVien nhanVien = new UC_QuanLyNhanVien();
                showUserControl(nhanVien);
            }
            else
            {
                MessageBox.Show("Bạn không có quyền");
            }
        }

        private void chứcVụToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (checkper("Admin"))
            {
                //MessageBox.Show("có quyền");
                UC_DanhMucChucVu chucVu = new UC_DanhMucChucVu();
                showUserControl(chucVu);
            }
            else
            {
                MessageBox.Show("Bạn không có quyền");
            }
        }

        private void quyềnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (checkper("Admin"))
            {
                //MessageBox.Show("có quyền");
                UC_DanhMucQuyenNV quyenNV = new UC_DanhMucQuyenNV();
                showUserControl(quyenNV);
            }
            else
            {
                MessageBox.Show("Bạn không có quyền");
            }
        }

        private void nhàCungCấpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (checkper("Admin") || checkper("User") || checkper("User_Kho"))
            {
                //MessageBox.Show("có quyền");
                UC_DanhMucNCC ncc = new UC_DanhMucNCC();
                showUserControl(ncc);
            }
            else
            {
                MessageBox.Show("Bạn không có quyền");
            }
        }

        private void chiNhánhToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (checkper("Admin") || checkper("User"))
            {
                //MessageBox.Show("có quyền");
                UC_DanhMucChiNhanh chiNhanh = new UC_DanhMucChiNhanh();
                showUserControl(chiNhanh);
            }
            else
            {
                MessageBox.Show("Bạn không có quyền");
            }
        }

        private void quầyHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (checkper("Admin") || checkper("User") || checkper("User_Kho"))
            {
                //MessageBox.Show("có quyền");
                UC_DanhMucQuayHang quayHang = new UC_DanhMucQuayHang();
                showUserControl(quayHang);
            }
            else
            {
                MessageBox.Show("Bạn không có quyền");
            }
        }

        private void hìnhThứcThanhToánToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (checkper("Admin") || checkper("User"))
            {
                //MessageBox.Show("có quyền");
                UC_DanhMucHT_ThanhToan htThanhToan = new UC_DanhMucHT_ThanhToan();
                showUserControl(htThanhToan);
            }
            else
            {
                MessageBox.Show("Bạn không có quyền");
            }
        }

        private void khuyếnMãiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (checkper("Admin") || checkper("User"))
            {
                //MessageBox.Show("có quyền");
                UC_DanhMucKhuyenMai khuyenMai = new UC_DanhMucKhuyenMai();
                showUserControl(khuyenMai);
            }
            else
            {
                MessageBox.Show("Bạn không có quyền");
            }
        }

        private void kháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (checkper("Admin") || checkper("User") || checkper("User_Ship") || checkper("User_Cash") || checkper("User_Sale"))
            {
                //MessageBox.Show("có quyền");
                UC_DanhMucKhachHang khachHang = new UC_DanhMucKhachHang();
                showUserControl(khachHang);
            }
            else
            {
                MessageBox.Show("Bạn không có quyền");
            }
        }

        private void lậpPhiếuNhậpHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (checkper("Admin") || checkper("User") || checkper("User_Kho"))
            {
                //MessageBox.Show("có quyền");
                UC_NhapKho nhapKho = new UC_NhapKho();
                showUserControl(nhapKho);
            }
            else
            {
                MessageBox.Show("Bạn không có quyền");
            }
        }

        private void lậpPhiếuXuấtHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (checkper("Admin") || checkper("User") || checkper("User_Kho"))
            {
                //MessageBox.Show("có quyền");
                UC_XuatKho xuatKho = new UC_XuatKho();
                showUserControl(xuatKho);
            }
            else
            {
                MessageBox.Show("Bạn không có quyền");
            }
        }

        private void lậpHóaĐơnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (checkper("Admin") || checkper("User") || checkper("User_Sale") || checkper("User_Cash") && !checkper("User_Kho"))
            {
                //MessageBox.Show("có quyền");
                UC_BanHang banHang = new UC_BanHang();
                showUserControl(banHang);
            }
            else
            {
                MessageBox.Show("Bạn không có quyền");
            }
        }

        private void lậpPhiếuGiaoHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (checkper("Admin") || checkper("User") || checkper("User_Kho") || checkper("User_Sale") || checkper("User_Cash") || checkper("User_Ship"))
            {
                //MessageBox.Show("có quyền");
                UC_GiaoHang giaoHang = new UC_GiaoHang();
                showUserControl(giaoHang);
            }
            else
            {
                MessageBox.Show("Bạn không có quyền");
            }
        }

        private void lậpPhiếuThanhLýToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (checkper("Admin") || checkper("User") || checkper("User_Kho"))
            {
                //MessageBox.Show("có quyền");
                UC_ThanhLy thanhLy = new UC_ThanhLy();
                showUserControl(thanhLy);
            }
            else
            {
                MessageBox.Show("Bạn không có quyền");
            }
        }

        private void doanhThuBánHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (checkper("Admin") || checkper("User") || checkper("User_Sale") || checkper("User_Cash"))
            {
                //MessageBox.Show("có quyền");
                UC_ThongKeDoanhThu doanhThu = new UC_ThongKeDoanhThu();
                showUserControl(doanhThu);
            }
            else
            {
                MessageBox.Show("Bạn không có quyền");
            }
        }

        private void lịchSửGiáToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (checkper("Admin") || checkper("User") || checkper("User_Kho"))
            {
                //MessageBox.Show("có quyền");
                UC_LichSuGia gia = new UC_LichSuGia();
                showUserControl(gia);
            }
            else
            {
                MessageBox.Show("Bạn không có quyền");
            }
        }

        private void thôngTinNgườiDùngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (checkper("Admin") || checkper("User") || checkper("User_Kho") || checkper("User_Sale") || checkper("User_Cash") || checkper("User_Ship"))
            {
                //MessageBox.Show("có quyền");
                UC_ThongTinNguoiDung tt = new UC_ThongTinNguoiDung();
                showUserControl(tt);
            }
            else
            {
                MessageBox.Show("Bạn không có quyền");
            }
        }

        private void frmTrangChu_Load(object sender, EventArgs e)
        {
            dsHoatDong = ds_HoatDong();
            lblTenNguoiDung.Text = "Xin chào " + frmDangNhap.tenNV;
        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult rs = MessageBox.Show("Bạn có muốn thoát chương trình này không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (rs == DialogResult.Yes)
                this.Close();
        }

        private void TKSanPham_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (checkper("Admin") || checkper("User") || checkper("User_Kho"))
            {
                UC_ThongKeSanPham sp = new UC_ThongKeSanPham();
                showUserControl(sp);
            }
            else
            {
                MessageBox.Show("Bạn không có quyền");
            }
        }

        private void Top10_SPBanChayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (checkper("Admin") || checkper("User") || checkper("User_Sale") || checkper("User_Cash"))
            {
                UC_ThongKeTop10SPBanChay banchay = new UC_ThongKeTop10SPBanChay();
                showUserControl(banchay);
            }
            else
            {
                MessageBox.Show("Bạn không có quyền");
            }
        }

        private void Top10_SPBanChamToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (checkper("Admin") || checkper("User") || checkper("User_Sale") || checkper("User_Cash"))
            {
                UC_ThongKeTop10SPBanCham bancham = new UC_ThongKeTop10SPBanCham();
                showUserControl(bancham);
            }
            else
            {
                MessageBox.Show("Bạn không có quyền");
            }
        }

        private void KHTiemNangToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (checkper("Admin") || checkper("User") || checkper("User_Sale") || checkper("User_Cash"))
            {
                UC_ThongKeKHTiemNang kh = new UC_ThongKeKHTiemNang();
                showUserControl(kh);
            }
            else
            {
                MessageBox.Show("Bạn không có quyền");
            }
        }

        private void PhieuTLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (checkper("Admin") || checkper("User") || checkper("User_Kho"))
            {
                UC_ThongKeThanhLy tl = new UC_ThongKeThanhLy();
                showUserControl(tl);
            }
            else
            {
                MessageBox.Show("Bạn không có quyền");
            }
        }
    }
}
