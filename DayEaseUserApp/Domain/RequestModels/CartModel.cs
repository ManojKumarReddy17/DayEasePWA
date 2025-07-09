using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.RequestModels
{
    public class CartModel
    {
        
        public string UserId { get; set; }


        public string CartItemId { get; set; }

        public string StoreId { get; set; }


        public string ProductId { get; set; }


        public int Quantity { get; set; }


        public DateTime CreateDate { get; set; }


        public DateTime UpdatedDate { get; set; }

        // Enriched fields

        public string ProductName { get; set; }

        public string ProductImage { get; set; }


        public decimal Price { get; set; }


        public decimal Discount { get; set; }


        public decimal TotalPrice { get; set; }


        public decimal NetPrice { get; set; }

        public string Variant { get; set; } // <-- USE THIS if it's defined
    }
}
