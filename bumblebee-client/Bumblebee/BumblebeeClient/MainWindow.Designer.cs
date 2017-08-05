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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.帮助ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.关于ElvesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.重新登录ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.agentDataGrid = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.managerBox = new System.Windows.Forms.ComboBox();
            this.searchContentTxt = new System.Windows.Forms.TextBox();
            this.subNameBox = new System.Windows.Forms.ComboBox();
            this.button2 = new System.Windows.Forms.Button();
            this.searchTypeBox = new System.Windows.Forms.ComboBox();
            this.mainNameBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.agentInfoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.ck_column = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.AgentIp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Result = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AgentName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Asset = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Manager = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MainName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SubName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.menuStrip1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.agentDataGrid)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.agentInfoBindingSource)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.menuStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(0);
            this.menuStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.帮助ToolStripMenuItem,
            this.重新登录ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(994, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // 帮助ToolStripMenuItem
            // 
            this.帮助ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.关于ElvesToolStripMenuItem});
            this.帮助ToolStripMenuItem.Name = "帮助ToolStripMenuItem";
            this.帮助ToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.帮助ToolStripMenuItem.Text = "帮助";
            this.帮助ToolStripMenuItem.Click += new System.EventHandler(this.帮助ToolStripMenuItem_Click);
            // 
            // 关于ElvesToolStripMenuItem
            // 
            this.关于ElvesToolStripMenuItem.Name = "关于ElvesToolStripMenuItem";
            this.关于ElvesToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.关于ElvesToolStripMenuItem.Text = "关于Bumblebee";
            this.关于ElvesToolStripMenuItem.Click += new System.EventHandler(this.关于ElvesToolStripMenuItem_Click);
            // 
            // 重新登录ToolStripMenuItem
            // 
            this.重新登录ToolStripMenuItem.Name = "重新登录ToolStripMenuItem";
            this.重新登录ToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
            this.重新登录ToolStripMenuItem.Text = "重新登录";
            this.重新登录ToolStripMenuItem.Click += new System.EventHandler(this.重新登录ToolStripMenuItem_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button4);
            this.groupBox2.Controls.Add(this.button3);
            this.groupBox2.Controls.Add(this.agentDataGrid);
            this.groupBox2.Location = new System.Drawing.Point(12, 89);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(970, 563);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "服务器列表";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(136, 525);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 2;
            this.button4.Text = "反选";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(34, 525);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 1;
            this.button3.Text = "全选";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // agentDataGrid
            // 
            this.agentDataGrid.AllowUserToAddRows = false;
            this.agentDataGrid.AllowUserToResizeRows = false;
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
            this.agentDataGrid.Size = new System.Drawing.Size(934, 480);
            this.agentDataGrid.TabIndex = 0;
            this.agentDataGrid.CellMouseEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.agentDataGrid_CellMouseEnter);
            this.agentDataGrid.CellMouseLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.agentDataGrid_CellMouseLeave);
            this.agentDataGrid.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.agentDataGrid_ColumnHeaderMouseClick);
            this.agentDataGrid.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.agentDataGrid_RowPostPaint);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.managerBox);
            this.groupBox1.Controls.Add(this.searchContentTxt);
            this.groupBox1.Controls.Add(this.subNameBox);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.searchTypeBox);
            this.groupBox1.Controls.Add(this.mainNameBox);
            this.groupBox1.Location = new System.Drawing.Point(12, 31);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(970, 55);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "搜索";
            // 
            // managerBox
            // 
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
            this.searchContentTxt.Location = new System.Drawing.Point(636, 23);
            this.searchContentTxt.Name = "searchContentTxt";
            this.searchContentTxt.Size = new System.Drawing.Size(183, 21);
            this.searchContentTxt.TabIndex = 7;
            // 
            // subNameBox
            // 
            this.subNameBox.FormattingEnabled = true;
            this.subNameBox.Items.AddRange(new object[] {
            "二级分类"});
            this.subNameBox.Location = new System.Drawing.Point(181, 22);
            this.subNameBox.Name = "subNameBox";
            this.subNameBox.Size = new System.Drawing.Size(132, 20);
            this.subNameBox.TabIndex = 1;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(851, 21);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 6;
            this.button2.Text = "搜索";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // searchTypeBox
            // 
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
            this.mainNameBox.FormattingEnabled = true;
            this.mainNameBox.Items.AddRange(new object[] {
            "一级分类"});
            this.mainNameBox.Location = new System.Drawing.Point(34, 22);
            this.mainNameBox.Name = "mainNameBox";
            this.mainNameBox.Size = new System.Drawing.Size(120, 20);
            this.mainNameBox.TabIndex = 0;
            this.mainNameBox.SelectedIndexChanged += new System.EventHandler(this.mainNameBox_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "命令：";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(72, 26);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(747, 21);
            this.textBox1.TabIndex = 3;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(851, 26);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "执行";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.textBox1);
            this.groupBox3.Controls.Add(this.button1);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Location = new System.Drawing.Point(12, 660);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(970, 65);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "操作";
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
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 747);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(994, 22);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            this.toolStripStatusLabel1.Margin = new System.Windows.Forms.Padding(0, 1, 1, 1);
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(68, 20);
            this.toolStripStatusLabel1.Text = "  登录帐号:";
            this.toolStripStatusLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(994, 769);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "MainWindow";
            this.Text = "Bumblebee";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainWindow_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainWindow_FormClosed);
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.agentDataGrid)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.agentInfoBindingSource)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 帮助ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 关于ElvesToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView agentDataGrid;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox subNameBox;
        private System.Windows.Forms.ComboBox mainNameBox;
        private System.Windows.Forms.ComboBox managerBox;
        private System.Windows.Forms.TextBox searchContentTxt;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ComboBox searchTypeBox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.ToolStripMenuItem 重新登录ToolStripMenuItem;
        private System.Windows.Forms.BindingSource agentInfoBindingSource;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ck_column;
        private System.Windows.Forms.DataGridViewTextBoxColumn AgentIp;
        private System.Windows.Forms.DataGridViewTextBoxColumn Result;
        private System.Windows.Forms.DataGridViewTextBoxColumn AgentName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Asset;
        private System.Windows.Forms.DataGridViewTextBoxColumn Manager;
        private System.Windows.Forms.DataGridViewTextBoxColumn MainName;
        private System.Windows.Forms.DataGridViewTextBoxColumn SubName;
    }
}

