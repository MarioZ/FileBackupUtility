namespace FileBackupUtility.DatabaseController
{
    public interface IDatabaseManager
    {
        void SetConnection(ConnectionOptions options);
        bool TestConnection();
        string[] GetDatabaseNames();
        bool CheckTableExists(string databaseName, string dataTableName);
        void CreateTable(string dataTableName, bool overrideExistingTable);
        void InsertFileItem(FileBackupUtility.FileController.FileItem file);
    }

    public sealed class ConnectionOptions
    {
        public string ServerName { get; set; }
        public bool IntegratedSecurity { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string DatabaseName { get; set; }
        public string DataTableName { get; set; }
    }
}
