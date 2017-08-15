using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BumblebeeClient
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Login loginForm = new Login();
            loginForm.StartPosition = FormStartPosition.Manual;
            int xWidth = SystemInformation.PrimaryMonitorSize.Width;
            int yHeight = SystemInformation.PrimaryMonitorSize.Height;
            loginForm.Location = new Point((xWidth-loginForm.Width) / 2, (yHeight-loginForm.Height) / 2);
            Application.Run(loginForm);
        }
    }
}
