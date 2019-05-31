using Bym.UI.Models.DAL;
using System.Data.SqlClient;
using System.Text;

namespace Bym.UI.App_Start
{
    public class DatabaseConfig
    {
        public static void Initialize(bool dropDb = false)
        {
            if (dropDb)
            {
                DropDatabase();
            }

            CreateDatabase();
            CreateTables();
        }

        private static void CreateDatabase()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("IF NOT EXISTS (SELECT 1 FROM sys.databases WHERE name = N'" + DbUtil.DatabaseName + "') BEGIN");
            sb.Append(" CREATE DATABASE " + DbUtil.DatabaseName + " ON PRIMARY");
            sb.Append(" (NAME = " + DbUtil.DatabaseName + ",");
            sb.Append(" FILENAME = '" + DbUtil.Path + DbUtil.DatabaseName + ".mdf',");
            sb.Append(" SIZE = 2MB, MAXSIZE = 10MB, FILEGROWTH = 10%)");
            sb.Append(" LOG ON (NAME = " + DbUtil.DatabaseName + "_Log,");
            sb.Append(" FILENAME = '" + DbUtil.Path + DbUtil.DatabaseName + "Log.ldf',");
            sb.Append(" SIZE = 1MB,");
            sb.Append(" MAXSIZE = 5MB,");
            sb.Append(" FILEGROWTH = 10%)");
            sb.Append("END");

            try
            {
                using (SqlConnection myConn = new SqlConnection(DbUtil.ConnectionString_Master))
                {
                    using (SqlCommand myCommand = new SqlCommand(sb.ToString(), myConn))
                    {
                        myConn.Open();
                        myCommand.ExecuteNonQuery();
                    }
                }
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        private static void CreateTables()
        {
            try
            {
                StringBuilder sb = new StringBuilder();

                sb.Append("IF OBJECT_ID('" + DbUtil.DatabaseName + ".USUARIOS') IS NULL");
                sb.Append(" BEGIN");
                sb.Append(" CREATE TABLE USUARIOS(");
                sb.Append(" Id INTEGER IDENTITY(1,1) PRIMARY KEY,");
                sb.Append(" Login VARCHAR(50),");
                sb.Append(" Senha VARCHAR(50)");
                sb.Append(");");
                sb.Append(" END");

                using (SqlConnection myConn = new SqlConnection(DbUtil.ConnectionString))
                {
                    using (SqlCommand myCommand = new SqlCommand(sb.ToString(), myConn))
                    {
                        myConn.Open();
                        myCommand.ExecuteNonQuery();
                    }
                }
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        private static void DropDatabase()
        {
            try
            {
                StringBuilder sb = new StringBuilder();

                sb.Append("IF EXISTS (SELECT 1 FROM sys.databases WHERE name = N'" + DbUtil.DatabaseName + "') BEGIN");
                sb.Append(" DROP DATABASE " + DbUtil.DatabaseName + ";");
                sb.Append("END");

                using (SqlConnection myConn = new SqlConnection(DbUtil.ConnectionString_Master))
                {
                    using (SqlCommand myCommand = new SqlCommand(sb.ToString(), myConn))
                    {
                        myConn.Open();
                        myCommand.ExecuteNonQuery();
                    }
                }
            }
            catch (System.Exception)
            {
                throw;
            }
        }
    }
}