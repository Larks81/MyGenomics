using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGenomics.DataModel
{
    public class WebApiLog : ModelBase
    {
        public string Status { get; set; }
        public string HttpVerb { get; set; }
        public DateTime Date { get; set; }
        public string RequestUri { get; set; }
        public string RequestBody { get; set; }
        public string ResponseBody { get; set; }
        public string Exception { get; set; }
        public string ClientIp { get; set; }
        public long Duration { get; set; }
    }
}
