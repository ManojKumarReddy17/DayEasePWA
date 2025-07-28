using Amazon.DynamoDBv2.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.RequestModels
{

    public class OrderRequestModel
    {
        public string OrderId { get; set; }
        public string UserId { get; set; }
        public string StoreId { get; set; }
        public string? StoreName { get; set; }
        public string OrderStatus { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal RainCharges { get; set; }
        public decimal DeliveryCharges { get; set; }
        //public string PaymentMethod { get; set; } // Added this property to fix CS0117  
        //public string DeliveryAddress { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public List<OrderItemModel> OrderItems { get; set; }




    }


    public class OrderItemModel
    {
        public string OrderItemId { get; set; }
        public string OrderId { get; set; }
        public string ProductId { get; set; }
        public string? ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public string CartItemId { get; set; }
    }




}
