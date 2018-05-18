using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BestSignSdk.Model
{
    public class BestSignPushDTO
    {

        public string action { get; set; }
        public ParamsDTO @params { get; set; }

    }

    public class ParamsDTO
    {
        public string contractId { get; set; }
        public string account { get; set; }
        public int signerStatus { get; set; }
        public string errMsg { get; set; }
        public string sid { get; set; }


        // 申请证书
        public string certType { get; set; }
        public string cert { get; set; }
        public string message { get; set; }
        public string taskId { get; set; }
        public string status { get; set; }

    }
}
