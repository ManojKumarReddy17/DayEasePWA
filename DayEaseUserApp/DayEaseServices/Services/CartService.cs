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
    }
}
