namespace MahalaxmiAPI.Models.DataModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("UserMaster")]
    public partial class UserMaster
    {
        [Column(TypeName = "numeric")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal id { get; set; }

        [StringLength(20)]
        public string profileid { get; set; }

        [StringLength(50)]
        public string firstname { get; set; }

        [StringLength(5)]
        public string studyyear { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? langstudies { get; set; }

        [StringLength(15)]
        public string phoneno { get; set; }

        public int? referraltype { get; set; }

        [StringLength(255)]
        public string referral { get; set; }

        [StringLength(4000)]
        public string email { get; set; }

        [StringLength(10)]
        public string userpassword { get; set; }

        [StringLength(10)]
        public string img { get; set; }

        public DateTime? regidate { get; set; }

        public bool? active { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? degree { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? major { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? countryid { get; set; }

        [StringLength(255)]
        public string City { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? University { get; set; }

        public bool? news { get; set; }

        public bool? sms { get; set; }

        [StringLength(10)]
        public string phonecode { get; set; }

        public bool? emailnotify { get; set; }

        [StringLength(50)]
        public string secretcode { get; set; }

        [StringLength(500)]
        public string cname { get; set; }

        [StringLength(100)]
        public string nickname { get; set; }
    }
}
