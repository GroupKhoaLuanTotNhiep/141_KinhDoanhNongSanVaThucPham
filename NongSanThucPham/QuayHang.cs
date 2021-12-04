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
    public class QuayHang
    {
        Connection conn = new Connection();
        SqlDataAdapter da_QuayHang;
        DataTable dt_QuayHang;
        DataSet ds_QuayHang;

        public DataTable loadQuayHang()
        {
            da_QuayHang = new SqlDataAdapter("Select * From QuayHang", conn.conn);
            dt_QuayHang = new DataTable();
            da_QuayHang.Fill(dt_QuayHang);
            return dt_QuayHang;
        }

        //Lấy tên quầy hàng theo mã quầy hàng
        public string GetTenQuayHang(string maquay)
        {
            string ten = "";
            string strSql = "Select TenQuay From QuayHang Where MaQuay='" + maquay + "'";
            SqlDataReader dr = conn.getDataReader(strSql);
            while (dr.Read())
            {
                ten = dr["TenQuay"].ToString();
            }
            dr.Close();
            return ten;
        }
        public string layTenQuayHang(string maquay)
        {
            return GetTenQuayHang(maquay);
        }
        public DataTable loadDataGV_QuayHang()
        {
            da_QuayHang = new SqlDataAdapter("Select * From QuayHang", conn.conn);
            ds_QuayHang = new DataSet();
            da_QuayHang.Fill(ds_QuayHang, "QuayHang");
            DataColumn[] key = new DataColumn[1];
            key[0] = ds_QuayHang.Tables["QuayHang"].Columns[0];
            ds_QuayHang.Tables["QuayHang"].PrimaryKey = key;
            return ds_QuayHang.Tables["QuayHang"];
        }

        public DataTable searchQuayHang(string tukhoa)
        {
            da_QuayHang = new SqlDataAdapter("Exec SP_SearchQuayHang N'" + tukhoa + "'", conn.conn);
            ds_QuayHang = new DataSet();
            da_QuayHang.Fill(ds_QuayHang, "QuayHang");
            DataColumn[] key = new DataColumn[1];
            key[0] = ds_QuayHang.Tables["QuayHang"].Columns[0];
            ds_QuayHang.Tables["QuayHang"].PrimaryKey = key;
            return ds_QuayHang.Tables["QuayHang"];
        }
        public bool addQuayHang(string maquay, string tenquay)
        {
            try
            {
                string strSQL = "EXEC SP_InsertQuayHang '" + maquay + "',N'" + tenquay + "'";
                conn.updateToDatabase(strSQL);
                return true;
            }
            catch
            {
                return false;
            }

        }
        public bool updateQuayHang(string maquay, string tenquay)
        {
            try
            {
                if (conn.checkExist("QuayHang", "maquay", maquay))
                {

                    string strSQL = "EXEC SP_UpdateQuayHang '" + maquay + "',N'" + tenquay + "'";
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
        public bool deleteQuayHang(string maquay)
        {
            try
            {
                if (conn.checkExist("QuayHang", "maquay", maquay))
                {
                    string strSQL = "EXEC sp_deleteQuayHang " + maquay;
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
