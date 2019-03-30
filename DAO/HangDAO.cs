using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using DTO;

namespace DAO
{
   public class HangDAO:Dataprovider
    {
       public List<DMHangDTO> getHA()
       {
           Connect();
           List<DMHangDTO> list = new List<DMHangDTO>();
           string sql = "SELECT * FROM Hang";

           string MaHang;
           string TenHang;
           string MaChatLieu;
           float SoLuong;
           float DonGiaNhap;
           float DonGiaBan;
           string Anh;
           string GhiChu;
           DateTime NgayXuatHD;          

           try
           {
               SqlDataReader dr = ExecuteReader(sql);
               while (dr.Read())
               {
                   MaHang = dr.GetString(0);
                   TenHang = dr.GetString(1);
                   MaChatLieu = dr.GetString(2);
                   SoLuong = float.Parse(dr.GetDouble(3).ToString());
                   DonGiaNhap = float.Parse(dr.GetDouble(4).ToString());
                   DonGiaBan = float.Parse(dr.GetDouble(5).ToString());
                   Anh = dr.GetString(6);
                   GhiChu = dr.GetString(7);
                   NgayXuatHD = dr.GetDateTime(8);


                   DMHangDTO ha = new DMHangDTO(MaHang, TenHang, MaChatLieu, SoLuong, DonGiaNhap, DonGiaBan, Anh, GhiChu, NgayXuatHD);
                   list.Add(ha);
               }
               dr.Close();
               return list;
           }
           catch (SqlException)
           {

               throw;
           }

       }


       public int them(DMHangDTO acc)
       {
           try
           {
               string sql = "INSERT INTO Hang VALUES (N'" + acc.MaHang + "',N'" + acc.TenHang + "',N'" + acc.MaChatLieu + "'," + acc.SoLuong + ","+acc.DonGiaNhap+","+acc.DonGiaBan+",N'"+acc.Anh+"',N'"+acc.GhiChu+"','"+acc.NgayXuatHD+"')";
               int NumberOfRow = ExcuteNonquery(sql);
               return NumberOfRow;
           }
           catch (SqlException ex)
           {

               throw ex;
           }
       }

       public int xoa(string MaHang)
       {
           try
           {
               string sql = "DELETE FROM Hang WHERE MaHang = N'" + MaHang + "'";
               int NumberOfRow = ExcuteNonquery(sql);
               return NumberOfRow;
           }
           catch (SqlException ex)
           {

               throw ex;
           }

       }


       public int sua(DMHangDTO acc)
       {
           Connect();
           try
           {
               string sql = "UPDATE Hang SET TenHang= N'" + acc.TenHang + "',MaChatLieu =N'" + acc.MaChatLieu + "',SoLuong=" + acc.SoLuong + ",DonGiaNhap=" + acc.DonGiaNhap + ",DonGiaBan=" + acc.DonGiaBan + ",Anh=N'" + acc.Anh + "',GhiChu=N'" + acc.GhiChu + "',NgayXuatHD='" + acc.NgayXuatHD + "' WHERE MaHang = N'"+acc.MaHang+"'";
               int NumberOfRow = ExcuteNonquery(sql);
               return NumberOfRow;
           }
           catch (SqlException ex)
           {
               throw ex;
           }

       }

       public int suasoluong(int acc,string mahang)
       {
           Connect();
           try
           {
               string sql = "UPDATE Hang SET SoLuong=" + acc + " WHERE MaHang = N'" + mahang + "'";
               int NumberOfRow = ExcuteNonquery(sql);
               return NumberOfRow;
           }
           catch (SqlException ex)
           {
               throw ex;
           }

       }

       public List<DMHangDTO> getHAValue(string name )
       {
           Connect();
           List<DMHangDTO> list = new List<DMHangDTO>();
           string sql = "SELECT * FROM Hang WHERE MaHang=N'"+name+"'";

           string MaHang;
           string TenHang;
           string MaChatLieu;
           float SoLuong;
           float DonGiaNhap;
           float DonGiaBan;
           string Anh;
           string GhiChu;
           DateTime NgayXuatHD;

           try
           {
               SqlDataReader dr = ExecuteReader(sql);
               while (dr.Read())
               {
                   MaHang = dr.GetString(0);
                   TenHang = dr.GetString(1);
                   MaChatLieu = dr.GetString(2);
                   SoLuong = float.Parse(dr.GetDouble(3).ToString());
                   DonGiaNhap = float.Parse(dr.GetDouble(4).ToString());
                   DonGiaBan = float.Parse(dr.GetDouble(5).ToString());
                   Anh = dr.GetString(6);
                   GhiChu = dr.GetString(7);
                   NgayXuatHD = dr.GetDateTime(8);


                   DMHangDTO ha = new DMHangDTO(MaHang, TenHang, MaChatLieu, SoLuong, DonGiaNhap, DonGiaBan, Anh, GhiChu, NgayXuatHD);
                   list.Add(ha);
               }
               dr.Close();
               return list;
           }
           catch (SqlException)
           {

               throw;
           }

       }
    }
}
