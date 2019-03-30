using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using DTO;
using DAO;

namespace BUS
{
    public class HoaDonBanBUS
    {
        public List<HoaDonBanDTO> data()
        {
            try
            {
                return (new HoaDonBanDAO().data());
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
                return (new HoaDonBanDAO().them(acc));
            }
            catch (Exception)
            {

                throw;
            }
        }

        public int xoa(string acc)
        {
            try
            {
                return (new HoaDonBanDAO().xoa(acc));
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<HoaDonBanDTO> dataValue(string name)
        {
            try
            {
                return (new HoaDonBanDAO().dataValue(name));
            }
            catch (SqlException)
            {
                throw;
            }
        }
    }
}
