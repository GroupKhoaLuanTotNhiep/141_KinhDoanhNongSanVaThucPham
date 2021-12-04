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
    public class KhuyenMai
    {
        Connection conn = new Connection();
        SqlDataAdapter da_KhuyenMai;
        DataSet ds_KhuyenMai;
        DataTable dt_KhuyenMai;

        public DataTable loadDataGV_KM()
        {
            da_KhuyenMai = new SqlDataAdapter("Select * From KhuyenMai", conn.conn);
            ds_KhuyenMai = new DataSet();
            da_KhuyenMai.Fill(ds_KhuyenMai, "KhuyenMai");
            DataColumn[] key = new DataColumn[1];
            key[0] = ds_KhuyenMai.Tables["KhuyenMai"].Columns[0];
            ds_KhuyenMai.Tables["KhuyenMai"].PrimaryKey = key;
            return ds_KhuyenMai.Tables["KhuyenMai"];
        }
        public bool addKM(string ma, string ten, float giatri, string noidung, int tichluy)
        {
            try
            {
                if (!conn.checkExist("KhuyenMai", "MaKM", ma))
                {
                    string strSQL = "EXEC SP_InsertKM '" + ma+ "',N'" + ten+ "'," + giatri+ ",N'" +noidung+ "',"+tichluy;
                    //string strSQL = "Insert KhuyenMai Values('" + ma + "', N'" + ten + "', " + giatri + ", N'" + noidung + "', " + tichluy +")";
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
        public bool updateKM(string ma, string ten, float giatri, string noidung, int tichluy)
        {
            try
            {
                if (conn.checkExist("KhuyenMai", "MaKM", ma))
                {

                    string strSQL = "EXEC SP_UpdateKM '" + ma + "',N'" +ten+ "'," + giatri+ ",N'" +noidung+ "',"+tichluy;
                    //string strSQL = "Update KhuyenMai Set TenKM='" + ten + "', GiaTriKM=" + giatri + ", NoiDung=N'" + noidung + "', TichLuy=" + tichluy + " Where MaKM='" + ma + "'";
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
        public bool deleteKM(string ma)
        {
            try
            {
                if (conn.checkExist("KhuyenMai", "Makm", ma))
                {
                    string strSQL = "EXEC sp_deleteKM " + ma;
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
        public DataTable loadKhuyenMai()
        {
            da_KhuyenMai = new SqlDataAdapter("Select * From KhuyenMai", conn.conn);
            dt_KhuyenMai = new DataTable();
            da_KhuyenMai.Fill(dt_KhuyenMai);
            return dt_KhuyenMai;
        }

        public string layGiaTriKM(string makm)
        {
            string giaTri = "";
            string strSql = "Select * From KhuyenMai Where MaKM = '" + makm + "'";
            SqlDataReader giaTridr = conn.getDataReader(strSql);
            while (giaTridr.Read())
            {
                giaTri = giaTridr["GiaTriKM"].ToString();
            }
            giaTridr.Close();
            return giaTri;
        }

        public string layTichLuy(string makm)
        {
            string tichLuy = "";
            string strSql = "Select * From KhuyenMai Where MaKM = '" + makm + "'";
            SqlDataReader tichLuydr = conn.getDataReader(strSql);
            while (tichLuydr.Read())
            {
                tichLuy = tichLuydr["TichLuy"].ToString();
            }
            tichLuydr.Close();
            return tichLuy;
        }

        //Lấy tên khuyến mãi theo mã khuyến mãi
        public string GetTenKhuyenMai(string makm)
        {
            string ten = "";
            string strSql = "Select TenKM From KhuyenMai Where MaKM='" + makm + "'";
            SqlDataReader dr = conn.getDataReader(strSql);
            while (dr.Read())
            {
                ten = dr["TenKM"].ToString();
            }
            dr.Close();
            return ten;
        }
        public string layTenKhuyenMai(string makm)
        {
            return GetTenKhuyenMai(makm);
        }
    }
}
