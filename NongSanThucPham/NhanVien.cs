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
        SqlDataAdapter da_ChamCong;
        DataSet ds_NhanVien, ds;
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

        public DataTable loadChucVu()
        {
            SqlDataAdapter da_ChucVu = new SqlDataAdapter("Select * From ChucVu", conn.conn);
            DataTable dt_ChucVu = new DataTable();
            da_ChucVu.Fill(dt_ChucVu);
            return dt_ChucVu;
        }

        public DataTable loadQuyen()
        {
            SqlDataAdapter da_NhomQuyen = new SqlDataAdapter("Select * From NhomQuyen", conn.conn);
            DataTable dt_NhomQuyen = new DataTable();
            da_NhomQuyen.Fill(dt_NhomQuyen);
            return dt_NhomQuyen;
        }

        public DataTable loadNhanVienChuaCoTaiKhoan()
        {
            string strSQL = "Select NhanVien.MaNV, TenNV, GioiTinh, TenChucVu From NhanVien, ChucVu" +
                " Where NhanVien.MaChucVu = ChucVu.MaChucVu And NhanVien.MaNV Not In (Select MaNV From Quyen_NhanVien)";
            da_NhanVien = new SqlDataAdapter(strSQL, conn.conn);
            ds = new DataSet();
            da_NhanVien.Fill(ds, "NhanVien, ChucVu");
            return ds.Tables["NhanVien, ChucVu"];
        }

        public DataTable loadNhanVienDaCoTaiKhoan()
        {
            string strSQL = "Select NhanVien.MaNV, TenNV, TenQuyen, TenDN, MatKhau, HoatDong From NhanVien, NhomQuyen, Quyen_NhanVien" +
                " Where NhanVien.MaNV = Quyen_NhanVien.MaNV And NhomQuyen.MaQuyen = Quyen_NhanVien.MaQuyen";
            da_NhanVien = new SqlDataAdapter(strSQL, conn.conn);
            ds = new DataSet();
            da_NhanVien.Fill(ds, "NhanVien, NhomQuyen, Quyen_NhanVien");
            return ds.Tables["NhanVien, NhomQuyen, Quyen_NhanVien"];
        }

        public DataTable loadBangChamCong()
        {
            string strSQL = "Select ChamCong.MaNV, TenNV, NgayLam, TinhTrang From NhanVien, ChamCong" +
                " Where NhanVien.MaNV = ChamCong.MaNV";
            da_ChamCong = new SqlDataAdapter(strSQL, conn.conn);
            ds = new DataSet();
            da_ChamCong.Fill(ds, "NhanVien, ChamCong");
            return ds.Tables["NhanVien, ChamCong"];
        }
    }
}
