namespace MahalaxmiAPI.Models.DataModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("emailformate")]
    public partial class emailformate
    {
        [Column(TypeName = "numeric")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal id { get; set; }

        [StringLength(1000)]
        public string mname { get; set; }

        [Column(TypeName = "ntext")]
        public string mcontent { get; set; }

        public bool? active { get; set; }
    }
}
