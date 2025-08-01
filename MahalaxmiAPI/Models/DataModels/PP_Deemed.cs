namespace MahalaxmiAPI.Models.DataModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class PP_Deemed
    {
        public long Id { get; set; }

        [StringLength(255)]
        public string Location { get; set; }

        public long? B030MG { get; set; }

        public long? B120MA { get; set; }

        public long? B220MN { get; set; }

        public long? B300MN { get; set; }

        public long? B400MN { get; set; }

        public long? B650MN { get; set; }

        public long? C015EG { get; set; }

        public long? C080MA { get; set; }

        public long? C080MT { get; set; }

        public long? C120MN { get; set; }

        public long? C320MN { get; set; }

        public long? D120MA { get; set; }

        public long? H019TG { get; set; }

        public long? H019TGL { get; set; }

        public long? H020EG { get; set; }

        public long? H026SG { get; set; }

        public long? H030SG { get; set; }

        public long? H030SGT { get; set; }

        public long? H033MG { get; set; }

        public long? H034SG { get; set; }

        public long? H034SGT { get; set; }

        public long? H045SG { get; set; }

        public long? H050MN { get; set; }

        public long? H060FU { get; set; }

        public long? H060MG { get; set; }

        public long? H080EY { get; set; }

        public long? H100EY { get; set; }

        public long? H110FG { get; set; }

        public long? H110FU { get; set; }

        public long? H110FUL { get; set; }

        public long? H110MA { get; set; }

        public long? H110MG { get; set; }

        public long? H200FG { get; set; }

        public long? H200MA { get; set; }

        public long? H200MG { get; set; }

        public long? H230FG { get; set; }

        public long? H350EG { get; set; }

        public long? H350FG { get; set; }

        public long? H350FH { get; set; }

        public long? H350FHT { get; set; }

        public long? N033MG { get; set; }

        public long? N350FG { get; set; }

        public long? UHF { get; set; }

        public long? ULF { get; set; }

        public long? AER003N { get; set; }

        public long? AM010N { get; set; }

        public long? AM120N { get; set; }

        public long? AM650N { get; set; }

        public long? AS030N { get; set; }

        public long? AS12000N { get; set; }

        public long? AS160N { get; set; }

        public long? AS4000N { get; set; }

        public long? MI3530 { get; set; }

        public long? MI3535 { get; set; }

        public long? H200MK { get; set; }

        public long? SR20NC { get; set; }

        public long? SR20NS { get; set; }

        public long? SRM100NC { get; set; }

        public long? SRM250NC { get; set; }

        public long? SRX100 { get; set; }

        public long? SS35N { get; set; }

        public long? SS80N { get; set; }
    }
}
