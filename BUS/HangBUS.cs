using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using DTO;
using DAO;

namespace BUS
{
    public class HangBUS
    {
        public List<DMHangDTO> data()
        {
            try
            {
                return (new HangDAO().getHA());
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
                return (new HangDAO().them(acc));
            }
            catch (Exception)
            {

                throw;
            }
        }

        public int xoa(string MaHang)
        {
            try
            {
                return (new HangDAO().xoa(MaHang));
            }
            catch (SqlException)
            {

                throw;
            }
        }

        public int sua(DMHangDTO acc)
        {
            try
            {
                return (new HangDAO().sua(acc));
            }
            catch (SqlException)
            {
                throw;
            }
        }

        public int suasoluong(int acc, string mahang)
        {
            try
            {
                return (new HangDAO().suasoluong(acc,mahang));
            }
            catch (SqlException)
            {
                throw;
            }
        }

        public List<DMHangDTO> getHAValue(string name)
        {
            try
            {
                return (new HangDAO().getHAValue(name));
            }
            catch (SqlException)
            {

                throw;
            }
        }
    }
}
