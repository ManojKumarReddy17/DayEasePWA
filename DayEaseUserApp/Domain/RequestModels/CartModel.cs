using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.RequestModels
{
    public class CartModel
    {
        //public List<CartItem> Items { get; set; } = new();

        //public decimal TotalAmount => Items.Sum(i => i.Price * i.Quantity);

        //public decimal OriginalTotal => Items.Sum(i => i.OriginalPrice * i.Quantity);
        public string UserId { get; set; }

        public string StoreProductKey { get; set; }

        public string CartItemId { get; set; }

        public string StoreId { get; set; }


        public string ProductId { get; set; }


        public int Quantity { get; set; }


        public DateTime AddedAt { get; set; }


        public DateTime UpdatedAt { get; set; }

        // Enriched fields

        public string ProductName { get; set; }
        public string ProductImage { get; set; }


        public decimal Price { get; set; }


        public decimal Discount { get; set; }


        public decimal TotalPrice { get; set; }


        public decimal NetPrice { get; set; }
    }
}
