using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Bym.UI.Models.DAL
{
    public class DbContext : IDisposable
    {
        private static string ConnectionString
        {
            get
            {
                return ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
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
            using (var conn = _SqlConnection)
            {
                using (var cmd = new SqlCommand())
                {
                    cmd.CommandText = query;
                    cmd.CommandType = CommandType.Text;

                    conn.Open();

                    cmd.ExecuteScalar();
                }
            }
        }

        public static void ExecuteNonQuery(string StoredProcedure, IList<SqlParameter> sqlParameters)
        {
            using (var conn = _SqlConnection)
            {
                using (var cmd = new SqlCommand(StoredProcedure, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddRange((SqlParameter[])sqlParameters);
                    
                    conn.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static IDataReader ExecuteReader(string StoredProcedure, IList<SqlParameter> sqlParameters)
        {
            using (var conn = _SqlConnection)
            {
                using (var cmd = new SqlCommand(StoredProcedure, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddRange((SqlParameter[])sqlParameters);

                    conn.Open();

                    return cmd.ExecuteReader(CommandBehavior.CloseConnection);
                }
            }
        }

        public static SqlDataReader ExecuteQueryComRetorno(string Query)
        {
            using (var conn = _SqlConnection)
            {
                using (var cmd = new SqlCommand(Query))
                {
                    conn.Open();

                    return cmd.ExecuteReader();
                }
            }
        }

        public void Dispose()
        {
            if (_SqlConnection.State != ConnectionState.Closed)
            {
                _SqlConnection.Close();
            }

            GC.SuppressFinalize(this);
        }
    }
}