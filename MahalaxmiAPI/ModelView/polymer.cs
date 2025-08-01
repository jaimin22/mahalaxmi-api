using System;
using System.Collections.Generic;

namespace MahalaxmiAPI.ModelView
{
    public partial class polymerView
    {
        public decimal id { get; set; }
        public string mname { get; set; }
        public string mcontent { get; set; }
        public Nullable<decimal> morder { get; set; }
        public string topimage { get; set; }
        public Nullable<int> mid { get; set; }
        public List<polymerView> polimarViewList { get; set; }
    }
}
