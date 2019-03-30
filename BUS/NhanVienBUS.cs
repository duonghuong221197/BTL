using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using DTO;
using DAO;

namespace BUS
{
    public class NhanVienBUS
    {
        public List<NhanVienDTO> data()
        {
            try
            {
                return (new NhanVienDAO().getNV());
            }
            catch (SqlException)
            {
                
                throw;
            }
        }
        public int them(NhanVienDTO nv)
        {
            try
            {
                return (new NhanVienDAO().them(nv));
            }
            catch (SqlException)
            {
                
                throw;
            }
        }

        public int xoa(string MaNhanVien)
        {
            try
            {
                return (new NhanVienDAO().xoa(MaNhanVien));
            }
            catch (Exception)
            {

                throw;
            }
        }

        public int sua(NhanVienDTO acc)
        {
            try
            {
                return (new NhanVienDAO().sua(acc));
            }
            catch (SqlException)
            {
                throw;
            }
        }

        public List<NhanVienDTO> getvnValue(string name)
        {
            try
            {
                return (new NhanVienDAO().getvnValue(name));
            }
            catch (SqlException)
            {

                throw;
            }
        }
    }
}
