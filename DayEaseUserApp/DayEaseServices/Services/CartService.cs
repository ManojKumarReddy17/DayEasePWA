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

            Console.WriteLine("Fetched Cart Items: " + (response?.Count ?? 0));

            return response;
        }
        public async Task<MysqlResponse<int>> AddCartItems(CartModel model)
        {
            string endpoint = "Cart/AddCartItem";
            var response = await _apiservice.PostAsync<CartModel, MysqlResponse<int>>(endpoint, model);

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

        public async Task<List<GuestCartItem>> GetGuestCartItemsAsync(CartModel request)
        {
            return await _apiservice.PostAsync<CartModel, List<GuestCartItem>>("Cart/GetGuestCartItems", request);
        }

        public async Task<MysqlResponse<int>> AddGuestCartItemAsync(CartModel model)
        {
            return await _apiservice.PostAsync<CartModel, MysqlResponse<int>>("Cart/AddGuestCartItem", model);
        }

        public async Task<MysqlResponse<int>> UpdateGuestCartItemQuantityAsync(CartModel model)
        {
            return await _apiservice.PostAsync<CartModel, MysqlResponse<int>>("Cart/UpdateGuestCartItemQuantity", model);
        }

        public async Task<MysqlResponse<int>> RemoveGuestCartItemAsync(CartModel model)
        {
            return await _apiservice.PostAsync<CartModel, MysqlResponse<int>>("Cart/DeleteGuestCartItem", model);
        }

        // ----------------- LOAD CART -----------------

        public async Task LoadCartItemCountAsync(CartModel model)
        {
            _cart.Clear();

            if (!string.IsNullOrEmpty(model.GuestUserId))
            {
                var guestCarts = await GetGuestCartItemsAsync(model);
                foreach (var item in guestCarts)
                {
                    if (!string.IsNullOrEmpty(item.ProductId))
                    {
                        _cart[item.ProductId] = (item.Quantity, item.ProductName);
                    }
                }
            }
            else if (!string.IsNullOrEmpty(model.UserId))
            {
                var userCarts = await GetCartItemsByUserId(model);
                foreach (var item in userCarts)
                {
                    if (!string.IsNullOrEmpty(item.ProductId))
                    {
                        _cart[item.ProductId] = (item.Quantity, item.ProductName);
                    }
                }
            }

            OnChange?.Invoke();
        }


        public void AddToCart(string productId, string productName, int quantity = 1)
        {
            if (_cart.ContainsKey(productId))
                _cart[productId] = (_cart[productId].quantity + quantity, productName);
            else
                _cart[productId] = (quantity, productName);

            OnChange?.Invoke();
        }

        public void IncreaseQuantity(string productId)
        {
            if (_cart.ContainsKey(productId))
            {
                _cart[productId] = (_cart[productId].quantity + 1, _cart[productId].name);
                OnChange?.Invoke();
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

                OnChange?.Invoke();
            }
        }
        public void RemoveFromCart(string productId)
        {
            if (_cart.ContainsKey(productId))
            {
                _cart.Remove(productId);
                OnChange?.Invoke();
            }
        }

        public void ClearCart()
        {
            _cart.Clear();
            OnChange?.Invoke();
        }
        public async Task<MysqlResponse<int>> MigrateCartAsync(string guestId, string userId)
        {
            var payload = new CartModel
            {
                GuestUserId = guestId,
                UserId = userId
            };

            return await _apiservice.PostAsync<CartModel, MysqlResponse<int>>("Cart/MigrateGuestCart", payload);

        }
    }

    //    public async Task LoadCartItemCountAsync(CartModel model)
    //    {
    //        var items = await GetCartItemsByUserId(model);
    //        _cart.Clear();

    //        foreach (var item in items)
    //        {
    //            _cart[item.ProductId.ToString()] = (item.Quantity, item.ProductName);
    //        }

    //        OnChange?.Invoke();
    //    }
    //    public void AddToCart(string productId, string productName, int quantity = 1)
    //    {
    //        if (_cart.ContainsKey(productId))
    //            _cart[productId] = (_cart[productId].quantity + quantity, productName);
    //        else
    //            _cart[productId] = (quantity, productName);


    //    }

    //    public void IncreaseQuantity(string productId)
    //    {
    //        if (_cart.ContainsKey(productId))
    //        {
    //            _cart[productId] = (_cart[productId].quantity + 1, _cart[productId].name);

    //        }
    //    }

    //    public void DecreaseQuantity(string productId)
    //    {
    //        if (_cart.ContainsKey(productId))
    //        {
    //            var newQty = _cart[productId].quantity - 1;
    //            if (newQty > 0)
    //                _cart[productId] = (newQty, _cart[productId].name);
    //            else
    //                _cart.Remove(productId);


    //        }
    //    }


    //}
}

