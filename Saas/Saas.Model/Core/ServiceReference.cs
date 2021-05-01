using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saas.Model.Core
{
    public class ServiceReference
    {
        public ServiceReference()
        {
            ScriptReferences = new List<ScriptReference>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ServiceReferenceId { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }
        public List<ScriptReference> ScriptReferences { get; set; }
        public string Status { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public string CreateUser { get; set; }
        public string UpdateUSer { get; set; }
       
    }
}
