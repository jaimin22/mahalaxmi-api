namespace MahalaxmiAPI.Models.DataModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("UserCustomerMappingView")]
    public partial class UserCustomerMappingView
    {
        [Key]
        [StringLength(100)]
        public string SoldToPartyId { get; set; }

        public string CustomerName { get; set; }

        [StringLength(128)]
        public string UserId { get; set; }

        public long? ProfileId { get; set; }
    }
}
