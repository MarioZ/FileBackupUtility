namespace FileBackupUtility
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lvFileItems = new System.Windows.Forms.ListView();
            this.column1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.column2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.lvContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.gbFolderSettings = new System.Windows.Forms.GroupBox();
            this.cbSubfolders = new System.Windows.Forms.CheckBox();
            this.txtBrowse = new System.Windows.Forms.TextBox();
            this.rbZip = new System.Windows.Forms.RadioButton();
            this.rbFolder = new System.Windows.Forms.RadioButton();
            this.gbFileSettings = new System.Windows.Forms.GroupBox();
            this.rbFiltersExclude = new System.Windows.Forms.RadioButton();
            this.rbFiltersInclude = new System.Windows.Forms.RadioButton();
            this.lbExtensionFiltersEG = new System.Windows.Forms.Label();
            this.txtFilters = new System.Windows.Forms.TextBox();
            this.lbExtensionFilters = new System.Windows.Forms.Label();
            this.nudFileCountLimit = new System.Windows.Forms.NumericUpDown();
            this.lbFileCountLimit = new System.Windows.Forms.Label();
            this.nudFileSizeLimit = new System.Windows.Forms.NumericUpDown();
            this.lbFileSizeLimit = new System.Windows.Forms.Label();
            this.gbDatabaseSettings = new System.Windows.Forms.GroupBox();
            this.btnCreateTable = new System.Windows.Forms.Button();
            this.cmbDatabaseNames = new System.Windows.Forms.ComboBox();
            this.txtTableName = new System.Windows.Forms.TextBox();
            this.lbDTName = new System.Windows.Forms.Label();
            this.lbDBName = new System.Windows.Forms.Label();
            this.btnTestConnection = new System.Windows.Forms.Button();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.lbPassword = new System.Windows.Forms.Label();
            this.lbUsername = new System.Windows.Forms.Label();
            this.rbSqlAuth = new System.Windows.Forms.RadioButton();
            this.rbWinAuth = new System.Windows.Forms.RadioButton();
            this.cbIPAddress = new System.Windows.Forms.CheckBox();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.lbPort = new System.Windows.Forms.Label();
            this.txtServer = new System.Windows.Forms.TextBox();
            this.lbServer = new System.Windows.Forms.Label();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.btnAbort = new System.Windows.Forms.Button();
            this.btnProcess = new System.Windows.Forms.Button();
            this.btnReady = new System.Windows.Forms.Button();
            this.lvToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lvContextMenuStrip.SuspendLayout();
            this.gbFolderSettings.SuspendLayout();
            this.gbFileSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudFileCountLimit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudFileSizeLimit)).BeginInit();
            this.gbDatabaseSettings.SuspendLayout();
            this.SuspendLayout();
            // 
            // lvFileItems
            // 
            this.lvFileItems.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvFileItems.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lvFileItems.CausesValidation = false;
            this.lvFileItems.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.column1,
            this.column2});
            this.lvFileItems.FullRowSelect = true;
            this.lvFileItems.GridLines = true;
            this.lvFileItems.Location = new System.Drawing.Point(352, 12);
            this.lvFileItems.Name = "lvFileItems";
            this.lvFileItems.ShowItemToolTips = true;
            this.lvFileItems.Size = new System.Drawing.Size(350, 474);
            this.lvFileItems.TabIndex = 0;
            this.lvFileItems.TabStop = false;
            this.lvFileItems.UseCompatibleStateImageBehavior = false;
            this.lvFileItems.View = System.Windows.Forms.View.Details;
            this.lvFileItems.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.lvFileItems_ItemSelectionChanged);
            this.lvFileItems.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lvFileItems_MouseClick);
            // 
            // column1
            // 
            this.column1.Text = "File Name";
            this.column1.Width = 230;
            // 
            // column2
            // 
            this.column2.Text = "File Size [kB]";
            this.column2.Width = 100;
            // 
            // progressBar
            // 
            this.progressBar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar.Location = new System.Drawing.Point(352, 492);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(350, 23);
            this.progressBar.TabIndex = 3;
            // 
            // lvContextMenuStrip
            // 
            this.lvContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lvToolStripMenuItem});
            this.lvContextMenuStrip.Name = "lvContextMenuStrip";
            this.lvContextMenuStrip.Size = new System.Drawing.Size(165, 26);
            // 
            // gbFolderSettings
            // 
            this.gbFolderSettings.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbFolderSettings.Controls.Add(this.cbSubfolders);
            this.gbFolderSettings.Controls.Add(this.txtBrowse);
            this.gbFolderSettings.Controls.Add(this.rbZip);
            this.gbFolderSettings.Controls.Add(this.rbFolder);
            this.gbFolderSettings.Controls.Add(this.btnBrowse);
            this.gbFolderSettings.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.gbFolderSettings.Location = new System.Drawing.Point(13, 286);
            this.gbFolderSettings.Name = "gbFolderSettings";
            this.gbFolderSettings.Size = new System.Drawing.Size(325, 117);
            this.gbFolderSettings.TabIndex = 9;
            this.gbFolderSettings.TabStop = false;
            this.gbFolderSettings.Text = "Folder Settings";
            // 
            // cbSubfolders
            // 
            this.cbSubfolders.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbSubfolders.AutoSize = true;
            this.cbSubfolders.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cbSubfolders.Checked = true;
            this.cbSubfolders.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbSubfolders.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.cbSubfolders.Location = new System.Drawing.Point(156, 91);
            this.cbSubfolders.Name = "cbSubfolders";
            this.cbSubfolders.Size = new System.Drawing.Size(112, 17);
            this.cbSubfolders.TabIndex = 13;
            this.cbSubfolders.Text = "Include subfolders";
            this.cbSubfolders.UseVisualStyleBackColor = true;
            // 
            // txtBrowse
            // 
            this.txtBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBrowse.BackColor = System.Drawing.SystemColors.Window;
            this.txtBrowse.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txtBrowse.Location = new System.Drawing.Point(6, 65);
            this.txtBrowse.Name = "txtBrowse";
            this.txtBrowse.ReadOnly = true;
            this.txtBrowse.Size = new System.Drawing.Size(262, 20);
            this.txtBrowse.TabIndex = 12;
            // 
            // rbZip
            // 
            this.rbZip.AutoSize = true;
            this.rbZip.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.rbZip.Location = new System.Drawing.Point(6, 42);
            this.rbZip.Name = "rbZip";
            this.rbZip.Size = new System.Drawing.Size(40, 17);
            this.rbZip.TabIndex = 11;
            this.rbZip.Text = "Zip";
            this.rbZip.UseVisualStyleBackColor = true;
            this.rbZip.CheckedChanged += new System.EventHandler(this.rbFolder_CheckedChanged);
            // 
            // rbFolder
            // 
            this.rbFolder.AutoSize = true;
            this.rbFolder.Checked = true;
            this.rbFolder.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.rbFolder.Location = new System.Drawing.Point(6, 19);
            this.rbFolder.Name = "rbFolder";
            this.rbFolder.Size = new System.Drawing.Size(54, 17);
            this.rbFolder.TabIndex = 10;
            this.rbFolder.TabStop = true;
            this.rbFolder.Text = "Folder";
            this.rbFolder.UseVisualStyleBackColor = true;
            this.rbFolder.CheckedChanged += new System.EventHandler(this.rbFolder_CheckedChanged);
            // 
            // gbFileSettings
            // 
            this.gbFileSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbFileSettings.Controls.Add(this.rbFiltersExclude);
            this.gbFileSettings.Controls.Add(this.rbFiltersInclude);
            this.gbFileSettings.Controls.Add(this.lbExtensionFiltersEG);
            this.gbFileSettings.Controls.Add(this.txtFilters);
            this.gbFileSettings.Controls.Add(this.lbExtensionFilters);
            this.gbFileSettings.Controls.Add(this.nudFileCountLimit);
            this.gbFileSettings.Controls.Add(this.lbFileCountLimit);
            this.gbFileSettings.Controls.Add(this.nudFileSizeLimit);
            this.gbFileSettings.Controls.Add(this.lbFileSizeLimit);
            this.gbFileSettings.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.gbFileSettings.Location = new System.Drawing.Point(13, 409);
            this.gbFileSettings.Name = "gbFileSettings";
            this.gbFileSettings.Size = new System.Drawing.Size(325, 172);
            this.gbFileSettings.TabIndex = 10;
            this.gbFileSettings.TabStop = false;
            this.gbFileSettings.Text = "File Settings";
            // 
            // rbFiltersExclude
            // 
            this.rbFiltersExclude.AutoSize = true;
            this.rbFiltersExclude.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.rbFiltersExclude.Location = new System.Drawing.Point(6, 114);
            this.rbFiltersExclude.Name = "rbFiltersExclude";
            this.rbFiltersExclude.Size = new System.Drawing.Size(63, 17);
            this.rbFiltersExclude.TabIndex = 13;
            this.rbFiltersExclude.Text = "Exclude";
            this.rbFiltersExclude.UseVisualStyleBackColor = true;
            // 
            // rbFiltersInclude
            // 
            this.rbFiltersInclude.AutoSize = true;
            this.rbFiltersInclude.Checked = true;
            this.rbFiltersInclude.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.rbFiltersInclude.Location = new System.Drawing.Point(6, 91);
            this.rbFiltersInclude.Name = "rbFiltersInclude";
            this.rbFiltersInclude.Size = new System.Drawing.Size(60, 17);
            this.rbFiltersInclude.TabIndex = 12;
            this.rbFiltersInclude.TabStop = true;
            this.rbFiltersInclude.Text = "Include";
            this.rbFiltersInclude.UseVisualStyleBackColor = true;
            // 
            // lbExtensionFiltersEG
            // 
            this.lbExtensionFiltersEG.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lbExtensionFiltersEG.AutoSize = true;
            this.lbExtensionFiltersEG.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbExtensionFiltersEG.Location = new System.Drawing.Point(140, 152);
            this.lbExtensionFiltersEG.Name = "lbExtensionFiltersEG";
            this.lbExtensionFiltersEG.Size = new System.Drawing.Size(179, 13);
            this.lbExtensionFiltersEG.TabIndex = 6;
            this.lbExtensionFiltersEG.Text = "(e.g. .txt, .xml, .doc, .xls, .pdf, .jpg ...)";
            // 
            // txtFilters
            // 
            this.txtFilters.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFilters.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txtFilters.Location = new System.Drawing.Point(75, 89);
            this.txtFilters.Multiline = true;
            this.txtFilters.Name = "txtFilters";
            this.txtFilters.Size = new System.Drawing.Size(244, 60);
            this.txtFilters.TabIndex = 5;
            // 
            // lbExtensionFilters
            // 
            this.lbExtensionFilters.AutoSize = true;
            this.lbExtensionFilters.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbExtensionFilters.Location = new System.Drawing.Point(4, 73);
            this.lbExtensionFilters.Name = "lbExtensionFilters";
            this.lbExtensionFilters.Size = new System.Drawing.Size(83, 13);
            this.lbExtensionFilters.TabIndex = 4;
            this.lbExtensionFilters.Text = "Extension filters:";
            // 
            // nudFileCountLimit
            // 
            this.nudFileCountLimit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.nudFileCountLimit.Location = new System.Drawing.Point(100, 47);
            this.nudFileCountLimit.Name = "nudFileCountLimit";
            this.nudFileCountLimit.Size = new System.Drawing.Size(75, 20);
            this.nudFileCountLimit.TabIndex = 3;
            // 
            // lbFileCountLimit
            // 
            this.lbFileCountLimit.AutoSize = true;
            this.lbFileCountLimit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbFileCountLimit.Location = new System.Drawing.Point(4, 49);
            this.lbFileCountLimit.Name = "lbFileCountLimit";
            this.lbFileCountLimit.Size = new System.Drawing.Size(76, 13);
            this.lbFileCountLimit.TabIndex = 2;
            this.lbFileCountLimit.Text = "File count limit:";
            // 
            // nudFileSizeLimit
            // 
            this.nudFileSizeLimit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.nudFileSizeLimit.Location = new System.Drawing.Point(100, 23);
            this.nudFileSizeLimit.Name = "nudFileSizeLimit";
            this.nudFileSizeLimit.Size = new System.Drawing.Size(75, 20);
            this.nudFileSizeLimit.TabIndex = 1;
            // 
            // lbFileSizeLimit
            // 
            this.lbFileSizeLimit.AutoSize = true;
            this.lbFileSizeLimit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbFileSizeLimit.Location = new System.Drawing.Point(4, 25);
            this.lbFileSizeLimit.Name = "lbFileSizeLimit";
            this.lbFileSizeLimit.Size = new System.Drawing.Size(89, 13);
            this.lbFileSizeLimit.TabIndex = 0;
            this.lbFileSizeLimit.Text = "File size limit [kB]:";
            // 
            // gbDatabaseSettings
            // 
            this.gbDatabaseSettings.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbDatabaseSettings.Controls.Add(this.btnCreateTable);
            this.gbDatabaseSettings.Controls.Add(this.cmbDatabaseNames);
            this.gbDatabaseSettings.Controls.Add(this.txtTableName);
            this.gbDatabaseSettings.Controls.Add(this.lbDTName);
            this.gbDatabaseSettings.Controls.Add(this.lbDBName);
            this.gbDatabaseSettings.Controls.Add(this.btnTestConnection);
            this.gbDatabaseSettings.Controls.Add(this.txtPassword);
            this.gbDatabaseSettings.Controls.Add(this.txtUsername);
            this.gbDatabaseSettings.Controls.Add(this.lbPassword);
            this.gbDatabaseSettings.Controls.Add(this.lbUsername);
            this.gbDatabaseSettings.Controls.Add(this.rbSqlAuth);
            this.gbDatabaseSettings.Controls.Add(this.rbWinAuth);
            this.gbDatabaseSettings.Controls.Add(this.cbIPAddress);
            this.gbDatabaseSettings.Controls.Add(this.txtPort);
            this.gbDatabaseSettings.Controls.Add(this.lbPort);
            this.gbDatabaseSettings.Controls.Add(this.txtServer);
            this.gbDatabaseSettings.Controls.Add(this.lbServer);
            this.gbDatabaseSettings.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.gbDatabaseSettings.Location = new System.Drawing.Point(13, 12);
            this.gbDatabaseSettings.Name = "gbDatabaseSettings";
            this.gbDatabaseSettings.Size = new System.Drawing.Size(325, 268);
            this.gbDatabaseSettings.TabIndex = 11;
            this.gbDatabaseSettings.TabStop = false;
            this.gbDatabaseSettings.Text = "Database Settings";
            // 
            // btnCreateTable
            // 
            this.btnCreateTable.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCreateTable.Enabled = false;
            this.btnCreateTable.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnCreateTable.Image = global::FileBackupUtility.Properties.Resources.DataTableUNKNOWN;
            this.btnCreateTable.Location = new System.Drawing.Point(274, 212);
            this.btnCreateTable.Name = "btnCreateTable";
            this.btnCreateTable.Size = new System.Drawing.Size(45, 47);
            this.btnCreateTable.TabIndex = 17;
            this.btnCreateTable.UseVisualStyleBackColor = true;
            this.btnCreateTable.Click += new System.EventHandler(this.btnCreateTable_Click);
            // 
            // cmbDatabaseNames
            // 
            this.cmbDatabaseNames.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbDatabaseNames.Enabled = false;
            this.cmbDatabaseNames.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.cmbDatabaseNames.FormattingEnabled = true;
            this.cmbDatabaseNames.Location = new System.Drawing.Point(98, 212);
            this.cmbDatabaseNames.Name = "cmbDatabaseNames";
            this.cmbDatabaseNames.Size = new System.Drawing.Size(170, 21);
            this.cmbDatabaseNames.TabIndex = 16;
            this.cmbDatabaseNames.SelectedIndexChanged += new System.EventHandler(this.databaseOrTableNameChanged);
            // 
            // txtTableName
            // 
            this.txtTableName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTableName.Enabled = false;
            this.txtTableName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txtTableName.Location = new System.Drawing.Point(97, 239);
            this.txtTableName.Name = "txtTableName";
            this.txtTableName.Size = new System.Drawing.Size(171, 20);
            this.txtTableName.TabIndex = 15;
            this.txtTableName.TextChanged += new System.EventHandler(this.databaseOrTableNameChanged);
            // 
            // lbDTName
            // 
            this.lbDTName.AutoSize = true;
            this.lbDTName.Enabled = false;
            this.lbDTName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbDTName.Location = new System.Drawing.Point(8, 242);
            this.lbDTName.Name = "lbDTName";
            this.lbDTName.Size = new System.Drawing.Size(66, 13);
            this.lbDTName.TabIndex = 13;
            this.lbDTName.Text = "Table name:";
            // 
            // lbDBName
            // 
            this.lbDBName.AutoSize = true;
            this.lbDBName.Enabled = false;
            this.lbDBName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbDBName.Location = new System.Drawing.Point(8, 215);
            this.lbDBName.Name = "lbDBName";
            this.lbDBName.Size = new System.Drawing.Size(85, 13);
            this.lbDBName.TabIndex = 12;
            this.lbDBName.Text = "Database name:";
            // 
            // btnTestConnection
            // 
            this.btnTestConnection.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnTestConnection.Location = new System.Drawing.Point(5, 183);
            this.btnTestConnection.Name = "btnTestConnection";
            this.btnTestConnection.Size = new System.Drawing.Size(314, 23);
            this.btnTestConnection.TabIndex = 11;
            this.btnTestConnection.Text = "Test Connection";
            this.btnTestConnection.UseVisualStyleBackColor = true;
            this.btnTestConnection.Click += new System.EventHandler(this.btnTestConnection_Click);
            // 
            // txtPassword
            // 
            this.txtPassword.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPassword.Enabled = false;
            this.txtPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txtPassword.Location = new System.Drawing.Point(99, 157);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(220, 20);
            this.txtPassword.TabIndex = 10;
            this.txtPassword.TextChanged += new System.EventHandler(this.serverOrAuthentificationChanged);
            // 
            // txtUsername
            // 
            this.txtUsername.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUsername.Enabled = false;
            this.txtUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txtUsername.Location = new System.Drawing.Point(99, 133);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(220, 20);
            this.txtUsername.TabIndex = 9;
            this.txtUsername.TextChanged += new System.EventHandler(this.serverOrAuthentificationChanged);
            // 
            // lbPassword
            // 
            this.lbPassword.AutoSize = true;
            this.lbPassword.Enabled = false;
            this.lbPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbPassword.Location = new System.Drawing.Point(35, 160);
            this.lbPassword.Name = "lbPassword";
            this.lbPassword.Size = new System.Drawing.Size(56, 13);
            this.lbPassword.TabIndex = 8;
            this.lbPassword.Text = "Password:";
            // 
            // lbUsername
            // 
            this.lbUsername.AutoSize = true;
            this.lbUsername.Enabled = false;
            this.lbUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbUsername.Location = new System.Drawing.Point(35, 136);
            this.lbUsername.Name = "lbUsername";
            this.lbUsername.Size = new System.Drawing.Size(58, 13);
            this.lbUsername.TabIndex = 7;
            this.lbUsername.Text = "Username:";
            // 
            // rbSqlAuth
            // 
            this.rbSqlAuth.AutoSize = true;
            this.rbSqlAuth.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.rbSqlAuth.Location = new System.Drawing.Point(6, 113);
            this.rbSqlAuth.Name = "rbSqlAuth";
            this.rbSqlAuth.Size = new System.Drawing.Size(147, 17);
            this.rbSqlAuth.TabIndex = 6;
            this.rbSqlAuth.Text = "Sql server authentification";
            this.rbSqlAuth.UseVisualStyleBackColor = true;
            this.rbSqlAuth.CheckedChanged += new System.EventHandler(this.rbAuth_CheckedChanged);
            // 
            // rbWinAuth
            // 
            this.rbWinAuth.AutoSize = true;
            this.rbWinAuth.Checked = true;
            this.rbWinAuth.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.rbWinAuth.Location = new System.Drawing.Point(6, 90);
            this.rbWinAuth.Name = "rbWinAuth";
            this.rbWinAuth.Size = new System.Drawing.Size(144, 17);
            this.rbWinAuth.TabIndex = 5;
            this.rbWinAuth.TabStop = true;
            this.rbWinAuth.Text = "Windows authentification";
            this.rbWinAuth.UseVisualStyleBackColor = true;
            this.rbWinAuth.CheckedChanged += new System.EventHandler(this.rbAuth_CheckedChanged);
            // 
            // cbIPAddress
            // 
            this.cbIPAddress.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbIPAddress.AutoSize = true;
            this.cbIPAddress.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cbIPAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.cbIPAddress.Location = new System.Drawing.Point(140, 67);
            this.cbIPAddress.Name = "cbIPAddress";
            this.cbIPAddress.Size = new System.Drawing.Size(98, 17);
            this.cbIPAddress.TabIndex = 4;
            this.cbIPAddress.Text = "Use IP address";
            this.cbIPAddress.UseVisualStyleBackColor = true;
            this.cbIPAddress.CheckedChanged += new System.EventHandler(this.cbIPAddress_CheckedChanged);
            // 
            // txtPort
            // 
            this.txtPort.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPort.Enabled = false;
            this.txtPort.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txtPort.Location = new System.Drawing.Point(244, 41);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(75, 20);
            this.txtPort.TabIndex = 3;
            this.txtPort.TextChanged += new System.EventHandler(this.serverOrAuthentificationChanged);
            // 
            // lbPort
            // 
            this.lbPort.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbPort.AutoSize = true;
            this.lbPort.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbPort.Location = new System.Drawing.Point(241, 25);
            this.lbPort.Name = "lbPort";
            this.lbPort.Size = new System.Drawing.Size(29, 13);
            this.lbPort.TabIndex = 2;
            this.lbPort.Text = "Port:";
            // 
            // txtServer
            // 
            this.txtServer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtServer.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txtServer.Location = new System.Drawing.Point(7, 41);
            this.txtServer.Name = "txtServer";
            this.txtServer.Size = new System.Drawing.Size(231, 20);
            this.txtServer.TabIndex = 1;
            this.txtServer.TextChanged += new System.EventHandler(this.serverOrAuthentificationChanged);
            // 
            // lbServer
            // 
            this.lbServer.AutoSize = true;
            this.lbServer.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbServer.Location = new System.Drawing.Point(4, 25);
            this.lbServer.Name = "lbServer";
            this.lbServer.Size = new System.Drawing.Size(41, 13);
            this.lbServer.TabIndex = 0;
            this.lbServer.Text = "Server:";
            // 
            // btnBrowse
            // 
            this.btnBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowse.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnBrowse.Image = global::FileBackupUtility.Properties.Resources.Folder;
            this.btnBrowse.Location = new System.Drawing.Point(274, 63);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(45, 45);
            this.btnBrowse.TabIndex = 9;
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // btnAbort
            // 
            this.btnAbort.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAbort.Enabled = false;
            this.btnAbort.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnAbort.Image = global::FileBackupUtility.Properties.Resources.Abort;
            this.btnAbort.Location = new System.Drawing.Point(602, 521);
            this.btnAbort.Name = "btnAbort";
            this.btnAbort.Size = new System.Drawing.Size(100, 60);
            this.btnAbort.TabIndex = 7;
            this.btnAbort.UseVisualStyleBackColor = true;
            this.btnAbort.Click += new System.EventHandler(this.btnAbort_Click);
            // 
            // btnProcess
            // 
            this.btnProcess.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnProcess.Enabled = false;
            this.btnProcess.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnProcess.Image = global::FileBackupUtility.Properties.Resources.Process;
            this.btnProcess.Location = new System.Drawing.Point(458, 521);
            this.btnProcess.Name = "btnProcess";
            this.btnProcess.Size = new System.Drawing.Size(138, 60);
            this.btnProcess.TabIndex = 2;
            this.btnProcess.UseVisualStyleBackColor = true;
            this.btnProcess.Click += new System.EventHandler(this.btnProcess_Click);
            // 
            // btnReady
            // 
            this.btnReady.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReady.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnReady.Image = global::FileBackupUtility.Properties.Resources.Ready;
            this.btnReady.Location = new System.Drawing.Point(352, 521);
            this.btnReady.Name = "btnReady";
            this.btnReady.Size = new System.Drawing.Size(100, 60);
            this.btnReady.TabIndex = 1;
            this.btnReady.UseVisualStyleBackColor = true;
            this.btnReady.Click += new System.EventHandler(this.btnReady_Click);
            // 
            // lvToolStripMenuItem
            // 
            this.lvToolStripMenuItem.Image = global::FileBackupUtility.Properties.Resources.Remove;
            this.lvToolStripMenuItem.Name = "lvToolStripMenuItem";
            this.lvToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.lvToolStripMenuItem.Text = "Remove Selected";
            this.lvToolStripMenuItem.Click += new System.EventHandler(this.lvToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(714, 586);
            this.Controls.Add(this.gbDatabaseSettings);
            this.Controls.Add(this.gbFileSettings);
            this.Controls.Add(this.gbFolderSettings);
            this.Controls.Add(this.btnAbort);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.btnProcess);
            this.Controls.Add(this.btnReady);
            this.Controls.Add(this.lvFileItems);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.MinimumSize = new System.Drawing.Size(730, 620);
            this.Name = "MainForm";
            this.Text = "File Backup Utility";
            this.lvContextMenuStrip.ResumeLayout(false);
            this.gbFolderSettings.ResumeLayout(false);
            this.gbFolderSettings.PerformLayout();
            this.gbFileSettings.ResumeLayout(false);
            this.gbFileSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudFileCountLimit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudFileSizeLimit)).EndInit();
            this.gbDatabaseSettings.ResumeLayout(false);
            this.gbDatabaseSettings.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lvFileItems;
        private System.Windows.Forms.ColumnHeader column1;
        private System.Windows.Forms.ColumnHeader column2;
        private System.Windows.Forms.Button btnReady;
        private System.Windows.Forms.Button btnProcess;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.ContextMenuStrip lvContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem lvToolStripMenuItem;
        private System.Windows.Forms.Button btnAbort;
        private System.Windows.Forms.GroupBox gbFolderSettings;
        private System.Windows.Forms.CheckBox cbSubfolders;
        private System.Windows.Forms.TextBox txtBrowse;
        private System.Windows.Forms.RadioButton rbZip;
        private System.Windows.Forms.RadioButton rbFolder;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.GroupBox gbFileSettings;
        private System.Windows.Forms.RadioButton rbFiltersExclude;
        private System.Windows.Forms.RadioButton rbFiltersInclude;
        private System.Windows.Forms.Label lbExtensionFiltersEG;
        private System.Windows.Forms.TextBox txtFilters;
        private System.Windows.Forms.Label lbExtensionFilters;
        private System.Windows.Forms.NumericUpDown nudFileCountLimit;
        private System.Windows.Forms.Label lbFileCountLimit;
        private System.Windows.Forms.NumericUpDown nudFileSizeLimit;
        private System.Windows.Forms.Label lbFileSizeLimit;
        private System.Windows.Forms.GroupBox gbDatabaseSettings;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.Label lbPort;
        private System.Windows.Forms.TextBox txtServer;
        private System.Windows.Forms.Label lbServer;
        private System.Windows.Forms.RadioButton rbSqlAuth;
        private System.Windows.Forms.RadioButton rbWinAuth;
        private System.Windows.Forms.CheckBox cbIPAddress;
        private System.Windows.Forms.TextBox txtTableName;
        private System.Windows.Forms.Label lbDTName;
        private System.Windows.Forms.Label lbDBName;
        private System.Windows.Forms.Button btnTestConnection;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label lbPassword;
        private System.Windows.Forms.Label lbUsername;
        private System.Windows.Forms.Button btnCreateTable;
        private System.Windows.Forms.ComboBox cmbDatabaseNames;
    }
}

