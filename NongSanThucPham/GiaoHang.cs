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
    public class GiaoHang
    {
        Connection conn = new Connection();
        SqlDataAdapter da_GiaoHang, da_CTGH;
        DataSet ds_GiaoHang, ds_CTGH;

        public DataTable loadDonViTinhTheoSanPham(string masp)
        {
            string strSQL = "Select * From DonViTinh, SanPham Where DonViTinh.MaDVT = SanPham.MaDVT And MaSP='" + masp + "'";
            DataTable dt_DVT = new DataTable();
            SqlDataAdapter da_DVT = new SqlDataAdapter(strSQL, conn.conn);
            da_DVT.Fill(dt_DVT);
            return dt_DVT;
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

        public string layMaPhieuGiao() //Lấy mã phiếu giao cuối cùng
        {
            string magh = "";
            string strSql = "Select * From PhieuGiaoHang";
            SqlDataReader dr = conn.getDataReader(strSql);
            while (dr.Read())
            {
                magh = dr["MaPGH"].ToString();
            }
            dr.Close();
            return magh;
        }

        public int updateTongTien(string magh)
        {
            int tongTien = 0;
            string strSql = "Select * From ChiTietPhieuGiaoHang Where MaPGH = '" + magh + "'";
            SqlDataReader tongTiendr = conn.getDataReader(strSql);
            while (tongTiendr.Read())
            {
                tongTien += int.Parse(tongTiendr["ThanhTien"].ToString());
            }
            tongTiendr.Close();
            return tongTien;
        }

        public string layTongTien(string magh)
        {
            string tongTien = "";
            string strSql = "Select * From PhieuGiaoHang Where MaPGH = '" + magh + "'";
            SqlDataReader tongTiendr = conn.getDataReader(strSql);
            while (tongTiendr.Read())
            {
                tongTien = tongTiendr["TongTien"].ToString();
            }
            tongTiendr.Close();
            return tongTien;
        }

        public string layTienPhaiTra(string magh)
        {
            string tienTra = "";
            string strSql = "Select * From PhieuGiaoHang Where MaPGH = '" + magh + "'";
            SqlDataReader tienTradr = conn.getDataReader(strSql);
            while (tienTradr.Read())
            {
                tienTra = tienTradr["TienPhaiTra"].ToString();
            }
            tienTradr.Close();
            return tienTra;
        }

        public string laySDTGiao(string mahd)
        {
            string sdt = "";
            string strSql = "Select * From HoaDon, KhachHang Where HoaDon.MaKH = KhachHang.MaKH And MaHoaDon = '" + mahd + "'";
            SqlDataReader sdtdr = conn.getDataReader(strSql);
            while (sdtdr.Read())
            {
                sdt = sdtdr["DienThoai"].ToString();
            }
            sdtdr.Close();
            return sdt;
        }

        public string layDiaChiGiao(string mahd)
        {
            string sdt = "";
            string strSql = "Select * From HoaDon, KhachHang Where HoaDon.MaKH = KhachHang.MaKH And MaHoaDon = '" + mahd + "'";
            SqlDataReader sdtdr = conn.getDataReader(strSql);
            while (sdtdr.Read())
            {
                sdt = sdtdr["DiaChi"].ToString();
            }
            sdtdr.Close();
            return sdt;
        }

        public string layMaHD(string magh)
        {
            string mahd = "";
            string strSql = "Select * From PhieuGiaoHang Where MaPGH= '" + magh + "'";
            SqlDataReader mahddr = conn.getDataReader(strSql);
            while (mahddr.Read())
            {
                mahd = mahddr["MaHoaDon"].ToString();
            }
            mahddr.Close();
            return mahd;
        }

        public string layTinhTrang(string magh)
        {
            string ttrang = "";
            string strSql = "Select * From PhieuGiaoHang Where MaPGH= '" + magh + "'";
            SqlDataReader ttrangdr = conn.getDataReader(strSql);
            while (ttrangdr.Read())
            {
                ttrang = ttrangdr["TinhTrang"].ToString();
            }
            ttrangdr.Close();
            return ttrang;
        }

        public DataTable loadHoaDonChuaGiao()
        {
            string strSQL = string.Format("Select * From HoaDon Where TinhTrang=N'Chưa giao hàng'");
            DataTable dt_HoaDon = new DataTable();
            SqlDataAdapter da_HoaDon = new SqlDataAdapter(strSQL, conn.conn);
            da_HoaDon.Fill(dt_HoaDon);
            return dt_HoaDon;
        }

        public DataTable loadKhuyenMaiTheoHoaDon(string mahd)
        {
            string strSQL = "Select * From KhuyenMai, HoaDon Where KhuyenMai.MaKM = HoaDon.MaKM And MaHoaDon='" + mahd + "'";
            DataTable dt_KM = new DataTable();
            SqlDataAdapter da_KM = new SqlDataAdapter(strSQL, conn.conn);
            da_KM.Fill(dt_KM);
            return dt_KM;
        }

        public DataTable searchPhieuGiaoHang(string magh)
        {
            DataTable table = new DataTable();
            string lenh = string.Format("Select * From PhieuGiaoHang Where MaPGH = '" + magh + "'");
            SqlDataAdapter da = new SqlDataAdapter(lenh, conn.conn);
            da.Fill(table);
            return table;
        }

        public DataTable searchPhieuGiaoHangTheoNgayGiao(string ngaylapdau, string ngaylapcuoi)
        {
            DataTable table = new DataTable();
            string lenh = string.Format("Select * From PhieuGiaoHang Where '" + ngaylapdau + "' <= NgayGiao And NgayGiao <='" + ngaylapcuoi + "'");
            SqlDataAdapter da = new SqlDataAdapter(lenh, conn.conn);
            da.Fill(table);
            return table;
        }

        //Bảng trong giao diện lập phiếu giao hàng
        public DataTable loadDataGV_CTPGHTheoMaPGH(string magh)
        {
            da_CTGH = new SqlDataAdapter("Select MaPGH, ChiTietPhieuGiaoHang.MaSP, SoLuongBan, GiaXuat, GiamGia, ThanhTien From ChiTietPhieuGiaoHang, SanPham Where ChiTietPhieuGiaoHang.MaSP = SanPham.MaSP And MaPGH='" + magh + "'", conn.conn);
            ds_CTGH = new DataSet();
            da_CTGH.Fill(ds_CTGH, "ChiTietPhieuGiaoHang, SanPham");
            //DataColumn[] key = new DataColumn[1];
            //key[0] = ds_CTHD.Tables["ChiTietPhieuGiaoHang, SanPham"].Columns[0];
            //ds_CTHD.Tables["ChiTietPhieuGiaoHang, SanPham"].PrimaryKey = key;
            return ds_CTGH.Tables["ChiTietPhieuGiaoHang, SanPham"];
        }

        public DataTable GetCTPGH(string magh)
        {
            string lenh = string.Format("Select MaPGH, ChiTietPhieuGiaoHang.MaSP, SoLuongBan, GiaXuat, GiamGia, ThanhTien From ChiTietPhieuGiaoHang, SanPham Where ChiTietPhieuGiaoHang.MaSP = SanPham.MaSP And MaPGH='" + magh + "'");
            DataTable table = new DataTable();
            SqlDataAdapter adt = new SqlDataAdapter(lenh, conn.conn);
            adt.Fill(table);
            return table;
        }
        public DataTable layCTPGH(string magh)
        {
            return GetCTPGH(magh);
        }

        //Bảng trong giao diện các phiếu giao hàng
        public DataTable loadDataGV_PhieuGiaoHang()
        {
            da_GiaoHang = new SqlDataAdapter("Select * From PhieuGiaoHang", conn.conn);
            ds_GiaoHang = new DataSet();
            da_GiaoHang.Fill(ds_GiaoHang, "PhieuGiaoHang");
            DataColumn[] key = new DataColumn[1];
            key[0] = ds_GiaoHang.Tables["PhieuGiaoHang"].Columns["MaPGH"];
            ds_GiaoHang.Tables["PhieuGiaoHang"].PrimaryKey = key;
            return ds_GiaoHang.Tables["PhieuGiaoHang"];
        }

        public DataTable loadDataGV_ChiTietPhieuGiaoHang()
        {
            string strSQL = "Select MaPGH, ChiTietPhieuGiaoHang.MaSP, TenSP, TenDVT, SoLuongBan, GiaXuat, GiamGia, ThanhTien From ChiTietPhieuGiaoHang, SanPham, DonViTinh" +
                " Where ChiTietPhieuGiaoHang.MaSP = SanPham.MaSP And SanPham.MaDVT = DonViTinh.MaDVT";
            da_CTGH = new SqlDataAdapter(strSQL, conn.conn);
            ds_CTGH = new DataSet();
            da_CTGH.Fill(ds_CTGH, "ChiTietPhieuGiaoHang, SanPham, DonViTinh");

            return ds_CTGH.Tables["ChiTietPhieuGiaoHang, SanPham, DonViTinh"];
        }

        public DataTable GetChiTietPhieuGiaoHang(string magh)
        {
            string lenh = string.Format("Select MaPGH, ChiTietPhieuGiaoHang.MaSP, TenSP, TenDVT, SoLuongBan, GiaXuat, GiamGia, ThanhTien From ChiTietPhieuGiaoHang, SanPham, DonViTinh" +
                " Where ChiTietPhieuGiaoHang.MaSP = SanPham.MaSP And SanPham.MaDVT = DonViTinh.MaDVT And MaPGH='" + magh + "'");
            DataTable table = new DataTable();
            SqlDataAdapter adt = new SqlDataAdapter(lenh, conn.conn);
            adt.Fill(table);
            return table;
        }
        public DataTable layChiTietPhieuGiaoHang(string magh)
        {
            return GetChiTietPhieuGiaoHang(magh);
        }
    }
}
