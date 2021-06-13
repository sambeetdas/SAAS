using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saas.Model.Core
{
    public class ScriptReference
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ScriptId { get; set; }
        public string Script { get; set; }
        public string ScriptType { get; set; } //PRE/POST
        
        #region Standard Properties
        public string Status { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public string CreateUser { get; set; }
        public string UpdateUser { get; set; }
        #endregion
    }
}
