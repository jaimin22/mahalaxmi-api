namespace MahalaxmiAPI.Models.DataModels
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("AppVersion")]
    public partial class AppVersion
    {
        public int Id { get; set; }

        [StringLength(50)]
        public string VersionNumber { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}
