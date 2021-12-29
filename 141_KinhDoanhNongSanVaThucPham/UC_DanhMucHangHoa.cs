using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using NongSanThucPham;
using DBConnect;

namespace _141_KinhDoanhNongSanVaThucPham
{

    public partial class UC_DanhMucHangHoa : UserControl
    {
        Connection conn = new Connection();
        frmThemHangHoa frm = new frmThemHangHoa();
        SanPham sp = new SanPham();
        DonViTinh dvt = new DonViTinh();
        LoaiSP loai = new LoaiSP();
        QuayHang qh = new QuayHang();
        LoHang lohang = new LoHang();
        string paths = Application.StartupPath.Substring(0, Application.StartupPath.Length - 10);
        int index = -1;
        public static string masp = "";
        public static string donvitinh = "";
        public static string malo = "";
        public static DateTime ngaysx;
        public static DateTime hsd;
        public static string pnh = "";
        public static string magia = "";

        public UC_DanhMucHangHoa()
        {
            InitializeComponent();
        }
        void loadGVSanPham() 
        {
            dataGV_HangHoa.DataSource = sp.loadDataGV_SanPham(); 
        }
        void loadCBBDVTTrongGridView()
        {
            MaDVT.DataSource = dvt.loadDonViTinh();
            MaDVT.DisplayMember = "TenDVT";
            MaDVT.ValueMember = "MaDVT";
        }
        void loadCBBLoaiSPTrongGridView()
        {
            MaLoaiSP.DataSource = loai.loadLoaiSanPham();
            MaLoaiSP.DisplayMember = "TenLoaiSP";
            MaLoaiSP.ValueMember = "MaLoaiSP";
        }
        void loadCBBQuayHangTrongGridView()
        {
            MaQuay.DataSource = qh.loadQuayHang();
            MaQuay.DisplayMember = "TenQuay";
            MaQuay.ValueMember = "MaQuay";
        }
        void loadComboBoxNhomHang()
        {
            cbbNhomHang.DataSource = loai.loadLoaiSanPham();
            cbbNhomHang.DisplayMember = "TenLoaiSP";
            cbbNhomHang.ValueMember = "MaLoaiSP";
        }
        void loadComboBoxQuayHang()
        {
            cbbQuayHang.DataSource = qh.loadQuayHang();
            cbbQuayHang.DisplayMember = "TenQuay";
            cbbQuayHang.ValueMember = "MaQuay";
        }
        private void btnThemHang_Click(object sender, EventArgs e)
        {
            if (frm.IsDisposed)
            {
                frm = new frmThemHangHoa();
            }
            frm.Show();
            frm.BringToFront();
            frm.Activate();
        }

        private void UC_DanhMucHangHoa_Load(object sender, EventArgs e)
        {
            loadComboBoxNhomHang();
            loadComboBoxQuayHang();
            loadCBBDVTTrongGridView();
            loadCBBLoaiSPTrongGridView();
            loadCBBQuayHangTrongGridView();
            loadGVSanPham();
        }

