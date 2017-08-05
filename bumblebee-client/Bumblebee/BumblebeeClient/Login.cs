using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BumblebeeClient
{
    public partial class Login : Form
    {

        public Login()
        {
            InitializeComponent();
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            string account = this.account_txt.Text;
            string pwd = this.pwd_txt.Text;

            if (String.IsNullOrEmpty(account))
            {
                MessageBox.Show("请输入登录邮箱","提示");
                this.account_txt.Focus();
                return;
            }

            if (String.IsNullOrEmpty(pwd))
            {
                MessageBox.Show("请输入登录密码！", "提示");
                this.pwd_txt.Focus();
                return;
            }

            this.login_btn.Enabled = false;

            Dictionary<string, string> pm = new Dictionary<string, string>();
            pm.Add("email", account);
            pm.Add("pwd", pwd);
            pm.Add("timestamp",SecurityUtil.GetTimestamp());
            string sign=SecurityUtil.CreateSign(pm);
            pm.Add("sign",sign);
            string result = HttpUtil.SendPost(ConstantUrl.loginUrl, pm);

            if (String.IsNullOrEmpty(result)){
                MessageBox.Show("登录失败，服务端异常！", "提示");
            }
            else if ("success".Equals(result))
            {
                MainWindow main = new MainWindow(this,account);
                main.StartPosition = FormStartPosition.Manual;
                int xWidth = SystemInformation.PrimaryMonitorSize.Width;
                int yHeight = SystemInformation.PrimaryMonitorSize.Height;
                main.Location = new Point((xWidth - main.Width) / 2, (yHeight - main.Height) / 2);
                this.Hide();
                main.Show();
            }
            else
            {
                MessageBox.Show("登录失败，用户名或密码错误！", "提示");
            }
            this.login_btn.Enabled = true;
        }

        private void close_btn_Click(object sender, EventArgs e)
        {
            MessageBoxButtons messButton = MessageBoxButtons.OKCancel;
            DialogResult dr = MessageBox.Show("确定退出应用么?", "退出系统", messButton);
            if (dr == DialogResult.OK)//如果点击“确定”按钮
            {
                System.Environment.Exit(0);
            }     
        }

        private void Login_Load(object sender, EventArgs e)
        {
           
        }

        private void Login_FormClosed(object sender, FormClosedEventArgs e)
        {
            System.Environment.Exit(0);
        }

        private void Login_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("确定退出应用么？", "退出系统", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
            {
                e.Cancel = true;
                return;
            }
        }

        private void Login_KeyDown(object sender, KeyEventArgs e)
        {
            
            if (e.KeyCode == Keys.Enter)//判断回车键
            {
                this.button1_Click(sender, e);
            }
        }

        private void Login_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void Login_Activated(object sender, EventArgs e)
        {
            this.account_txt.Focus();
        }
    }
}
