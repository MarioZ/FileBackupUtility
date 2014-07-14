using System.Linq;

namespace FileBackupUtility.FileController
{
    public sealed class FileOptions
    {
        private string[] extensionFilters;

        public string Root { get; set; }
        public bool IsArchiveRoot { get; set; }
        public bool IsIncludeFilters { get; set; }
        public bool IncludeSubfolders { get; set; }
        public int FileSizeLimit { get; set; }
        public int FileCountLimit { get; set; }

        public FileOptions() { }

        public void SetExtensionFilters(string searchPattern)
        {
            if (string.IsNullOrWhiteSpace(searchPattern))
                this.extensionFilters = null;
            else
                this.extensionFilters = searchPattern.Split(',').Select(filter => filter.Trim()).ToArray();
        }

        public string[] GetExtensionFilters()
        {
            return this.extensionFilters;
        }
    }
}