using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using DTO;
using DAO;

namespace BUS
{
    public class KhachBUS
    {
        public List<KhachDTO> data()
        {
            try
            {
                return (new KhachDAO().getKH());
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
                return (new KhachDAO().them(acc));
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public int xoa(string MaKhach)
        {
            try
            {
                return (new KhachDAO().xoa(MaKhach));
            }
            catch (SqlException)
            {
                
                throw;
            }
        }
        public int sua(KhachDTO acc)
        {
            try
            {
                return (new KhachDAO().sua(acc));
            }
            catch (SqlException)
            {               
                throw;
            }
        }

        public List<KhachDTO> getKHVualue(string name)
        {
            try
            {
                return (new KhachDAO().getKHVualue(name));
            }
            catch (SqlException)
            {

                throw;
            }
        }
    }
}
