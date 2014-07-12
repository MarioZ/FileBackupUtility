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
        private bool isValidConnection;

        public MainForm()
        {
            this.InitializeComponent();
            this.InitializeListViewEnhancements();
            this.files = new FileItemCollection();
            this.options = new FileOptions();
            this.isValidConnection = false;
        }

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

        private void InitializeListViewEnhancements()
        {
            this.lvFileItems.GetType().GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic)
                            .SetValue(this.lvFileItems, true, null);

            this.lvFileItems.LostFocus += (sender, e) =>
            {
                for (int i = 0; i < this.lvFileItems.SelectedIndices.Count; i++)
                    this.lvFileItems.Items[this.lvFileItems.SelectedIndices[i]].Selected = false;
            };
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

            worker.RunWorkerCompleted += (sender, e) =>
            {
                this.SetProcessButtenEnabled();
            };

            return worker;
        }

        #region User's workflow
        private void btnTestConnection_Click(object sender, EventArgs e)
        {
            // TODO
            this.isValidConnection = true;
            this.lbDBName.Enabled = this.lbDTName.Enabled = this.cmbDatabaseNames.Enabled = this.txtTableName.Enabled = this.btnCreateTable.Enabled = this.isValidConnection;
            this.SetProcessButtenEnabled();
        }

        private void btnCreateTable_Click(object sender, EventArgs e)
        {
            // TODO
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            bool dialogResult;
            if (this.rbZip.Checked)
            {
                dialogResult = this.ZipDialog.ShowDialog() == DialogResult.OK;
                this.txtBrowse.Text = this.ZipDialog.FileName;
            }
            else
            {
                dialogResult = this.FolderDialog.ShowDialog(this.Handle);
                this.txtBrowse.Text = this.FolderDialog.FileName;
            }

            if (!dialogResult)
            {
                this.btnProcess.Enabled = false;
                this.txtBrowse.Text = string.Empty;
            }
        }

        private void btnReady_Click(object sender, EventArgs e)
        {
            this.options.FileSizeLimit = (int)this.nudFileSizeLimit.Value * 1024;
            this.options.FileCountLimit = (int)this.nudFileCountLimit.Value;
            this.options.IsIncludeFilters = this.rbFiltersInclude.Checked;
            this.options.SetExtensionFilters(this.txtFilters.Text);

            this.options.IsArchiveRoot = this.rbZip.Checked;
            this.options.Root = this.txtBrowse.Text;
            this.options.SearchOption = (this.cbSubfolders.Checked) ? System.IO.SearchOption.AllDirectories : System.IO.SearchOption.TopDirectoryOnly;

            this.lvFileItems.Items.Clear();
            this.InitializeBackgroundWorker().RunWorkerAsync();
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            // TODO
            this.SetSettingsGroupBoxEnabled(false);
        }

        private void btnAbort_Click(object sender, EventArgs e)
        {
            // TODO
            this.SetSettingsGroupBoxEnabled(true);
        }
        #endregion

        private void lvFileItems_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && this.btnReady.Enabled)
            {
                ListViewItem item = this.lvFileItems.GetItemAt(e.X, e.Y);
                if (item != null)
                {
                    item.Selected = true;
                    this.lvContextMenuStrip.Show(this.lvFileItems, e.Location);
                }
            }
        }

        private void lvFileItems_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (!this.btnReady.Enabled)
                e.Item.Selected = false;
        }

        private void lvToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in this.lvFileItems.SelectedItems)
            {
                this.files.RemoveAt(item.Index);
                item.Remove();
            }
        }

        private void rbAuth_CheckedChanged(object sender, EventArgs e)
        {
            this.lbUsername.Enabled = this.lbPassword.Enabled = this.txtUsername.Enabled = this.txtPassword.Enabled = this.rbSqlAuth.Checked;
        }

        private void rbFolder_CheckedChanged(object sender, EventArgs e)
        {
            if (this.rbZip.Checked)
                this.btnBrowse.Image = Properties.Resources.Zip;
            else
                this.btnBrowse.Image = Properties.Resources.Folder;
        }

        private void SetProcessButtenEnabled()
        {
            this.btnProcess.Enabled = this.isValidConnection && this.files.Count > 0;
        }

        private void SetSettingsGroupBoxEnabled(bool enable)
        {
            this.gbDatabaseSettings.Enabled = this.gbFileSettings.Enabled = this.gbFolderSettings.Enabled = this.btnReady.Enabled = enable;
            this.btnAbort.Enabled = !enable;
        }
    }
}
