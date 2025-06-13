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
        public List<StoreWithProductsModel> Stores { get; set; }

    }
    public class ProductModel
    {
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductDesc { get; set; }
        public double Price { get; set; }
        public double Discount { get; set; }
        public string ProductImg { get; set; }
    }

    public class StoreWithProductsModel
    {
        public string StoreId { get; set; }
        public string StoreName { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public double Distance { get; set; }
        public List<ProductModel> Products { get; set; }
    }
}
