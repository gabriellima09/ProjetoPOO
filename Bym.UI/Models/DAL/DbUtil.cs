using System.Configuration;
using System.Data.SqlClient;

namespace Bym.UI.Models.DAL
{
    public class DbUtil
    {
        public static string ConnectionString => _SqlConnectionStringBuilder.ConnectionString;
        public static string ConnectionString_Master => _SqlConnectionStringBuilder_Master.ConnectionString;
        public static string DatabaseName => _DatabaseNameBuilder;
        public static string Path => _PathBuilder;
        public static string DataServerName => _ServerNameBuilder;

        private static string _DatabaseNameBuilder
        {
            get
            {
                return ConfigurationManager.AppSettings["DatabaseName"];
            }
        }

        private static string _PathBuilder
        {
            get
            {
                return ConfigurationManager.AppSettings["DatabasePath"];
            }
        }

        private static string _ServerNameBuilder
        {
            get
            {
                return ConfigurationManager.AppSettings["ServerName"];
            }
        }

        private static SqlConnectionStringBuilder _SqlConnectionStringBuilder
        {
            get
            {
                return new SqlConnectionStringBuilder
                {
                    DataSource = _ServerNameBuilder,
                    InitialCatalog = _DatabaseNameBuilder,
                    IntegratedSecurity = true
                };
            }
        }

        private static SqlConnectionStringBuilder _SqlConnectionStringBuilder_Master
        {
            get
            {
                return new SqlConnectionStringBuilder
                {
                    DataSource = _ServerNameBuilder,
                    InitialCatalog = ConfigurationManager.AppSettings["DatabaseName_Master"],
                    IntegratedSecurity = true
                };
            }
        }

    }
}