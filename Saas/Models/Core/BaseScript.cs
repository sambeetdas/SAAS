using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Saas.Model.Core
{
    public class BaseScript
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid BaseScriptId { get; set; }
        public string Script { get; set; }
        
        #region Standard Properties
        public string Status { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public string CreateUser { get; set; }
        public string UpdateUser { get; set; }
        #endregion
    }
}
