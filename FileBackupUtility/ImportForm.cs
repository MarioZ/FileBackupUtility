using System;
using System.Windows.Forms;
using System.ComponentModel;
using FileBackupUtility.DatabaseController;
using FileBackupUtility.FileController;
using FileBackupUtility.FolderSelect;

namespace FileBackupUtility
{
    public partial class ImportForm : Form
    {
        private FileItemCollection files;
        private FileOptions options;
        private IDatabaseManager databaseManager;

        private OpenFileDialog zipDialog;
        private FolderSelectDialog folderDialog;

        private bool isValidDataTable;

        public ImportForm(IDatabaseManager databaseManager)
        {
            this.InitializeComponent();
            this.InitializeListViewEnhancements();

            this.files = new FileItemCollection();
            this.options = new FileOptions();
            this.databaseManager = databaseManager;

            this.isValidDataTable = false;
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

        private BackgroundWorker InitializeListViewWorker()
        {
            const int FilesChunkSize = 30;
            var worker = new BackgroundWorker { WorkerReportsProgress = true, WorkerSupportsCancellation = false };

            worker.DoWork += (sender, e) =>
            {
                int progress = 0;
                var filesChunk = new FileItem[FilesChunkSize];
                foreach (var file in this.files.AddRange(options))
                {
                    int currentIndex = progress % FilesChunkSize;

                    if(currentIndex == 0)
                        worker.ReportProgress(progress, filesChunk);

                    filesChunk[currentIndex] = file;
                    progress++;
                }
                worker.ReportProgress(progress, filesChunk);
            };

            worker.ProgressChanged += (sender, e) =>
            {
                var filesChunk = (FileItem[])e.UserState;

                int filesCount = (e.ProgressPercentage == 0) ? 0 : ((filesCount = e.ProgressPercentage % FilesChunkSize) == 0) ? FilesChunkSize : filesCount;

                for (int i = 0; i < filesCount; i++)
                    this.lvFileItems.Items.Add(
                        new ListViewItem(
                            new string[] { filesChunk[i].Name, string.Format("{0:0.0} kB", (filesChunk[i].Size / 1024d)) }) { ToolTipText = System.IO.Path.Combine(filesChunk[i].Folder, filesChunk[i].Name) });
            };

            worker.RunWorkerCompleted += (sender, e) =>
            {
                this.SetProcessButtenEnabled();
            };

            return worker;
        }

        private void btnTestConnection_Click(object sender, EventArgs e)
        {
            var connectionOptions = new ConnectionOptions()
            {
                ServerName = (this.cbIPAddress.Checked) ? string.Format("{0},{1}", this.txtServer.Text, this.txtPort.Text) : this.txtServer.Text,
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
            if (this.databaseManager.CheckTableExists(this.cmbDatabaseNames.Text, this.txtTableName.Text))
            {
                if (MessageBox.Show(string.Format("DataTable \"{0}\" already exists.{1}Press OK if you want to override it.", this.txtTableName.Text, Environment.NewLine),
                                    "DataTable exists!",
                                    MessageBoxButtons.OKCancel) == DialogResult.OK)
                    this.CreateTable(true);
            }
            else
                this.CreateTable(false);
        }

        private void CreateTable(bool overrideTable)
        {
            this.databaseManager.CreateTable(this.txtTableName.Text, overrideTable);
            this.btnCreateTable.Image = Properties.Resources.DataTableOK;
            this.isValidDataTable = true;
            this.SetProcessButtenEnabled();
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
                this.ClearFileItems();
                this.SetProcessButtenEnabled();
                this.txtBrowse.Text = string.Empty;
            }
        }

        private void btnReady_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.options.Root = this.txtBrowse.Text))
                return;

            this.options.FileSizeLimit = (int)this.nudFileSizeLimit.Value * 1024;
            this.options.FileCountLimit = (int)this.nudFileCountLimit.Value;
            this.options.IsIncludeFilters = this.rbFiltersInclude.Checked;
            this.options.SetExtensionFilters(this.txtFilters.Text);
            this.options.IsArchiveRoot = this.rbZip.Checked;
            this.options.IncludeSubfolders = this.cbSubfolders.Checked;

            this.ClearFileItems();
            this.InitializeListViewWorker().RunWorkerAsync();
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
            this.SetProcessButtenEnabled();
        }

        private void cbIPAddress_CheckedChanged(object sender, EventArgs e)
        {
            this.txtPort.Enabled = this.cbIPAddress.Checked;
            this.serverOrAuthentificationChanged(sender, e);
        }

        private void rbAuth_CheckedChanged(object sender, EventArgs e)
        {
            this.lbUsername.Enabled = this.lbPassword.Enabled = this.txtUsername.Enabled = this.txtPassword.Enabled = this.rbSqlAuth.Checked;
            this.serverOrAuthentificationChanged(sender, e);
        }

        private void rbFolder_CheckedChanged(object sender, EventArgs e)
        {
            if (this.rbZip.Checked)
                this.btnBrowse.Image = Properties.Resources.Zip;
            else
                this.btnBrowse.Image = Properties.Resources.Folder;
        }

        private void serverOrAuthentificationChanged(object sender, EventArgs e)
        {
            this.SetValidConnectionEnabled(false);
            this.databaseOrTableNameChanged(sender, e);
        }

        private void databaseOrTableNameChanged(object sender, EventArgs e)
        {
            this.isValidDataTable = false;
            this.btnCreateTable.Image = Properties.Resources.DataTableUNKNOWN;
            this.SetProcessButtenEnabled();
        }

        private void ClearFileItems()
        {
            this.files.Clear();
            this.lvFileItems.Items.Clear();
        }

        private void SetValidConnectionEnabled(bool enable)
        {
            this.btnTestConnection.Image = (enable) ? Properties.Resources.ConnectionOK : Properties.Resources.ConnectionUKNOWN;
            this.lbDBName.Enabled = this.lbDTName.Enabled = this.cmbDatabaseNames.Enabled = this.txtTableName.Enabled = this.btnCreateTable.Enabled = enable;
        }

        private void SetProcessButtenEnabled()
        {
            this.btnProcess.Enabled = this.isValidDataTable && this.files.Count > 0;
        }

        private void SetSettingsGroupBoxEnabled(bool enable)
        {
            this.gbDatabaseSettings.Enabled = this.gbFileSettings.Enabled = this.gbFolderSettings.Enabled = this.btnReady.Enabled = enable;
            this.btnAbort.Enabled = !enable;
        }
    }
}
