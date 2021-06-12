using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Saas.Model.Service
{
    public class SubscriptionModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid SubscriptionId { get; set; }

        public string SubscriptionUser { get; set; }
        public string SubscriptionPassword { get; set; }
        public string SubscriptionType { get; set; }

        #region Standard Properties
        public string Status { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public string CreateUser { get; set; }
        public string UpdateUSer { get; set; }
        #endregion
    }
}
