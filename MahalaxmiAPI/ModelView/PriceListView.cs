using MahalaxmiAPI.Models.DataModels;
using System;
using System.Collections.Generic;

namespace MahalaxmiAPI.ModelView
{
    public partial class PriceListView
    {
        public long? PlantPrice { get; set; }
        public long? DeprotPrice { get; set; }
        public long? DeemedPrice { get; set; }
    }
    public partial class LocationView
    {
        public long value { get; set; }
        public string display { get; set; }
      
    }
    public partial class ProductView
    {
        public string value { get; set; }
        public string display { get; set; }
    }
    public partial class ProductOptionView
    {
        public List<LocationView> location { get; set; }
        public List<LocationView> locationForDepot { get; set; }
        public List<ProductView> product { get; set; }
        public List<Favriote> Favriote { get; set; }
    }

}
