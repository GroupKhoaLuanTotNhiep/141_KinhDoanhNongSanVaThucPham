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
using DBConnect;

namespace _141_KinhDoanhNongSanVaThucPham
{
    public partial class frmQuyDoiDonViTinh : Form
    {
        Connection conn = new Connection();
        SanPham sanPham = new SanPham();
        LoHang loHang = new LoHang();

        public frmQuyDoiDonViTinh()
        {
            InitializeComponent();
            loadComboBoxSanPham();
        }

        void loadComboBoxSanPham()
        {
            cbbSanPhamDuocQD.DataSource = sanPham.loadSanPham();
            cbbSanPhamDuocQD.DisplayMember = "MaSP";
            cbbSanPhamDuocQD.ValueMember = "MaSP";
        }

        void loadComboBoxLoHang()
        {
            cbbLoHangCu.DataSource = loHang.loadLoHangChuaHetHanTheoSanPham(cbbSanPhamDuocQD.Text.Trim());
            cbbLoHangCu.DisplayMember = "MaLo";
            cbbLoHangCu.ValueMember = "MaLo";
        }

        private void cbbSanPhamDuocQD_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (conn.checkExist("LoHang", "MaSP", cbbSanPhamDuocQD.Text))
            {
                loadComboBoxLoHang();
                if (cbbLoHangCu.Items.Count == 0)
                    cbbLoHangCu.Text = "";
            }
            else
            {
                cbbLoHangCu.DataSource = loHang.loadLoHangChuaHetHanTheoSanPham(cbbSanPhamDuocQD.Text.Trim());
                cbbLoHangCu.Text = txtTenLoMoi.Text = "";
            }

            txtDVTDuocQD.Text = sanPham.layDonViTinhTheoSanPham(cbbSanPhamDuocQD.Text.Trim());
            txtGiaBan.Text = sanPham.layGiaBan(cbbSanPhamDuocQD.Text.Trim());
        }

