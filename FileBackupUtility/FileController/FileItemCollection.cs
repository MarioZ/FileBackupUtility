using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Collections.Generic;

namespace FileBackupUtility.FileController
{
    public sealed class FileItemCollection : IEnumerable<FileItem>
    {
        private List<FileItem> fileItems;
        private FileOptions options;

        public int Count { get { return this.fileItems.Count; } }

        public FileItemCollection()
        {
            this.fileItems = new List<FileItem>();
        }

        public void AddRange(FileOptions options)
        {
            if (string.IsNullOrWhiteSpace(options.Root))
                return;

            this.options = options;

            if (this.options.IsArchiveRoot)
                this.fileItems.AddRange(this.GetFileItemsFromZip());
            else
                this.fileItems.AddRange(this.GetFileItemsFromFolder());
        }

        public async System.Threading.Tasks.Task AddRangeAsync(FileOptions options)
        {
            await System.Threading.Tasks.Task.Run(() => this.AddRange(options));
        }

        public void Clear()
        {
            this.fileItems.Clear();
        }

        public IEnumerator<FileItem> GetEnumerator()
        {
            return this.fileItems.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public void RemoveAt(int index)
        {
            this.fileItems.RemoveAt(index);
        }

        private IEnumerable<FileItem> GetFileItemsFromZip()
        {
            ZipArchive archive = ZipFile.OpenRead(this.options.Root);

            foreach (ZipArchiveEntry entry in archive.Entries)
            {
                if (!this.CheckFileItemCount())
                    break;

                else if (string.IsNullOrEmpty(entry.Name) ||
                         this.options.SearchOption == SearchOption.TopDirectoryOnly && entry.FullName != entry.Name)
                    continue;

                else if (this.CheckFileExtension(Path.GetExtension(entry.Name)))
                {
                    FileItem item = this.CreateFileItem(entry);
                    if (item != null)
                        yield return item;
                }
            }
        }

        private IEnumerable<FileItem> GetFileItemsFromFolder()
        {
            foreach (var file in Directory.GetFiles(this.options.Root, "*", this.options.SearchOption))
            {
                if (!this.CheckFileItemCount())
                    break;

                else if (this.CheckFileExtension(Path.GetExtension(file)))
                {
                    FileItem item = this.CreateFileItem(file);
                    if (item != null)
                        yield return item;
                }
            }
        }

        private FileItem CreateFileItem(ZipArchiveEntry fileZipEntry)
        {
            var archiveFileItem = new ArchiveFileItem(fileZipEntry, this.options.Root);
            if (this.CheckFileItemSize(archiveFileItem))
                return archiveFileItem;
            return null;
        }

        private FileItem CreateFileItem(string filePath)
        {
            var physicalFileItem = new PhysicalFileItem(filePath);
            if (this.CheckFileItemSize(physicalFileItem))
                return physicalFileItem;
            return null;
        }

        private bool CheckFileExtension(string extension)
        {
            string[] extensionFilters = this.options.GetExtensionFilters();
            if (extensionFilters == null)
                return true;
            bool contained = extensionFilters.Contains(extension, System.StringComparer.OrdinalIgnoreCase);
            return (this.options.IsIncludeFilters) ? contained : !contained;

        }

        private bool CheckFileItemSize(FileItem item)
        {
            if ((this.options.FileSizeLimit != 0 &&
                 item.Size > this.options.FileSizeLimit) ||
                (item.Size > int.MaxValue))
                return false;
            return true;
        }

        private bool CheckFileItemCount()
        {
            if ((this.options.SampleCountLimit != 0 &&
                 this.Count == this.options.SampleCountLimit))
                return false;
            return true;
        }
    }
}