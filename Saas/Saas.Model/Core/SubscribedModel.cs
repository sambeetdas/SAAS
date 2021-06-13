using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Saas.Model.Core
{
    public class SubscribedModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid SubscribedId { get; set; }
        public string SubscribedEmail { get; set; }
        public string SubscribedPhone { get; set; }
        public string SubscribedPassword { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Guid SubscriptionId { get; set; }
        public string SubcriptionCode { get; set; }

        #region Standard Properties
        public string Status { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public string CreateUser { get; set; }
        public string UpdateUser { get; set; }
        #endregion
    }
}
