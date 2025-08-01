namespace MahalaxmiAPI.Models.DataModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class cm
    {
        [Key]
        [Column(Order = 0, TypeName = "numeric")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal id { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(255)]
        public string pagename { get; set; }

        [Column(TypeName = "ntext")]
        public string pagedesc { get; set; }

        public bool? active { get; set; }

        public bool? videostatus { get; set; }

        [StringLength(50)]
        public string video { get; set; }

        [Column(TypeName = "ntext")]
        public string videodesc { get; set; }

        public bool? status { get; set; }
    }
}
