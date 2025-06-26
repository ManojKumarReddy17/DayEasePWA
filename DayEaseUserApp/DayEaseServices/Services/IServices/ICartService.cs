using Domain.RequestModels;
using Domain.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DayEaseServices.Services.IServices
{
    public interface ICartService
    {
        Task<List<CartModel>> GetCartItemsByUserId(CartModel model);
        Task<MysqlResponse<int>> UpdateCartItems(CartModel model);
        Task<MysqlResponse<int>> RemoveCartItems(CartModel model);

        event Action OnChange;

        int CartItemCount { get; }
        Dictionary<string, (int quantity, string name)> CartItems { get; }

        void AddToCart(string productId, string productName, int quantity = 1);
        void IncreaseQuantity(string productId);
        void DecreaseQuantity(string productId);
        void ClearCart();
    }
}
