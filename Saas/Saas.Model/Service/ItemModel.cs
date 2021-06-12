using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Saas.Model.Service
{
    public class ItemModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ItemId { get; set; }
        [Required]
        public string Sku { get; set; }

        #region Standard Properties
        public string Status { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public string CreateUser { get; set; }
        public string UpdateUSer { get; set; }
        #endregion
    }
}
