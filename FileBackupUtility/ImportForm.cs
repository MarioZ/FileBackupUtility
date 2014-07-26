using System;
using System.Windows.Forms;
using System.ComponentModel;
using FileBackupUtility.DatabaseController;
using FileBackupUtility.FileController;
using FileBackupUtility.FolderSelect;
using System.Globalization;

namespace FileBackupUtility
{
    public partial class ImportForm : Form
    {
        private FileItemCollection files;
        private FileOptions options;
        private IDatabaseManager databaseManager;

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

        private BackgroundWorker listViewWorker;
        private BackgroundWorker processWorker;
        private bool isValidDataTable;

        public ImportForm(IDatabaseManager databaseManager)
        {
            this.InitializeComponent();
            this.InitializeListViewEnhancements();
            this.listViewWorker = this.InitializeListViewWorker();
            this.processWorker = this.InitializeProcessWorker();

            this.files = new FileItemCollection();
            this.options = new FileOptions();
            this.databaseManager = databaseManager;

            this.isValidDataTable = false;
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

        private BackgroundWorker InitializeListViewWorker()
        {
            const byte FilesChunkSize = 64;
            var worker = new BackgroundWorker { WorkerReportsProgress = true };

            worker.DoWork += (sender, e) =>
            {
                int progressCount = 0;
                var filesChunk = new FileItem[FilesChunkSize];
                foreach (var file in this.files.AddRange(options))
                {
                    int currentIndex = progressCount % FilesChunkSize;

                    if(currentIndex == 0)
                        worker.ReportProgress(progressCount, filesChunk);

                    filesChunk[currentIndex] = file;
                    progressCount++;
                }
                worker.ReportProgress(progressCount, filesChunk);
            };

            worker.ProgressChanged += (sender, e) =>
            {
                var filesChunk = (FileItem[])e.UserState;
                int filesCount = (e.ProgressPercentage == 0) ? 0 : ((filesCount = e.ProgressPercentage % FilesChunkSize) == 0) ? FilesChunkSize : filesCount;
                
                this.lvFileItems.BeginUpdate();

                for (int i = 0; i < filesCount; i++)
                    this.lvFileItems.Items.Add(
                        new ListViewItem(
                            new string[] { filesChunk[i].Name, string.Format(CultureInfo.InvariantCulture, "{0:0.0} kB", (filesChunk[i].Size / 1024d)) }) { ToolTipText = System.IO.Path.Combine(filesChunk[i].Folder, filesChunk[i].Name) });
                
                this.lvFileItems.EndUpdate();
            };

            worker.RunWorkerCompleted += (sender, e) =>
            {
                this.SetProcessButtenEnabled(true);
            };

            return worker;
        }

        private BackgroundWorker InitializeProcessWorker()
        {
            var worker = new BackgroundWorker { WorkerReportsProgress = true, WorkerSupportsCancellation = true };

            worker.DoWork += (sender, e) =>
            {
                long progressSize = 0;
                for (int i = 0; i < this.files.Count; i++)
                {
                    if (worker.CancellationPending) { e.Cancel = true; break; }

                    var file = this.files[i];
                    progressSize += file.Size;

                    this.databaseManager.InsertFileItem(this.txtTableName.Text, file);
                    worker.ReportProgress((int)(progressSize * 100 / this.files.TotalSize), i);
                }
            };

            worker.ProgressChanged += (sender, e) =>
            {
                    this.lvFileItems.Items[(int)e.UserState].ForeColor = System.Drawing.Color.Green;
                    this.progressBar.Value = e.ProgressPercentage;
            };

            worker.RunWorkerCompleted += (sender, e) =>
            {
                if (e.Cancelled) { }
                this.SetSettingsGroupBoxEnabled(true);
            };

            return worker;
        }

        private void btnTestConnection_Click(object sender, EventArgs e)
        {
            var connectionOptions = new ConnectionOptions()
            {
                ServerName = (this.cbIPAddress.Checked) ? string.Format(CultureInfo.InvariantCulture, "{0},{1}", this.txtServer.Text, this.txtPort.Text) : this.txtServer.Text,
                IntegratedSecurity = !this.rbSqlAuth.Checked,
                UserName = this.txtUsername.Text,
                Password = this.txtPassword.Text,
                DatabaseName = string.Empty
            };

            this.databaseManager.SetConnection(connectionOptions);
            if (this.databaseManager.TestConnection())
            {
                this.cmbDatabaseNames.DataSource = this.databaseManager.GetDatabaseNames();
                this.SetValidConnectionEnabled(true);
            }
        }

        private void btnCreateTable_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(this.txtTableName.Text))
                return;
            else if (this.databaseManager.CheckTableExists(this.cmbDatabaseNames.Text, this.txtTableName.Text))
            {
                if (MessageBox.Show(string.Format(CultureInfo.InvariantCulture, "DataTable {0} already exists.{1}Press OK if you want to override it.", this.txtTableName.Text, Environment.NewLine),
                                    "DataTable exists!",
                                    MessageBoxButtons.OKCancel) == DialogResult.OK)
                    this.CreateTable(true);
                else
                {
                    this.btnCreateTable.Image = Properties.Resources.DataTableUNKNOWN;
                    this.txtTableName.Text = string.Empty;
                    this.isValidDataTable = false;
                }
            }
            else
                this.CreateTable(false);
        }

