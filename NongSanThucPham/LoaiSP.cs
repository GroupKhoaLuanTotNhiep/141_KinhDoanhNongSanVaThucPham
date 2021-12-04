using DBConnect;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NongSanThucPham
{
    public class LoaiSP
    {
        Connection conn = new Connection();
        SqlDataAdapter da_LoaiSP;
        DataSet ds_LoaiSP;
        DataTable dt_LoaiSP;

        public DataTable loadDataGV_LoaiSP()
        {
            da_LoaiSP = new SqlDataAdapter("Select * From LoaiSanPham", conn.conn);
            ds_LoaiSP = new DataSet();
            da_LoaiSP.Fill(ds_LoaiSP, "LoaiSanPham");
            DataColumn[] key = new DataColumn[1];
            key[0] = ds_LoaiSP.Tables["LoaiSanPham"].Columns[0];
            ds_LoaiSP.Tables["LoaiSanPham"].PrimaryKey = key;
            return ds_LoaiSP.Tables["LoaiSanPham"];
        }

        public DataTable loadLoaiSanPham()
        {
            da_LoaiSP = new SqlDataAdapter("Select * From LoaiSanPham", conn.conn);
            dt_LoaiSP = new DataTable();
            da_LoaiSP.Fill(dt_LoaiSP);
            return dt_LoaiSP;
        }

        public bool addLoaiSP(string ten)
        {
            try
            {

                string strSQL = "EXEC SP_InsertLoaiSP N'" + ten + "'";
                conn.updateToDatabase(strSQL);
                return true;

            }
            catch
            {
                return false;
            }

        }
        public bool updateLoaiSP(int ma, string ten)
        {
            try
            {

                if (conn.checkExist("Loaisanpham", "maloaisp", ma.ToString()))
                {
                    string strSQL = "EXEC sp_updateloaisp " + ma + ",N'" + ten + "'";
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
        public bool deleteLoaiSP(int ma)
        {
            try
            {
                if (conn.checkExist("Loaisanpham", "maloaisp", ma.ToString()))
                {
                    string strSQL = "EXEC sp_deleteloaisp " + ma;
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
