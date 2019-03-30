using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DTO;
using System.Data.SqlClient;

namespace DAO
{
    public class LoginDAO:Dataprovider
    {
        public bool Login(LoginDTO acc)
        {
            string sql = "SELECT COUNT (UserName) FROM Users WHERE UserName = '" + acc.UserName + "'AND Password ='" + acc.Password + "'";
            int number;
            try
            {
                number = myExcuteScalar(sql);
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
            if (number > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public int UpdateAccount(LoginDTO acc, string passNew)
        {
            string sql = "UPDATE Users SET Password = '" + passNew + "' WHERE UserName = '" + acc.UserName + "' AND Password = '" + acc.Password + "'";

            try
            {
                return ExcuteNonquery(sql);
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }


        public int InsertAccount(LoginDTO acc)
        {
            string sql = "INSERT INTO Users VALUES ( '" + acc.UserName + "' , '" + acc.Password + "',2)";

            try
            {
                return ExcuteNonquery(sql);
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }
    }
}
