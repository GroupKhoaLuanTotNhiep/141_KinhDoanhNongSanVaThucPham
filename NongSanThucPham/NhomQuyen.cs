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
    public class NhomQuyen
    {
        Connection conn = new Connection();
        SqlDataAdapter da_Quyen, da_NhanVien;
        DataSet ds_Quyen;
        DataSet ds;

        public DataTable loadDataGV_Quyen()
        {
            da_Quyen = new SqlDataAdapter("Select * From NhomQuyen", conn.conn);
            ds_Quyen = new DataSet();
            da_Quyen.Fill(ds_Quyen, "NhomQuyen");
            DataColumn[] key = new DataColumn[1];
            key[0] = ds_Quyen.Tables["NhomQuyen"].Columns[0];
            ds_Quyen.Tables["NhomQuyen"].PrimaryKey = key;
            return ds_Quyen.Tables["NhomQuyen"];
        }

        public DataTable loadDataGV_NhanVien()
        {
            string strSQL = "Select NhanVien.MaNV, TenNV, GioiTinh, NgaySinh, DiaChi, DienThoai, Email, TenDN, MatKhau, NhomQuyen.MaQuyen From NhanVien, Quyen_NhanVien, NhomQuyen Where NhanVien.MaNV = Quyen_NhanVien.MaNV And NhomQuyen.MaQuyen = Quyen_NhanVien.MaQuyen";
            da_NhanVien = new SqlDataAdapter(strSQL, conn.conn);
            ds = new DataSet();
            da_NhanVien.Fill(ds, "NhanVien, Quyen_NhanVien, NhomQuyen");

            return ds.Tables["NhanVien, Quyen_NhanVien, NhomQuyen"];
        }

        public DataTable GetNhanVien(string ma)
        {
            string lenh = string.Format("Select NhanVien.MaNV, TenNV, GioiTinh, NgaySinh, DiaChi, DienThoai, Email, TenDN, MatKhau, NhomQuyen.MaQuyen From NhanVien, Quyen_NhanVien, NhomQuyen Where NhanVien.MaNV = Quyen_NhanVien.MaNV And NhomQuyen.MaQuyen = Quyen_NhanVien.MaQuyen And NhomQuyen.MaQuyen='" + ma + "'");
            DataTable table = new DataTable();
            SqlDataAdapter adt = new SqlDataAdapter(lenh, conn.conn);
            adt.Fill(table);
            return table;
        }

        public DataTable layNhanVien(string ma)
        {
            return GetNhanVien(ma);
        }

        public DataTable loadQuyen()
        {
            da_Quyen = new SqlDataAdapter("Select * From NhomQuyen", conn.conn);
            DataTable dt_Quyen = new DataTable();
            da_Quyen.Fill(dt_Quyen);
            return dt_Quyen;
        }
    }
}
