namespace MahalaxmiAPI.Models.DataModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("pdffile")]
    public partial class pdffile
    {
        [Column(TypeName = "numeric")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal id { get; set; }

        [StringLength(255)]
        public string mname { get; set; }

        [Column(TypeName = "ntext")]
        public string mcontent { get; set; }

        public DateTime? morder { get; set; }

        [StringLength(500)]
        public string topimage { get; set; }

        public bool? histroy { get; set; }

        [StringLength(20)]
        public string productname { get; set; }
    }
}
