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
    public class ChucVu
    {
        Connection conn = new Connection();
        SqlDataAdapter da_ChucVu, da_NhanVien;
        DataSet ds_ChucVu, ds_NhanVien;

        public DataTable loadDataGV_ChucVu()
        {
            da_ChucVu = new SqlDataAdapter("Select * From ChucVu", conn.conn);
            ds_ChucVu = new DataSet();
            da_ChucVu.Fill(ds_ChucVu, "ChucVu");
            DataColumn[] key = new DataColumn[1];
            key[0] = ds_ChucVu.Tables["ChucVu"].Columns[0];
            ds_ChucVu.Tables["ChucVu"].PrimaryKey = key;
            return ds_ChucVu.Tables["ChucVu"];
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

        //Lấy nhân viên theo chức vụ (theo mã chức vụ)
        public DataTable GetNhanVien(string ma)
        {
            string lenh = string.Format("Select * From NhanVien Where MaChucVu ='" + ma + "'");
            DataTable table = new DataTable();
            SqlDataAdapter adt = new SqlDataAdapter(lenh, conn.conn);
            adt.Fill(table);
            return table;
        }
        public DataTable layNhanVien(string ma)
        {
            return GetNhanVien(ma);
        }

        public DataTable loadChucVu()
        {
            da_ChucVu = new SqlDataAdapter("Select * From ChucVu", conn.conn);
            DataTable dt_ChucVu = new DataTable();
            da_ChucVu.Fill(dt_ChucVu);
            return dt_ChucVu;
        }

        //Lấy tên chức vụ theo mã chức vụ
        public string GetTenChucVu(string ma)
        {
            string ten = "";
            string strSql = "Select TenChucVu From ChucVu Where MaChucVu='" + ma + "'";
            SqlDataReader dr = conn.getDataReader(strSql);
            while(dr.Read())
            {
                ten = dr["TenChucVu"].ToString();
            }
            dr.Close();
            return ten;
        }
        public string layTenChucVu(string ma)
        {
            return GetTenChucVu(ma);
        }
    }
}
