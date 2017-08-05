using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BumblebeeClient
{
    class AgentInfo
    {
        private string agentIp;

        public string AgentIp
        {
            get { return agentIp; }
            set { agentIp = value; }
        }

        private string agentName;

        public string AgentName
        {
            get { return agentName; }
            set { agentName = value; }
        }

        private string asset;

        public string Asset
        {
            get { return asset; }
            set { asset = value; }
        }

        private string manager;

        public string Manager
        {
            get { return manager; }
            set { manager = value; }
        }

        private string mainName;

        public string MainName
        {
            get { return mainName; }
            set { mainName = value; }
        }

        private string subName;

        public string SubName
        {
            get { return subName; }
            set { subName = value; }
        }

    }
}
