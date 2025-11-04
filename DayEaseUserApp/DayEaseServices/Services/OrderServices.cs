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
    public class OrderServices(IApiService _apiService) : IOrderService
    {

        public async Task<PlaceOrderResponseModel> CreateAsync(OrderRequestModel model)
    => await _apiService.PostAsync<OrderRequestModel, PlaceOrderResponseModel>
       ("Order/CreateOrderAsync", model);

        public async Task<OrderResponseModel> GetOrder(GetOrderDetailsByIdRequestModel model)
            => await _apiService.PostAsync<GetOrderDetailsByIdRequestModel, OrderResponseModel>
               ("Order/GetOrderById", model);

        public async Task<List<OrderRequestModel>> OrderDetailsbyUser(OrderRequestModel model)
            => await _apiService.PostAsync<OrderRequestModel, List<OrderRequestModel>>
               ("Order/GetOrderDetailsByUserId", model);

        public async Task<OrderStatusResponse> OrderStatus(UpdateOrderStatusRequest model)
            => await _apiService.PostAsync<UpdateOrderStatusRequest, OrderStatusResponse>
               ("Order/OrderStatus", model);

       
    }
}
