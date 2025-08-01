namespace MahalaxmiAPI.Models.DataModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MyOrder")]
    public partial class MyOrder
    {
        public long Id { get; set; }

        [StringLength(10)]
        public string Product { get; set; }

        [StringLength(500)]
        public string Grade { get; set; }

        public decimal? Qty { get; set; }

        [StringLength(50)]
        public string Type { get; set; }

        public DateTime? ScheduledDate { get; set; }

        [StringLength(50)]
        public string Status { get; set; }

        [StringLength(50)]
        public string PaymentTerms { get; set; }

        [StringLength(50)]
        public string SoldToPartyId { get; set; }

        [StringLength(128)]
        public string CreatedBy { get; set; }

        public DateTime? CreatedDate { get; set; }

        public bool? IsDeleted { get; set; }
    }
}
