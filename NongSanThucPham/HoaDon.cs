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
    public class HoaDon
    {
        Connection conn = new Connection();
        SqlDataAdapter da_HoaDon, da_CTHD;
        DataSet ds_HoaDon, ds_CTHD;

        public DataTable loadDonViTinhTheoSanPham(string masp)
        {
            string strSQL = "Select * From DonViTinh, SanPham Where DonViTinh.MaDVT = SanPham.MaDVT And MaSP='" + masp + "'";
            DataTable dt_DVT = new DataTable();
            SqlDataAdapter da_DVT = new SqlDataAdapter(strSQL, conn.conn);
            da_DVT.Fill(dt_DVT);
            return dt_DVT;
        }

        public DataTable loadLoHangTheoSanPhamChuaHetHan(string masp)
        {
            string strSQL = "Select * From LoHang Where HanSuDung >='" + DateTime.Now + "' And MaSP='" + masp + "'";
            DataTable dt_LoHang = new DataTable();
            SqlDataAdapter da_LoHang = new SqlDataAdapter(strSQL, conn.conn);
            da_LoHang.Fill(dt_LoHang);
            return dt_LoHang;
        }

        public string layGiaBanTheoSanPham(string masp)
        {
            string giaBan = "";
            string strSql = "Select * From SanPham Where MaSP='" + masp + "'";
            SqlDataReader dr = conn.getDataReader(strSql);
            while (dr.Read())
            {
                giaBan = dr["GiaBan"].ToString();
            }
            dr.Close();
            return giaBan;
        }

        public string layGiamGiaTheoSanPham(string masp)
        {
            string giamGia = "";
            string strSql = "Select * From SanPham Where MaSP='" + masp + "'";
            SqlDataReader dr = conn.getDataReader(strSql);
            while (dr.Read())
            {
                giamGia = dr["GiamGia"].ToString();
            }
            dr.Close();
            return giamGia;
        }

        public string laySoLuongSPTheoSanPham(string masp)
        {
            string soLuongSP = "";
            string strSql = "Select * From SanPham Where MaSP='" + masp + "'";
            SqlDataReader dr = conn.getDataReader(strSql);
            while (dr.Read())
            {
                soLuongSP = dr["SoLuongSP"].ToString();
            }
            dr.Close();
            return soLuongSP;
        }

        public string layKhauTru(string mahd)
        {
            string khauTru = "";
            string strSql = "Select * From HoaDon Where MaHoaDon='" + mahd + "'";
            SqlDataReader dr = conn.getDataReader(strSql);
            while (dr.Read())
            {
                khauTru = dr["KhauTru"].ToString();
            }
            dr.Close();
            return khauTru;
        }

        public int updateTongTien(string mahd)
        {
            int tongTien = 0;
            string strSql = "Select * From ChiTietHoaDon Where MaHoaDon = '" + mahd + "'";
            SqlDataReader tongTiendr = conn.getDataReader(strSql);
            while (tongTiendr.Read())
            {
                tongTien += int.Parse(tongTiendr["ThanhTien"].ToString());
            }
            tongTiendr.Close();
            return tongTien;
        }

        public string layTongTien(string mahd)
        {
            string tongTien = "";
            string strSql = "Select * From HoaDon Where MaHoaDon = '" + mahd + "'";
            SqlDataReader tongTiendr = conn.getDataReader(strSql);
            while (tongTiendr.Read())
            {
                tongTien = tongTiendr["TongTien"].ToString();
            }
            tongTiendr.Close();
            return tongTien;
        }

        public string layTienPhaiTra(string mahd)
        {
            string tienTra = "";
            string strSql = "Select * From HoaDon Where MaHoaDon = '" + mahd + "'";
            SqlDataReader tienTradr = conn.getDataReader(strSql);
            while (tienTradr.Read())
            {
                tienTra = tienTradr["TienPhaiTra"].ToString();
            }
            tienTradr.Close();
            return tienTra;
        }

        public string layMakhOHoaDon(string mahd)
        {
            string makh = "";
            string strSql = "Select * From HoaDon Where MaHoaDon = '" + mahd + "'";
            SqlDataReader makhdr = conn.getDataReader(strSql);
            while (makhdr.Read())
            {
                makh = makhdr["MaKH"].ToString();
            }
            makhdr.Close();
            return makh;
        }

        public string layMaHoaDon() //Lấy mã hóa đơn cuối cùng
        {
            string mahd = "";
            string strSql = "Select * From HoaDon";
            SqlDataReader dr = conn.getDataReader(strSql);
            while (dr.Read())
            {
                mahd = dr["MaHoaDon"].ToString();
            }
            dr.Close();
            return mahd;
        }

        public string laySoLuongBan(string mahd, string masp)
        {
            string soLuong = "";
            string strSql = "Select * From ChiTietHoaDon Where MaHoaDon = '" + mahd + "' And MaSP='" + masp + "'";
            SqlDataReader soLuongdr = conn.getDataReader(strSql);
            while (soLuongdr.Read())
            {
                soLuong = soLuongdr["SoLuongBan"].ToString();
            }
            soLuongdr.Close();
            return soLuong;
        }

        public string layGiaBan(string malo)
        {
            string gia = "";
            string strSql = "Select * From LoHang, BangGia Where LoHang.MaGia = BangGia.MaGia And MaLo = '" + malo + "'";
            //string strSql = "Select * From LoHang, SanPham, Gia_SanPham, BangGia Where LoHang.MaSP = SanPham.MaSP And SanPham.MaSP = Gia_SanPham.MaSP And BangGia.MaGia = Gia_SanPham.MaGia And MaLo = '" + malo + "'";
            SqlDataReader dr = conn.getDataReader(strSql);
            while (dr.Read())
            {
                gia = dr["GiaSP"].ToString();
            }
            dr.Close();
            return gia;
        }

        public DataTable searchHoaDon(string mahd)
        {
            DataTable table = new DataTable();
            string lenh = string.Format("Select * From HoaDon Where MaHoaDon = '" + mahd + "'");
            SqlDataAdapter da = new SqlDataAdapter(lenh, conn.conn);
            da.Fill(table);
            return table;
        }

        public DataTable searchHoaDonTheoMaKH(string makh)
        {
            DataTable table = new DataTable();
            string lenh = string.Format("Select * From HoaDon Where MaKH = '" + makh + "'");
            SqlDataAdapter da = new SqlDataAdapter(lenh, conn.conn);
            da.Fill(table);
            return table;
        }

        public DataTable searchHoaDonTheoNgayLap(string ngaylapdau, string ngaylapcuoi)
        {
            DataTable table = new DataTable();
            string lenh = string.Format("Select * From HoaDon Where '" + ngaylapdau + "' <= NgayLap And NgayLap <='" + ngaylapcuoi + "'");
            SqlDataAdapter da = new SqlDataAdapter(lenh, conn.conn);
            da.Fill(table);
            return table;
        }

        public DataTable loadHoaDon()
        {
            da_HoaDon = new SqlDataAdapter("Select * From HoaDon", conn.conn);
            DataTable dt_HoaDon = new DataTable();
            da_HoaDon.Fill(dt_HoaDon);
            return dt_HoaDon;
        }

        //Bảng trong giao diện lập hóa đơn
        public DataTable loadDataGV_CTHDTheoMaHD(string mahd)
        {
            da_CTHD = new SqlDataAdapter("Select MaHoaDon, ChiTietHoaDon.MaSP, SoLuongBan, ChiTietHoaDon.GiaBan, GiamGia, ThanhTien, MaLo From ChiTietHoaDon, SanPham Where ChiTietHoaDon.MaSP = SanPham.MaSP And MaHoaDon='" + mahd + "'", conn.conn);
            ds_CTHD = new DataSet();
            da_CTHD.Fill(ds_CTHD, "ChiTietHoaDon, SanPham");
            //DataColumn[] key = new DataColumn[1];
            //key[0] = ds_CTHD.Tables["ChiTietHoaDon, SanPham"].Columns[0];
            //ds_CTHD.Tables["ChiTietHoaDon, SanPham"].PrimaryKey = key;
            return ds_CTHD.Tables["ChiTietHoaDon, SanPham"];
        }

        public DataTable GetCTHD(string mahd)
        {
            string lenh = string.Format("Select MaHoaDon, ChiTietHoaDon.MaSP, SoLuongBan, ChiTietHoaDon.GiaBan, GiamGia, ThanhTien, MaLo From ChiTietHoaDon, SanPham Where ChiTietHoaDon.MaSP = SanPham.MaSP And MaHoaDon='" + mahd + "'");
            DataTable table = new DataTable();
            SqlDataAdapter adt = new SqlDataAdapter(lenh, conn.conn);
            adt.Fill(table);
            return table;
        }
        public DataTable layCTHD(string mahd)
        {
            return GetCTHD(mahd);
        }

        //Bảng trong giao diện các hóa đơn
        public DataTable loadDataGV_HoaDon()
        {
            da_HoaDon = new SqlDataAdapter("Select * From HoaDon", conn.conn);
            ds_HoaDon = new DataSet();
            da_HoaDon.Fill(ds_HoaDon, "HoaDon");
            DataColumn[] key = new DataColumn[1];
            key[0] = ds_HoaDon.Tables["HoaDon"].Columns["MaHoaDon"];
            ds_HoaDon.Tables["HoaDon"].PrimaryKey = key;
            return ds_HoaDon.Tables["HoaDon"];
        }

        public DataTable loadDataGV_ChiTietHoaDon()
        {
            string strSQL = "Select MaHoaDon, ChiTietHoaDon.MaSP, TenSP, TenDVT, SoLuongBan, ChiTietHoaDon.GiaBan, GiamGia, ThanhTien, MaLo From ChiTietHoaDon, SanPham, DonViTinh" +
                " Where ChiTietHoaDon.MaSP = SanPham.MaSP And SanPham.MaDVT = DonViTinh.MaDVT";
            da_CTHD = new SqlDataAdapter(strSQL, conn.conn);
            ds_CTHD = new DataSet();
            da_CTHD.Fill(ds_CTHD, "ChiTietHoaDon, SanPham, DonViTinh");

            return ds_CTHD.Tables["ChiTietHoaDon, SanPham, DonViTinh"];
        }

        public DataTable GetChiTietHoaDon(string mahd)
        {
            string lenh = string.Format("Select MaHoaDon, ChiTietHoaDon.MaSP, TenSP, TenDVT, SoLuongBan, ChiTietHoaDon.GiaBan, GiamGia, ThanhTien, MaLo From ChiTietHoaDon, SanPham, DonViTinh" +
                " Where ChiTietHoaDon.MaSP = SanPham.MaSP And SanPham.MaDVT = DonViTinh.MaDVT And MaHoaDon='" + mahd + "'");
            DataTable table = new DataTable();
            SqlDataAdapter adt = new SqlDataAdapter(lenh, conn.conn);
            adt.Fill(table);
            return table;
        }
        public DataTable layChiTietHoaDon(string mahd)
        {
            return GetChiTietHoaDon(mahd);
        }

        public DataTable loadThongKeTheoThang(DateTime fromDate, DateTime toDate)
        {
            conn.openConnect();
            var cmd = new SqlCommand("ThongKeDoanhThu_Thang", conn.conn);
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
        public DataTable loadThongKeTheoNhanVien(DateTime fromDate, DateTime toDate)
        {
            conn.openConnect();
            var cmd = new SqlCommand("ThongKeDoanhThu_NhanVien", conn.conn);
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
        public DataTable loadThongKeTheoKhachHang(DateTime fromDate, DateTime toDate)
        {
            conn.openConnect();
            var cmd = new SqlCommand("ThongKeDoanhThu_KhachHang", conn.conn);
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
        public DataTable loadThongKeTheoMatHang(DateTime fromDate, DateTime toDate)
        {
            conn.openConnect();
            var cmd = new SqlCommand("ThongKeDoanhThu_MatHang", conn.conn);
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
    }
}
