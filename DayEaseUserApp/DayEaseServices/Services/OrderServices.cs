using DayEaseServices.Services.IServices;
using Domain.DomainModels;
using Domain.RequestModels;
using Domain.Utilities;
using Registration.IApiService;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DayEaseServices.Services
{
    public class OrderServices : IOrderService
    {
        private readonly IApiService _apiService;

        public OrderServices(IApiService apiService)
        {
            _apiService = apiService;
        }

        public async  Task<string> CreateAsync<TRequest, TResponse>(OrderRequestModel model)
        {
            string endpoint = "Order/CreateOrderAsync";
            var result = await _apiService.PostAsync<OrderRequestModel, string>(endpoint, model);
            return result;
        }
        public async Task<OrderResponseModel> GetOrder<TRequest, TResponse>(GetOrderDetailsByIdRequestModel model)
        {
            string endpoint = "Order/GetOrderById";
            var result = await _apiService.PostAsync<GetOrderDetailsByIdRequestModel, OrderResponseModel>(endpoint, model);
            return result;
        }

        public async Task<OrderRequestModel> OrderDetailsbyUser<TRequest, TResponse>(OrderRequestModel model)
        {
            string endpoint = "Order/GetOrderDetailsByUserId";
 
            var result = await _apiService.PostAsync<OrderRequestModel, OrderRequestModel>(endpoint, model);
            return result;
        }

        public async Task<OrderStatusResponse> OrderStatus<TRequest, TResponse>(UpdateOrderStatusRequest model)
        {
            string endpoint = "Order/OrderStatus";
            var result = await _apiService.PostAsync<UpdateOrderStatusRequest, OrderStatusResponse>(endpoint, model);
            return result;
        }
    }
}
