using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Saas.Model.Core
{
    public class SubscribedModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid SubscribedId { get; set; }

        [Required]
        public string SubscribedEmail { get; set; }
        public string SubscribedPhone { get; set; }

        [Required]
        public string SubscribedPassword { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string SubcriptionCode { get; set; }
        public DateTime SubcriptionStartDate { get; set; }
        public DateTime SubcriptionEndDate { get; set; }

        #region Standard Properties
        public string Status { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public string CreateUser { get; set; }
        public string UpdateUser { get; set; }
        #endregion
    }
}
