using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAO;
using System.Data.SqlClient;

namespace BUS
{
    public class BackupAndRestoreBUS
    {
        BackupAndRestoreDAO aa = new BackupAndRestoreDAO();
        public int backup(string path)
        {
            try
            {
                return (aa.backup(path));
            }
            catch (SqlException)
            {

                throw;
            }
        }
        public void restore(string path)
        {
            aa.restore(path);
        }
    }
}