        private void CreateTable(bool overrideTable)
        {
            this.databaseManager.CreateTable(this.txtTableName.Text, overrideTable);
            this.btnCreateTable.Image = Properties.Resources.DataTableOK;
            this.isValidDataTable = true;
            this.SetProcessButtenEnabled(true);
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
                this.txtBrowse.Text = string.Empty;
                this.FileOrFolderSettingsChanged(sender, e);
            }
        }

        private void btnReady_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.options.Root = this.txtBrowse.Text) || this.listViewWorker.IsBusy)
                return;

            this.options.FileSizeLimit = (int)this.nudFileSizeLimit.Value * 1024;
            this.options.FileCountLimit = (int)this.nudFileCountLimit.Value;
            this.options.IsIncludeFilters = this.rbFiltersInclude.Checked;
            this.options.SetExtensionFilters(this.txtFilters.Text);
            this.options.IsArchiveRoot = this.rbZip.Checked;
            this.options.IncludeSubfolders = this.cbSubfolders.Checked;

            this.ClearFileItems();
            this.listViewWorker.RunWorkerAsync();
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            if (this.processWorker.IsBusy)
                return;

            this.SetSettingsGroupBoxEnabled(false);
            this.lvFileItems.ForeColor = System.Drawing.Color.Gray;
            this.processWorker.RunWorkerAsync();
        }

        private void btnAbort_Click(object sender, EventArgs e)
        {
            this.processWorker.CancelAsync();
        }

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
            this.SetProcessButtenEnabled(true);
        }

        private void cbIPAddress_CheckedChanged(object sender, EventArgs e)
        {
            this.txtPort.Enabled = this.cbIPAddress.Checked;
            this.ServerOrAuthentificationChanged(sender, e);
        }

        private void rbAuth_CheckedChanged(object sender, EventArgs e)
        {
            this.lbUsername.Enabled = this.lbPassword.Enabled = this.txtUsername.Enabled = this.txtPassword.Enabled = this.rbSqlAuth.Checked;
            this.ServerOrAuthentificationChanged(sender, e);
        }

        private void rbFolder_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void ServerOrAuthentificationChanged(object sender, EventArgs e)
        {
            this.SetValidConnectionEnabled(false);
            this.DatabaseOrTableNameChanged(sender, e);
        }

        private void DatabaseOrTableNameChanged(object sender, EventArgs e)
        {
            this.isValidDataTable = false;
            this.btnCreateTable.Image = Properties.Resources.DataTableUNKNOWN;
            this.SetProcessButtenEnabled(false);
        }

        private void FileOrFolderSettingsChanged(object sender, EventArgs e)
        {
            this.ClearFileItems();
            this.SetProcessButtenEnabled(false);
        }

        private void ClearFileItems()
        {
            this.files.Clear();
            this.lvFileItems.Items.Clear();
            this.lvFileItems.ForeColor = System.Drawing.Color.Black;
            this.progressBar.Value = 0;
        }

        private void SetValidConnectionEnabled(bool enable)
        {
            this.btnTestConnection.Image = (enable) ? Properties.Resources.ConnectionOK : Properties.Resources.ConnectionUKNOWN;
            this.lbDBName.Enabled = this.lbDTName.Enabled = this.cmbDatabaseNames.Enabled = this.txtTableName.Enabled = this.btnCreateTable.Enabled = enable;
        }

        private void SetProcessButtenEnabled(bool enabled)
        {
            this.btnProcess.Enabled = enabled && this.isValidDataTable && this.files.Count > 0;
        }

        private void SetSettingsGroupBoxEnabled(bool enable)
        {
            this.gbDatabaseSettings.Enabled = this.gbFileSettings.Enabled = this.gbFolderSettings.Enabled = this.btnReady.Enabled = enable;
            this.btnAbort.Enabled = !enable;
        }
    }
}
