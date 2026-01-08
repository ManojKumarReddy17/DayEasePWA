using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using DayEaseServices.Services.IServices;
using Domain.RequestModels;
using Domain.ResponseModels;
using Microsoft.JSInterop;
using Registration.IApiService;

namespace DayEaseServices.Services
{
    public class CartService
    {
        private readonly IApiService _apiService;
        private readonly IJSRuntime _js;

        private readonly UserLocationManager _location;

        public CartService(IApiService apiService, IJSRuntime js, UserLocationManager location)
        {
            _apiService = apiService;
            _js = js;
            _location = location;
        }

        public event Action? OnCartChanged;

        public event Action? OnChange;

        public Dictionary<string, CartModel> CartItems { get; } = new();

        public int CartItemCount => CartItems.Values.Sum(x => x.Quantity);
        private string? _currentUserId;
        private bool _isDirty = false;

        private void RaiseCartEvents()
        {
            OnChange?.Invoke();
            OnCartChanged?.Invoke();
        }
        // =========================
        // RESTORE FROM SESSION
        // =========================

        public async Task RestoreAsync()
        {
            var json = await _js.InvokeAsync<string>("cartSession.load");

            if (string.IsNullOrWhiteSpace(json))
                return;

            var list = JsonSerializer.Deserialize<List<CartModel>>(json,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            if (list == null || list.Count == 0)
                return;

            CartItems.Clear();

            foreach (var item in list)
            {
                if (!string.IsNullOrWhiteSpace(item.ProductId))
                    CartItems[item.ProductId] = item;
            }

            RaiseCartEvents();
        }


        
        // =========================
        // SAVE TO SESSION
        // =========================
        private async Task PersistAsync()
        {
            var list = CartItems.Values.ToList();
            await _js.InvokeVoidAsync("cartSession.save", list);
        }

        // =========================
        // LOCAL CART OPERATIONS
        // =========================
        public async Task AddToCart(CartModel item)
        {
            if (CartItems.TryGetValue(item.ProductId, out var existing))
            {
                existing.Quantity += item.Quantity;
                existing.TotalPrice = existing.NetPrice * existing.Quantity;
            }
            else
            {
                CartItems[item.ProductId] = item;
            }

            _isDirty = true;

            await PersistAsync();
            RaiseCartEvents();
        }

        public async Task IncreaseQuantity(string productId)
        {
            if (!CartItems.TryGetValue(productId, out var item))
                return;

            item.Quantity++;
            item.TotalPrice = item.Price * item.Quantity;

            _isDirty = true;

            await PersistAsync();
            RaiseCartEvents();
        }

        public async Task DecreaseQuantity(string productId)
        {
            if (!CartItems.TryGetValue(productId, out var item))
                return;

            item.Quantity--;

            if (item.Quantity <= 0)
            {
                // remove product from cart
                CartItems.Remove(productId);
            }
            else
            {
                // update total when still > 0
                item.TotalPrice = item.Price * item.Quantity;
            }

            _isDirty = true;

            await PersistAsync();
            RaiseCartEvents();
        }


        // =========================
        // BACKEND: GET USER CART
        // =========================
        public async Task<List<CartModel>> GetCartItemsByUserIdAsync(string userId)
        {
            if (string.IsNullOrWhiteSpace(userId))
                return new();

            return await _apiService.PostAsync<CartModel, List<CartModel>>(
                "Cart/GetCartItemsByUserId",
                new CartModel { UserId = userId }
            );
        }

        // =========================
        // RESTORE FROM BACKEND ➜ SESSION
        // =========================
        public async Task RestoreFromBackendAsync(string userId)
        {
            var items = await GetCartItemsByUserIdAsync(userId);

            CartItems.Clear();

            foreach (var item in items)
                CartItems[item.ProductId] = item;

            _isDirty = true;
            await PersistAsync();
            RaiseCartEvents();
        }

        // =========================
        // CLEAR
        // =========================
        public async Task ClearCart()
        {
            CartItems.Clear();
            await _js.InvokeVoidAsync("cartSession.clear");
            OnChange?.Invoke();
        }

        // =========================
        // SAVE LOCAL CART -> DB
        // =========================
        public async Task SaveCartToDbAsync(string userId)
        {
            if (!_isDirty)
                return;
            if (string.IsNullOrWhiteSpace(userId))
                return;

            // Convert UI cart items to AddCartItemRequest
            var apiItems = CartItems.Values.Select(item => new CartModel
            {
                UserId = userId,
                StoreId = item.StoreId,
                ProductId = item.ProductId,
                Quantity = item.Quantity,
                Price = item.Price,
                Discount = item.Discount,
                NetPrice = item.NetPrice,
                TotalPrice = item.TotalPrice,
                ProductName = item.ProductName,
                ProductImage = item.ProductImage
            }).ToList();

            var request = new CartRequest
            {
                UserId = userId,
                cartItems = apiItems
            };

            await _apiService.PostAsync<CartRequest, MysqlResponse<int>>(
                "Cart/UserCart",
                request
            );
            _isDirty = false;
        }
        public async Task SyncCartToBackendAsync()
        {
            if (!_isDirty)
                return;

            var userId = _location.UserId;

            if (string.IsNullOrWhiteSpace(userId))
                return;

            await SaveCartToDbAsync(userId);

            _isDirty = false;
        }

        public async Task MigrateGuestCartAsync(string userId)
        {
            await SaveCartToDbAsync(userId);
            await ClearCart();
        }

        // =========================
        // JS SESSION END -> SAVE
        // =========================
        [JSInvokable]
        public async Task OnSessionEnd(string cartJson)
        {
            var items = JsonSerializer.Deserialize<List<CartModel>>(cartJson);

            if (items == null || items.Count == 0)
                return;

            var userId = items.FirstOrDefault()?.UserId;

            if (string.IsNullOrWhiteSpace(userId))
                return;

            var apiItems = items.Select(item => new CartModel
            {
                UserId = userId,
                StoreId = item.StoreId,
                ProductId = item.ProductId,
                Quantity = item.Quantity,
                Price = item.Price,
                Discount = item.Discount,
                NetPrice = item.NetPrice,
                TotalPrice = item.TotalPrice,
                ProductName = item.ProductName,
                ProductImage = item.ProductImage
            }).ToList();

            var request = new CartRequest
            {
                UserId = userId,
                cartItems = apiItems
            };

            await _apiService.PostAsync<CartRequest, MysqlResponse<int>>(
                "Cart/UserCart",
                request
            );
        }

    }

}




