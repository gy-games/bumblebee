using System;
using System.Windows.Forms;

namespace BumblebeeClient
{
    public partial class About : Form
    {
        public About()
        {
            InitializeComponent();
            this.intro_label1.Text = "Bumblebee(大黄蜂)运维工具(" + Login.VERSION + ")";
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/gy-games/bumblebee");
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/gy-games/elves");
        }
    }
}
