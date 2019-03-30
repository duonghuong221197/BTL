using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using DTO;
using DAO;

namespace BUS
{
    public class LoginBUS
    {
        LoginDAO loginbus = new LoginDAO();
        public bool Login(LoginDTO acc)
        {
            try
            {
                return loginbus.Login(acc);
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }

        public int UpdateAccount(LoginDTO acc,string passNew)
        {
            try
            {
                return loginbus.UpdateAccount(acc, passNew);
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }

        public int InsertAccount(LoginDTO acc)
        {
            try
            {
                return loginbus.InsertAccount(acc);
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }
    }
}
