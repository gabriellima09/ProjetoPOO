using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Bym.UI.Models.DAL
{
    public class DbContext
    {
        private static string ConnectionString
        {
            get
            {
                return DbUtil.ConnectionString;
            }
        }

        private static SqlConnection _SqlConnection
        {
            get
            {
                return new SqlConnection(ConnectionString);
            }
        }

        public static void ExecuteQuery(string query)
        {
            try
            {
                using (var conn = _SqlConnection)
                {
                    using (var cmd = new SqlCommand(query, conn))
                    {
                        cmd.CommandType = CommandType.Text;

                        conn.Open();

                        cmd.ExecuteScalar();
                    }
                }

                _SqlConnection.Close();
            }
            catch (SqlException ex)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static SqlDataReader ExecuteQueryReader(string Query)
        {
            try
            {
                var conn = _SqlConnection;
                var cmd = new SqlCommand(Query, conn);
                cmd.CommandType = CommandType.Text;

                conn.Open();

                return cmd.ExecuteReader();
            }
            catch (SqlException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}