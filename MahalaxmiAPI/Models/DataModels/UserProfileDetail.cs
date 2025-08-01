namespace MahalaxmiAPI.Models.DataModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class UserProfileDetail
    {
        public long Id { get; set; }

        [StringLength(128)]
        public string UserId { get; set; }

        public string UserName { get; set; }

        public string Name { get; set; }

        public string EmaiId { get; set; }

        public bool? IsDeleted { get; set; }
    }
}
