namespace MahalaxmiAPI.Models.DataModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Favriote1
    {
        public long Id { get; set; }

        [StringLength(50)]
        public string ProfileID { get; set; }

        [StringLength(50)]
        public string NameOfCustomer { get; set; }

        [StringLength(500)]
        public string Product { get; set; }

        [StringLength(50)]
        public string Domestic { get; set; }

        [StringLength(50)]
        public string Deemed { get; set; }
    }
}
