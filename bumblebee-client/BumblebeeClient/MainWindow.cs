using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.Threading;
using System.Text.RegularExpressions;
using MaterialSkin;
using MaterialSkin.Controls;
using System.Diagnostics;

namespace BumblebeeClient
{
    public partial class MainWindow : MaterialForm
    {
        private static int jobcnt=0, succcnt = 0, failcnt = 0;
        private static bool execing = false;
        private readonly MaterialSkinManager materialSkinManager;
        private delegate void UpdateExecStatus(string txt,int execcnt);
        private delegate void UpdateExecRow(Dictionary<string, string> dic,int rowindex);
        Login currLogin = null;

        public MainWindow(Login loginPannel)
        {
            //Control.CheckForIllegalCrossThreadCalls = false;
            currLogin = loginPannel;
            InitializeComponent();
            materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);
            this.usernameLabel.Text = Login.EMAIL;
        }
        private void MainWindow_Load(object sender, EventArgs e)
        {
            //首页获取搜索栏
            Dictionary<string, string> pm = new Dictionary<string, string>();
            pm.Add("email", Login.EMAIL);
            pm.Add("timestamp", SecurityUtil.GetTimestamp());
            string sign = SecurityUtil.CreateSign(pm, Login.PWDKEY);
            pm.Add("sign", sign);
            try
            {
                string result = HttpUtil.SendGet(ConstantUrl.agentConditionUrl, pm);
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
                    managerList.Add("负责人");
                    managerList.AddRange(data["managerList"]);
                    this.managerBox.DataSource = managerList;
                    this.managerBox.SelectedIndex = 0;
                    this.searchTypeBox.SelectedIndex = 0;
                }
                else
                {
                    MessageBox.Show("获取搜索表单异常，数据返回为空！", "提示");
                    return;
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show("获取搜索表单异常(" + ee.Message + ")", "提示");
                return;
            }
            Dictionary<string, string> pm2 = new Dictionary<string, string>();
            pm2.Add("email", Login.EMAIL);
            pm2.Add("timestamp", SecurityUtil.GetTimestamp());
            string sign2 = SecurityUtil.CreateSign(pm2, Login.PWDKEY);
            pm2.Add("sign", sign2);
            int cnt = 0;
            try
            {
                string result2 = HttpUtil.SendGet(ConstantUrl.agentListUrl, pm2);
                if (!string.IsNullOrEmpty(result2))
                {
                    List<AgentInfo> data2 = JsonConvert.DeserializeObject<List<AgentInfo>>(result2);
                    //foreach data2
                    DataTable dt = DataTableExtensions.ToDataTable(data2);
                    //dt.Columns.Add("rflag", typeof(String));
                    //dt.Columns.Add("Result", typeof(String));
                    this.agentDataGrid.DataSource = dt;
                    cnt= data2.Count;
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show("默认服务器列表获取异常！(" + ee.Message + ")", "提示");
            }
            this.serverlist.Text = "服务器列表 总数:" + cnt.ToString() + "";
        }
        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            currLogin.Close();
            this.Close();
            Application.ExitThread();
        }
        private void agentDataGrid_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            //序号实现
            Rectangle rectangle = new Rectangle(e.RowBounds.Location.X, e.RowBounds.Location.Y, agentDataGrid.RowHeadersWidth - 4, e.RowBounds.Height);
            TextRenderer.DrawText(e.Graphics, (e.RowIndex + 1).ToString(), agentDataGrid.RowHeadersDefaultCellStyle.Font, rectangle, agentDataGrid.RowHeadersDefaultCellStyle.ForeColor, TextFormatFlags.VerticalCenter | TextFormatFlags.Right);
        }
        private void searchbtn_Click(object sender, EventArgs e)
        {
            //搜索
            Dictionary<string, string> pm = new Dictionary<string, string>();
            pm.Add("timestamp", SecurityUtil.GetTimestamp());
            pm.Add("email", Login.EMAIL);
            string mainName = mainNameBox.Text;
            if (!"一级分类".Equals(mainName) && !"".Equals(mainName))
            {
                pm.Add("mainName", mainName);
            }
            string subName = subNameBox.Text;
            if (!"二级分类".Equals(subName) && !"".Equals(subName))
            {
                pm.Add("subName", subName);
            }
            string manager = managerBox.Text;
            if (!"负责人".Equals(manager) && !"".Equals(manager))
            {
                pm.Add("manager", manager);
            }
            string searchType = searchTypeBox.Text;
            string searchContent = searchContentTxt.Text;
            if (!"".Equals(searchContent))
            {
                if ("IP".Equals(searchType))
                {
                    pm.Add("agentIp", searchContent);
                }
                else if ("应用".Equals(searchType))
                {
                    pm.Add("agentName", searchContent);
                }
                else if ("资产号".Equals(searchType))
                {
                    pm.Add("asset", searchContent);
                }
                else
                {
                    MessageBox.Show("请选择搜索条件！", "提示");
                }
            }
            string sign = SecurityUtil.CreateSign(pm, Login.PWDKEY);
            pm.Add("sign", sign);
            int cnt = 0;
            try
            {
                string result = HttpUtil.SendPost(ConstantUrl.agentListUrl, pm);
                if (!string.IsNullOrEmpty(result))
                {
                    List<AgentInfo> data2 = JsonConvert.DeserializeObject<List<AgentInfo>>(result);
                    DataTable dt = DataTableExtensions.ToDataTable(data2);
                    //dt.Columns.Add("rflag", typeof(String));
                    //dt.Columns.Add("Result", typeof(String));
                    this.agentDataGrid.DataSource = dt;
                    cnt = data2.Count;
                }
                else
                {
                    MessageBox.Show("查询异常,未返回查询结果！", "提示");
                    this.agentDataGrid.DataSource = null;
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show("查询异常!(" + ee.Message + ")", "提示");
                this.agentDataGrid.DataSource = null;
            }
            this.serverlist.Text = "服务器列表 总数:" + cnt.ToString() + "";
            //succcnt = 0;failcnt = 0;
            execStatus.Text = "执行中:0,成功:0,失败:0";
        }
        private void selectall_Click(object sender, EventArgs e)
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
        private void selectrev_Click(object sender, EventArgs e)
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
        private void execbtn_Click(object sender, EventArgs e)
        {
            jobcnt  = 0;
            succcnt = 0;
            failcnt = 0;
            //运行命令获取结果
            string command = cmdtext.Text;
            if ("".Equals(command.Trim()))
            {
                MessageBox.Show("命令为空，请输入命令！", "提示");
                return;
            }
            List<int> jobs = new List<int>();
            if (agentDataGrid.Rows.Count > 0)
            {
                for (int i = 0; i < agentDataGrid.Rows.Count; i++)
                {
                    agentDataGrid.Rows[i].DefaultCellStyle.BackColor = Color.White;
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
                this.execbtn.Text = "执行中..";
                this.execbtn.Enabled = false;
                execing = true;
                jobcnt = jobs.Count;
                string uri = "";
                if (this.isdaemon.Checked == true)
                {
                    uri = ConstantUrl.runDaemonCommandUrl;
                }
                else {
                    uri = ConstantUrl.runCommandUrl;
                }
                for (int c = 0; c < agentDataGrid.Columns.Count; c++) {
                    agentDataGrid.Columns[c].SortMode = DataGridViewColumnSortMode.NotSortable;
                }
                foreach (int index in jobs)
                {
                    string ip = agentDataGrid.Rows[index].Cells["AgentIp"].EditedFormattedValue.ToString();
                    Dictionary<string, string> pm = new Dictionary<string, string>();
                    pm.Add("email", Login.EMAIL);
                    pm.Add("ip", ip);
                    pm.Add("command", command);
                    pm.Add("timestamp", SecurityUtil.GetTimestamp());
                    pm.Add("sign", SecurityUtil.CreateSign(pm, Login.PWDKEY));
                    Thread oGetArgThread = new Thread(new ThreadStart(() =>
                    {
                        Dictionary < string, string >  rowrst = this.ThreadEXEC(pm, uri);
                        this.UpdateExecRowACT(rowrst,index);
                    }));     
                    oGetArgThread.IsBackground = true;
                    oGetArgThread.Start();
                }
            }
            
        }
        private Dictionary<string, string> ThreadEXEC(Dictionary<string, string> pm, string uri) {
            Dictionary<string, string> rst = new Dictionary<string, string>();
            try
            {
                string result = HttpUtil.SendPost(uri, pm);
                if (String.IsNullOrEmpty(result.Trim()))
                {
                    //返回结果为空
                    rst["color"] = "red";
                    rst["rflag"] = "异常";
                    rst["rResult"] = "Bumblebee Server Error！";
                    rst["rstfull"] = "Bumblebee Server返回结果为空！";
                    failcnt++;
                }
                else
                {
                    Dictionary<string, Object> data = JsonConvert.DeserializeObject<Dictionary<string, Object>>(result);
                    if (data == null || data["code"] == null || int.Parse(data["code"].ToString()) != 0)
                    {
                        //失败
                        rst["color"] = "red";
                        rst["rflag"] = "失败";
                        rst["rResult"] = data == null ? "Bumblebee Server返回结果解析为空或返回码错误！" : data["data"].ToString();
                        rst["rstfull"] = data == null?"Bumblebee Server返回结果解析为空或返回码错误！": data["data"].ToString();
                        failcnt++;
                    }
                    else
                    {
                        //成功
                        rst["color"] = "green";
                        rst["rflag"] = "成功";
                        string miniValue = "";
                        if (Unicode2String(data["data"].ToString()).Length > 40)
                        {
                            miniValue = Unicode2String(data["data"].ToString()).Substring(0, 40);
                        }
                        else
                        {
                            miniValue = Unicode2String(data["data"].ToString());
                        }
                        rst["rResult"] = miniValue;
                        rst["rstfull"] = Unicode2String(data["data"].ToString());
                        succcnt++;
                    }
                }
            }
            catch (Exception ee)
            {
                rst["color"]   = "red";
                rst["rflag"]   = "异常";
                rst["rResult"] = "BumblebeeClient Catch Exception!";
                rst["rstfull"] = ee.ToString();
                failcnt++;
            }
            this.UpdateExecStatusACT("执行中:" + (jobcnt - succcnt - failcnt).ToString() + ",成功:" + succcnt.ToString() + ",失败:" + failcnt.ToString(), (jobcnt - succcnt - failcnt));
            return rst;
        }
        private void UpdateExecStatusACT(string val,int execcnt) {
            if (this.execStatus.InvokeRequired)
            {
                UpdateExecStatus fc = new UpdateExecStatus(UpdateExecStatusACT);
                this.Invoke(fc, new object[2] { val, execcnt });
            }
            else {
                this.execStatus.Text = val;
                this.execStatus.Refresh();
            }
            if (execcnt == 0) {
                this.execbtn.Enabled = true;
                this.execbtn.Text = "执行";
                execing = false;
                for (int c = 0; c < agentDataGrid.Columns.Count; c++)
                {
                    agentDataGrid.Columns[c].SortMode = DataGridViewColumnSortMode.Automatic;
                }
            }
        }
        private void UpdateExecRowACT(Dictionary<string, string> dic, int rowindex) {

            if (this.agentDataGrid.InvokeRequired)
            {
                UpdateExecRow fc = new UpdateExecRow(UpdateExecRowACT);
                this.Invoke(fc, new object[2] { dic, rowindex });
            }
            else
            {
                if (dic["color"] == "red") {
                    agentDataGrid.Rows[rowindex].DefaultCellStyle.BackColor = System.Drawing.Color.Red;
                }
                else if(dic["color"] == "green") {
                    agentDataGrid.Rows[rowindex].DefaultCellStyle.BackColor = System.Drawing.Color.PaleGreen;
                }
                this.agentDataGrid.Rows[rowindex].Cells["rResult"].Value = dic["rResult"];
                this.agentDataGrid.Rows[rowindex].Cells["rstfull"].Value = dic["rstfull"];
                this.agentDataGrid.Rows[rowindex].Cells["rflag"].Value   = dic["rflag"];
                this.agentDataGrid.Refresh();
            }
        }
        private void MainWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            //currLogin.Close();
            //this.Close();
            System.Environment.Exit(0);
        }
        private void mainNameBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string mainName = this.mainNameBox.Text;
            List<string> data = new List<string>();
            data.Add("二级分类");
            if (mainName != "一级分类")
            {
                Dictionary<string, string> pm = new Dictionary<string, string>();
                pm.Add("mainName", mainName);
                pm.Add("email", Login.EMAIL);
                pm.Add("timestamp", SecurityUtil.GetTimestamp());
                string sign = SecurityUtil.CreateSign(pm, Login.PWDKEY);
                pm.Add("sign", sign);
                try
                {
                    string result = HttpUtil.SendGet(ConstantUrl.subNameListUrl, pm);
                    if (!String.IsNullOrEmpty(result))
                    {
                        List<string> subNameList = JsonConvert.DeserializeObject<List<string>>(result);
                        data.AddRange(subNameList);
                    }
                }
                catch (Exception ee)
                {
                    MessageBox.Show("获取联动搜索内容异常!(" + ee.Message + ")", "提示");
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
        private void agentDataGrid_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (execing == false) {
                for (int i = 0; i < agentDataGrid.Rows.Count; i++)
                {
                    if (agentDataGrid.Rows[i].Cells["rflag"].Value.ToString() == "成功")
                    {
                        agentDataGrid.Rows[i].DefaultCellStyle.BackColor = System.Drawing.Color.PaleGreen;
                    }
                    else if (agentDataGrid.Rows[i].Cells["rflag"].Value.ToString() == "失败")
                    {
                        agentDataGrid.Rows[i].DefaultCellStyle.BackColor = System.Drawing.Color.Red;
                    }
                    else
                    {
                        agentDataGrid.Rows[i].DefaultCellStyle.BackColor = System.Drawing.Color.White;
                    }
                }
            }
        }
        private void agentDataGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                if (e.ColumnIndex != 0)
                {
                    if (e.ColumnIndex == 11)
                    {
                        Random rd = new Random();
                        string Port = rd.Next(60000, 65535).ToString();
                        try
                        {
                            Process myProcess = new Process();
                            myProcess.StartInfo.UseShellExecute = false;
                            myProcess.StartInfo.FileName = "cmd.exe";
                            myProcess.StartInfo.Arguments = "/c nc -i 3 " + agentDataGrid.Rows[e.RowIndex].Cells["AgentIp"].Value.ToString() + " "+ Port;
                            myProcess.Start();
                        }
                        catch (Exception ee)
                        {
                            MessageBox.Show("本地启动SHELL连接失败!(" + ee.Message + ")", "提示");
                        }
                        Thread oGetArgThread = new Thread(new System.Threading.ThreadStart(() =>
                        {
                            string ip = agentDataGrid.Rows[e.RowIndex].Cells["AgentIp"].Value.ToString();
                            
                            Dictionary<string, string> pm = new Dictionary<string, string>();
                            pm.Add("email", Login.EMAIL);
                            pm.Add("ip", ip);
                            pm.Add("port", Port);
                            pm.Add("timestamp", SecurityUtil.GetTimestamp());
                            string sign = SecurityUtil.CreateSign(pm, Login.PWDKEY);
                            pm.Add("sign", sign);
                            //Console.WriteLine(pm);
                            try
                            {
                                string result = HttpUtil.SendPost(ConstantUrl.runShellUrl, pm);
                                if (String.IsNullOrEmpty(result.Trim()))
                                {
                                    MessageBox.Show("创建连接BumblebeeServer创建SHELL失败!", "提示");
                                }
                                else
                                {
                                    Dictionary<string, Object> data = JsonConvert.DeserializeObject<Dictionary<string, Object>>(result);
                                    if (data == null || data["code"] == null)
                                    {
                                        MessageBox.Show("服务器(" + ip + ")返回异常,创建SHELL失败!", "提示");
                                    } else if (int.Parse(data["code"].ToString()) != 0) {
                                        MessageBox.Show(data["data"].ToString(), "提示");
                                    }
                                    else
                                    {
                                        //success
                                    }

                                }
                            }
                            catch (Exception ee)
                            {
                                MessageBox.Show("创建SHELL失败!(" + ee.Message + ")", "提示");
                            }
                        }));
                        oGetArgThread.IsBackground = true;
                        oGetArgThread.Start();
                    
                    }
                    else {
                        this.rsttitle.Text = "IP:" + agentDataGrid.Rows[e.RowIndex].Cells["AgentIp"].Value.ToString() + " Result:";
                        if (agentDataGrid.Rows[e.RowIndex].Cells["rstfull"].Value != null)
                        {
                            this.rst.Text = Unicode2String(agentDataGrid.Rows[e.RowIndex].Cells["rstfull"].Value.ToString()).Replace("\n", "\r\n").Replace("\\n", "\r\n");
                        }
                        else
                        {
                            this.rst.Text = "";
                        }
                    }
                }
            }
        }
        private void rstx_Click(object sender, EventArgs e)
        {
            Clipboard.SetDataObject(this.rst.Text);
        }
        public static string Unicode2String(string source)
        {
            try
            {
                return new Regex(@"\\u([0-9A-F]{4})", RegexOptions.IgnoreCase | RegexOptions.Compiled).Replace(
                                             source, x => string.Empty + Convert.ToChar(Convert.ToUInt16(x.Result("$1"), 16)));
            }
            catch (Exception ee)
            {
                return "返回结果编码转换异常!" + ee.Message;
            }
        }
        private void reloginbtn_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确定要重新登录么？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                this.currLogin.account_txt.Text = "";
                this.currLogin.pwd_txt.Text = "";
                this.currLogin.Show();
                this.Hide();
            }
        }
        private void aboutbtn_Click(object sender, EventArgs e)
        {
            About dialog = new About();
            dialog.StartPosition = FormStartPosition.Manual;
            int xWidth = SystemInformation.PrimaryMonitorSize.Width;
            int yHeight = SystemInformation.PrimaryMonitorSize.Height;
            dialog.Location = new Point((xWidth - dialog.Width) / 2, (yHeight - dialog.Height) / 2);
            dialog.ShowDialog();
        }
    }
}