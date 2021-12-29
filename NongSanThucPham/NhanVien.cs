using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using DBConnect;

namespace NongSanThucPham
{
    public class NhanVien
    {
        Connection conn = new Connection();
        SqlDataAdapter da_NhanVien;
        SqlDataAdapter da_ChamCong, da_TinhLuong;
        DataSet ds_NhanVien, ds, ds_ChamCong, ds_TinhLuong;
        string _MaNV, _TenNV, _ChucVu, _GioiTinh, _DiaChi, _DienThoai, _Email, _HinhAnh;
        string _NgaySinh;

        public string MaNV
        {
            get { return _MaNV; }
            set { _MaNV = value; }
        }

        public string TenNV
        {
            get { return _TenNV; }
            set { _TenNV = value; }
        }

        public string ChucVu
        {
            get { return _ChucVu; }
            set { _ChucVu = value; }
        }

        public string NgaySinh
        {
            get { return _NgaySinh; }
            set { _NgaySinh = value; }
        }

        public DataTable loadDataGV_NhanVien()
        {
            da_NhanVien = new SqlDataAdapter("Select * From NhanVien", conn.conn);
            ds_NhanVien = new DataSet();
            da_NhanVien.Fill(ds_NhanVien, "NhanVien");
            DataColumn[] key = new DataColumn[1];
            key[0] = ds_NhanVien.Tables["NhanVien"].Columns[0];
            ds_NhanVien.Tables["NhanVien"].PrimaryKey = key;
            return ds_NhanVien.Tables["NhanVien"];
        }

        public DataTable searchNhanVien(string tukhoa)
        {
            da_NhanVien = new SqlDataAdapter("Exec SP_SearchNV N'" + tukhoa + "'", conn.conn);
            ds_NhanVien = new DataSet();
            da_NhanVien.Fill(ds_NhanVien, "NhanVien");
            DataColumn[] key = new DataColumn[1];
            key[0] = ds_NhanVien.Tables["NhanVien"].Columns[0];
            ds_NhanVien.Tables["NhanVien"].PrimaryKey = key;
            return ds_NhanVien.Tables["NhanVien"];
        }

        public DataTable loadBangNhanVienChuaCoTaiKhoan()
        {
            string strSQL = "Select NhanVien.MaNV, TenNV, GioiTinh, TenChucVu From NhanVien, ChucVu" +
                " Where NhanVien.MaChucVu = ChucVu.MaChucVu And NhanVien.MaNV Not In (Select MaNV From Quyen_NhanVien)";
            da_NhanVien = new SqlDataAdapter(strSQL, conn.conn);
            ds = new DataSet();
            da_NhanVien.Fill(ds, "NhanVien, ChucVu");
            return ds.Tables["NhanVien, ChucVu"];
        }

        public DataTable loadBangNhanVienDaCoTaiKhoan()
        {
            string strSQL = "Select NhanVien.MaNV, TenNV, TenQuyen, TenDN, MatKhau, HoatDong From NhanVien, NhomQuyen, Quyen_NhanVien" +
                " Where NhanVien.MaNV = Quyen_NhanVien.MaNV And NhomQuyen.MaQuyen = Quyen_NhanVien.MaQuyen";
            da_NhanVien = new SqlDataAdapter(strSQL, conn.conn);
            ds = new DataSet();
            da_NhanVien.Fill(ds, "NhanVien, NhomQuyen, Quyen_NhanVien");
            return ds.Tables["NhanVien, NhomQuyen, Quyen_NhanVien"];
        }

        public DataTable loadNhanVienLenBangChamCong()
        {
            string strSQL = "Select MaNV, TenNV From NhanVien";
            da_NhanVien = new SqlDataAdapter(strSQL, conn.conn);
            ds = new DataSet();
            da_NhanVien.Fill(ds, "NhanVien");
            return ds.Tables["NhanVien"];
        }

        public DataTable loadBangChamCong()
        {
            string strSql = "Select NhanVien.MaNV, TenNV, NgayLam, TinhTrang From NhanVien, ChamCong Where NhanVien.MaNV = ChamCong.MaNV";
            da_ChamCong = new SqlDataAdapter(strSql, conn.conn);
            ds_ChamCong = new DataSet();
            da_ChamCong.Fill(ds_ChamCong, "NhanVien, ChamCong");

            return ds_ChamCong.Tables["NhanVien, ChamCong"];
        }

        public DataTable loadNhanVienLenBangTinhLuong()
        {
            string strSQL = "Select MaNV, TenNV, HeSoLuong, LuongCoBan From NhanVien, ChucVu Where NhanVien.MaChucVu = ChucVu.MaChucVu";
            da_NhanVien = new SqlDataAdapter(strSQL, conn.conn);
            ds = new DataSet();
            da_NhanVien.Fill(ds, "NhanVien, ChucVu");
            return ds.Tables["NhanVien, ChucVu"];
        }

