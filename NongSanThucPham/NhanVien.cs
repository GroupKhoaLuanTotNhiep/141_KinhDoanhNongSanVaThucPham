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
        SqlDataAdapter da_ChucVu;
        DataSet ds_NhanVien;

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
    }
}
