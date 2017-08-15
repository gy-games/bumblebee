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
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.HelpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AbloutElvesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ReloginToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.serverlist = new System.Windows.Forms.GroupBox();
            this.selectrev = new System.Windows.Forms.Button();
            this.selectall = new System.Windows.Forms.Button();
            this.agentDataGrid = new System.Windows.Forms.DataGridView();
            this.ck_column = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.AgentIp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Result = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AgentName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Asset = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Manager = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MainName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SubName = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.loginStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.rsttitle = new System.Windows.Forms.GroupBox();
            this.rst = new System.Windows.Forms.TextBox();
            this.menuStrip.SuspendLayout();
            this.serverlist.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.agentDataGrid)).BeginInit();
            this.groupSearch.SuspendLayout();
            this.groupAction.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.agentInfoBindingSource)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.rsttitle.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.menuStrip.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.menuStrip.GripMargin = new System.Windows.Forms.Padding(0);
            this.menuStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.HelpToolStripMenuItem,
            this.ReloginToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(1195, 25);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip1";
            this.menuStrip.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // HelpToolStripMenuItem
            // 
            this.HelpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AbloutElvesToolStripMenuItem});
            this.HelpToolStripMenuItem.Name = "HelpToolStripMenuItem";
            this.HelpToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.HelpToolStripMenuItem.Text = "帮助";
            this.HelpToolStripMenuItem.Click += new System.EventHandler(this.HelpToolStripMenuItem_Click);
            // 
            // AbloutElvesToolStripMenuItem
            // 
            this.AbloutElvesToolStripMenuItem.Name = "AbloutElvesToolStripMenuItem";
            this.AbloutElvesToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.AbloutElvesToolStripMenuItem.Text = "关于Bumblebee";
            this.AbloutElvesToolStripMenuItem.Click += new System.EventHandler(this.AboutElvesToolStripMenuItem_Click);
            // 
            // ReloginToolStripMenuItem
            // 
            this.ReloginToolStripMenuItem.Name = "ReloginToolStripMenuItem";
            this.ReloginToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.ReloginToolStripMenuItem.Text = "重新登录";
            this.ReloginToolStripMenuItem.Click += new System.EventHandler(this.ReloginToolStripMenuItem_Click);
            // 
            // serverlist
            // 
            this.serverlist.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.serverlist.Controls.Add(this.selectrev);
            this.serverlist.Controls.Add(this.selectall);
            this.serverlist.Controls.Add(this.agentDataGrid);
            this.serverlist.Location = new System.Drawing.Point(12, 89);
            this.serverlist.Name = "serverlist";
            this.serverlist.Size = new System.Drawing.Size(917, 556);
            this.serverlist.TabIndex = 0;
            this.serverlist.TabStop = false;
            this.serverlist.Text = "服务器列表";
            // 
            // selectrev
            // 
            this.selectrev.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.selectrev.Location = new System.Drawing.Point(117, 521);
            this.selectrev.Name = "selectrev";
            this.selectrev.Size = new System.Drawing.Size(75, 23);
            this.selectrev.TabIndex = 2;
            this.selectrev.Text = "反选";
            this.selectrev.UseVisualStyleBackColor = true;
            this.selectrev.Click += new System.EventHandler(this.button4_Click);
            // 
            // selectall
            // 
            this.selectall.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.selectall.Location = new System.Drawing.Point(18, 521);
            this.selectall.Name = "selectall";
            this.selectall.Size = new System.Drawing.Size(75, 23);
            this.selectall.TabIndex = 1;
            this.selectall.Text = "全选";
            this.selectall.UseVisualStyleBackColor = true;
            this.selectall.Click += new System.EventHandler(this.button3_Click);
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
            this.Result,
            this.AgentName,
            this.Asset,
            this.Manager,
            this.MainName,
            this.SubName});
            this.agentDataGrid.Location = new System.Drawing.Point(18, 29);
            this.agentDataGrid.Name = "agentDataGrid";
            this.agentDataGrid.RowTemplate.Height = 23;
            this.agentDataGrid.ShowCellToolTips = false;
            this.agentDataGrid.ShowEditingIcon = false;
            this.agentDataGrid.Size = new System.Drawing.Size(893, 483);
            this.agentDataGrid.TabIndex = 0;
            this.agentDataGrid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.agentDataGrid_CellContentClick);
            this.agentDataGrid.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.agentDataGrid_ColumnHeaderMouseClick);
            this.agentDataGrid.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.agentDataGrid_RowPostPaint);
            // 
            // ck_column
            // 
            this.ck_column.HeaderText = "";
            this.ck_column.MinimumWidth = 45;
            this.ck_column.Name = "ck_column";
            this.ck_column.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ck_column.Width = 45;
            // 
            // AgentIp
            // 
            this.AgentIp.DataPropertyName = "AgentIp";
            this.AgentIp.HeaderText = "IP";
            this.AgentIp.Name = "AgentIp";
            this.AgentIp.ReadOnly = true;
            this.AgentIp.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // Result
            // 
            this.Result.FillWeight = 350F;
            this.Result.HeaderText = "结果";
            this.Result.MinimumWidth = 350;
            this.Result.Name = "Result";
            this.Result.ReadOnly = true;
            this.Result.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.Result.Width = 350;
            // 
            // AgentName
            // 
            this.AgentName.DataPropertyName = "AgentName";
            this.AgentName.FillWeight = 80F;
            this.AgentName.HeaderText = "资产名称";
            this.AgentName.MinimumWidth = 80;
            this.AgentName.Name = "AgentName";
            this.AgentName.ReadOnly = true;
            this.AgentName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.AgentName.Width = 80;
            // 
            // Asset
            // 
            this.Asset.DataPropertyName = "Asset";
            this.Asset.FillWeight = 60F;
            this.Asset.HeaderText = "资产号";
            this.Asset.MinimumWidth = 60;
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
            this.Manager.MinimumWidth = 60;
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
            this.MainName.MinimumWidth = 80;
            this.MainName.Name = "MainName";
            this.MainName.ReadOnly = true;
            this.MainName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.MainName.Width = 80;
            // 
            // SubName
            // 
            this.SubName.DataPropertyName = "SubName";
            this.SubName.FillWeight = 80F;
            this.SubName.HeaderText = "二级分类";
            this.SubName.MinimumWidth = 80;
            this.SubName.Name = "SubName";
            this.SubName.ReadOnly = true;
            this.SubName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.SubName.Width = 80;
            // 
            // rstx
            // 
            this.rstx.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.rstx.Location = new System.Drawing.Point(155, 523);
            this.rstx.Name = "rstx";
            this.rstx.Size = new System.Drawing.Size(84, 23);
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
            this.groupSearch.Location = new System.Drawing.Point(12, 31);
            this.groupSearch.Name = "groupSearch";
            this.groupSearch.Size = new System.Drawing.Size(1162, 55);
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
            this.managerBox.Location = new System.Drawing.Point(338, 23);
            this.managerBox.Name = "managerBox";
            this.managerBox.Size = new System.Drawing.Size(128, 20);
            this.managerBox.TabIndex = 8;
            // 
            // searchContentTxt
            // 
            this.searchContentTxt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.searchContentTxt.Location = new System.Drawing.Point(636, 23);
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
            this.subNameBox.Location = new System.Drawing.Point(181, 22);
            this.subNameBox.Name = "subNameBox";
            this.subNameBox.Size = new System.Drawing.Size(132, 20);
            this.subNameBox.TabIndex = 1;
            // 
            // searchbtn
            // 
            this.searchbtn.Location = new System.Drawing.Point(851, 21);
            this.searchbtn.Name = "searchbtn";
            this.searchbtn.Size = new System.Drawing.Size(75, 23);
            this.searchbtn.TabIndex = 6;
            this.searchbtn.Text = "搜索";
            this.searchbtn.UseVisualStyleBackColor = true;
            this.searchbtn.Click += new System.EventHandler(this.button2_Click);
            // 
            // searchTypeBox
            // 
            this.searchTypeBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.searchTypeBox.FormattingEnabled = true;
            this.searchTypeBox.Items.AddRange(new object[] {
            "其它搜索条件",
            "IP",
            "资产名称",
            "资产号"});
            this.searchTypeBox.Location = new System.Drawing.Point(497, 24);
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
            this.mainNameBox.Location = new System.Drawing.Point(34, 22);
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
            this.label_cmd_title.Location = new System.Drawing.Point(16, 29);
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
            this.cmdtext.Size = new System.Drawing.Size(939, 21);
            this.cmdtext.TabIndex = 3;
            // 
            // execbtn
            // 
            this.execbtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.execbtn.Location = new System.Drawing.Point(1043, 26);
            this.execbtn.Name = "execbtn";
            this.execbtn.Size = new System.Drawing.Size(75, 23);
            this.execbtn.TabIndex = 4;
            this.execbtn.Text = "执行";
            this.execbtn.UseVisualStyleBackColor = true;
            this.execbtn.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupAction
            // 
            this.groupAction.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupAction.Controls.Add(this.cmdtext);
            this.groupAction.Controls.Add(this.execbtn);
            this.groupAction.Controls.Add(this.label_cmd_title);
            this.groupAction.Location = new System.Drawing.Point(12, 660);
            this.groupAction.Name = "groupAction";
            this.groupAction.Size = new System.Drawing.Size(1162, 65);
            this.groupAction.TabIndex = 2;
            this.groupAction.TabStop = false;
            this.groupAction.Text = "操作";
            // 
            // toolTip1
            // 
            this.toolTip1.AutomaticDelay = 0;
            this.toolTip1.BackColor = System.Drawing.SystemColors.Control;
            this.toolTip1.OwnerDraw = true;
            this.toolTip1.ShowAlways = true;
            this.toolTip1.Draw += new System.Windows.Forms.DrawToolTipEventHandler(this.toolTip1_Draw);
            this.toolTip1.Popup += new System.Windows.Forms.PopupEventHandler(this.toolTip1_Popup);
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loginStatusLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 746);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1195, 23);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // loginStatusLabel
            // 
            this.loginStatusLabel.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            this.loginStatusLabel.Margin = new System.Windows.Forms.Padding(0, 1, 1, 1);
            this.loginStatusLabel.Name = "loginStatusLabel";
            this.loginStatusLabel.Size = new System.Drawing.Size(71, 21);
            this.loginStatusLabel.Text = "  登录帐号:";
            this.loginStatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // rsttitle
            // 
            this.rsttitle.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rsttitle.Controls.Add(this.rst);
            this.rsttitle.Controls.Add(this.rstx);
            this.rsttitle.Location = new System.Drawing.Point(929, 89);
            this.rsttitle.Name = "rsttitle";
            this.rsttitle.Size = new System.Drawing.Size(245, 556);
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
            this.rst.Size = new System.Drawing.Size(233, 483);
            this.rst.TabIndex = 6;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1195, 769);
            this.Controls.Add(this.rsttitle);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.groupAction);
            this.Controls.Add(this.groupSearch);
            this.Controls.Add(this.serverlist);
            this.Controls.Add(this.menuStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip;
            this.Name = "MainWindow";
            this.Text = "Bumblebee";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainWindow_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainWindow_FormClosed);
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.serverlist.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.agentDataGrid)).EndInit();
            this.groupSearch.ResumeLayout(false);
            this.groupSearch.PerformLayout();
            this.groupAction.ResumeLayout(false);
            this.groupAction.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.agentInfoBindingSource)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.rsttitle.ResumeLayout(false);
            this.rsttitle.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem HelpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AbloutElvesToolStripMenuItem;
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
        private System.Windows.Forms.ToolStripMenuItem ReloginToolStripMenuItem;
        private System.Windows.Forms.BindingSource agentInfoBindingSource;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel loginStatusLabel;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ck_column;
        private System.Windows.Forms.DataGridViewTextBoxColumn AgentIp;
        private System.Windows.Forms.DataGridViewTextBoxColumn Result;
        private System.Windows.Forms.DataGridViewTextBoxColumn AgentName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Asset;
        private System.Windows.Forms.DataGridViewTextBoxColumn Manager;
        private System.Windows.Forms.DataGridViewTextBoxColumn MainName;
        private System.Windows.Forms.DataGridViewTextBoxColumn SubName;
        private System.Windows.Forms.Button rstx;
        private System.Windows.Forms.GroupBox rsttitle;
        private System.Windows.Forms.TextBox rst;
    }
}

