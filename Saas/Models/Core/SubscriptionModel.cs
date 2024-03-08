using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Saas.Model.Core
{
    public class SubscriptionModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid SubscriptionId { get; set; }
        public string SubcriptionCode { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public string Amount { get; set; }
        public string Currency { get; set; }
        public string Frequency { get; set; }
        public string Services { get; set; }

        #region Standard Properties
        public string Status { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public string CreateUser { get; set; }
        public string UpdateUser { get; set; }
        #endregion
    }
}
