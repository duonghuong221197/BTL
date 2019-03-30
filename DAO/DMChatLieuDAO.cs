using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using DTO;

namespace DAO
{
    public class DMChatLieuDAO:Dataprovider
    {
        public List<DMChatLieuDTO> getCL()
        {
            Connect();
            List<DMChatLieuDTO> list = new List<DMChatLieuDTO>();
            string sql = "SELECT *FROM ChatLieu";

            string MaChatLieu;
            string TenChatLieu;
          
            try
            {
                SqlDataReader dr = ExecuteReader(sql);
                while (dr.Read())
                {
                    MaChatLieu = dr.GetString(0);
                    TenChatLieu = dr.GetString(1);
                   
                    DMChatLieuDTO cl = new DMChatLieuDTO(MaChatLieu, TenChatLieu);
                    list.Add(cl);
                }
                dr.Close();
                return list;
            }
            catch (SqlException)
            {

                throw;
            }
         
        }
        public int them(DMChatLieuDTO cl)
        {         
            try
            {
                string sql = "INSERT INTO ChatLieu VALUES (N'" + cl.MaChatLieu + "',N'" + cl.TenChatLieu  + "')";
                int NumberOfRow = ExcuteNonquery(sql);
                return NumberOfRow;
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }

        public int xoa(string MaChatLieu)
        {
            try
            {
                string sql = "DELETE FROM ChatLieu WHERE MaChatLieu = N'" + MaChatLieu + "'";
                int NumberOfRow = ExcuteNonquery(sql);
                return NumberOfRow;
            }
            catch (SqlException ex)
            {

                throw ex;
            }

        }

        public int sua(DMChatLieuDTO acc)
        {
            Connect();
            try
            {
                string sql = "UPDATE ChatLieu SET TenChatLieu = N'" + acc.TenChatLieu + "'WHERE MaChatLieu = N'" + acc.MaChatLieu+"' ";
                int NumberOfRow = ExcuteNonquery(sql);
                return NumberOfRow;
            }
            catch (SqlException ex)
            {
                throw ex;
            }

        }

        public List<DMChatLieuDTO> getCLValue(String name )
        {
            Connect();
            List<DMChatLieuDTO> list = new List<DMChatLieuDTO>();
            string sql = "SELECT *FROM ChatLieu WHERE MaChatLieu=N'"+name+"'";

            string MaChatLieu;
            string TenChatLieu;

            try
            {
                SqlDataReader dr = ExecuteReader(sql);
                while (dr.Read())
                {
                    MaChatLieu = dr.GetString(0);
                    TenChatLieu = dr.GetString(1);

                    DMChatLieuDTO cl = new DMChatLieuDTO(MaChatLieu, TenChatLieu);
                    list.Add(cl);
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
