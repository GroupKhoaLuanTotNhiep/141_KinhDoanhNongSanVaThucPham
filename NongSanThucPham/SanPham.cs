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
    public class SanPham
    {
        Connection conn = new Connection();
        SqlDataAdapter da_SanPham;
        DataSet ds_SanPham;
        DataTable dt_KhachHang;
        public DataTable loadDataGV_SanPham()
        {
            da_SanPham = new SqlDataAdapter("Select * From SanPham", conn.conn);
            ds_SanPham = new DataSet();
            da_SanPham.Fill(ds_SanPham, "SanPham");
            DataColumn[] key = new DataColumn[1];
            key[0] = ds_SanPham.Tables["SanPham"].Columns["MaSP"];
            ds_SanPham.Tables["SanPham"].PrimaryKey = key;
            return ds_SanPham.Tables["SanPham"];
        }
        public DataTable searchSanPham(string tukhoa)
        {
            da_SanPham = new SqlDataAdapter("Exec SP_SearchSP N'" + tukhoa + "'", conn.conn);
            ds_SanPham = new DataSet();
            da_SanPham.Fill(ds_SanPham, "SanPham");
            DataColumn[] key = new DataColumn[1];
            key[0] = ds_SanPham.Tables["SanPham"].Columns["MaSP"];
            ds_SanPham.Tables["SanPham"].PrimaryKey = key;
            return ds_SanPham.Tables["SanPham"];
        }
        public bool addSP(string masp, string tensp, string hinhanh, int giavon ,int giaban,float giamgia ,float soluong ,string xuatxu ,string	mota ,int maloaisp ,int	madvt ,string maquay )
        {
            try
            {
                string strSQL = "Insert SanPham Values('" + masp + "', N'" + tensp + "', '" + hinhanh+ "', " + giavon+ "," + giaban + "," + giamgia + "," +soluong + ",N'" +xuatxu + "',N'" +mota + "'," +maloaisp + "," +madvt + ",'" +maquay + "')";
                conn.updateToDatabase(strSQL);
                return true;
            }
            catch
            {
                return false;
            }

        }
        public bool updateSP(string masp, string tensp, string hinhanh, int giavon, int giaban, float giamgia, float soluong, string xuatxu, string mota, int maloaisp, int madvt, string maquay)
        {
            try
            {
                if (conn.checkExist("SanPham", "masp", masp.ToString()))
                {

                    string strSQL = "Update SanPham Set TenSP=N'" + tensp.Trim() + "', HinhAnh='" + hinhanh + "',GiaVon=" + giavon + ",GiaBan=" + giaban + ",GiamGia=" + giamgia + ",SoLuongSP=" + soluong + ",XuatXu=N'" + xuatxu + "',MoTa=N'" + mota + "',MaLoaiSP=" + maloaisp + ",MaDVT=" + madvt + ",MaQuay='" + maquay + "' Where MaSP='" + masp + "'";
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
        public bool deleteSP(string masp)
        {
            try
            {
                if (conn.checkExist("SanPham", "masp", masp.ToString()))
                {
                    string strSQL = "Delete SanPham Where MaSP='" + masp.ToString() + "'";
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

        public DataTable loadSanPham()
        {
            da_SanPham = new SqlDataAdapter("Select * From SanPham", conn.conn);
            DataTable dt_SanPham = new DataTable();
            da_SanPham.Fill(dt_SanPham);
            return dt_SanPham;
        }

        public DataTable loadGiaBan()
        {
            SqlDataAdapter da_GiaBan = new SqlDataAdapter("Select * From BangGia", conn.conn);
            DataTable dt_GiaBan = new DataTable();
            da_GiaBan.Fill(dt_GiaBan);
            return dt_GiaBan;
        }

        public DataTable loadGiaBanTheoSanPham(string masp)
        {
            SqlDataAdapter da_GiaBan = new SqlDataAdapter("Select * From BangGia, Gia_SanPham Where BangGia.MaGia = Gia_SanPham.MaGia And MaSP='" + masp + "'", conn.conn);
            DataTable dt_GiaBan = new DataTable();
            da_GiaBan.Fill(dt_GiaBan);
            return dt_GiaBan;
        }

        //Lấy tên sản phẩm theo mã sản phẩm
        public string GetTenSanPham(string masp)
        {
            string ten = "";
            string strSql = "Select TenSP From SanPham Where MaSP='" + masp + "'";
            SqlDataReader dr = conn.getDataReader(strSql);
            while (dr.Read())
            {
                ten = dr["TenSP"].ToString();
            }
            dr.Close();
            return ten;
        }
        public string layTenSanPham(string masp)
        {
            return GetTenSanPham(masp);
        }

        public DataTable GetLoHangTheoSanPham(string masp)
        {
            string lenh = string.Format("Select MaLo, TenLo, NgaySanXuat, HanSuDung, SoLuong, LoHang.MaPNH, NgayNhap, MaGia From LoHang, PhieuNhapHang" +
                " Where LoHang.MaPNH = PhieuNhapHang.MaPNH And MaSP='" + masp + "'");
            DataTable table = new DataTable();
            SqlDataAdapter adt = new SqlDataAdapter(lenh, conn.conn);
            adt.Fill(table);
            return table;
        }
        public DataTable layLoHangTheoSanPham(string masp)
        {
            return GetLoHangTheoSanPham(masp);
        }

        //Bảng giá
        public string layMaGiaBan()
        {
            string magia = "";
            string strSql = "Select * From BangGia";
            SqlDataReader dr = conn.getDataReader(strSql);
            while (dr.Read())
            {
                magia = dr["MaGia"].ToString();
            }
            dr.Close();
            return magia;
        }

        public string layMaGiaBanTheoTenGia(int gia)
        {
            string magia = "";
            string strSql = "Select MaGia From BangGia Where GiaSP=" + gia;
            SqlDataReader dr = conn.getDataReader(strSql);
            while (dr.Read())
            {
                magia = dr["MaGia"].ToString();
            }
            dr.Close();
            return magia;
        }

        //Bảng giảm giá
        public string layMaGiamGia()
        {
            string magiam = "";
            string strSql = "Select * From GiamGia";
            SqlDataReader dr = conn.getDataReader(strSql);
            while (dr.Read())
            {
                magiam = dr["MaGiam"].ToString();
            }
            dr.Close();
            return magiam;
        }

        public string layMaGiamGiaTheoPhanTramGiam(float giam)
        {
            string magiam = "";
            string strSql = "Select MaGiam From GiamGia Where PhanTramGiam=" + giam;
            SqlDataReader dr = conn.getDataReader(strSql);
            while (dr.Read())
            {
                magiam = dr["MaGiam"].ToString();
            }
            dr.Close();
            return magiam;
        }

        public string layGiaVon(string masp)
        {
            string giavon = "";
            string strSql = "Select GiaVon From SanPham Where MaSP='" + masp + "'";
            SqlDataReader dr = conn.getDataReader(strSql);
            while (dr.Read())
            {
                giavon = dr["GiaVon"].ToString();
            }
            dr.Close();
            return giavon;
        }

        public string layGiaBan(string masp)
        {
            string giaban = "";
            string strSql = "Select GiaBan From SanPham Where MaSP='" + masp + "'";
            SqlDataReader dr = conn.getDataReader(strSql);
            while (dr.Read())
            {
                giaban = dr["GiaBan"].ToString();
            }
            dr.Close();
            return giaban;
        }

        public string layGiamGia(string masp)
        {
            string giamgia = "";
            string strSql = "Select GiamGia From SanPham Where MaSP='" + masp + "'";
            SqlDataReader dr = conn.getDataReader(strSql);
            while (dr.Read())
            {
                giamgia = dr["GiamGia"].ToString();
            }
            dr.Close();
            return giamgia;
        }

        public string layNgayApDung(string masp, int magia)
        {
            string ngayad = "";
            string strSql = "Select NgayApDung From Gia_SanPham Where MaSP='" + masp + "' And MaGia=" + magia;
            SqlDataReader dr = conn.getDataReader(strSql);
            while (dr.Read())
            {
                ngayad = dr["NgayApDung"].ToString();
            }
            dr.Close();
            return ngayad;
        }

        public string laySoLuongSPTheoSanPham(string masp)
        {
            string soLuong = "";
            string strSql = "Select SoLuongSP From SanPham Where MaSP='" + masp + "'";
            SqlDataReader dr = conn.getDataReader(strSql);
            while (dr.Read())
            {
                soLuong = dr["SoLuongSP"].ToString();
            }
            dr.Close();
            return soLuong;
        }

        public DataTable searchSanPhamTheoLoaiSP(string loai)
        {
            DataTable table = new DataTable();
            string lenh = string.Format("Select SanPham.* From SanPham, LoaiSanPham Where SanPham.MaLoaiSP = LoaiSanPham.MaLoaiSP And TenLoaiSP =N'" + loai + "'");
            SqlDataAdapter da = new SqlDataAdapter(lenh, conn.conn);
            da.Fill(table);
            return table;
        }

        public DataTable searchSanPhamTheoQuayHang(string maquay)
        {
            DataTable table = new DataTable();
            string lenh = string.Format("Select * From SanPham Where MaQuay ='" + maquay + "'");
            SqlDataAdapter da = new SqlDataAdapter(lenh, conn.conn);
            da.Fill(table);
            return table;
        }

        public string layDonViTinhTheoSanPham(string masp)
        {
            string dvt = "";
            string strSQL = "Select * From DonViTinh, SanPham Where SanPham.MaDVT = DonViTinh.MaDVT And MaSP='" + masp + "'";
            SqlDataReader dr = conn.getDataReader(strSQL);
            while (dr.Read())
            {
                dvt = dr["TenDVT"].ToString();
            }
            dr.Close();
            return dvt;
        }
        public DataTable loadMaSP()
        {
            da_SanPham = new SqlDataAdapter("Select distinct * From SanPham", conn.conn);
            DataTable dt_SanPham = new DataTable();
            da_SanPham.Fill(dt_SanPham);
            return dt_SanPham;
        }
        public DataTable loadLichSuGiaBan(string masp)
        {
            conn.openConnect();
            var cmd = new SqlCommand("LichSuGiaBan", conn.conn);
            cmd.CommandType = CommandType.StoredProcedure;
            using (DataTable dt = new DataTable())
            {
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    da.SelectCommand.Parameters.Add(new SqlParameter("@masp", SqlDbType.VarChar));
                    da.SelectCommand.Parameters["@masp"].Value = masp;
                    da.Fill(dt);
                    conn.closeConnect();
                    return dt;
                }
            }
        }
        public DataTable loadGiaVon()
        {
            //da_SanPham = new SqlDataAdapter("Select * From ChiTietPhieuNhapHang", conn.conn);
            da_SanPham = new SqlDataAdapter("Select distinct * From SanPham", conn.conn);
            DataTable dt_SanPham = new DataTable();
            da_SanPham.Fill(dt_SanPham);
            return dt_SanPham;
        }
        public DataTable loadLichSuGiaVon(string masp)
        {
            conn.openConnect();
            var cmd = new SqlCommand("LichSuGiaNhap", conn.conn);
            cmd.CommandType = CommandType.StoredProcedure;
            using (DataTable dt = new DataTable())
            {
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    da.SelectCommand.Parameters.Add(new SqlParameter("@masp", SqlDbType.VarChar));
                    da.SelectCommand.Parameters["@masp"].Value = masp;
                    da.Fill(dt);
                    conn.closeConnect();
                    return dt;
                }
            }
        }
        public DataTable loadGiamGia()
        {
            //da_SanPham = new SqlDataAdapter("Select * From GiamGia_SanPham", conn.conn);
            da_SanPham = new SqlDataAdapter("Select distinct * From SanPham", conn.conn);
            DataTable dt_SanPham = new DataTable();
            da_SanPham.Fill(dt_SanPham);
            return dt_SanPham;
        }
        public DataTable loadLichSuGiamGia(string masp)
        {
            conn.openConnect();
            var cmd = new SqlCommand("LichSuGiamGia", conn.conn);
            cmd.CommandType = CommandType.StoredProcedure;
            using (DataTable dt = new DataTable())
            {
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    da.SelectCommand.Parameters.Add(new SqlParameter("@masp", SqlDbType.VarChar));
                    da.SelectCommand.Parameters["@masp"].Value = masp;
                    da.Fill(dt);
                    conn.closeConnect();
                    return dt;
                }
            }
        }
        //Thống kê sản phẩm sắp hết hạn sd
        public DataTable loadThongKeSPSapHetHan()
        {
            conn.openConnect();
            var cmd = new SqlCommand("ThongKe_SPSapHetHanSD", conn.conn);
            cmd.CommandType = CommandType.StoredProcedure;
            using (DataTable dt = new DataTable())
            {
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    da.Fill(dt);
                    conn.closeConnect();
                    return dt;
                }
            }
        }
        //Thống kê sản phẩm hết hạn sd
        public DataTable loadThongKeSPHetHan()
        {
            conn.openConnect();
            var cmd = new SqlCommand("ThongKe_SPHetHanSD", conn.conn);
            cmd.CommandType = CommandType.StoredProcedure;
            using (DataTable dt = new DataTable())
            {
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    da.Fill(dt);
                    conn.closeConnect();
                    return dt;
                }
            }
        }
        //Thống kê sản phẩm sắp hết hàng
        public DataTable loadThongKeSPHetHang()
        {
            conn.openConnect();
            var cmd = new SqlCommand("ThongKe_SapHetHang", conn.conn);
            cmd.CommandType = CommandType.StoredProcedure;
            using (DataTable dt = new DataTable())
            {
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    da.Fill(dt);
                    conn.closeConnect();
                    return dt;
                }
            }
        }
        //Thống kê top 10 sản phẩm bán chạy nhất
        public DataTable loadThongKe_Top5SPBanChay(DateTime @fromDate, DateTime @toDate)
        {
            conn.openConnect();
            var cmd = new SqlCommand("ThongKe_Top5SPBanChay", conn.conn);
            cmd.CommandType = CommandType.StoredProcedure;
            using (DataTable dt = new DataTable())
            {
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    da.SelectCommand.Parameters.Add(new SqlParameter("@fromDate", SqlDbType.Date));
                    da.SelectCommand.Parameters["@fromDate"].Value = fromDate;
                    da.SelectCommand.Parameters.Add(new SqlParameter("@toDate", SqlDbType.Date));
                    da.SelectCommand.Parameters["@toDate"].Value = toDate;
                    da.Fill(dt);
                    conn.closeConnect();
                    return dt;
                }
            }
        }
        //Thống kê top 10 sản phẩm bán chậm nhất
        public DataTable loadThongKe_Top5SPBanCham(DateTime @fromDate, DateTime @toDate)
        {
            conn.openConnect();
            var cmd = new SqlCommand("ThongKe_Top5SPBanCham", conn.conn);
            cmd.CommandType = CommandType.StoredProcedure;
            using (DataTable dt = new DataTable())
            {
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    da.SelectCommand.Parameters.Add(new SqlParameter("@fromDate", SqlDbType.Date));
                    da.SelectCommand.Parameters["@fromDate"].Value = fromDate;
                    da.SelectCommand.Parameters.Add(new SqlParameter("@toDate", SqlDbType.Date));
                    da.SelectCommand.Parameters["@toDate"].Value = toDate;
                    da.Fill(dt);
                    conn.closeConnect();
                    return dt;
                }
            }
        }
        //Thống kê KH tiềm năng
        public DataTable loadThongKe_KHTiemNang(DateTime fromDate, DateTime toDate)
        {
            conn.openConnect();
            var cmd = new SqlCommand("ThongKeKHTiemNang", conn.conn);
            cmd.CommandType = CommandType.StoredProcedure;
            using (DataTable dt = new DataTable())
            {
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    da.SelectCommand.Parameters.Add(new SqlParameter("@fromDate", SqlDbType.Date));
                    da.SelectCommand.Parameters["@fromDate"].Value = fromDate;
                    da.SelectCommand.Parameters.Add(new SqlParameter("@toDate", SqlDbType.Date));
                    da.SelectCommand.Parameters["@toDate"].Value = toDate;
                    da.Fill(dt);
                    conn.closeConnect();
                    return dt;
                }
            }
        }
        //Thống kê tình trạng phiếu thanh lý đã thanh lý
        public DataTable loadThongKe_DaThanhLy(DateTime fromDate, DateTime toDate)
        {
            conn.openConnect();
            var cmd = new SqlCommand("ThongKe_DaThanhLy", conn.conn);
            cmd.CommandType = CommandType.StoredProcedure;
            using (DataTable dt = new DataTable())
            {
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    da.SelectCommand.Parameters.Add(new SqlParameter("@fromDate", SqlDbType.Date));
                    da.SelectCommand.Parameters["@fromDate"].Value = fromDate;
                    da.SelectCommand.Parameters.Add(new SqlParameter("@toDate", SqlDbType.Date));
                    da.SelectCommand.Parameters["@toDate"].Value = toDate;
                    da.Fill(dt);
                    conn.closeConnect();
                    return dt;
                }
            }
        }
        //Thống kê tình trạng phiếu thanh lý chưa thanh lý
        public DataTable loadThongKe_ChuaThanhLy()
        {
            conn.openConnect();
            var cmd = new SqlCommand("ThongKe_ChuaThanhLy", conn.conn);
            cmd.CommandType = CommandType.StoredProcedure;
            using (DataTable dt = new DataTable())
            {
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    da.Fill(dt);
                    conn.closeConnect();
                    return dt;
                }
            }
        }
    }
}
