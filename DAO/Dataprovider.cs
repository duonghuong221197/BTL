using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace DAO
{
    public class Dataprovider
    {
        SqlConnection cn = null;
        public Dataprovider()
        {
            string cnstr = "Data Source=DELL-PC\\SQLEXPRESS;Initial Catalog=QuanLyBanHang;Integrated Security=True";
            cn = new SqlConnection(cnstr);
        }
        public void Connect()
        {
            if (cn != null && cn.State != System.Data.ConnectionState.Open)
            {
                cn.Open();
            }
        }
        public void DisConnect()
        {
            if (cn != null && cn.State != System.Data.ConnectionState.Closed)
            {
                cn.Close();
            }
        }
        public int myExcuteScalar (string sql)
        {
           
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandText= sql;
            cmd.CommandType = System.Data.CommandType.Text;
            Connect();
            try
            {
                int number = (int)cmd.ExecuteScalar();
                return number;
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
            finally
            {
                DisConnect();
            }
       }
        public SqlDataReader ExecuteReader(string sql)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandText = sql;
            cmd.CommandType = System.Data.CommandType.Text;
            try
            {
                return (cmd.ExecuteReader());
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public int ExcuteNonquery(string sql)//, List<SqlParameter> parameters)
        {
            SqlCommand cmd = new SqlCommand(sql, cn);
            cmd.CommandType = CommandType.Text;
            /*if (parameters != null)
            {
                foreach (SqlParameter parameter in parameters)
                {
                    cmd.Parameters.Add(parameter);
                }
            }*/
            Connect();
            try
            {
                return cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {

                throw ex;
            }
            finally
            {
                DisConnect();
            }
        }
    }
}
