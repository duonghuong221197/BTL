using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DTO;
using System.Data.SqlClient;

namespace DAO
{
    public class HoaDonDAO:Dataprovider
    {
        public List<HoaDonDTO> data(string mahd)
        {
            Connect();
            List<HoaDonDTO> list = new List<HoaDonDTO>();
            string sql = "SELECT a.MaHDBan,a.MaHang,b.MaNhanVien,b.MaKhach,c.DonGiaBan,a.SoLuong,a.ThanhTien,b.NgayBan FROM ChiTietHDBan a ,HDBan b,Hang c WHERE a.MaHDBan=b.MaHDBan AND a.MaHang=c.MaHang AND a.MaHDBan = '" + mahd + "'";

            string MaHDBan;
            string MaHang;
            float SoLuong;
            float ThanhTien;
            string MaKhach;
            
            string MaNhanVien;
            float DonGiaBan;
            DateTime ngayban;
            try
            {
                SqlDataReader dr = ExecuteReader(sql);
                while (dr.Read())
                {
                    MaHDBan = dr.GetString(0);
                    MaHang = dr.GetString(1);
                    MaNhanVien = dr.GetString(2);
                    MaKhach = dr.GetString(3);
                    DonGiaBan = float.Parse(dr.GetDouble(4).ToString());
                    SoLuong = float.Parse(dr.GetDouble(5).ToString());
                
                    ThanhTien = float.Parse(dr.GetDouble(6).ToString());
                    ngayban = dr.GetDateTime(7);


                    HoaDonDTO kh = new HoaDonDTO(MaHDBan, MaHang, MaNhanVien,MaKhach, DonGiaBan, SoLuong, ThanhTien, ngayban);
                    list.Add(kh);
                }
                dr.Close();
                return list;
            }
            catch (SqlException)
            {

                throw;
            }

        }

        public int xoa(string MaHD,string MaHang)
        {
            try
            {
                string sql = "DELETE FROM ChiTietHDBan WHERE MaHDBan = N'" + MaHD + "'AND MaHang=N'" + MaHang + "'";
                int NumberOfRow = ExcuteNonquery(sql);
                return NumberOfRow;
            }
            catch (SqlException ex)
            {

                throw ex;
            }

        }

        public int them(HoaDonDTO acc)
        {
            try
            {
                string sql = "INSERT INTO ChiTietHDBan VALUES (N'" + acc.MaHD + "',N'" + acc.MaHang + "'," + acc.SoLuong + "," + acc.ThanhTien + ")";
                int NumberOfRow = ExcuteNonquery(sql);
                return NumberOfRow;
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }
    }
}
