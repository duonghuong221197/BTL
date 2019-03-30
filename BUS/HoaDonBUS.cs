using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using DTO;
using DAO;

namespace BUS
{
    public class HoaDonBUS
    {
        public List<HoaDonDTO> data(string mahd)
        {
            try
            {
                return (new HoaDonDAO().data(mahd));
            }
            catch (SqlException)
            {
                throw;
            }
        }

        public int xoa(string MaHD, string MaHang)
        {
            try
            {
                return (new HoaDonDAO().xoa(MaHD, MaHang));
            }
            catch (SqlException)
            {

                throw;
            }
        }

        public int them(HoaDonDTO acc)
        {
            try
            {
                return (new HoaDonDAO().them(acc));
            }
            catch (SqlException)
            {

                throw;
            }
        }
    }
}
