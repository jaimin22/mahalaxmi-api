namespace MahalaxmiAPI.Models.DataModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CustomerMaster")]
    public partial class CustomerMaster
    {
        [Key]
        [StringLength(100)]
        public string SoldToPartyId { get; set; }

        public string CustomerName { get; set; }

        public string CustomerEmailId { get; set; }

        public string CustomerPhoneNumber { get; set; }

        public bool? IsDeleted { get; set; }
    }
}
