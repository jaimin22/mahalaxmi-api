namespace MahalaxmiAPI.Models.DataModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class PE_Depot1
    {
        public long Id { get; set; }

        [StringLength(255)]
        public string Location { get; set; }

        [Column("45GP004")]
        public long? C45GP004 { get; set; }

        [Column("45GP004B")]
        public long? C45GP004B { get; set; }

        [Column("45GP004UV")]
        public long? C45GP004UV { get; set; }

        [Column("46GP003")]
        public long? C46GP003 { get; set; }

        [Column("46GP009")]
        public long? C46GP009 { get; set; }

        [Column("46GP009UV")]
        public long? C46GP009UV { get; set; }

        [Column("50GF003")]
        public long? C50GF003 { get; set; }

        [Column("52DB003")]
        public long? C52DB003 { get; set; }

        [Column("52DF004")]
        public long? C52DF004 { get; set; }

        [Column("52GB001")]
        public long? C52GB001 { get; set; }

        [Column("52GB002")]
        public long? C52GB002 { get; set; }

        [Column("52GB003")]
        public long? C52GB003 { get; set; }

        [Column("52GF004")]
        public long? C52GF004 { get; set; }

        [Column("54DB012")]
        public long? C54DB012 { get; set; }

        [Column("54GB012")]
        public long? C54GB012 { get; set; }

        [Column("55EF010")]
        public long? C55EF010 { get; set; }

        public long? B56003 { get; set; }

        public long? E41003 { get; set; }

        public long? E52009 { get; set; }

        public long? EE20 { get; set; }

        public long? F46003 { get; set; }

        public long? F46003E { get; set; }

        public long? F56003 { get; set; }

        public long? HD50MA180 { get; set; }

        public long? HD53EA010 { get; set; }

        public long? HD53MA020 { get; set; }

        public long? HD53TA010 { get; set; }

        public long? L60075 { get; set; }

        public long? M60075 { get; set; }

        public long? M60200 { get; set; }

        public long? S42005 { get; set; }

        public long? UE { get; set; }

        public long? UEGC { get; set; }

        public long? UENC { get; set; }

        public long? UFHMGC { get; set; }

        public long? UM { get; set; }

        public long? UMNC { get; set; }

        public long? E18010 { get; set; }

        public long? E19010 { get; set; }

        public long? E24065 { get; set; }

        public long? F18010 { get; set; }

        public long? F18020 { get; set; }

        public long? F19010 { get; set; }

        public long? F22020 { get; set; }

        public long? HP19010 { get; set; }

        public long? LL20DS010 { get; set; }

        public long? LL20FA010 { get; set; }

        public long? LL20FA020 { get; set; }

        public long? LL20FS010 { get; set; }

        public long? LL20FS020 { get; set; }

        public long? LL24FA030 { get; set; }

        public long? LL36RA045 { get; set; }

        public long? LL36RA045UV { get; set; }

        public long? LL40RA040 { get; set; }

        public long? LL40RA040UV { get; set; }

        public long? M24200 { get; set; }

        public long? M24300 { get; set; }

        public long? M26500 { get; set; }

        public long? O19010 { get; set; }

        public long? O20010 { get; set; }

        public long? O21010 { get; set; }

        public long? O30042 { get; set; }

        public long? O35042 { get; set; }

        public long? R35042 { get; set; }

        public long? UF { get; set; }

        public long? UFNC { get; set; }

        public long? UMLL { get; set; }

        public long? UR { get; set; }

        public long? URNC { get; set; }

        public long? X24065 { get; set; }

        public long? X24065J { get; set; }

        [Column("1003FA20")]
        public long? C1003FA20 { get; set; }

        [Column("1005FY20")]
        public long? C1005FY20 { get; set; }

        [Column("1020FA20")]
        public long? C1020FA20 { get; set; }

        [Column("1035FS20")]
        public long? C1035FS20 { get; set; }

        [Column("1070LA17")]
        public long? C1070LA17 { get; set; }

        [Column("16MA400")]
        public long? C16MA400 { get; set; }

        [Column("20XL020")]
        public long? C20XL020 { get; set; }

        [Column("22FA002")]
        public long? C22FA002 { get; set; }

        [Column("23FY005")]
        public long? C23FY005 { get; set; }

        [Column("24BA008")]
        public long? C24BA008 { get; set; }

        [Column("24FA040")]
        public long? C24FA040 { get; set; }

        [Column("24FS040")]
        public long? C24FS040 { get; set; }

        public long? UTBC { get; set; }

        public long? UTMBC { get; set; }

        public long? UTNC { get; set; }
    }
}
