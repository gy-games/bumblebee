namespace BumblebeeClient
{
    partial class About
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
            this.intro_label_2 = new System.Windows.Forms.Label();
            this.intro_label1 = new System.Windows.Forms.Label();
            this.intro_lic_label = new System.Windows.Forms.Label();
            this.intro_copyright_label = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.linkLabel2 = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // intro_label_2
            // 
            this.intro_label_2.AutoSize = true;
            this.intro_label_2.Location = new System.Drawing.Point(24, 82);
            this.intro_label_2.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
            this.intro_label_2.MaximumSize = new System.Drawing.Size(360, 0);
            this.intro_label_2.Name = "intro_label_2";
            this.intro_label_2.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.intro_label_2.Size = new System.Drawing.Size(353, 74);
            this.intro_label_2.TabIndex = 0;
            this.intro_label_2.Text = "Bumblebee是基于Elves开发的远程命令行执行工具，支持批量命令行指令执行，指令黑名单，统计/审计等功能\r\n\r\nBumblebee开源地址：\r\n\r\nElv" +
    "es开源地址：";
            this.intro_label_2.Click += new System.EventHandler(this.label1_Click);
            // 
            // intro_label1
            // 
            this.intro_label1.AutoSize = true;
            this.intro_label1.Location = new System.Drawing.Point(12, 23);
            this.intro_label1.MaximumSize = new System.Drawing.Size(197, 12);
            this.intro_label1.MinimumSize = new System.Drawing.Size(197, 12);
            this.intro_label1.Name = "intro_label1";
            this.intro_label1.Size = new System.Drawing.Size(197, 12);
            this.intro_label1.TabIndex = 1;
            this.intro_label1.Text = "Bumblebee(大黄蜂)运维工具(0.0.3)";
            // 
            // intro_lic_label
            // 
            this.intro_lic_label.AutoSize = true;
            this.intro_lic_label.Location = new System.Drawing.Point(130, 196);
            this.intro_lic_label.Name = "intro_lic_label";
            this.intro_lic_label.Size = new System.Drawing.Size(281, 12);
            this.intro_lic_label.TabIndex = 2;
            this.intro_lic_label.Text = "Licensed under the Apache License, Version 2.0";
            // 
            // intro_copyright_label
            // 
            this.intro_copyright_label.AutoSize = true;
            this.intro_copyright_label.Location = new System.Drawing.Point(12, 46);
            this.intro_copyright_label.Name = "intro_copyright_label";
            this.intro_copyright_label.Size = new System.Drawing.Size(209, 12);
            this.intro_copyright_label.TabIndex = 3;
            this.intro_copyright_label.Text = "Copyright 2017-2018 Gy-Games, Inc.";
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(117, 145);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(203, 12);
            this.linkLabel1.TabIndex = 4;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "https://github.com/gy-games/elves";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // linkLabel2
            // 
            this.linkLabel2.AutoSize = true;
            this.linkLabel2.Location = new System.Drawing.Point(140, 119);
            this.linkLabel2.Name = "linkLabel2";
            this.linkLabel2.Size = new System.Drawing.Size(227, 12);
            this.linkLabel2.TabIndex = 5;
            this.linkLabel2.TabStop = true;
            this.linkLabel2.Text = "https://github.com/gy-games/bumblebee";
            this.linkLabel2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel2_LinkClicked);
            // 
            // About
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(423, 224);
            this.Controls.Add(this.linkLabel2);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.intro_copyright_label);
            this.Controls.Add(this.intro_lic_label);
            this.Controls.Add(this.intro_label1);
            this.Controls.Add(this.intro_label_2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "About";
            this.ShowIcon = false;
            this.Text = "关于Bumblebee";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label intro_label_2;
        private System.Windows.Forms.Label intro_label1;
        private System.Windows.Forms.Label intro_lic_label;
        private System.Windows.Forms.Label intro_copyright_label;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.LinkLabel linkLabel2;
    }
}