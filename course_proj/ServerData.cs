using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kursaCH
{
    class ServerData
    {
        public string dataBaseName { get; }
        public string dataBasePassword { get; }
        public string dataBaseUserName { get; }
        public string dataBaseServerName { get; }

        public ServerData(string dbName, string dbPassword, string dbUserName, string dbServerName)
        {

            dataBaseName = dbName;
            dataBasePassword = dbPassword;
            dataBaseUserName = dbUserName;
            dataBaseServerName = dbServerName;
        }
    }
}
