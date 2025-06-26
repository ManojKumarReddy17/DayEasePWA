using DayEaseServices.Services.IServices;
using Domain.RequestModels;
using Domain.ResponseModels;
using Registration.IApiService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DayEaseServices.Services
{
    public class CartService: ICartService
    {
        private readonly IApiService _apiservice;
        public event Action OnChange;

        private readonly Dictionary<string, (int quantity, string name)> _cart = new();

        public Dictionary<string, (int quantity, string name)> CartItems => _cart;

        public int CartItemCount => _cart.Values.Sum(x => x.quantity);

        public CartService(IApiService apiservice)
        {
            _apiservice = apiservice;
        }


        public async Task<List<CartModel>> GetCartItemsByUserId(CartModel model)
        {
            string endpoint = "Cart/GetCartItemsByUserId";
            var response = await _apiservice.PostAsync<CartModel, List<CartModel>>(endpoint, model);

            return response;
        }

        public async Task<MysqlResponse<int>> UpdateCartItems(CartModel model)
        {
            string endpoint = "Cart/UpdateCartItemQuantity";
            var response = await _apiservice.PostAsync<CartModel, MysqlResponse<int>>(endpoint, model);

            return response;
        }
        public async Task<MysqlResponse<int>> RemoveCartItems(CartModel model)
        {
            string endpoint = "Cart/DeleteCartItem";
            var response = await _apiservice.PostAsync<CartModel, MysqlResponse<int>>(endpoint, model);

            return response;
        }
        public void AddToCart(string productId, string productName, int quantity = 1)
        {
            if (_cart.ContainsKey(productId))
                _cart[productId] = (_cart[productId].quantity + quantity, productName);
            else
                _cart[productId] = (quantity, productName);

            NotifyStateChanged();
        }

        public void IncreaseQuantity(string productId)
        {
            if (_cart.ContainsKey(productId))
            {
                _cart[productId] = (_cart[productId].quantity + 1, _cart[productId].name);
                NotifyStateChanged();
            }
        }

        public void DecreaseQuantity(string productId)
        {
            if (_cart.ContainsKey(productId))
            {
                var newQty = _cart[productId].quantity - 1;
                if (newQty > 0)
                    _cart[productId] = (newQty, _cart[productId].name);
                else
                    _cart.Remove(productId);

                NotifyStateChanged();
            }
        }

        public void ClearCart()
        {
            _cart.Clear();
            NotifyStateChanged();
        }

        private void NotifyStateChanged() => OnChange?.Invoke();
    }
}

