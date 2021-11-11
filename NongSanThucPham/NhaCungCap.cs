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
    public class NhaCungCap
    {
        Connection conn = new Connection();
        SqlDataAdapter da_NhaCungCap;
        DataSet ds_NhaCungCap;
        
        public DataTable loadDataGV_NhaCungCap()
        {
            da_NhaCungCap = new SqlDataAdapter("Select * From NhaCungCap", conn.conn);
            ds_NhaCungCap = new DataSet();
            da_NhaCungCap.Fill(ds_NhaCungCap, "NhaCungCap");
            DataColumn[] key = new DataColumn[1];
            key[0] = ds_NhaCungCap.Tables["NhaCungCap"].Columns[0];
            ds_NhaCungCap.Tables["NhaCungCap"].PrimaryKey = key;
            return ds_NhaCungCap.Tables["NhaCungCap"];
        }

        public DataTable searchNCC(string tukhoa)
        {
            da_NhaCungCap = new SqlDataAdapter("Exec SP_SearchNCC N'"+tukhoa+"'", conn.conn);
            ds_NhaCungCap = new DataSet();
            da_NhaCungCap.Fill(ds_NhaCungCap, "NhaCungCap");
            DataColumn[] key = new DataColumn[1];
            key[0] = ds_NhaCungCap.Tables["NhaCungCap"].Columns[0];
            ds_NhaCungCap.Tables["NhaCungCap"].PrimaryKey = key;
            return ds_NhaCungCap.Tables["NhaCungCap"];
        }
        public bool addNCC(string mancc,string tenncc,string diachi,string dienthoai,string email,int congno,string stk)
        {
            try
            {
                if (!conn.checkExist("Nhacungcap", "mancc", mancc))
                {
                    string strSQL = "EXEC SP_InsertNCC " + mancc + "," + tenncc + "," + diachi + "," + dienthoai + "," + email + "," + congno + "," + stk;
                    conn.updateToDatabase(strSQL);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch {
                return false;
            }
            
        }
        public bool updateNCC(string mancc, string tenncc, string diachi, string dienthoai, string email, int congno, string stk)
        {
            try
            {
                if (conn.checkExist("Nhacungcap", "mancc", mancc))
                {
                    
                    string strSQL = "EXEC SP_UpdateNCC " + mancc + "," + tenncc + "," + diachi + "," + dienthoai + "," + email + "," + congno + "," + stk;
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
        public bool deleteNCC(string mancc)
        {
            try
            {
                if (conn.checkExist("Nhacungcap", "mancc", mancc))
                {
                    string strSQL = "EXEC sp_deletencc " + mancc;
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