        private void frmQuyDoiDonViTinh_Load(object sender, EventArgs e)
        {
            chkLuuLoCu.Checked = true;
            txtDVTCanQD.Enabled = txtDVTDuocQD.Enabled = txtMaLoSPDoi.Enabled = txtMaPNH.Enabled = txtGiaBan.Enabled = false;
            txtMaSPCanQD.Text = UC_DanhMucHangHoa.masp;
            txtDVTCanQD.Text = UC_DanhMucHangHoa.donvitinh;
            txtMaLoSPDoi.Text = UC_DanhMucHangHoa.malo;
            loadComboBoxSanPham();
            //loadComboBoxLoHang();
            txtMaPNH.Text = UC_DanhMucHangHoa.pnh;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                string strMaSPCanDoi = txtMaSPCanQD.Text.Trim();
                string strSLSPCanDoi = txtSoLuongDoi.Text.Trim();
                string strMaLoSPCanDoi = txtMaLoSPDoi.Text.Trim();
                string strMaLoMoi = (chkLuuLoCu.Checked) ? cbbLoHangCu.Text.Trim() : (txtMaLoMoi.Text.Trim() + strMaSPCanDoi);
                string strTenLoMoi = txtTenLoMoi.Text.Trim();
                string strMaSPDuocDoi = cbbSanPhamDuocQD.Text.Trim();
                string strSLQuyDoi1DV = txtSLQuyDoi.Text.Trim();
                DateTime ngaySanXuat = UC_DanhMucHangHoa.ngaysx;
                DateTime hanSuDung = UC_DanhMucHangHoa.hsd;
                int strMaPNH = int.Parse(txtMaPNH.Text.Trim());
                float soLuongDuocDoi = float.Parse(strSLSPCanDoi) * float.Parse(strSLQuyDoi1DV);

                if(float.Parse(strSLSPCanDoi) > float.Parse(sanPham.laySoLuongSPTheoSanPham(strMaSPCanDoi)))
                {
                    MessageBox.Show("Số lượng sản phẩm đổi phải nhỏ hơn hoặc bằng số lượng sản phẩm đang có!");
                    txtSoLuongDoi.Focus();
                    return;
                }
                if (float.Parse(strSLSPCanDoi) > float.Parse(loHang.laySoLuong(strMaLoSPCanDoi)))
                {
                    MessageBox.Show("Số lượng sản phẩm đổi phải nhỏ hơn hoặc bằng số lượng sản phẩm đang có trong lô!");
                    txtSoLuongDoi.Focus();
                    return;
                }

                string strSqlCanDoi = "UPDATE SanPham SET SoLuongSP=" + (float.Parse(sanPham.laySoLuongSPTheoSanPham(strMaSPCanDoi)) - float.Parse(strSLSPCanDoi)) + " WHERE MaSP='" + strMaSPCanDoi + "'";
                conn.updateToDatabase(strSqlCanDoi);
                string strSqlUDLo = "UPDATE LoHang SET SoLuong=" + (float.Parse(loHang.laySoLuong(strMaLoSPCanDoi)) - float.Parse(strSLSPCanDoi)) + " WHERE MaLo='" + strMaLoSPCanDoi + "'";
                conn.updateToDatabase(strSqlUDLo);

                string strSqlDuocDoi = "UPDATE SanPham SET SoLuongSP=" + (float.Parse(sanPham.laySoLuongSPTheoSanPham(strMaSPDuocDoi)) + soLuongDuocDoi) + " WHERE MaSP='" + strMaSPDuocDoi + "'";
                conn.updateToDatabase(strSqlDuocDoi);
                if (conn.checkExistTwoKey("LoHang", "MaLo", "MaPNH", strMaLoMoi, strMaPNH.ToString()))
                {
                    string strSqlUDLoMoi = "UPDATE LoHang SET SoLuong=" + (float.Parse(loHang.laySoLuong(strMaLoMoi)) + soLuongDuocDoi) + " WHERE MaLo='" + strMaLoMoi + "'";
                    conn.updateToDatabase(strSqlUDLoMoi);
                    MessageBox.Show("Cập nhật thành công!");
                }
                else
                {
                    if (loHang.addLoHang(strMaLoMoi, strTenLoMoi, ngaySanXuat, hanSuDung, soLuongDuocDoi, strMaPNH, strMaSPDuocDoi, int.Parse(sanPham.layMaGiaBanTheoTenGia(int.Parse(txtGiaBan.Text)))))
                    {
                        MessageBox.Show("Thêm thành công!");
                    }
                }
                if (!conn.checkExistTwoKey("Gia_SanPham", "MaSP", "MaGia", strMaSPDuocDoi, sanPham.layMaGiaBanTheoTenGia(int.Parse(txtGiaBan.Text))))
                {
                    string strSqlGSP = "Insert Gia_SanPham Values('" + strMaSPDuocDoi + "', " + sanPham.layMaGiaBanTheoTenGia(int.Parse(txtGiaBan.Text)) + ", '" + DateTime.Now.ToString() + "', NULL)";
                    conn.updateToDatabase(strSqlGSP);
                    MessageBox.Show("Đã thêm thông tin giá sản phẩm");
                }
                MessageBox.Show("Lưu thành công!");
                this.Close();
            }
            catch
            {
                MessageBox.Show("Lưu thất bại!");
            }
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void chkLuuLoCu_CheckedChanged(object sender, EventArgs e)
        {
            if (chkLuuLoCu.Checked)
            {
                cbbLoHangCu.Visible = true;
                txtMaLoMoi.Visible = false;
                txtTenLoMoi.Enabled = false;
            }
            else
            {
                cbbLoHangCu.Visible = false;
                txtMaLoMoi.Visible = true;
                txtTenLoMoi.Enabled = true;
            }
            txtTenLoMoi.Text = "";
        }

        private void cbbLoHangCu_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtTenLoMoi.Text = loHang.layTenLoHang(cbbLoHangCu.Text);
        }

    }
}
