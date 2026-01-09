using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.RequestModels
{
    public class CartState
    {
        public List<CartModel> CartItems { get; set; } = new();
        public string UserId { get; set; }
        public string StoreId { get; set; }
       public decimal TotalAmount 
        { 
            get 
            {
                return CartItems.Sum(item => item.Price * item.Quantity);
            }
        }

        public void ClearCart()
        {
            CartItems.Clear();
        }
    }
}
