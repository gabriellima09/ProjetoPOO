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

        public static void ExecuteNonQuery(string StoredProcedure, IList<SqlParameter> sqlParameters)
        {
            try
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
            catch (SqlException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static IDataReader ExecuteNonQueryReader(string StoredProcedure, IList<SqlParameter> sqlParameters)
        {
            try
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
            catch (SqlException)
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
                using (var conn = _SqlConnection)
                {
                    using (var cmd = new SqlCommand(Query, conn))
                    {
                        conn.Open();

                        return cmd.ExecuteReader();
                    }
                }
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