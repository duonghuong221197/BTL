using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace DAO
{
    public class BackupAndRestoreDAO:Dataprovider
    {
        
        public int backup(string path)
        {
            string database = "QuanLyBanHang";
            try
            {
               
                Connect();
                string sql = "backup DATABASE " + database + " TO DISK ='" + path + "\\" + "database" + "-" + DateTime.Now.ToString("yyyy-MM-dd--HH-mm-ss") + ".bak' WITH FORMAT;";
                int NumberOfRow = ExcuteNonquery(sql);

                return NumberOfRow; 
            }
            catch (SqlException)
            {
                
                throw;
            }
        }

        public void restore(string path) 
        {
            try
            {
                string database = "QuanLyBanHang";
                string sqlStmt2 = string.Format("ALTER DATABASE " + database + " SET SINGLE_USER WITH ROLLBACK IMMEDIATE");
                int NumberOfRow = ExcuteNonquery(sqlStmt2);

                string sqlStmt3 = "USE MASTER RESTORE DATABASE " + database + " FROM DISK='" + path + "'WITH REPLACE;";
                int NumberOfRow3 = ExcuteNonquery(sqlStmt3);

                string sqlStmt4 = string.Format("ALTER DATABASE " + database + " SET MULTI_USER");
                int NumberOfRow4 = ExcuteNonquery(sqlStmt4);
            }
            catch (SqlException)
            {
                
                throw;
            }

        }
    }
}
