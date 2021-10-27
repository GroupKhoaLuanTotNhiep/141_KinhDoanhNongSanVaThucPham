using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DBConnect
{
    public class Connection
    {
        private SqlConnection _conn;
        private string _strConnect, _strServerName, _strDBName, _strUserID, _strPassword;

        public SqlConnection conn
        {
            get { return _conn; }
            set { _conn = value; }
        }

        public string strConnect
        {
            get { return _strConnect; }
            set { _strConnect = value; }
        }

        public string strServerName
        {
            get { return _strServerName; }
            set { _strServerName = value; }
        }

        public string strDBName
        {
            get { return _strDBName; }
            set { _strDBName = value; }
        }

        public string strUserID
        {
            get { return _strUserID; }
            set { _strUserID = value; }
        }

        public string strPassword
        {
            get { return _strPassword; }
            set { _strPassword = value; }
        }

        public Connection()
        {
            strServerName = @"LAPTOP-U0DUSSA2\SQLEXPRESS";
            strDBName = "QL_SieuThiNongSan";

            //Dùng với quyền của Windowns
            //strConnect = @"Data Source=" + strServerName + ";Initial Catalog=" + strDBName + ";Integrated Security=true";

            //Dùng với quyền của SQL Server
            strUserID = "sa";
            strPassword = "sa2012";
            strConnect = @"Data Source=" + strServerName + ";Initial Catalog=" + strDBName + ";User ID=" + strUserID + ";Password=" + strPassword;

            conn = new SqlConnection(strConnect); //Khởi tạo đối tượng kết nối đến CSDL
        }

        public void openConnect()
        {
            if (conn.State == ConnectionState.Closed)
                conn.Open();
        }

        public void closeConnect()
        {
            if (conn.State == ConnectionState.Open)
                conn.Close();
        }

        public void disposeConnect()
        {
            if (conn.State == ConnectionState.Open)
                conn.Close();
            conn.Dispose(); //Giải phóng vùng nhớ đã cấp phát cho conn
        }

        public void updateToDatabase(string strSQL) //Cho phép cập nhật CSDL với các thao tác Thêm, Xóa, Sửa
        {
            openConnect();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = strSQL; //Câu truy vấn đưa vào
            cmd.ExecuteNonQuery(); //Thực thi

            closeConnect();
        }

        //public int getCount(string strSQL)
        //{
        //    openConnect();
        //    SqlCommand cmd = new SqlCommand();
        //    cmd.Connection = conn;
        //    cmd.CommandText = strSQL;
        //    int count = (int)cmd.ExecuteScalar();
        //    closeConnect();
        //    return count;
        //}

        //public bool checkExist(string tableName, string fieldName, string value)
        //{
        //    string strSQL = "SELECT COUNT(*) FROM " + tableName + " WHERE " + fieldName + "='" + value + "'";
        //    return getCount(strSQL) > 0 ? true : false;
        //}

        //public bool checkExistTwoKey(string tableName, string fieldName1, string fieldName2, string value1, string value2)
        //{
        //    string strSQL = "SELECT COUNT(*) FROM " + tableName + " WHERE " + fieldName1 + "='" + value1 + "' AND " + fieldName2 + "='" + value2 + "'";
        //    return getCount(strSQL) > 0 ? true : false;
        //}
    }
}
