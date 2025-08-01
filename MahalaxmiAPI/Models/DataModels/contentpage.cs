namespace MahalaxmiAPI.Models.DataModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("contentpage")]
    public partial class contentpage
    {
        [Column(TypeName = "numeric")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal id { get; set; }

        [StringLength(255)]
        public string mname { get; set; }

        [Column(TypeName = "ntext")]
        public string mcontent { get; set; }

        [StringLength(10)]
        public string topimage { get; set; }
    }
}
