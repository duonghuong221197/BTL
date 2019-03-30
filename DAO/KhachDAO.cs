using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using DTO;

namespace DAO
{
   public class KhachDAO:Dataprovider
    {
       public List<KhachDTO> getKH()
       {
           Connect();
           List<KhachDTO> list = new List<KhachDTO>();
           string sql = "SELECT *FROM Khach";
           
           string Makhach;
           string TenKhach;
           string DiaChi;
           string DienThoai;
           try
           {
               SqlDataReader dr = ExecuteReader(sql);
               while (dr.Read())
               {
                   Makhach = dr.GetString(0);
                   TenKhach = dr.GetString(1);
                   DiaChi = dr.GetString(2);
                   DienThoai = dr.GetString(3);

                   KhachDTO kh = new KhachDTO(Makhach, TenKhach, DiaChi, DienThoai);
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
       public int them(KhachDTO acc)
       {      
           try
           {
               string sql = "INSERT INTO Khach VALUES (N'" + acc.MaKhach + "',N'" + acc.TenKhach + "',N'" + acc.DiaChi + "',N'" + acc.DienThoai + "')";
               int NumberOfRow = ExcuteNonquery(sql);
               return NumberOfRow;
           }
           catch (SqlException ex)
           {

               throw ex;
           }
       }
       public int xoa(string MaKhach)
       {
           try
           {
               string sql = "DELETE FROM Khach WHERE MaKhach = N'" + MaKhach + "'";
               int NumberOfRow = ExcuteNonquery(sql);
               return NumberOfRow;
           }
           catch (SqlException ex)
           {

               throw ex;
           }
          
       }
       public int sua(KhachDTO acc)
       {
           Connect();
           try
           {
               string sql = "UPDATE Khach SET TenKhach = N'" + acc.TenKhach + "', DiaChi = N'" + acc.DiaChi + "',DienThoai=N'" + acc.DienThoai + "' WHERE MaKhach = N'" + acc.MaKhach+"' ";
               int NumberOfRow = ExcuteNonquery(sql);
               return NumberOfRow;
           }
           catch (SqlException ex)
           {
               throw ex;
           }

       }


       public List<KhachDTO> getKHVualue(string name)
       {
           Connect();
           List<KhachDTO> list = new List<KhachDTO>();
           string sql = "SELECT *FROM Khach WHERE MaKhach=N'"+name+"'";

           string Makhach;
           string TenKhach;
           string DiaChi;
           string DienThoai;
           try
           {
               SqlDataReader dr = ExecuteReader(sql);
               while (dr.Read())
               {
                   Makhach = dr.GetString(0);
                   TenKhach = dr.GetString(1);
                   DiaChi = dr.GetString(2);
                   DienThoai = dr.GetString(3);

                   KhachDTO kh = new KhachDTO(Makhach, TenKhach, DiaChi, DienThoai);
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
    }
}
