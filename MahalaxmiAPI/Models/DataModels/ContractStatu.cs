namespace MahalaxmiAPI.Models.DataModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ContractStatu
    {
        public long Id { get; set; }

        [StringLength(50)]
        public string SoldToParty { get; set; }

        [StringLength(50)]
        public string Product { get; set; }

        [StringLength(500)]
        public string ClientName { get; set; }

        public string Grade { get; set; }

        [StringLength(50)]
        public string ContractNo { get; set; }

        [StringLength(10)]
        public string ContractQty { get; set; }

        [StringLength(10)]
        public string DispQty { get; set; }

        [StringLength(50)]
        public string OrderPlaced { get; set; }

        [StringLength(50)]
        public string BalaQty { get; set; }

        [StringLength(50)]
        public string TRA_No { get; set; }

        [StringLength(50)]
        public string Invalidation_No { get; set; }

        [StringLength(50)]
        public string PC_No { get; set; }

        [StringLength(50)]
        public string CT3_No { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Expiry_Dt { get; set; }

        public string Remarks { get; set; }
    }
}
