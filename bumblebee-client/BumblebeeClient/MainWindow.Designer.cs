namespace BumblebeeClient
{
    partial class MainWindow
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.serverlist = new System.Windows.Forms.GroupBox();
            this.execStatus = new System.Windows.Forms.Label();
            this.selectrev = new System.Windows.Forms.Button();
            this.selectall = new System.Windows.Forms.Button();
            this.agentDataGrid = new System.Windows.Forms.DataGridView();
            this.rstx = new System.Windows.Forms.Button();
            this.groupSearch = new System.Windows.Forms.GroupBox();
            this.managerBox = new System.Windows.Forms.ComboBox();
            this.searchContentTxt = new System.Windows.Forms.TextBox();
            this.subNameBox = new System.Windows.Forms.ComboBox();
            this.searchbtn = new System.Windows.Forms.Button();
            this.searchTypeBox = new System.Windows.Forms.ComboBox();
            this.mainNameBox = new System.Windows.Forms.ComboBox();
            this.label_cmd_title = new System.Windows.Forms.Label();
            this.cmdtext = new System.Windows.Forms.TextBox();
            this.execbtn = new System.Windows.Forms.Button();
            this.groupAction = new System.Windows.Forms.GroupBox();
            this.agentInfoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.rsttitle = new System.Windows.Forms.GroupBox();
            this.rst = new System.Windows.Forms.TextBox();
            this.reloginbtn = new System.Windows.Forms.Label();
            this.aboutbtn = new System.Windows.Forms.Label();
            this.usernameLabel = new System.Windows.Forms.Label();
            this.ck_column = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.AgentIp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rflag = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rResult = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rstfull = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AgentName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Asset = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Manager = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MainName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SubName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.shell = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Os = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.serverlist.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.agentDataGrid)).BeginInit();
            this.groupSearch.SuspendLayout();
            this.groupAction.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.agentInfoBindingSource)).BeginInit();
            this.rsttitle.SuspendLayout();
            this.SuspendLayout();
            // 
            // serverlist
            // 
            this.serverlist.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.serverlist.Controls.Add(this.execStatus);
            this.serverlist.Controls.Add(this.selectrev);
            this.serverlist.Controls.Add(this.selectall);
            this.serverlist.Controls.Add(this.agentDataGrid);
            this.serverlist.Location = new System.Drawing.Point(12, 150);
            this.serverlist.Name = "serverlist";
            this.serverlist.Size = new System.Drawing.Size(853, 420);
            this.serverlist.TabIndex = 0;
            this.serverlist.TabStop = false;
            this.serverlist.Text = "服务器列表 总数:0";
            // 
            // execStatus
            // 
            this.execStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.execStatus.Location = new System.Drawing.Point(566, 386);
            this.execStatus.Name = "execStatus";
            this.execStatus.Size = new System.Drawing.Size(280, 23);
            this.execStatus.TabIndex = 3;
            this.execStatus.Text = "执行中:0,成功:0,失败:0";
            this.execStatus.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // selectrev
            // 
            this.selectrev.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.selectrev.Location = new System.Drawing.Point(117, 385);
            this.selectrev.Name = "selectrev";
            this.selectrev.Size = new System.Drawing.Size(75, 23);
            this.selectrev.TabIndex = 2;
            this.selectrev.Text = "反选";
            this.selectrev.UseVisualStyleBackColor = true;
            this.selectrev.Click += new System.EventHandler(this.selectrev_Click);
            // 
            // selectall
            // 
            this.selectall.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.selectall.Location = new System.Drawing.Point(18, 385);
            this.selectall.Name = "selectall";
            this.selectall.Size = new System.Drawing.Size(75, 23);
            this.selectall.TabIndex = 1;
            this.selectall.Text = "全选";
            this.selectall.UseVisualStyleBackColor = true;
            this.selectall.Click += new System.EventHandler(this.selectall_Click);
            // 
            // agentDataGrid
            // 
            this.agentDataGrid.AllowUserToAddRows = false;
            this.agentDataGrid.AllowUserToResizeRows = false;
            this.agentDataGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.agentDataGrid.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.agentDataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ck_column,
            this.AgentIp,
            this.rflag,
            this.rResult,
            this.rstfull,
            this.AgentName,
            this.Asset,
            this.Manager,
            this.MainName,
            this.SubName,
            this.shell,
            this.Os});
            this.agentDataGrid.Location = new System.Drawing.Point(18, 29);
            this.agentDataGrid.Name = "agentDataGrid";
            this.agentDataGrid.RowTemplate.Height = 23;
            this.agentDataGrid.ShowCellToolTips = false;
            this.agentDataGrid.ShowEditingIcon = false;
            this.agentDataGrid.Size = new System.Drawing.Size(829, 347);
            this.agentDataGrid.TabIndex = 0;
            this.agentDataGrid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.agentDataGrid_CellContentClick);
            this.agentDataGrid.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.agentDataGrid_ColumnHeaderMouseClick);
            this.agentDataGrid.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.agentDataGrid_RowPostPaint);
            // 
            // rstx
            // 
            this.rstx.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.rstx.Location = new System.Drawing.Point(124, 387);
            this.rstx.Name = "rstx";
            this.rstx.Size = new System.Drawing.Size(90, 23);
            this.rstx.TabIndex = 5;
            this.rstx.Text = "复制执行结果";
            this.rstx.UseVisualStyleBackColor = true;
            this.rstx.Click += new System.EventHandler(this.rstx_Click);
            // 
            // groupSearch
            // 
            this.groupSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupSearch.Controls.Add(this.managerBox);
            this.groupSearch.Controls.Add(this.searchContentTxt);
            this.groupSearch.Controls.Add(this.subNameBox);
            this.groupSearch.Controls.Add(this.searchbtn);
            this.groupSearch.Controls.Add(this.searchTypeBox);
            this.groupSearch.Controls.Add(this.mainNameBox);
            this.groupSearch.Location = new System.Drawing.Point(12, 75);
            this.groupSearch.Name = "groupSearch";
            this.groupSearch.Size = new System.Drawing.Size(1079, 55);
            this.groupSearch.TabIndex = 1;
            this.groupSearch.TabStop = false;
            this.groupSearch.Text = "搜索";
            // 
            // managerBox
            // 
            this.managerBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.managerBox.FormattingEnabled = true;
            this.managerBox.Items.AddRange(new object[] {
            "负责人"});
            this.managerBox.Location = new System.Drawing.Point(372, 21);
            this.managerBox.Name = "managerBox";
            this.managerBox.Size = new System.Drawing.Size(128, 20);
            this.managerBox.TabIndex = 8;
            // 
            // searchContentTxt
            // 
            this.searchContentTxt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.searchContentTxt.Location = new System.Drawing.Point(718, 20);
            this.searchContentTxt.Name = "searchContentTxt";
            this.searchContentTxt.Size = new System.Drawing.Size(183, 21);
            this.searchContentTxt.TabIndex = 7;
            // 
            // subNameBox
            // 
            this.subNameBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.subNameBox.FormattingEnabled = true;
            this.subNameBox.Items.AddRange(new object[] {
            "二级分类"});
            this.subNameBox.Location = new System.Drawing.Point(195, 21);
            this.subNameBox.Name = "subNameBox";
            this.subNameBox.Size = new System.Drawing.Size(132, 20);
            this.subNameBox.TabIndex = 1;
            // 
            // searchbtn
            // 
            this.searchbtn.Location = new System.Drawing.Point(927, 19);
            this.searchbtn.Name = "searchbtn";
            this.searchbtn.Size = new System.Drawing.Size(75, 23);
            this.searchbtn.TabIndex = 6;
            this.searchbtn.Text = "搜索";
            this.searchbtn.UseVisualStyleBackColor = true;
            this.searchbtn.Click += new System.EventHandler(this.searchbtn_Click);
            // 
            // searchTypeBox
            // 
            this.searchTypeBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.searchTypeBox.FormattingEnabled = true;
            this.searchTypeBox.Items.AddRange(new object[] {
            "其它搜索条件",
            "IP",
            "应用",
            "资产号"});
            this.searchTypeBox.Location = new System.Drawing.Point(544, 21);
            this.searchTypeBox.Name = "searchTypeBox";
            this.searchTypeBox.Size = new System.Drawing.Size(115, 20);
            this.searchTypeBox.TabIndex = 5;
            // 
            // mainNameBox
            // 
            this.mainNameBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.mainNameBox.FormattingEnabled = true;
            this.mainNameBox.Items.AddRange(new object[] {
            "一级分类"});
            this.mainNameBox.Location = new System.Drawing.Point(36, 21);
            this.mainNameBox.Name = "mainNameBox";
            this.mainNameBox.Size = new System.Drawing.Size(120, 20);
            this.mainNameBox.TabIndex = 0;
            this.mainNameBox.SelectedIndexChanged += new System.EventHandler(this.mainNameBox_SelectedIndexChanged);
            // 
            // label_cmd_title
            // 
            this.label_cmd_title.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label_cmd_title.AutoSize = true;
            this.label_cmd_title.Location = new System.Drawing.Point(17, 31);
            this.label_cmd_title.Name = "label_cmd_title";
            this.label_cmd_title.Size = new System.Drawing.Size(41, 12);
            this.label_cmd_title.TabIndex = 2;
            this.label_cmd_title.Text = "命令：";
            // 
            // cmdtext
            // 
            this.cmdtext.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdtext.Location = new System.Drawing.Point(72, 26);
            this.cmdtext.Name = "cmdtext";
            this.cmdtext.Size = new System.Drawing.Size(880, 21);
            this.cmdtext.TabIndex = 3;
            // 
            // execbtn
            // 
            this.execbtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.execbtn.Location = new System.Drawing.Point(970, 24);
            this.execbtn.Name = "execbtn";
            this.execbtn.Size = new System.Drawing.Size(100, 23);
            this.execbtn.TabIndex = 4;
            this.execbtn.Text = "执行";
            this.execbtn.UseVisualStyleBackColor = true;
            this.execbtn.Click += new System.EventHandler(this.execbtn_Click);
            // 
            // groupAction
            // 
            this.groupAction.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupAction.Controls.Add(this.cmdtext);
            this.groupAction.Controls.Add(this.execbtn);
            this.groupAction.Controls.Add(this.label_cmd_title);
            this.groupAction.Location = new System.Drawing.Point(12, 576);
            this.groupAction.Name = "groupAction";
            this.groupAction.Size = new System.Drawing.Size(1079, 65);
            this.groupAction.TabIndex = 2;
            this.groupAction.TabStop = false;
            this.groupAction.Text = "操作";
            // 
            // rsttitle
            // 
            this.rsttitle.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rsttitle.Controls.Add(this.rst);
            this.rsttitle.Controls.Add(this.rstx);
            this.rsttitle.Location = new System.Drawing.Point(871, 150);
            this.rsttitle.Name = "rsttitle";
            this.rsttitle.Size = new System.Drawing.Size(220, 420);
            this.rsttitle.TabIndex = 4;
            this.rsttitle.TabStop = false;
            this.rsttitle.Text = "Result:";
            // 
            // rst
            // 
            this.rst.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rst.Location = new System.Drawing.Point(6, 26);
            this.rst.Multiline = true;
            this.rst.Name = "rst";
            this.rst.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.rst.Size = new System.Drawing.Size(208, 347);
            this.rst.TabIndex = 6;
            // 
            // reloginbtn
            // 
            this.reloginbtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.reloginbtn.AutoSize = true;
            this.reloginbtn.BackColor = System.Drawing.Color.Transparent;
            this.reloginbtn.ForeColor = System.Drawing.Color.White;
            this.reloginbtn.Location = new System.Drawing.Point(940, 40);
            this.reloginbtn.Name = "reloginbtn";
            this.reloginbtn.Size = new System.Drawing.Size(65, 12);
            this.reloginbtn.TabIndex = 5;
            this.reloginbtn.Text = "(重新登录)";
            this.reloginbtn.Click += new System.EventHandler(this.reloginbtn_Click);
            // 
            // aboutbtn
            // 
            this.aboutbtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.aboutbtn.AutoSize = true;
            this.aboutbtn.BackColor = System.Drawing.Color.Transparent;
            this.aboutbtn.ForeColor = System.Drawing.Color.White;
            this.aboutbtn.Location = new System.Drawing.Point(1017, 40);
            this.aboutbtn.Name = "aboutbtn";
            this.aboutbtn.Size = new System.Drawing.Size(83, 12);
            this.aboutbtn.TabIndex = 6;
            this.aboutbtn.Text = "关于Bumblebee";
            this.aboutbtn.Click += new System.EventHandler(this.aboutbtn_Click);
            // 
            // usernameLabel
            // 
            this.usernameLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.usernameLabel.BackColor = System.Drawing.Color.Transparent;
            this.usernameLabel.ForeColor = System.Drawing.Color.White;
            this.usernameLabel.Location = new System.Drawing.Point(692, 40);
            this.usernameLabel.Name = "usernameLabel";
            this.usernameLabel.Size = new System.Drawing.Size(248, 12);
            this.usernameLabel.TabIndex = 7;
            this.usernameLabel.Text = "u";
            this.usernameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ck_column
            // 
            this.ck_column.HeaderText = "";
            this.ck_column.MinimumWidth = 30;
            this.ck_column.Name = "ck_column";
            this.ck_column.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ck_column.Width = 30;
            // 
            // AgentIp
            // 
            this.AgentIp.DataPropertyName = "AgentIp";
            this.AgentIp.HeaderText = "IP";
            this.AgentIp.Name = "AgentIp";
            this.AgentIp.ReadOnly = true;
            this.AgentIp.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // rflag
            // 
            this.rflag.DataPropertyName = "rflag";
            this.rflag.HeaderText = "状态";
            this.rflag.Name = "rflag";
            this.rflag.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.rflag.Width = 40;
            // 
            // rResult
            // 
            this.rResult.DataPropertyName = "rResult";
            this.rResult.FillWeight = 350F;
            this.rResult.HeaderText = "返回值";
            this.rResult.MinimumWidth = 50;
            this.rResult.Name = "rResult";
            this.rResult.ReadOnly = true;
            this.rResult.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.rResult.Width = 170;
            // 
            // rstfull
            // 
            this.rstfull.HeaderText = "rstfull";
            this.rstfull.Name = "rstfull";
            this.rstfull.ReadOnly = true;
            this.rstfull.Visible = false;
            // 
            // AgentName
            // 
            this.AgentName.DataPropertyName = "AgentName";
            this.AgentName.FillWeight = 80F;
            this.AgentName.HeaderText = "应用";
            this.AgentName.Name = "AgentName";
            this.AgentName.ReadOnly = true;
            this.AgentName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.AgentName.Width = 75;
            // 
            // Asset
            // 
            this.Asset.DataPropertyName = "Asset";
            this.Asset.FillWeight = 60F;
            this.Asset.HeaderText = "资产号";
            this.Asset.Name = "Asset";
            this.Asset.ReadOnly = true;
            this.Asset.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.Asset.Width = 60;
            // 
            // Manager
            // 
            this.Manager.DataPropertyName = "Manager";
            this.Manager.FillWeight = 60F;
            this.Manager.HeaderText = "负责人";
            this.Manager.Name = "Manager";
            this.Manager.ReadOnly = true;
            this.Manager.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.Manager.Width = 60;
            // 
            // MainName
            // 
            this.MainName.DataPropertyName = "MainName";
            this.MainName.FillWeight = 80F;
            this.MainName.HeaderText = "一级分类";
            this.MainName.Name = "MainName";
            this.MainName.ReadOnly = true;
            this.MainName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.MainName.Width = 75;
            // 
            // SubName
            // 
            this.SubName.DataPropertyName = "SubName";
            this.SubName.FillWeight = 80F;
            this.SubName.HeaderText = "二级分类";
            this.SubName.Name = "SubName";
            this.SubName.ReadOnly = true;
            this.SubName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.SubName.Width = 75;
            // 
            // shell
            // 
            this.shell.DataPropertyName = "conn";
            this.shell.HeaderText = "SHELL";
            this.shell.Name = "shell";
            this.shell.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.shell.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.shell.Text = "连接";
            this.shell.ToolTipText = "连接";
            this.shell.UseColumnTextForButtonValue = true;
            this.shell.Visible = false;
            this.shell.Width = 45;
            // 
            // Os
            // 
            this.Os.DataPropertyName = "Os";
            this.Os.HeaderText = "操作系统";
            this.Os.Name = "Os";
            this.Os.Width = 80;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1112, 653);
            this.Controls.Add(this.usernameLabel);
            this.Controls.Add(this.aboutbtn);
            this.Controls.Add(this.reloginbtn);
            this.Controls.Add(this.rsttitle);
            this.Controls.Add(this.groupAction);
            this.Controls.Add(this.groupSearch);
            this.Controls.Add(this.serverlist);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(1112, 653);
            this.Name = "MainWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BumblebeeClient";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainWindow_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainWindow_FormClosed);
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.serverlist.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.agentDataGrid)).EndInit();
            this.groupSearch.ResumeLayout(false);
            this.groupSearch.PerformLayout();
            this.groupAction.ResumeLayout(false);
            this.groupAction.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.agentInfoBindingSource)).EndInit();
            this.rsttitle.ResumeLayout(false);
            this.rsttitle.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox serverlist;
        private System.Windows.Forms.DataGridView agentDataGrid;
        private System.Windows.Forms.GroupBox groupSearch;
        private System.Windows.Forms.ComboBox subNameBox;
        private System.Windows.Forms.ComboBox mainNameBox;
        private System.Windows.Forms.ComboBox managerBox;
        private System.Windows.Forms.TextBox searchContentTxt;
        private System.Windows.Forms.Button searchbtn;
        private System.Windows.Forms.ComboBox searchTypeBox;
        private System.Windows.Forms.Button execbtn;
        private System.Windows.Forms.TextBox cmdtext;
        private System.Windows.Forms.Label label_cmd_title;
        private System.Windows.Forms.GroupBox groupAction;
        private System.Windows.Forms.Button selectall;
        private System.Windows.Forms.Button selectrev;
        private System.Windows.Forms.BindingSource agentInfoBindingSource;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button rstx;
        private System.Windows.Forms.GroupBox rsttitle;
        private System.Windows.Forms.TextBox rst;
        private System.Windows.Forms.Label reloginbtn;
        private System.Windows.Forms.Label aboutbtn;
        private System.Windows.Forms.Label usernameLabel;
        private System.Windows.Forms.Label execStatus;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ck_column;
        private System.Windows.Forms.DataGridViewTextBoxColumn AgentIp;
        private System.Windows.Forms.DataGridViewTextBoxColumn rflag;
        private System.Windows.Forms.DataGridViewTextBoxColumn rResult;
        private System.Windows.Forms.DataGridViewTextBoxColumn rstfull;
        private System.Windows.Forms.DataGridViewTextBoxColumn AgentName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Asset;
        private System.Windows.Forms.DataGridViewTextBoxColumn Manager;
        private System.Windows.Forms.DataGridViewTextBoxColumn MainName;
        private System.Windows.Forms.DataGridViewTextBoxColumn SubName;
        private System.Windows.Forms.DataGridViewButtonColumn shell;
        private System.Windows.Forms.DataGridViewTextBoxColumn Os;
    }
}

