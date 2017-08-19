using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;
using Newtonsoft.Json;

namespace BumblebeeClient
{
    public partial class Login : MaterialForm
    {
        private readonly MaterialSkinManager materialSkinManager;

        public static String VERSION = "0.0.5";
        public static String EMAIL;
        public static String PWDKEY;

        public Login()
        {
            InitializeComponent();
            materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);
        }

        private void login_btn_Click(object sender, EventArgs e)
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
            
            Login.EMAIL  = account;
            Login.PWDKEY = SecurityUtil.CreateMD5Hash(pwd);
            //Login.PWDKEY = "";
            pm.Add("version",Login.VERSION);
            pm.Add("email", Login.EMAIL);
            //pm.Add("pwd", pwd);
            pm.Add("timestamp",SecurityUtil.GetTimestamp());
            string sign=SecurityUtil.CreateSign(pm, Login.PWDKEY);
            pm.Add("sign",sign);
            try
            {
                string result = HttpUtil.SendPost(ConstantUrl.loginUrl, pm);
                Console.WriteLine(result);
                if (String.IsNullOrEmpty(result))
                {
                    MessageBox.Show("登录失败，帐号密码错误！", "提示");
                }
                else {
                    Dictionary<string, string> r = JsonConvert.DeserializeObject<Dictionary<string, string>>(result);
                    if (r["code"] == "0") {
                        if (!string.IsNullOrEmpty(r["msg"])) {
                            MessageBox.Show(r["msg"], "提示");
                        }
                        MainWindow main = new MainWindow(this);
                        main.StartPosition = FormStartPosition.Manual;
                        int xWidth = SystemInformation.PrimaryMonitorSize.Width;
                        int yHeight = SystemInformation.PrimaryMonitorSize.Height;
                        main.Location = new Point((xWidth - main.Width) / 2, (yHeight - main.Height) / 2);
                        this.Hide();
                        main.Show();
                    }
                    else {
                        MessageBox.Show(r["msg"], "提示");
                    }

                }
            }
            catch (Exception ee) {
                MessageBox.Show("登录失败，服务端异常！("+ee.Message+")", "提示");
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
                this.login_btn_Click(sender, e);
            }
        }

        private void Login_Activated(object sender, EventArgs e)
        {
            this.account_txt.Focus();
        }

        private void enterwebcontrol_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(ConstantUrl.url);
        }
    }
}
