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
    public class DonViTinh
    {
        Connection conn = new Connection();
        SqlDataAdapter da_LoaiSP, da_DVT;
        DataSet ds_LoaiSP, ds_DVT;
        DataTable dt_DVT;

        public DataTable loadDataGV_DVT()
        {
            da_LoaiSP = new SqlDataAdapter("Select * From DonViTinh", conn.conn);
            ds_LoaiSP = new DataSet();
            da_LoaiSP.Fill(ds_LoaiSP, "DonViTinh");
            DataColumn[] key = new DataColumn[1];
            key[0] = ds_LoaiSP.Tables["DonViTinh"].Columns[0];
            ds_LoaiSP.Tables["DonViTinh"].PrimaryKey = key;
            return ds_LoaiSP.Tables["DonViTinh"];
        }

        public DataTable loadDonViTinh()
        {
            da_DVT = new SqlDataAdapter("Select * From DonViTinh", conn.conn);
            dt_DVT = new DataTable();
            da_DVT.Fill(dt_DVT);
            return dt_DVT;
        }

        public bool addDVT(string ten)
        {
            try
            {

                string strSQL = "EXEC SP_InsertDVT N'" + ten + "'";
                conn.updateToDatabase(strSQL);
                return true;

            }
            catch
            {
                return false;
            }

        }
        public bool updateDVT(int ma, string ten)
        {
            try
            {

                if (conn.checkExist("DonViTinh", "MaDVT", ma.ToString()))
                {
                    string strSQL = "EXEC sp_updateDVT " + ma + ",N'" + ten + "'";
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
        public bool deleteDVT(int ma)
        {
            try
            {
                if (conn.checkExist("DonViTinh", "MaDVT", ma.ToString()))
                {
                    string strSQL = "EXEC sp_deleteDVT " + ma;
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

        //Lấy tên đơn vị tính theo mã đơn vị tính
        public string GetTenDonViTinh(string madvt)
        {
            string ten = "";
            string strSql = "Select TenDVT From DonViTinh Where MaDVT='" + madvt + "'";
            SqlDataReader dr = conn.getDataReader(strSql);
            while (dr.Read())
            {
                ten = dr["TenDVT"].ToString();
            }
            dr.Close();
            return ten;
        }
        public string layTenDonViTinh(string madvt)
        {
            return GetTenDonViTinh(madvt);
        }
    }
}
