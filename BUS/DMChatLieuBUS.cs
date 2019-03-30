using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using DTO;
using DAO;

namespace BUS
{
    public class DMChatLieuBUS
    {
        public List<DMChatLieuDTO> data()
        {
            try
            {
                return (new DMChatLieuDAO().getCL());
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
                return (new DMChatLieuDAO().them(cl));
            }
            catch (SqlException)
            {
                
                throw;
            }
        }

        public int xoa(string MaChatLieu)
        {
            try
            {
                return (new DMChatLieuDAO().xoa(MaChatLieu));
            }
            catch (SqlException)
            {

                throw;
            }
        }
        public int sua(DMChatLieuDTO acc)
        {
            try
            {
                return (new DMChatLieuDAO().sua(acc));
            }
            catch (SqlException)
            {
                throw;
            }
        }


        public List<DMChatLieuDTO> dataValue(String name)
        {
            try
            {
                return (new DMChatLieuDAO().getCLValue(name));
            }
            catch (SqlException)
            {

                throw;
            }
        }
    }
}
