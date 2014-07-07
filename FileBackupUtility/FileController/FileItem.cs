using System;
using System.IO;
using System.IO.Compression;

namespace FileBackupUtility.FileController
{
    public abstract class FileItem
    {
        abstract public string Folder { get; }
        abstract public string Name { get; }
        abstract public string Extension { get; }
        abstract public int Size { get; }
        abstract public DateTime? Created { get; }
        abstract public DateTime? Modified { get; }
        abstract public string ToBase64String();
        abstract public string ToMD5Hash();
    }

    public sealed class PhysicalFileItem : FileItem
    {
        private readonly FileInfo fileInfo;

        public override string Folder { get { return this.fileInfo.DirectoryName; } }
        public override string Name { get { return this.fileInfo.Name; } }
        public override string Extension { get { return this.fileInfo.Extension.Replace(".", string.Empty).ToUpper(); } }
        public override int Size { get { return (int)this.fileInfo.Length; } }
        public override DateTime? Created { get { return this.fileInfo.CreationTime; } }
        public override DateTime? Modified { get { return this.fileInfo.LastWriteTime; } }

        public PhysicalFileItem(string filePath)
        {
            this.fileInfo = new FileInfo(filePath);
        }

        public override string ToBase64String()
        {
            return Convert.ToBase64String(File.ReadAllBytes(this.fileInfo.FullName));
        }

        public override string ToMD5Hash()
        {
            using (var md5 = System.Security.Cryptography.MD5.Create())
            using (var fileStream = File.OpenRead(this.fileInfo.FullName))
                return BitConverter.ToString(md5.ComputeHash(fileStream)).Replace("-", string.Empty);
        }
    }

    public sealed class ArchiveFileItem : FileItem
    {
        private readonly ZipArchiveEntry fileZipEntry;
        private readonly string folder;

        public override string Folder { get { return this.folder; } }
        public override string Name { get { return this.fileZipEntry.Name; } }
        public override string Extension { get { return Path.GetExtension(this.fileZipEntry.Name).Replace(".", string.Empty).ToUpper(); } }
        public override int Size { get { return (int)this.fileZipEntry.Length; } }
        public override DateTime? Created { get { return null; } }
        public override DateTime? Modified { get { return this.fileZipEntry.LastWriteTime.DateTime; } }

        public ArchiveFileItem(ZipArchiveEntry fileZipEntry, string zipPath)
        {
            this.fileZipEntry = fileZipEntry;
            if (fileZipEntry.FullName != fileZipEntry.Name)
                this.folder = Path.Combine(
                                zipPath,
                                fileZipEntry.FullName.Replace("/", "\\")
                                                     .Substring(0, fileZipEntry.FullName.Length - fileZipEntry.Name.Length - 1));
            else
                this.folder = zipPath;
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2202:Do not dispose objects multiple times",
         Justification = "MSDN IDisposable.Dispose: The object must not throw an exception if its Dispose method is called multiple times.")]
        public override string ToBase64String()
        {
            byte[] fileData;
            using (var zipStream = this.fileZipEntry.Open())
            using (var reader = new BinaryReader(zipStream))
                fileData = reader.ReadBytes(this.Size);

            return Convert.ToBase64String(fileData);
        }

        public override string ToMD5Hash()
        {
            using (var md5 = System.Security.Cryptography.MD5.Create())
            using (var zipStream = this.fileZipEntry.Open())
                return BitConverter.ToString(md5.ComputeHash(zipStream)).Replace("-", string.Empty);
        }
    }
}
