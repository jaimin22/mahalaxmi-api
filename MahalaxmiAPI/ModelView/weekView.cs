using System;
using System.Collections.Generic;

namespace MahalaxmiAPI.ModelView
{
    public partial class weekView
    {
        public int id { get; set; }
        public string startDay { get; set; }
        public string endDay { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
    }
}
