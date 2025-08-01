namespace MahalaxmiAPI.Models.DataModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("UserAndCompanyDetailsView")]
    public partial class UserAndCompanyDetailsView
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long Id { get; set; }

        [StringLength(128)]
        public string UserId { get; set; }

        public long? ProfileId { get; set; }

        [StringLength(100)]
        public string SoldToPartyId { get; set; }

        public string CustomerName { get; set; }

        public string UserName { get; set; }
        public string CustomerEmailId { get; set; }
    }
}
