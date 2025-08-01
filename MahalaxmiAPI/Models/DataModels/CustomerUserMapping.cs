namespace MahalaxmiAPI.Models.DataModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CustomerUserMapping")]
    public partial class CustomerUserMapping
    {
        public long Id { get; set; }

        [StringLength(128)]
        public string UserId { get; set; }

        public long? ProfileId { get; set; }

        [StringLength(100)]
        public string SoldToPartyId { get; set; }

        public bool? IsDeleted { get; set; }
    }
}
