using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DTO;
using System.Data.SqlClient;

namespace DAO
{
    public class HoaDonBanDAO:Dataprovider
    {
        public List<HoaDonBanDTO> data()
        {
            Connect();
            List<HoaDonBanDTO> list = new List<HoaDonBanDTO>();
            string sql = "SELECT *FROM HDBan";

            string Makhach;
            string MaHDBan;
            string MaNV;
            DateTime NgayBan;
           
            try
            {
                SqlDataReader dr = ExecuteReader(sql);
                while (dr.Read())
                {
                    MaHDBan = dr.GetString(0);
                    MaNV = dr.GetString(1);
                    NgayBan = dr.GetDateTime(2);
                    Makhach = dr.GetString(3);
                    

                    HoaDonBanDTO kh = new HoaDonBanDTO(MaHDBan, MaNV, NgayBan, Makhach);
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

        public int them(HoaDonBanDTO acc)
        {
            try
            {
                string sql = "INSERT INTO HDBan VALUES (N'" + acc.MaHDBan + "',N'" + acc.MaNV + "','" + acc.NgayBan + "',N'" + acc.MaKhach + "')";
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
                string sql = "DELETE FROM HDBan WHERE MaHDBan = N'" + MaKhach + "'";
                int NumberOfRow = ExcuteNonquery(sql);
                return NumberOfRow;
            }
            catch (SqlException ex)
            {

                throw ex;
            }

        }

        public List<HoaDonBanDTO> dataValue(string name)
        {
            Connect();
            List<HoaDonBanDTO> list = new List<HoaDonBanDTO>();
            string sql = "SELECT *FROM HDBan WHERE MaHDBan = N'"+name+"'";

            string Makhach;
            string MaHDBan;
            string MaNV;
            DateTime NgayBan;

            try
            {
                SqlDataReader dr = ExecuteReader(sql);
                while (dr.Read())
                {
                    MaHDBan = dr.GetString(0);
                    MaNV = dr.GetString(1);
                    NgayBan = dr.GetDateTime(2);
                    Makhach = dr.GetString(3);


                    HoaDonBanDTO kh = new HoaDonBanDTO(MaHDBan, MaNV, NgayBan, Makhach);
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
