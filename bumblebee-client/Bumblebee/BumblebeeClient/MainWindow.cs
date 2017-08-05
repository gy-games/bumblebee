using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.Threading;
using System.Reflection;

namespace BumblebeeClient
{
    public partial class MainWindow : Form
    {
        Login currLogin = null;

        string loginUserEmail=null;

        public MainWindow(Login log,string email)
        {
            currLogin = log;
            loginUserEmail=email;
            InitializeComponent();
            this.toolStripStatusLabel1.Text = this.toolStripStatusLabel1.Text +"【" +loginUserEmail+"】";
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            //首页获取搜索栏
            Dictionary<string, string> pm = new Dictionary<string, string>();
            pm.Add("email", loginUserEmail);
            pm.Add("timestamp", SecurityUtil.GetTimestamp());
            string sign = SecurityUtil.CreateSign(pm);
            pm.Add("sign", sign);
            string result = HttpUtil.SendGet(ConstantUrl.agentConditionUrl,pm);

            if (!string.IsNullOrEmpty(result)) 
            {
                IDictionary<string, List<string>> data = JsonConvert.DeserializeObject<IDictionary<string, List<string>>>(result);
                List<string> mainNameList = new List<string>();
                mainNameList.Add("一级分类");
                mainNameList.AddRange(data["mainNameList"]);
                this.mainNameBox.DataSource = mainNameList;
                this.mainNameBox.SelectedIndex = 0;

                List<string> subNameList = new List<string>();
                subNameList.Add("二级分类");
                subNameList.AddRange(data["subNameList"]);
                this.subNameBox.DataSource = subNameList;
                this.subNameBox.SelectedIndex = 0;

                List<string> managerList = new List<string>();
                managerList.Add("管理员");
                managerList.AddRange(data["managerList"]);
                this.managerBox.DataSource = managerList;
                this.managerBox.SelectedIndex = 0;

                this.searchTypeBox.SelectedIndex = 0;
            }
            else
            {
                MessageBox.Show("查询异常，请联系管理员！", "提示");
                return;
            }
            
            Dictionary<string, string> pm2 = new Dictionary<string, string>();
            pm2.Add("email", loginUserEmail);
            pm2.Add("timestamp",SecurityUtil.GetTimestamp());
            string sign2 = SecurityUtil.CreateSign(pm2);
            pm2.Add("sign", sign2);
            string result2 = HttpUtil.SendGet(ConstantUrl.agentListUrl, pm2);

            if (!string.IsNullOrEmpty(result2))
            {
                List<AgentInfo> data2 = JsonConvert.DeserializeObject<List<AgentInfo>>(result2);
                DataTable dt = DataTableExtensions.ToDataTable(data2);
                this.agentDataGrid.DataSource = dt;
                
            }
            else 
            {
                MessageBox.Show("查询异常，请联系管理员！", "提示");   
            }
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            currLogin.Close();
            this.Close();
            Application.ExitThread();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void agentDataGrid_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            
        }

        private void agentDataGrid_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            //序号实现
            Rectangle rectangle = new Rectangle(e.RowBounds.Location.X,e.RowBounds.Location.Y,
                                        agentDataGrid.RowHeadersWidth - 4,e.RowBounds.Height);
            TextRenderer.DrawText(e.Graphics,(e.RowIndex + 1).ToString(),agentDataGrid.RowHeadersDefaultCellStyle.Font,rectangle,
                   agentDataGrid.RowHeadersDefaultCellStyle.ForeColor,TextFormatFlags.VerticalCenter | TextFormatFlags.Right);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //搜索
            Dictionary<string, string> pm = new Dictionary<string, string>();
            pm.Add("timestamp", SecurityUtil.GetTimestamp());
            pm.Add("email", loginUserEmail);

            string mainName = mainNameBox.Text;
            if (!"一级分类".Equals(mainName)&& !"".Equals(mainName))
            {
                pm.Add("mainName", mainName);
            }

            string subName = subNameBox.Text;
            if (!"二级分类".Equals(subName) && !"".Equals(subName))
            {
                pm.Add("subName", subName);
            }

            string manager = managerBox.Text;
            if (!"管理员".Equals(manager) && !"".Equals(manager))
            {
                pm.Add("manager", manager);
            }

            string searchType = searchTypeBox.Text;
            string searchContent = searchContentTxt.Text;

            if (!"".Equals(searchContent))
            {
                if("IP".Equals(searchType))
                {
                    pm.Add("agentIp", searchContent);
                }
                else if ("资产名称".Equals(searchType))
                {
                    pm.Add("agentName", searchContent);
                }
                else if ("资产号".Equals(searchType))
                {
                    pm.Add("asset", searchContent);
                }
                else 
                { 
                    //不搜索
                }
            }

