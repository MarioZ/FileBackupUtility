using System;
using System.Windows.Forms;
using System.ComponentModel;
using FileBackupUtility.FileController;
using FileBackupUtility.FolderSelect;

namespace FileBackupUtility
{
    public partial class MainForm : Form
    {
        private FileItemCollection files;
        private FileOptions options;
        private OpenFileDialog zipDialog;
        private FolderSelectDialog folderDialog;

        private OpenFileDialog ZipDialog
        {
            get
            {
                if (this.zipDialog == null)
                    this.zipDialog = new OpenFileDialog() { Title = "Select Zip", Filter = "Zip Files|*.zip" };
                return this.zipDialog;
            }
        }

        private FolderSelectDialog FolderDialog
        {
            get
            {
                if (this.folderDialog == null)
                    this.folderDialog = new FolderSelectDialog() { Title = "Select Folder" };
                return this.folderDialog;
            }
        }

        public MainForm()
        {
            InitializeComponent();
            InitializeDoubleBuffered(this.lvFileItems);
            this.files = new FileItemCollection();

            // TODO REMOVE
            // Dummy FileOptions for testing.
            this.options = new FileOptions();
            this.options.IsIncludeFilters = true;
            this.options.SetExtensionFilters(".doc,.docx,.htm");
            this.options.SearchOption = System.IO.SearchOption.AllDirectories;
        }

        private static void InitializeDoubleBuffered(Control list)
        {
            list.GetType().GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic)
                          .SetValue(list, true, null);
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            if (this.options.IsArchiveRoot = this.rbZip.Checked)
            {
                if (this.ZipDialog.ShowDialog() == DialogResult.OK)
                    this.options.Root = this.ZipDialog.FileName;
            }
            else
                if (this.FolderDialog.ShowDialog(this.Handle))
                    this.options.Root = this.FolderDialog.FileName;
        }

        private void btnReady_Click(object sender, EventArgs e)
        {
            this.lvFileItems.Items.Clear();
            this.InitializeBackgroundWorker().RunWorkerAsync();
        }

        private BackgroundWorker InitializeBackgroundWorker()
        {
            var worker = new BackgroundWorker { WorkerReportsProgress = true, WorkerSupportsCancellation = false };

            worker.DoWork += (sender, e) =>
            {
                this.files.Clear();
                foreach (var file in this.files.AddRange(options))
                    worker.ReportProgress(0, file);
            };

            worker.ProgressChanged += (sender, e) =>
            {
                var file = (FileItem)e.UserState;
                this.lvFileItems.Items.Add(
                    new ListViewItem(
                        new string[] { file.Name, string.Format("{0:0.0} kB", (file.Size / 1024d)) }) { ToolTipText = System.IO.Path.Combine(file.Folder, file.Name) });
            };

            return worker;
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException("TODO");
        }

        private void lvFileItems_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                ListViewItem item = this.lvFileItems.GetItemAt(e.X, e.Y);
                if (item != null)
                {
                    item.Selected = true;
                    this.lvContextMenuStrip.Show(this.lvFileItems, e.Location);
                }
            }
        }

        private void lvToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in this.lvFileItems.SelectedItems)
            {
                this.files.RemoveAt(item.Index);
                item.Remove();
            }
        }
    }
}
