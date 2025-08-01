namespace MahalaxmiAPI.Models.DataModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class PVC_Plant
    {
        public long Id { get; set; }

        [StringLength(255)]
        public string Location { get; set; }

        [Column("57GER01")]
        public long? C57GER01 { get; set; }

        [Column("57GER01 D")]
        public long? C57GER01_D { get; set; }

        [Column("57GER01 E")]
        public long? C57GER01_E { get; set; }

        [Column("57GMR01")]
        public long? C57GMR01 { get; set; }

        [Column("57GMR01 D")]
        public long? C57GMR01_D { get; set; }

        [Column("57GMR02")]
        public long? C57GMR02 { get; set; }

        [Column("57GMR03")]
        public long? C57GMR03 { get; set; }

        [Column("67BER01")]
        public long? C67BER01 { get; set; }

        [Column("67BER02")]
        public long? C67BER02 { get; set; }

        [Column("67BER03")]
        public long? C67BER03 { get; set; }

        [Column("67GER01")]
        public long? C67GER01 { get; set; }

        [Column("67GER01 D")]
        public long? C67GER01_D { get; set; }

        [Column("67GER01 E")]
        public long? C67GER01_E { get; set; }

        [Column("67GER01F")]
        public long? C67GER01F { get; set; }

        [Column("67GER01F D")]
        public long? C67GER01F_D { get; set; }

        [Column("67GER02")]
        public long? C67GER02 { get; set; }

        [Column("67GER02 D")]
        public long? C67GER02_D { get; set; }

        [Column("67GER02 E")]
        public long? C67GER02_E { get; set; }

        [Column("67GER03")]
        public long? C67GER03 { get; set; }

        [Column("67GER031")]
        public long? C67GER031 { get; set; }

        [Column("67GER03 E")]
        public long? C67GER03_E { get; set; }

        public long? GSPV { get; set; }

        public long? K6701 { get; set; }

        [Column("K6701 D")]
        public long? K6701_D { get; set; }

        [Column("K6701 E")]
        public long? K6701_E { get; set; }

        public long? K6702 { get; set; }

        [Column("K6702 D")]
        public long? K6702_D { get; set; }

        public long? K6702_E { get; set; }

        public long? K6703 { get; set; }

        [Column("K6703 D")]
        public long? K6703_D { get; set; }

        [Column("K6703 E")]
        public long? K6703_E { get; set; }

        public long? K6711 { get; set; }

        [Column("K6711 D")]
        public long? K6711_D { get; set; }
    }
}
