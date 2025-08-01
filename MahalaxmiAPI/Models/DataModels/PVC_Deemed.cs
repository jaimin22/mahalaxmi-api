namespace MahalaxmiAPI.Models.DataModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class PVC_Deemed
    {
        public long Id { get; set; }

        [StringLength(255)]
        public string Location { get; set; }

        [Column("67GER01")]
        public long? C67GER01 { get; set; }

        [Column("67GER01 D")]
        public long? C67GER01_D { get; set; }

        [Column("67GER01 E")]
        public long? C67GER01_E { get; set; }

        [Column("K67-01")]
        public long? K67_01 { get; set; }

        [Column("K6701 D")]
        public long? K6701_D { get; set; }

        [Column("K6701 E")]
        public long? K6701_E { get; set; }

        [Column("67GER01F")]
        public long? C67GER01F { get; set; }

        [Column("67GER01F D")]
        public long? C67GER01F_D { get; set; }

        [Column("K67-11")]
        public long? K67_11 { get; set; }

        [Column("K6711 D")]
        public long? K6711_D { get; set; }

        [Column("57GER01")]
        public long? C57GER01 { get; set; }

        [Column("57GMR01")]
        public long? C57GMR01 { get; set; }

        [Column("57GER01 D")]
        public long? C57GER01_D { get; set; }

        [Column("57GER01 E")]
        public long? C57GER01_E { get; set; }
    }
}