        public DataTable loadBangTinhLuong()
        {
            string strSql = "Select NhanVien.MaNV, TenNV, HeSoLuong, LuongCoBan, SoNgayLam, PhuCap, TienThuong, TienPhat, TongLuong, NgayTinhLuong From NhanVien, ChucVu, BangLuong Where NhanVien.MaChucVu = ChucVu.MaChucVu And NhanVien.MaNV = BangLuong.MaNV";
            da_TinhLuong = new SqlDataAdapter(strSql, conn.conn);
            ds_TinhLuong = new DataSet();
            da_TinhLuong.Fill(ds_TinhLuong, "NhanVien, ChucVu, BangLuong");

            return ds_TinhLuong.Tables["NhanVien, ChucVu, BangLuong"];
        }

        public DataTable loadNhanVien()
        {
            da_NhanVien = new SqlDataAdapter("Select * From NhanVien", conn.conn);
            DataTable dt_NhanVien = new DataTable();
            da_NhanVien.Fill(dt_NhanVien);
            return dt_NhanVien;
        }

        public DataTable loadNhanVienGiaoHang()
        {
            da_NhanVien = new SqlDataAdapter("Select * From NhanVien, ChucVu Where NhanVien.MaChucVu = ChucVu.MaChucVu And ChucVu.MaChucVu='NVGH'", conn.conn);
            DataTable dt_NhanVien = new DataTable();
            da_NhanVien.Fill(dt_NhanVien);
            return dt_NhanVien;
        }

        //Lấy tên nhân viên theo mã nhân viên
        public string GetTenNhanVien(string manv)
        {
            string ten = "";
            string strSql = "Select TenNV From NhanVien Where MaNV='" + manv + "'";
            SqlDataReader dr = conn.getDataReader(strSql);
            while (dr.Read())
            {
                ten = dr["TenNV"].ToString();
            }
            dr.Close();
            return ten;
        }
        public string layTenNhanVien(string manv)
        {
            return GetTenNhanVien(manv);
        }

        public int GetTenMaNVVien(string tendn, string matkhau)
        {
            int manv = -1;
            string strSql = "select MaNV from Quyen_NhanVien where TenDN = N'" + tendn + "' and MatKhau = '" + matkhau + "'";
            SqlDataReader dr = conn.getDataReader(strSql);
            while (dr.Read())
            {
                manv = int.Parse(dr["MaNV"].ToString());
            }
            dr.Close();
            return manv;
        }

        public DataTable searchNgayCongTheoNgayLam(string ngaylam)
        {
            DataTable table = new DataTable();
            string lenh = string.Format("Select NhanVien.MaNV, TenNV, NgayLam, TinhTrang From NhanVien, ChamCong Where NhanVien.MaNV = ChamCong.MaNV And NgayLam = '" + ngaylam + "'");
            SqlDataAdapter da = new SqlDataAdapter(lenh, conn.conn);
            da.Fill(table);
            return table;
        }

        public DataTable searchNgayCongTheoMaNV(string manv)
        {
            DataTable table = new DataTable();
            string lenh = string.Format("Select NhanVien.MaNV, TenNV, NgayLam, TinhTrang From NhanVien, ChamCong Where NhanVien.MaNV = ChamCong.MaNV And NhanVien.MaNV = '" + manv + "'");
            SqlDataAdapter da = new SqlDataAdapter(lenh, conn.conn);
            da.Fill(table);
            return table;
        }

        public DataTable searchThongTinLuong(string ngaydau, string ngaycuoi)
        {
            string lenh = string.Format("Select NhanVien.MaNV, TenNV, HeSoLuong, LuongCoBan, SoNgayLam, PhuCap, TienThuong, TienPhat, TongLuong, NgayTinhLuong From NhanVien, ChucVu, BangLuong Where NhanVien.MaChucVu = ChucVu.MaChucVu And NhanVien.MaNV = BangLuong.MaNV And '" + ngaydau + "' <= NgayTinhLuong And NgayTinhLuong <='" + ngaycuoi + "'");
            da_TinhLuong = new SqlDataAdapter(lenh, conn.conn);
            ds_TinhLuong = new DataSet();
            da_TinhLuong.Fill(ds_TinhLuong, "NhanVien, ChucVu, BangLuong");
            return ds_TinhLuong.Tables["NhanVien, ChucVu, BangLuong"];
        }

        public int demSoNgayLam(string manv, string ngaydau, string ngaycuoi)
        {
            int soNgayLam = 0;
            string strSql = "Select * From ChamCong Where MaNV='" + manv + "' And NgayLam>='" + ngaydau + "' And NgayLam<='" + ngaycuoi + "' And TinhTrang=N'Đi làm'";
            SqlDataReader dr = conn.getDataReader(strSql);
            while (dr.Read())
            {
                soNgayLam++;
            }
            dr.Close();
            return soNgayLam;
        }

        public bool kiemTraTonTaiThangLuong(string tableName, string fieldName1, string fieldName2, string value1, string value2, string value3) 
        {
            string strSQL = "SELECT COUNT(*) FROM " + tableName + " WHERE " + fieldName1 + "='" + value1 + "' AND " + fieldName2 + ">='" + value2 + "' AND " + fieldName2 + "<='" + value3 + "'";
            return conn.getCount(strSQL) > 0 ? true : false;
        }
    }
}
