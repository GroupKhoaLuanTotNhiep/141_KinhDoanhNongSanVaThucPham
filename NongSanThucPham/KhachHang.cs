using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using DBConnect;
using NongSanThucPham;

namespace NongSanThucPham
{
    public class KhachHang
    {
        Connection conn = new Connection();
        SqlDataAdapter da_KhachHang;
        DataSet ds_KhachHang;
        DataTable dt_KhachHang;
        public DataTable loadDataGV_KhachHang()
        {
            da_KhachHang = new SqlDataAdapter("Select * From KhachHang", conn.conn);
            ds_KhachHang = new DataSet();
            da_KhachHang.Fill(ds_KhachHang, "KhachHang");
            DataColumn[] key = new DataColumn[1];
            key[0] = ds_KhachHang.Tables["KhachHang"].Columns[0];
            ds_KhachHang.Tables["KhachHang"].PrimaryKey = key;
            return ds_KhachHang.Tables["KhachHang"];
        }
        public DataTable searchKhachHang(string tukhoa)
        {
            da_KhachHang = new SqlDataAdapter("Exec SP_SearchKH N'" + tukhoa + "'", conn.conn);
            ds_KhachHang = new DataSet();
            da_KhachHang.Fill(ds_KhachHang, "KhachHang");
            DataColumn[] key = new DataColumn[1];
            key[0] = ds_KhachHang.Tables["KhachHang"].Columns[0];
            ds_KhachHang.Tables["KhachHang"].PrimaryKey = key;
            return ds_KhachHang.Tables["KhachHang"];
        }
        public bool addKH(string tenkh, string diachi, string dienthoai, string email, int congno, int tichdiem)
        {
            try
            {
                string strSQL = "Insert KhachHang Values(N'" + tenkh + "',N'" + diachi + "','" + dienthoai + "','" + email + "'," + tichdiem + "," + congno + ")";
                conn.updateToDatabase(strSQL);
                return true;
            }
            catch
            {
                return false;
            }

        }
        public bool updateKH(int makh, string tenkh, string diachi, string dienthoai, string email, int congno, int tichdiem)
        {
            try
            {
                if (conn.checkExist("KhachHang", "makh", makh.ToString()))
                {
                    //string strSQL = "EXEC SP_UpdateKH " + makh + "," + tenkh + "," + diachi + "," + dienthoai + "," + email + "," + tichdiem + "," + congno;
                    string strSQL = "Update KhachHang Set TenKH=N'" + tenkh + "', DiaChi=N'" + diachi + "', DienThoai='" + dienthoai + "', Email='" + email + "', TichDiem=" + tichdiem + ", CongNo=" + congno + " Where MaKH='" + makh + "'";
                    conn.updateToDatabase(strSQL);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }
        public bool deleteKH(int makh)
        {
            try
            {
                if (conn.checkExist("KhachHang", "makh", makh.ToString()))
                {
                    string strSQL = "EXEC sp_deleteKH " + makh;
                    conn.updateToDatabase(strSQL);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }
        public DataTable loadKhachHang()
        {
            da_KhachHang = new SqlDataAdapter("Select * From KhachHang", conn.conn);
            dt_KhachHang = new DataTable();
            da_KhachHang.Fill(dt_KhachHang);
            return dt_KhachHang;
        }

        public string layTichDiem(string makh)
        {
            string tichDiem = "";
            string strSql = "Select * From KhachHang Where MaKH='" + makh + "'";
            SqlDataReader dr = conn.getDataReader(strSql);
            while (dr.Read())
            {
                tichDiem = dr["TichDiem"].ToString();
            }
            dr.Close();
            return tichDiem;
        }

        public string layCongNo(string makh)
        {
            string congno = "";
            string strSql = "Select * From KhachHang Where MaKH = '" + makh + "'";
            SqlDataReader congnodr = conn.getDataReader(strSql);
            while (congnodr.Read())
            {
                congno = congnodr["CongNo"].ToString();
            }
            congnodr.Close();
            return congno;
        }

        //Lấy tên khách hàng theo mã khách hàng
        public string GetTenKhachHang(string makh)
        {
            string ten = "";
            string strSql = "Select TenKH From KhachHang Where MaKH='" + makh + "'";
            SqlDataReader dr = conn.getDataReader(strSql);
            while (dr.Read())
            {
                ten = dr["TenKH"].ToString();
            }
            dr.Close();
            return ten;
        }
        public string layTenKhachHang(string makh)
        {
            return GetTenKhachHang(makh);
        }

        
    }
}
