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

                sb.Append("IF (SELECT COUNT(name) FROM " + DbUtil.DatabaseName + ".sys.tables where name = 'USUARIOS') = 0");
                sb.Append(" BEGIN");
                sb.Append(" CREATE TABLE USUARIOS(");
                sb.Append(" Id INT IDENTITY(1,1) PRIMARY KEY,");
                sb.Append(" Login VARCHAR(50),");
                sb.Append(" Senha VARCHAR(50)");
                sb.Append(");");
                sb.Append(" END");

                sb.Append("\n");

                sb.Append("IF (SELECT COUNT(name) FROM " + DbUtil.DatabaseName + ".sys.tables where name = 'RESERVAS') = 0");
                sb.Append(" BEGIN");
                sb.Append(" CREATE TABLE RESERVAS(");
                sb.Append(" Id INT IDENTITY(1,1) PRIMARY KEY,");
                sb.Append(" DataHora SMALLDATETIME,");
                sb.Append(" HorasReservadas INT,");
                sb.Append(" IdSala INT,");
                sb.Append(" IdUsuario INT");
                sb.Append(");");
                sb.Append(" END");

                sb.Append("\n");

                sb.Append("IF (SELECT COUNT(name) FROM " + DbUtil.DatabaseName + ".sys.tables where name = 'SALAS') = 0");
                sb.Append(" BEGIN");
                sb.Append(" CREATE TABLE SALAS(");
                sb.Append(" Id INT IDENTITY(1,1) PRIMARY KEY,");
                sb.Append(" CapacidadeMaxima INT,");
                sb.Append(" Descricao VARCHAR(50),");
                sb.Append(" Nome VARCHAR(50),");
                sb.Append(" ValorHora DECIMAL(8,2),");
                sb.Append(" Logradouro VARCHAR(50),");
                sb.Append(" Numero VARCHAR(50),");
                sb.Append(" Complemento VARCHAR(50)");
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