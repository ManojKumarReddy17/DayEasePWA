using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DomainModels
{
    public class NearbyStoresResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; }

        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalStoresCount { get; set; }

        public bool HasNextPage { get; set; }
        public List<StoreWithProductsModel> Stores { get; set; }

    }
   

    public class StoreWithProductsModel
    {
        public string storeId { get; set; }
        public string storeName { get; set; }
        public double latitude { get; set; }
        public double longitude { get; set; }
        public string storeImage { get; set; }
        public double distance { get; set; }
    }
}
