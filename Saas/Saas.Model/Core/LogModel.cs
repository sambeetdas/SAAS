using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saas.Model.Core
{
    public class LogModel
    {
        public Guid LogId { get; set; }
        public string ApiType { get; set; }
        public string ApiName { get; set; }
        public string Request { get; set; }
        public string Response { get; set; }
        public string Status { get; set; }
        public string Scheme { get; set; }
        public DateTime RequestedDateTime { get; set; }
        public string User { get; set; }
    }
}
