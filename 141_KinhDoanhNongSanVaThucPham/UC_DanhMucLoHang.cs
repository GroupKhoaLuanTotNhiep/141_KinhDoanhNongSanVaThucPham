using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using DBConnect;
using NongSanThucPham;

namespace _141_KinhDoanhNongSanVaThucPham
{
    public partial class UC_DanhMucLoHang : UserControl
    {
        Connection conn = new Connection();
        LoHang loHang = new LoHang();
        NhapKho nhapKho = new NhapKho();
        SanPham sanPham = new SanPham();
        frmThemLoHang frm = new frmThemLoHang();
        int index = -1;

        public UC_DanhMucLoHang()
        {
            InitializeComponent();
        }

        void loadComboBoxPhieuNhapHang()
        {
            cbbPhieuNhap.DataSource = nhapKho.loadPhieuNhapHang();
            cbbPhieuNhap.DisplayMember = "MaPNH";
            cbbPhieuNhap.ValueMember = "MaPNH";
        }
        
        void loadCBBPhieuNhapHangTrongGridView()
        {
            MaPNH.DataSource = nhapKho.loadPhieuNhapHang();
            MaPNH.DisplayMember = "MaPNH";
            MaPNH.ValueMember = "MaPNH";
        }

        void loadCBBSanPhamTrongGridView()
        {
            MaSP.DataSource = sanPham.loadSanPham();
            MaSP.DisplayMember = "TenSP";
            MaSP.ValueMember = "MaSP";
        }

        void loadCBBGiaBanTrongGridView()
        {
            MaGia.DataSource = sanPham.loadGiaBan();
            MaGia.DisplayMember = "GiaSP";
            MaGia.ValueMember = "MaGia";
        }

        void createTable_LoHang()
        {
            dataGV_LoHang.DataSource = loHang.loadDataGV_LoHang();
        }

        private void UC_DanhMucLoHang_Load(object sender, EventArgs e)
        {
            loadComboBoxPhieuNhapHang();
            loadCBBPhieuNhapHangTrongGridView();
            loadCBBSanPhamTrongGridView();
            loadCBBGiaBanTrongGridView();
            createTable_LoHang(); 
        }

        private void btnTKLoHang_Click(object sender, EventArgs e)
        {
            if (conn.checkExist("LoHang", "MaLo", txtTKLoHang.Text.Trim()))
            {
                dataGV_LoHang.DataSource = loHang.searchLoHangTheoMaLo(txtTKLoHang.Text.Trim());
            }
            else
            {
                MessageBox.Show("Không tìm thấy lô hàng này!");
                createTable_LoHang();
            }
        }

        private void dataGV_LoHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                index = e.RowIndex;
                btnSuaLo.Enabled = btnXoaLo.Enabled = true;
            }
        }

        public bool kiemTraNgaySXVaNgayHSD()
        {
            string strNgaySanXuat = dataGV_LoHang.Rows[index].Cells[2].Value.ToString();
            string strHanSuDung = dataGV_LoHang.Rows[index].Cells[3].Value.ToString();
            int ngay = DateTime.Parse(strHanSuDung).Day - DateTime.Parse(strNgaySanXuat).Day;
            int thang = DateTime.Parse(strHanSuDung).Month - DateTime.Parse(strNgaySanXuat).Month;
            int nam = DateTime.Parse(strHanSuDung).Year - DateTime.Parse(strNgaySanXuat).Year;
            if (nam < 0 || (thang < 0 && nam == 0) || ((ngay < 0 || ngay == 0) && thang == 0 && nam == 0))
                return false;
            return true;
        }

        private void btnXoaLo_Click(object sender, EventArgs e)
        {
            try
            {
                string malo = dataGV_LoHang.Rows[index].Cells[0].Value.ToString();
                if (!conn.checkExist("LoHang", "MaLo", malo))
                {
                    MessageBox.Show("Mã lô " + malo + " này chưa tồn tại!");
                    return;
                }
                if(conn.checkExist("ChiTietPhieuXuatHang", "MaLo", malo))
                {
                    MessageBox.Show("Lô này đang được sử dụng trong bảng chi tiết phiếu xuất hàng");
                    return;
                }
                if (conn.checkExist("ChiTietPhieuThanhLy", "MaLo", malo))
                {
                    MessageBox.Show("Lô này đang được sử dụng trong bảng chi tiết phiếu thanh lý");
                    return;
                }
                if (string.IsNullOrEmpty(malo))
                {
                    MessageBox.Show("Xóa thất bại");
                }
                else
                {
                    if (MessageBox.Show("Bạn có thật sự muốn xóa lô hàng này không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.No)
                        return;
                    loHang.deleteLoHang(malo);
                    index = -1;
                    MessageBox.Show("Xóa thành công");
                    createTable_LoHang();
                    btnSuaLo.Enabled = btnXoaLo.Enabled = false;
                }
            }
            catch
            {
                MessageBox.Show("Xóa thất bại");
            }
        }

        private void btnSuaLo_Click(object sender, EventArgs e)
        {
            try
            {
                string malo = dataGV_LoHang.Rows[index].Cells[0].Value.ToString();
                string tenlo = dataGV_LoHang.Rows[index].Cells[1].Value.ToString();
                DateTime nsx = DateTime.Parse( dataGV_LoHang.Rows[index].Cells[2].Value.ToString());
                DateTime hsd= DateTime.Parse(dataGV_LoHang.Rows[index].Cells[3].Value.ToString());
                int sl = int.Parse( dataGV_LoHang.Rows[index].Cells[4].Value.ToString());
                int mapnh = int.Parse(dataGV_LoHang.Rows[index].Cells[5].Value.ToString());
                string masp = dataGV_LoHang.Rows[index].Cells[6].Value.ToString();
                int magia = int.Parse(dataGV_LoHang.Rows[index].Cells[7].Value.ToString());

                if (string.IsNullOrEmpty(malo))
                {
                    MessageBox.Show("Sửa thất bại");
                }
                else
                {
                    if (!conn.checkExist("LoHang", "MaLo", malo))
                    {
                        MessageBox.Show("Mã lô " + malo + " này chưa tồn tại!");
                        return;
                    }
                    if (kiemTraNgaySXVaNgayHSD() == false)
                    {
                        MessageBox.Show("Ngày sản xuất phải nhỏ hơn Hạn sử dụng!");
                        return;
                    }
                    if (loHang.updateLoHang(malo, tenlo, nsx, hsd, mapnh, masp, magia))
                    {
                        index = -1;
                        MessageBox.Show("Sửa thành công");
                        createTable_LoHang();
                        btnSuaLo.Enabled = btnXoaLo.Enabled = false;
                    }
                    else
                    {
                        MessageBox.Show("Sửa thất bại");
                    }
                }
            }
            catch
            {
                MessageBox.Show("Sửa thất bại");
            }
        }

        private void cbbPhieuNhap_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cbbPhieuNhap.Items.Count > 0)
                dataGV_LoHang.DataSource = loHang.searchLoHangTheoMaPNH(cbbPhieuNhap.Text.Trim());
            else
                createTable_LoHang();
        }
    }
}
