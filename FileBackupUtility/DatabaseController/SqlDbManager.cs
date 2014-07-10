using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace FileBackupUtility.DatabaseController
{
    class SqlDbManager
    {
        public static bool TestConnection(string connection)
        {
            using (SqlConnection conn = new SqlConnection(connection))
            {
                try { conn.Open(); }
                catch (InvalidOperationException) { return false; }
                catch (ArgumentException) { return false; }
                catch (SqlException) { return false; }
                catch (Exception) { return false; }
            }
            return true;
        }

        public static List<string> GetAllDatabases(string connString)
        {
            var databaseNames = new List<string>();
            using (SqlConnection con = new SqlConnection(connString))
            {
                try { con.Open(); }
                catch (SqlException) { return null; }

                using (var cmd = new SqlCommand("SELECT name from sys.databases", con))
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

        public static void CreateTable(string tableName, string connection)
        {
            string newTableQuery = string.Format("CREATE TABLE {0} (ID INT PRIMARY KEY IDENTITY,Folder VARCHAR(MAX) NOT NULL,FileName VARCHAR(200) NOT NULL,Exstension VARCHAR(200) NOT NULL,FileSize INT NOT NULL, Base64 TEXT NOT NULL, MD5Hash CHAR(32) NOT NULL, FileDateCreated DATETIME NULL,FileDateModified DATETIME  NULL)", tableName);

            using (var conn = new SqlConnection(connection))
            {
                try { conn.Open(); }
                catch (SqlException) { }

                using (var cmd = new SqlCommand(newTableQuery, conn))
                    if (!CheckTableExists(connection, tableName))
                        ExecuteCommand(cmd);
            }
        }

        public static bool CheckTableExists(string connection, string tableName)
        {
            string sql = string.Format("SELECT count(*) as IsExists FROM dbo.sysobjects where id = object_id('[dbo].[{0}]')", tableName);

            using (var conn = new SqlConnection(connection))
            {
                var cmd = new SqlCommand(sql, conn);

                try
                {
                    conn.Open();
                    if ((int)cmd.ExecuteScalar() > 0)
                        return true;
                }
                catch (SqlException) { }
            }
            return false;
        }

        public static void DropTable(string tableName, string connection)
        {
            string dropTableQuery = "DROP TABLE " + tableName;

            using (var conn = new SqlConnection(connection))
            {
                try { conn.Open(); }
                catch (SqlException) { }

                using (var cmd = new SqlCommand(dropTableQuery, conn))
                    using (var drop = new SqlCommand(dropTableQuery, conn))
                        ExecuteCommand(drop);
            }
        }

        public static void SaveFileItem(string connection, string tableName)
        {
            //using (SqlConnection conn = new SqlConnection(connection))
            //    InsertRecord(tableName, conn, file);
        }

        private static void InsertRecord(string tableName, SqlConnection conn)
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
