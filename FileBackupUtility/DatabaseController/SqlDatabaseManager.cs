using System.Data;
using System.Data.SqlClient;

namespace FileBackupUtility.DatabaseController
{
    public sealed class SqlDatabaseManager : IDatabaseManager
    {
        private readonly SqlConnectionStringBuilder builder;

        public SqlDatabaseManager()
        {
            this.builder = new SqlConnectionStringBuilder() { NetworkLibrary = "DBMSSOCN" };
        }

        public void SetConnection(ConnectionOptions options)
        {
            this.ConnectionOptionsToConnectionBuilder(options);
            this.SetConnection();
        }

        private void SetConnection()
        {
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

            string selectTableQuery = "SELECT count(*) as IsExists FROM dbo.sysobjects where id = object_id('[dbo].[@tablename]')";
            using(var conn = this.GetConnection())
            using (var cmd = new SqlCommand(selectTableQuery, conn))
            {
                conn.Open();
                cmd.Parameters.Add("@tablename", SqlDbType.NVarChar).Value = dataTableName;

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

                string createTableQuery = "CREATE TABLE @tablename (ID INT PRIMARY KEY IDENTITY,Folder VARCHAR(MAX) NOT NULL,FileName VARCHAR(200) NOT NULL,Exstension VARCHAR(200) NOT NULL,FileSize INT NOT NULL, Base64 TEXT NOT NULL, MD5Hash CHAR(32) NOT NULL, FileDateCreated DATETIME NULL,FileDateModified DATETIME  NULL)";
                using (var cmd = new SqlCommand(createTableQuery, conn))
                {
                    cmd.Parameters.Add("@tablename", SqlDbType.NVarChar).Value = dataTableName;
                    ExecuteCommand(cmd);
                }
            }
        }

        private void DropTable(string dataTableName, SqlConnection conn)
        {
            string dropTableQuery = "DROP TABLE @tablename";
            using (var cmd = new SqlCommand(dropTableQuery, conn))
            {
                cmd.Parameters.Add("@tablename", SqlDbType.NVarChar).Value = dataTableName;
                ExecuteCommand(cmd);
            }
        }

        public void InsertFileItem(FileBackupUtility.FileController.FileItem file)
        {
            // TODO
            //System.Text.StringBuilder insert = new System.Text.StringBuilder();
            //insert.Append("INSERT INTO ");
            //insert.Append(tableName);
            ////insert.Append(" (Folder, FileName, Exstension, FileSize, Base64, MD5Hash, FileDateCreated, FileDateModified) VALUES (");
            //insert.Append(" (Folder, FileName, Exstension, FileSize, Base64, MD5Hash) VALUES (");
            //insert.Append("'");
            //insert.Append(file.Folder);
            //insert.Append("',");
            //insert.Append(" '");
            //insert.Append(file.Name);
            //insert.Append("',");
            //insert.Append(" '");
            //insert.Append(file.Extension);
            //insert.Append("',");
            //insert.Append(" '");
            //insert.Append(file.Size);
            //insert.Append("',");
            //insert.Append(" '");
            //insert.Append(file.ToBase64String());
            //insert.Append("',");
            //insert.Append(" '");
            //insert.Append(file.ToMD5Hash());
            ////insert.Append("',");
            ////insert.Append(" '");
            //////insert.Append((file.Created) ?? DBNull.Value.ToString());
            ////insert.Append(file.Created);
            ////insert.Append("',");
            ////insert.Append(" '");
            //////insert.Append((file.Modified) ?? DBNull.Value.ToString());
            ////insert.Append(file.Modified);
            //insert.Append("')");
            //using (SqlCommand cmd = new SqlCommand(insert.ToString(), conn))
            //    ExecuteCommand(cmd);
        }

        private static void ExecuteCommand(SqlCommand cmd)
        {
            try { cmd.ExecuteNonQuery(); }
            catch (SqlException) { }
        }
    }
}