            string sign = SecurityUtil.CreateSign(pm);
            pm.Add("sign", sign);

            string result = HttpUtil.SendPost(ConstantUrl.agentListUrl, pm);
            if (!string.IsNullOrEmpty(result))
            {
                List<AgentInfo> data2 = JsonConvert.DeserializeObject<List<AgentInfo>>(result);
                DataTable dt = DataTableExtensions.ToDataTable(data2);
                this.agentDataGrid.DataSource = dt;
            }
            else
            {
                MessageBox.Show("查询异常，请联系管理员！", "提示");
                this.agentDataGrid.DataSource = null;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //全选
            if (agentDataGrid.Rows.Count > 0)
            {
                for (int i = 0; i < agentDataGrid.Rows.Count; i++)
                {
                    string _selectValue = agentDataGrid.Rows[i].Cells["ck_column"].EditedFormattedValue.ToString();
                    if (_selectValue != "True")
                    {
                        agentDataGrid.Rows[i].Cells["ck_column"].Value = true;
                    }
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //反选
            if (agentDataGrid.Rows.Count > 0)
            {
                for (int i = 0; i < agentDataGrid.Rows.Count; i++)
                {
                    string _selectValue = agentDataGrid.Rows[i].Cells["ck_column"].EditedFormattedValue.ToString();
                    if (_selectValue == "True")
                    {
                        //如果CheckBox已选中，则在此处继续编写代码
                        agentDataGrid.Rows[i].Cells["ck_column"].Value = false;
                    }
                    else 
                    {
                        agentDataGrid.Rows[i].Cells["ck_column"].Value = true;
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //运行命令获取结果
            string command = textBox1.Text;
            if ("".Equals(command)) 
            {
                MessageBox.Show("命令为空，请输入命令！","提示");
                return;
            }
            
            this.button1.Enabled = false;


            List<int> jobs = new List<int>();


            if (agentDataGrid.Rows.Count > 0)
            {
                for (int i = 0; i < agentDataGrid.Rows.Count; i++)
                {
                    agentDataGrid.Rows[i].DefaultCellStyle.BackColor = System.Drawing.Color.White;
                    string _selectValue = agentDataGrid.Rows[i].Cells["ck_column"].EditedFormattedValue.ToString();
                    if (_selectValue == "True")
                    {
                        jobs.Add(i);
                    }
                }
            }

            
            if (jobs.Count == 0)
            {
                MessageBox.Show("请选择机器！", "提示");
            }
            else
            {
                foreach(int index in jobs)
                {
                    DataGridViewRow row = agentDataGrid.Rows[index];
                    string ip = row.Cells["AgentIp"].EditedFormattedValue.ToString();

                    Dictionary<string, string> pm = new Dictionary<string, string>();
                    pm.Add("email", loginUserEmail);
                    pm.Add("ip", ip);
                    pm.Add("command", command);
                    pm.Add("timestamp", SecurityUtil.GetTimestamp());
                    string sign = SecurityUtil.CreateSign(pm);
                    pm.Add("sign", sign);

                    Thread oGetArgThread = new Thread(new System.Threading.ThreadStart(() =>
                    {
                        string result = HttpUtil.SendPost(ConstantUrl.runCommandUrl, pm);
                        if (String.IsNullOrEmpty(result))
                        {
                            row.DefaultCellStyle.BackColor = System.Drawing.Color.Red;
                            row.Cells["Result"].Value = "bumblebee server error";
                        }
                        else
                        {
                            Dictionary<string, Object> data = JsonConvert.DeserializeObject<Dictionary<string, Object>>(result);
                            if (data == null || data["code"] == null || int.Parse(data["code"].ToString()) != 0)
                            {
                                //失败
                                row.DefaultCellStyle.BackColor = System.Drawing.Color.Red;
                            }
                            else
                            {
                                //成功
                                row.DefaultCellStyle.BackColor = System.Drawing.Color.PaleGreen;
                            }
                            row.Cells["Result"].Value = data["data"];
                        }
                    }));
                    oGetArgThread.IsBackground = true;
                    oGetArgThread.Start();             
                }
            }
            this.button1.Enabled = true;
            
        }

        private void MainWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            System.Environment.Exit(0);
        }

        private void 帮助ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void mainNameBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string mainName=this.mainNameBox.Text;
            List<string> data = new List<string>();
            data.Add("二级分类");
            if (mainName != "一级分类")
            {
                Dictionary<string, string> pm = new Dictionary<string, string>();
                pm.Add("mainName", mainName);
                pm.Add("email", loginUserEmail);
                pm.Add("timestamp", SecurityUtil.GetTimestamp());
                string sign = SecurityUtil.CreateSign(pm);
                pm.Add("sign", sign);

                string result = HttpUtil.SendGet(ConstantUrl.subNameListUrl, pm);
                if (!String.IsNullOrEmpty(result))
                {
                    List<string> subNameList = JsonConvert.DeserializeObject<List<string>>(result);
                    data.AddRange(subNameList);
                }
            }
            this.subNameBox.DataSource = data;
            this.subNameBox.SelectedIndex = 0;
        }

        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("确定退出应用么？", "退出系统", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
            {
                e.Cancel = true;
                return;
            }
        }

        private void 重新登录ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确定要重新登录么？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                this.currLogin.account_txt.Text = "";
                this.currLogin.pwd_txt.Text = "";
                this.currLogin.Show();
                this.Hide();
            }
        }

        private void 关于ElvesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Dialog dialog = new Dialog();
            dialog.StartPosition = FormStartPosition.Manual;
            int xWidth = SystemInformation.PrimaryMonitorSize.Width;
            int yHeight = SystemInformation.PrimaryMonitorSize.Height;
            dialog.Location = new Point((xWidth - dialog.Width) / 2, (yHeight - dialog.Height) / 2);
            dialog.ShowDialog();
        }

