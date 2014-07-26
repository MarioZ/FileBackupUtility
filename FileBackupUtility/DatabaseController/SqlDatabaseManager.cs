using System.Data;
using System.Data.SqlClient;

namespace FileBackupUtility.DatabaseController
{
    public sealed class SqlDatabaseManager : IDatabaseManager
    {
        private readonly SqlConnectionStringBuilder builder;

        public SqlDatabaseManager()
        {
            this.builder = new SqlConnectionStringBuilder();
        }

        public void SetConnection(ConnectionOptions options)
        {
            this.ConnectionOptionsToConnectionBuilder(options);
            this.SetConnection();
        }

        private void SetConnection()
        {
            // http://technet.microsoft.com/en-us/library/ms143531(v=sql.120).aspx
            if (this.builder.DataSource.Contains(","))
                this.builder.NetworkLibrary = "DBMSSOCN";
            else
                this.builder.Remove("Network Library");

            if (this.builder.IntegratedSecurity)
            {
                this.builder.Remove("User ID");
                this.builder.Remove("Password");
            }

            if (string.IsNullOrEmpty(this.builder.InitialCatalog))
                this.builder.Remove("Initial Catalog");
        }

        private SqlConnection GetConnection()
        {
            // http://msdn.microsoft.com/en-us/library/8xx3tyca(v=vs.110).aspx
            return new SqlConnection(builder.ConnectionString);
        }

        private void ConnectionOptionsToConnectionBuilder(ConnectionOptions options)
        {
            this.builder.DataSource = options.ServerName;
            this.builder.IntegratedSecurity = options.IntegratedSecurity;
            this.builder.UserID = options.UserName;
            this.builder.Password = options.Password;
            this.builder.InitialCatalog = options.DatabaseName;
        }

        public bool TestConnection()
        {
            using (var conn = this.GetConnection())
            {
                try { conn.Open(); }
                catch (SqlException) { return false; }
            }
            return true;
        }

        public string[] GetDatabaseNames()
        {
            string selectDatabasesQuery = "SELECT name FROM sys.databases";
            using (var conn = this.GetConnection())
            using (var cmd = new SqlCommand(selectDatabasesQuery, conn))
            {
                try { conn.Open(); }
                catch (SqlException) { return null; }

                var databaseNames = new System.Collections.Generic.List<string>();

                try
                {
                    using (IDataReader dr = cmd.ExecuteReader())
                        while (dr.Read())
                            databaseNames.Add(dr[0].ToString());
                }
                catch (SqlException) { return null; }

                return databaseNames.ToArray();
            }
        }


        public bool CheckTableExists(string databaseName, string dataTableName)
        {
            this.builder.InitialCatalog = databaseName;
            this.SetConnection();

            string selectTableQuery = "SELECT count(*) as IsExists FROM dbo.sysobjects where id = object_id('[dbo].[" + dataTableName + "]')";
            using(var conn = this.GetConnection())
            using (var cmd = new SqlCommand(selectTableQuery, conn))
            {
                conn.Open();
                if ((int)cmd.ExecuteScalar() > 0)
                    return true;
                else
                    return false;
            }
        }

        public void CreateTable(string dataTableName, bool overrideExistingTable)
        {
            using (var conn = this.GetConnection())
            {
                conn.Open();
                if (overrideExistingTable)
                    this.DropTable(dataTableName, conn);

                string createTableQuery = "CREATE TABLE " + dataTableName + "(Folder VARCHAR(MAX) NOT NULL,FileName VARCHAR(200) NOT NULL,Exstension VARCHAR(200) NOT NULL,FileSize INT NOT NULL,Base64 TEXT NOT NULL,MD5Hash CHAR(32) NOT NULL,FileDateCreated DATETIME NULL,FileDateModified DATETIME NULL);";
                ExecuteQuery(createTableQuery, conn);
            }
        }

        private void DropTable(string dataTableName, SqlConnection conn)
        {
            string dropTableQuery = "DROP TABLE " + dataTableName;
            ExecuteQuery(dropTableQuery, conn);
        }

        public void InsertFileItem(string dataTableName, FileBackupUtility.FileController.FileItem file)
        {
            using (var conn = this.GetConnection())
            {
                conn.Open();

                string insertRecordQuery = "INSERT INTO " + dataTableName + " (Folder, FileName, Exstension, FileSize, Base64, MD5Hash, FileDateCreated, FileDateModified) VALUES (@FileFolder, @FileName, @FileExtension, @FileSize, @FileBase64, @FileMD5Hash, @FileCreated, @FileModified)";
                using (var cmd = new SqlCommand(insertRecordQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@FileFolder", file.Folder);
                    cmd.Parameters.AddWithValue("@FileName", file.Name);
                    cmd.Parameters.AddWithValue("@FileExtension", file.Extension);
                    cmd.Parameters.AddWithValue("@FileSize", file.Size);
                    cmd.Parameters.AddWithValue("@FileBase64", file.ToBase64String());
                    cmd.Parameters.AddWithValue("@FileMD5Hash", file.ToMD5HashString());
                    cmd.Parameters.AddWithValue("@FileCreated", (object)file.Created ?? System.DBNull.Value);
                    cmd.Parameters.AddWithValue("@FileModified", (object)file.Modified ?? System.DBNull.Value);

                    try { cmd.ExecuteNonQuery(); }
                    catch (SqlException) { }
                }
            }
        }

        private static void ExecuteQuery(string query, SqlConnection conn)
        {
            using (var cmd = new SqlCommand(query, conn))
            {
                try { cmd.ExecuteNonQuery(); }
                catch (SqlException) { }
            }
        }
    }
}