        private void dataGV_HangHoa_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex != -1)          
                index = e.RowIndex;
            masp = dataGV_HangHoa.Rows[index].Cells["MaSP"].Value.ToString().Trim();
            donvitinh = dvt.layTenDonViTinh(dataGV_HangHoa.Rows[index].Cells["MaDVT"].Value.ToString().Trim());
            string a = dataGV_HangHoa.Rows[index].Cells[0].Value.ToString();
            dataGV_LoHang.DataSource = sp.layLoHangTheoSanPham(a);
        }

        private void btnXoaHang_Click(object sender, EventArgs e)
        {
            try
            {
                string masp = dataGV_HangHoa.Rows[index].Cells["MaSP"].Value.ToString();
                if (!conn.checkExist("SanPham", "MaSP", masp))
                {
                    MessageBox.Show("Mã sản phẩm " + masp + " chưa tồn tại");
                    return;
                }
                if (string.IsNullOrEmpty(masp))
                {
                    MessageBox.Show("Bạn phải chọn sản phẩm cần xóa");
                    return;
                }
                else
                {
                    if (MessageBox.Show("Bạn có thật sự muốn xóa sản phẩm này không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.No)
                        return;
                    if (sp.deleteSP(masp))
                    {
                        index = -1;
                        MessageBox.Show("Xóa thành công");
                        loadGVSanPham();
                    }
                    else
                        MessageBox.Show("Xóa thất bại");
                }

            }
            catch
            {
                MessageBox.Show("Xóa thất bại");
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            loadCBBDVTTrongGridView();
            loadCBBLoaiSPTrongGridView();
            loadCBBQuayHangTrongGridView();
            loadGVSanPham();
            txtTimKiem.Clear();
            cbbNhomHang.SelectedIndex = 0;
            cbbQuayHang.SelectedIndex = 0;
        }

        private void btnSuaHang_Click(object sender, EventArgs e)
        {
            try
            {
                string masp = dataGV_HangHoa.Rows[index].Cells["MaSP"].Value.ToString().Trim();
                string tensp = dataGV_HangHoa.Rows[index].Cells["TenSP"].Value.ToString().Trim();
                string hinhanh = dataGV_HangHoa.Rows[index].Cells["HinhAnh"].Value.ToString().Trim();
                int giavon = int.Parse(dataGV_HangHoa.Rows[index].Cells["GiaVon"].Value.ToString().Trim());
                int giaban = int.Parse(dataGV_HangHoa.Rows[index].Cells["GiaBan"].Value.ToString().Trim());
                float giamgia = float.Parse(dataGV_HangHoa.Rows[index].Cells["GiamGia"].Value.ToString().Trim());
                float soluong = float.Parse(dataGV_HangHoa.Rows[index].Cells["SoLuongSP"].Value.ToString().Trim());
                string xuatxu = dataGV_HangHoa.Rows[index].Cells["XuatXu"].Value.ToString().Trim();
                string mota = dataGV_HangHoa.Rows[index].Cells["MoTa"].Value.ToString().Trim();
                int maloaisp = int.Parse(dataGV_HangHoa.Rows[index].Cells["MaLoaiSP"].Value.ToString().Trim());
                int madvt = int.Parse(dataGV_HangHoa.Rows[index].Cells["MaDVT"].Value.ToString().Trim());
                string maquay = dataGV_HangHoa.Rows[index].Cells["MaQuay"].Value.ToString().Trim();
                int gia = int.Parse(sp.layGiaBan(masp));
                float giam = float.Parse(sp.layGiamGia(masp));

                if (!conn.checkExist("SanPham", "MaSP", masp))
                {
                    MessageBox.Show("Mã sản phẩm " + masp + " chưa tồn tại");
                    return;
                }
                if(gia != giaban)
                {
                    if (conn.checkExist("Gia_SanPham", "MaSP", masp))
                    {
                        string sqlngay = "UPDATE Gia_SanPham SET NgayKetThuc ='" + DateTime.Now.ToString() + "' WHERE MaSP='" + masp + "' AND MaGia='" + sp.layMaGiaBanTheoTenGia(gia) + "'";
                        conn.updateToDatabase(sqlngay);
                    }
                    if(conn.checkExistTwoKey("Gia_SanPham", "MaSP", "MaGia", masp, sp.layMaGiaBanTheoTenGia(giaban)))
                    {
                        string sqlngaykt = "UPDATE Gia_SanPham SET NgayKetThuc = NULL WHERE MaSP='" + masp + "' AND MaGia='" + sp.layMaGiaBanTheoTenGia(giaban) + "'";
                        conn.updateToDatabase(sqlngaykt);
                    }
                }
                if (giam != giamgia)
                {
                    if (conn.checkExist("GiamGia_SanPham", "MaSP", masp))
                    {
                        string sqln = "UPDATE GiamGia_SanPham SET NgayKT ='" + DateTime.Now.ToString() + "' WHERE MaSP='" + masp + "' AND MaGiam='" + sp.layMaGiamGiaTheoPhanTramGiam(giam) + "'";
                        conn.updateToDatabase(sqln);
                    }
                    if(conn.checkExistTwoKey("GiamGia_SanPham", "MaSP", "MaGiam", masp, sp.layMaGiamGiaTheoPhanTramGiam(giamgia)))
                    {
                        string sqlnkt = "UPDATE GiamGia_SanPham SET NgayKT = NULL WHERE MaSP='" + masp + "' AND MaGiam='" + sp.layMaGiamGiaTheoPhanTramGiam(giamgia) + "'";
                        conn.updateToDatabase(sqlnkt);
                    }
                }
                if (sp.updateSP(masp, tensp, hinhanh, giavon, giaban, giamgia, soluong, xuatxu, mota, maloaisp, madvt, maquay))
                {
                    MessageBox.Show("Sửa hàng hóa thành công");
                    //Thêm thông tin bảng Bảng giá và Giá sản phẩm
                    if (!conn.checkExist("BangGia", "GiaSP", giaban.ToString()))
                    {
                        string strSqlBG = "Insert BangGia Values(" + giaban + ")";
                        conn.updateToDatabase(strSqlBG);
                        MessageBox.Show("Đã thêm thông tin giá bán");
                        string strSqlGSP = "Insert Gia_SanPham Values('" + masp + "', " + sp.layMaGiaBanTheoTenGia(giaban).ToString() + ", '" + DateTime.Now.ToString() + "', NULL)";
                        conn.updateToDatabase(strSqlGSP);
                        MessageBox.Show("Đã thêm thông tin giá sản phẩm");
                    }
                    else
                    {
                        MessageBox.Show("Đã tồn tại giá này trong bảng giá");
                    }
                    if(!conn.checkExistTwoKey("Gia_SanPham", "MaSP", "MaGia", masp, sp.layMaGiaBanTheoTenGia(giaban)))
                    {
                        string strSqlGSP = "Insert Gia_SanPham Values('" + masp + "', " + sp.layMaGiaBanTheoTenGia(giaban) + ", '" + DateTime.Now.ToString() + "', NULL)";
                        conn.updateToDatabase(strSqlGSP);
                        MessageBox.Show("Đã thêm thông tin giá sản phẩm");
                    }
                    //Thêm thông tin bảng Giảm giá và Giảm giá sản phẩm
                    if (!conn.checkExist("GiamGia", "PhanTramGiam", giamgia.ToString()))
                    {
                        string strSqlGG = "Insert GiamGia Values(" + giamgia + ")";
                        conn.updateToDatabase(strSqlGG);
                        MessageBox.Show("Đã thêm thông tin giảm giá");
                        string strSqlGGSP = "Insert GiamGia_SanPham Values('" + masp + "', " + sp.layMaGiamGiaTheoPhanTramGiam(giamgia).ToString() + ", '" + DateTime.Now.ToString() + "', NULL )";
                        conn.updateToDatabase(strSqlGGSP);
                        MessageBox.Show("Đã thêm thông tin giảm giá sản phẩm");
                    }
                    else
                    {
                        MessageBox.Show("Đã tồn tại phần trăm giảm này trong bảng giảm giá");
                    }
                    if (!conn.checkExistTwoKey("GiamGia_SanPham", "MaSP", "MaGiam", masp, sp.layMaGiamGiaTheoPhanTramGiam(giamgia)))
                    {
                        string strSqlGG_SP = "Insert GiamGia_SanPham Values('" + masp + "', " + sp.layMaGiamGiaTheoPhanTramGiam(giamgia) + ", '" + DateTime.Now.ToString() + "', NULL)";
                        conn.updateToDatabase(strSqlGG_SP);
                        MessageBox.Show("Đã thêm thông tin giảm giá sản phẩm");
                    }

                    loadGVSanPham();

                    //Cập nhật giá cho lô hàng
                    try
                    {
                        //float sllo = float.Parse(dataGV_LoHang.Rows[index].Cells["SoLuong"].Value.ToString().Trim());
                        for(int i = 0; i < dataGV_LoHang.RowCount - 1; i++)
                        {
                            string maLo = dataGV_LoHang.Rows[i].Cells[0].Value.ToString().Trim();
                            //string malo = lohang.layLo(masp);
                            string sql = "UPDATE LoHang SET MaGia=" + sp.layMaGiaBanTheoTenGia(giaban) + " WHERE MaLo='" + maLo + "' AND DATEDIFF(day, GETDATE(), HanSuDung) >" + 30 + " AND SoLuong >" + 0;
                            conn.updateToDatabase(sql);
                        }
                    }
                    catch { }
                }
                else
                {
                    MessageBox.Show("Sửa hàng hóa thất bại");
                }
            }
            catch
            {
                MessageBox.Show("Sửa thất bại");
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string tukhoa = txtTimKiem.Text;
            dataGV_HangHoa.DataSource = sp.searchSanPham(tukhoa);
        }

        private void cbbNhomHang_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadCBBDVTTrongGridView();
            loadCBBLoaiSPTrongGridView();
            loadCBBQuayHangTrongGridView();
            dataGV_HangHoa.DataSource = sp.searchSanPhamTheoLoaiSP(cbbNhomHang.Text.Trim());
        }

        private void cbbQuayHang_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbQuayHang.SelectedIndex >= 0)
            {
                loadCBBDVTTrongGridView();
                loadCBBLoaiSPTrongGridView();
                loadCBBQuayHangTrongGridView();
                dataGV_HangHoa.DataSource = sp.searchSanPhamTheoQuayHang(cbbQuayHang.SelectedValue.ToString());
            }
            else
                loadGVSanPham();
        }

        private void btnNhap_Click(object sender, EventArgs e)
        {
            frmNhapKho nhap = new frmNhapKho();
            nhap.ShowDialog();
        }

        private void btnThanhLy_Click(object sender, EventArgs e)
        {
            frmThanhLy thanhLy = new frmThanhLy();
            thanhLy.ShowDialog();
        }

        private void btnQuyDoiDVT_Click(object sender, EventArgs e)
        {
            try
            {
                //masp = dataGV_HangHoa.Rows[index].Cells["MaSP"].Value.ToString().Trim();
                //donvitinh = dvt.layTenDonViTinh(dataGV_HangHoa.Rows[index].Cells["MaDVT"].Value.ToString().Trim());
                malo = dataGV_LoHang.Rows[index].Cells[0].Value.ToString().Trim();
                ngaysx = DateTime.Parse(dataGV_LoHang.Rows[index].Cells[2].Value.ToString().Trim());
                hsd = DateTime.Parse(dataGV_LoHang.Rows[index].Cells[3].Value.ToString().Trim());
                pnh = dataGV_LoHang.Rows[index].Cells[5].Value.ToString().Trim();
                //magia = sp.layMaGiaBanTheoTenGia(int.Parse(dataGV_HangHoa.Rows[index].Cells["GiaBan"].Value.ToString().Trim()));
                frmQuyDoiDonViTinh qddvt = new frmQuyDoiDonViTinh();
                qddvt.Show();
            }
            catch { }
        }

        private void dataGV_LoHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
                index = e.RowIndex;
        }

        private void btnCapNhatHinh_Click(object sender, EventArgs e)
        {
            try
            {
                if (index == -1)
                {
                    MessageBox.Show("Vui lòng chọn sản phẩm muốn cập nhật hình!");
                }
                else
                {
                    string hinhanh = dataGV_HangHoa.Rows[index].Cells["HinhAnh"].Value.ToString().Trim();
                    try
                    {                 
                        OpenFileDialog open = new OpenFileDialog();
                        open.InitialDirectory = "D:\\";
                        open.Filter = "Image File (*.jpg)|*.jpg|All File (*.*)|*.*";
                        if (open.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                        {
                            string name = System.IO.Path.GetFileName(open.FileName);
                            string luu = paths + "\\image\\" + name;
                            FileStream fs = new FileStream(open.FileName, FileMode.Open, FileAccess.Read);
                            System.IO.File.Copy(open.FileName, luu);
                            MessageBox.Show("Upload file ảnh thành công", "Thông báo");
                            hinhanh = name;
                            fs.Close();
                        }
                        string updatehinh = "UPDATE SanPham SET HinhAnh='" + hinhanh + "' WHERE MaSP='" + masp + "'";
                        conn.updateToDatabase(updatehinh);
                        loadGVSanPham();
                        MessageBox.Show("Cập nhật hình thành công!");
                    }
                    catch
                    {
                        MessageBox.Show("Cập nhật hình thất bại!");
                    }
                }
            }
            catch
            {
                MessageBox.Show("Vui lòng chọn sản phẩm muốn cập nhật hình");
            }
        }

    }
}
