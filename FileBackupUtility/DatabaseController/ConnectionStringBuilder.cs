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
            var builder = new SqlConnectionStringBuilder()
                          {
                              DataSource = this.DataSource,
                              InitialCatalog = this.InitialCatalog,
                              IntegratedSecurity = true
                          };

            if (this.IsSqlAuth)
            {
                builder.UserID = this.UserID;
                builder.Password = this.Password;
                builder.IntegratedSecurity = false;
                if (IsIPSelected)
                {
                    builder.NetworkLibrary = "DBMSSOCN";
                    builder.DataSource = string.Format("{0},{1}", builder.DataSource, this.Port);
                }
            }

            return builder.ToString();
        }

        public string GetDataSourceConnectionString()
        {
            var builder = new SqlConnectionStringBuilder()
                          {
                              DataSource = this.DataSource,
                              IntegratedSecurity = true
                          };

            if (this.IsSqlAuth)
            {
                builder.UserID = this.UserID;
                builder.Password = this.Password;
                builder.IntegratedSecurity = false;
                if (IsIPSelected)
                {
                    builder.NetworkLibrary = "DBMSSOCN";
                    builder.DataSource = builder.DataSource + "," + this.Port;
                }
            }

            return builder.ToString();
        }
    }
}
