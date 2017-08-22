using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace BumblebeeClient
{
    class ConstantUrl
    {
        private static string bumblebeeHost =ConfigurationManager.AppSettings.Get("BumblebeeServerHost");

        public static string url = bumblebeeHost + "/";

        public static string loginUrl = bumblebeeHost + "/terminal/login";

        public static string agentConditionUrl = bumblebeeHost + "/terminal/agentCondition";

        public static string subNameListUrl = bumblebeeHost + "/terminal/subNameList";

        public static string agentListUrl = bumblebeeHost + "/terminal/agentList";

        public static string runCommandUrl = bumblebeeHost + "/terminal/runCommand";

        public static string runDaemonCommandUrl = bumblebeeHost + "/terminal/runDaemonCommand";

        public static string runShellUrl = bumblebeeHost + "/terminal/runShell";

    }
}
