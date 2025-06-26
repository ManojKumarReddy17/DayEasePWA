using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DomainModels
{
    public class OrderResponseModel
    {
        public string OrderId { get; set; }
        public string UserId { get; set; }
        public string StoreId { get; set; }
        //public string StoreName { get; set; }
        public string OrderStatus { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal RainCharges { get; set; }
        public decimal DeliveryCharges { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public List<OrderItemResponseModel> OrderItems { get; set; }
        public string Message { get; set; }

    }
    public class OrderItemResponseModel
    {
        public string OrderItemId { get; set; }
        public string OrderId { get; set; }
        public string ProductId { get; set; }
        //public string ProductName { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }
    }
}

