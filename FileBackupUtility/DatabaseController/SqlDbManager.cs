using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace FileBackupUtility.DatabaseController
{
    class SqlDbManager
    {
        private static string DataTableName;
        private static readonly SqlConnectionStringBuilder Builder = new SqlConnectionStringBuilder() { NetworkLibrary = "DBMSSOCN" };
        public static SqlConnectionStringBuilder ConnectionBuilder { get { return Builder; } }

        private static void SetConnection(bool includeInitialCatalog)
        {
            if(Builder.IntegratedSecurity)
            {
                Builder.Remove("User ID");
                Builder.Remove("Password");
            }

            if (!includeInitialCatalog)
                Builder.Remove("Initial Catalog");
        }

        private static SqlConnection GetConnection()
        {
            return new SqlConnection(Builder.ToString());
        }

        public static bool TestConnection()
        {
            SetConnection(false);
            using (var conn = GetConnection())
            {
                try { conn.Open(); }
                catch (InvalidOperationException) { return false; }
                catch (ArgumentException) { return false; }
                catch (SqlException) { return false; }
                catch (Exception) { return false; }
            }
            return true;
        }

        public static List<string> GetAllDatabases()
        {
            var databaseNames = new  List<string>();
            using (var conn = GetConnection())
            {
                try { conn.Open(); }
                catch (SqlException) { return null; }

                using (var cmd = new SqlCommand("SELECT name FROM sys.databases", conn))
                {
                    try
                    {
                        using (IDataReader dr = cmd.ExecuteReader())
                            while (dr.Read())
                                databaseNames.Add(dr[0].ToString());
                    }
                    catch (SqlException) { }
                }
            }
            return databaseNames;
        }

        public static bool? CreateTable(string databaseName, string tableName, bool overrideExistingTable)
        {
            Builder.InitialCatalog = databaseName;
            SetConnection(true);

            using (var conn = GetConnection())
            {
                try { conn.Open(); }
                catch (SqlException) { return null; }

                if (overrideExistingTable)
                    DropTable(conn);
                else if (CheckTableExists(conn))
                    return false;

                DataTableName = tableName;
                string createTableQuery = "CREATE TABLE @tablename (ID INT PRIMARY KEY IDENTITY,Folder VARCHAR(MAX) NOT NULL,FileName VARCHAR(200) NOT NULL,Exstension VARCHAR(200) NOT NULL,FileSize INT NOT NULL, Base64 TEXT NOT NULL, MD5Hash CHAR(32) NOT NULL, FileDateCreated DATETIME NULL,FileDateModified DATETIME  NULL)";

                using (var cmd = new SqlCommand(createTableQuery, conn))
                {
                    cmd.Parameters.Add("@tablename", SqlDbType.NVarChar).Value = DataTableName;
                    ExecuteCommand(cmd);
                    return true;
                }
            }
        }

        private static bool CheckTableExists(SqlConnection conn)
        {
            string selectTableQuery = "SELECT count(*) as IsExists FROM dbo.sysobjects where id = object_id('[dbo].[@tablename]')";

            using (var cmd = new SqlCommand(selectTableQuery, conn))
            {
                cmd.Parameters.Add("@tablename", SqlDbType.NVarChar).Value = DataTableName;

                if ((int)cmd.ExecuteScalar() > 0)
                    return true;
                else
                    return false;
            }
        }

        private static void DropTable(SqlConnection conn)
        {
            string dropTableQuery = "DROP TABLE @tablename";
            using (var cmd = new SqlCommand(dropTableQuery, conn))
            {
                cmd.Parameters.Add("@tablename", SqlDbType.NVarChar).Value = DataTableName;
                ExecuteCommand(cmd);
            }
        }

        public static void SaveFileItems(FileBackupUtility.FileController.FileItemCollection files)
        {
            // TODO
        }

        private static void InsertRecord(SqlConnection conn, string tableName)
        {
            //conn.Open();

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
            catch (InvalidOperationException) { }
            catch (InvalidExpressionException) { }
            catch (SqlException) { }
        }
    }
}
