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
    public class HinhThucThanhToan
    {
        Connection conn = new Connection();
        SqlDataAdapter da_HTTT;
        DataTable dt_HTTT;
        DataSet ds_HTTT;

        public DataTable loadHinhThuc()
        {
            da_HTTT = new SqlDataAdapter("Select * From HT_ThanhToan", conn.conn);
            dt_HTTT = new DataTable();
            da_HTTT.Fill(dt_HTTT);
            return dt_HTTT;
        }

        //Lấy tên hình thức thanh toán theo mã hình thức thanh toán
        public string GetTenHTTT(string maht)
        {
            string ten = "";
            string strSql = "Select TenHT From HT_ThanhToan Where MaHT='" + maht + "'";
            SqlDataReader dr = conn.getDataReader(strSql);
            while (dr.Read())
            {
                ten = dr["TenHT"].ToString();
            }
            dr.Close();
            return ten;
        }
        public string layTenHTTT(string maht)
        {
            return GetTenHTTT(maht);
        }
        public DataTable loadDataGV_HTTT()
        {
            da_HTTT = new SqlDataAdapter("Select * From HT_ThanhToan", conn.conn);
            ds_HTTT = new DataSet();
            da_HTTT.Fill(ds_HTTT, "HT_ThanhToan");
            DataColumn[] key = new DataColumn[1];
            key[0] = ds_HTTT.Tables["HT_ThanhToan"].Columns[0];
            ds_HTTT.Tables["HT_ThanhToan"].PrimaryKey = key;
            return ds_HTTT.Tables["HT_ThanhToan"];
        }


        public bool addHTTT(string ten)
        {
            try
            {

                string strSQL = "EXEC SP_InsertHTTT N'" + ten + "'";
                conn.updateToDatabase(strSQL);
                return true;

            }
            catch
            {
                return false;
            }

        }
        public bool updateHTTT(int ma, string ten)
        {
            try
            {

                if (conn.checkExist("HT_ThanhToan", "MaHT", ma.ToString()))
                {
                    string strSQL = "EXEC sp_updateHTTT '" + ma + "',N'" + ten + "'";
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
        public bool deleteHTTT(string ma)
        {
            try
            {
                if (conn.checkExist("HT_ThanhToan", "MaHT", ma.ToString()))
                {
                    string strSQL = "EXEC sp_deleteHTTT " + ma;
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
    }
}
