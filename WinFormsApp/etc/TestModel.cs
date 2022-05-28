using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp16.etc
{

    class TestModel
    {
        public string ID{ get; set; }
        public string TYPE { get; set; }
        public string NAME { get; set; }
        public string MAC_ADDRESS { get; set; }
        public string IP { get; set; }
        public string CONNECT_STATUS{ get; set; }
    }
    class TestModel2
    {
        public string ID { get; set; }
        
        public string NAME { get; set; }
        public string ROLE { get; set; }
        public string ACCOUNT_STATUS { get; set; }
        public string CONNECT_STATUS { get; set; }
    }
    class TestModel3
    {
        public string ACCESS_IP { get; set; }

        public string CLIENT_TYPE { get; set; }
        public string LOG_LEVEL { get; set; }
        public string INFORMATION { get; set; }
        public string ACTIVITY { get; set; }
        public string TIMESTAMP { get; set; }
    }
}
