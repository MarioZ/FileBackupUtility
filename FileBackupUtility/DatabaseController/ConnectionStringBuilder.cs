using System;
using System.Data.SqlClient;

namespace FileBackupUtility.DatabaseController
{
    public class ConnectionStringBuilder
    {
        public string DataSource { private get; set; }
        public string InitialCatalog { private get; set; }
        public string UserID { private get; set; }
        public string Password { private get; set; }
        public bool IsSqlAuth { private get; set; }
        public bool IsIPSelected { private get; set; }
        public string Port { private get; set; }

        public ConnectionStringBuilder() { }

        public string GetFullConnectionString()
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();

            builder.DataSource = this.DataSource;
            builder.InitialCatalog = this.InitialCatalog;
            builder.IntegratedSecurity = true;

            if (this.IsSqlAuth == true)
            {
                builder.UserID = this.UserID;
                builder.Password = this.Password;
                builder.IntegratedSecurity = false;
                if (IsIPSelected == true)
                {
                    builder.NetworkLibrary = "DBMSSOCN";
                    builder.DataSource = builder.DataSource + "," + this.Port;
                }
            }

            return builder.ToString();
        }

        public string GetDataSourceConnectionString()
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();

            builder.DataSource = this.DataSource;
            builder.IntegratedSecurity = true;

            if (this.IsSqlAuth == true)
            {
                builder.UserID = this.UserID;
                builder.Password = this.Password;
                builder.IntegratedSecurity = false;
                if (IsIPSelected == true)
                {
                    builder.NetworkLibrary = "DBMSSOCN";
                    builder.DataSource = builder.DataSource + "," + this.Port;
                }

            }
            return builder.ToString();

        }
    }
}
