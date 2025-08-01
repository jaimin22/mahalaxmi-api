namespace MahalaxmiAPI.Models.DataModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("productMember")]
    public partial class productMember
    {
        [Column(TypeName = "numeric")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal id { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? productid { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? userid { get; set; }

        [StringLength(50)]
        public string product_code { get; set; }

        [StringLength(500)]
        public string payerid { get; set; }
    }
}
