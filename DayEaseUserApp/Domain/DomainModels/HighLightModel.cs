using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DomainModels
{
    public class HighLightModel
    {
        public string StoreId { get; set; }
        public string StoreName { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public double DistanceInKm { get; set; }
        public List<string> DailyOffers { get; set; }
        public string SpecialOffer { get; set; }

        public List<ProductModel> Products { get; set; }
    }
}
