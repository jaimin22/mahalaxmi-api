namespace MahalaxmiAPI.Models.DataModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("admin")]
    public partial class admin
    {
        [Key]
        [Column(TypeName = "numeric")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal admin_id { get; set; }

        [StringLength(50)]
        public string administrator_name { get; set; }

        [StringLength(50)]
        public string admin_password { get; set; }

        [StringLength(50)]
        public string admin_type { get; set; }

        [StringLength(50)]
        public string admin_email { get; set; }

        public bool? Active { get; set; }
    }
}