        private void agentDataGrid_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridViewColumn newColumn = agentDataGrid.Columns[e.ColumnIndex];
            if(!String.IsNullOrEmpty(newColumn.DataPropertyName) && newColumn.SortMode ==DataGridViewColumnSortMode.Programmatic) 
            {
                DataGridViewColumn oldColumn = agentDataGrid.SortedColumn;
                ListSortDirection direction;

                // If oldColumn is null, then the DataGridView is not sorted.
                if (oldColumn != null)
                {
                    // Sort the same column again, reversing the SortOrder.
                    if (oldColumn == newColumn &&
                        agentDataGrid.SortOrder == SortOrder.Ascending)
                    {
                        direction = ListSortDirection.Descending;
                    }
                    else
                    {
                        // Sort a new column and remove the old SortGlyph.
                        direction = ListSortDirection.Ascending;
                        oldColumn.HeaderCell.SortGlyphDirection = SortOrder.None;
                    }
                }
                else
                {
                    direction = ListSortDirection.Ascending;
                }

                // Sort the selected column.
                agentDataGrid.Sort(newColumn, direction);
                newColumn.HeaderCell.SortGlyphDirection = direction == ListSortDirection.Ascending ? SortOrder.Ascending : SortOrder.Descending;
            }
        }

        private void toolTip1_Draw(object sender, DrawToolTipEventArgs e)
        {
            e.DrawBackground();
            e.DrawBorder();
            Rectangle rectg = new Rectangle(0, 0, e.Bounds.Width + 1, e.Bounds.Height + 1);
            e.Graphics.DrawRectangle(Pens.Black, rectg);
            e.Graphics.DrawString(this.toolTip1.ToolTipTitle + e.ToolTipText, e.Font, Brushes.Black, rectg);

            
        }

        private void agentDataGrid_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            //鼠标移出单元格后隐藏提示
            this.toolTip1.Hide(this.agentDataGrid);
        }

        private void agentDataGrid_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            this.toolTip1.RemoveAll();
            
            //判断选择单元格是否有效  
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
            {  
                return;  
            }
            
            this.toolTip1.Hide(this.agentDataGrid);  
            int i = e.ColumnIndex;//获取鼠标停留的列索引
            int ei = e.RowIndex;//获取停留的行索引

            if (i == 1 && ei >= 0)  
            {
                Point mousePos = PointToClient(MousePosition);//获取鼠标当前的位置
                string tips = this.agentDataGrid[1, ei].Value == null ? "" : this.agentDataGrid[1, ei].Value.ToString();
                if (!String.IsNullOrEmpty(tips))
                {
                    this.toolTip1.Show(tips, this, new Point(mousePos.X+60, mousePos.Y+30));//在指定位置显示提示框
                }
                 
            }
            
        }

        private void toolTip1_Popup(object sender, PopupEventArgs e)
        {
            //重设tooltip 的大小
            int width = e.ToolTipSize.Width;
            int height = e.ToolTipSize.Height+50;
            //如果超过窗体大小，则最高为窗体大小-100
            if (height >= this.Height)
            {
                height = this.Height-100;
            }
            e.ToolTipSize = new Size(new Point(width, height));
        }

       
    }
}
