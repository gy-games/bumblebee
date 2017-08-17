namespace BumblebeeClient
{
    partial class Login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.login_btn = new System.Windows.Forms.Button();
            this.close_btn = new System.Windows.Forms.Button();
            this.label_username = new System.Windows.Forms.Label();
            this.label_password = new System.Windows.Forms.Label();
            this.account_txt = new System.Windows.Forms.TextBox();
            this.pwd_txt = new System.Windows.Forms.TextBox();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.enterwebcontrol = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // login_btn
            // 
            this.login_btn.Location = new System.Drawing.Point(225, 200);
            this.login_btn.Name = "login_btn";
            this.login_btn.Size = new System.Drawing.Size(75, 23);
            this.login_btn.TabIndex = 0;
            this.login_btn.Text = "登录";
            this.login_btn.UseVisualStyleBackColor = true;
            this.login_btn.Click += new System.EventHandler(this.login_btn_Click);
            // 
            // close_btn
            // 
            this.close_btn.Location = new System.Drawing.Point(354, 199);
            this.close_btn.Name = "close_btn";
            this.close_btn.Size = new System.Drawing.Size(75, 23);
            this.close_btn.TabIndex = 1;
            this.close_btn.Text = "退出";
            this.close_btn.UseVisualStyleBackColor = true;
            this.close_btn.Click += new System.EventHandler(this.close_btn_Click);
            // 
            // label_username
            // 
            this.label_username.AutoSize = true;
            this.label_username.Location = new System.Drawing.Point(220, 103);
            this.label_username.Name = "label_username";
            this.label_username.Size = new System.Drawing.Size(35, 12);
            this.label_username.TabIndex = 2;
            this.label_username.Text = "帐号:";
            // 
            // label_password
            // 
            this.label_password.AutoSize = true;
            this.label_password.Location = new System.Drawing.Point(221, 151);
            this.label_password.Name = "label_password";
            this.label_password.Size = new System.Drawing.Size(35, 12);
            this.label_password.TabIndex = 3;
            this.label_password.Text = "密码:";
            // 
            // account_txt
            // 
            this.account_txt.Location = new System.Drawing.Point(283, 100);
            this.account_txt.Name = "account_txt";
            this.account_txt.Size = new System.Drawing.Size(159, 21);
            this.account_txt.TabIndex = 4;
            // 
            // pwd_txt
            // 
            this.pwd_txt.Location = new System.Drawing.Point(283, 142);
            this.pwd_txt.Name = "pwd_txt";
            this.pwd_txt.Size = new System.Drawing.Size(159, 21);
            this.pwd_txt.TabIndex = 5;
            this.pwd_txt.UseSystemPasswordChar = true;
            // 
            // pictureBox
            // 
            this.pictureBox.Image = global::BumblebeeClient.Properties.Resources.bg;
            this.pictureBox.Location = new System.Drawing.Point(11, 91);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(190, 120);
            this.pictureBox.TabIndex = 6;
            this.pictureBox.TabStop = false;
            // 
            // enterwebcontrol
            // 
            this.enterwebcontrol.AutoSize = true;
            this.enterwebcontrol.BackColor = System.Drawing.Color.Transparent;
            this.enterwebcontrol.ForeColor = System.Drawing.Color.White;
            this.enterwebcontrol.Location = new System.Drawing.Point(365, 40);
            this.enterwebcontrol.Name = "enterwebcontrol";
            this.enterwebcontrol.Size = new System.Drawing.Size(77, 12);
            this.enterwebcontrol.TabIndex = 7;
            this.enterwebcontrol.Text = "进入管理平台";
            this.enterwebcontrol.Click += new System.EventHandler(this.enterwebcontrol_Click);
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(468, 255);
            this.Controls.Add(this.enterwebcontrol);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.pwd_txt);
            this.Controls.Add(this.account_txt);
            this.Controls.Add(this.label_password);
            this.Controls.Add(this.label_username);
            this.Controls.Add(this.close_btn);
            this.Controls.Add(this.login_btn);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(468, 255);
            this.MinimumSize = new System.Drawing.Size(468, 255);
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BumblebeeClient";
            this.Activated += new System.EventHandler(this.Login_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Login_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Login_FormClosed);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Login_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button login_btn;
        private System.Windows.Forms.Button close_btn;
        private System.Windows.Forms.Label label_username;
        private System.Windows.Forms.Label label_password;
        private System.Windows.Forms.PictureBox pictureBox;
        public System.Windows.Forms.TextBox account_txt;
        public System.Windows.Forms.TextBox pwd_txt;
        private System.Windows.Forms.Label enterwebcontrol;
    }
}