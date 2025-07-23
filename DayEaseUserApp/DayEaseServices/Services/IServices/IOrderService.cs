using Domain.DomainModels;
using Domain.RequestModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DayEaseServices.Services.IServices
{
    public interface IOrderService
    {
       
        Task<PlaceOrderResponseModel> CreateAsync<TRequest, TResponse>(OrderRequestModel model);
        Task<OrderResponseModel> GetOrder<TRequest, TResponse>(GetOrderDetailsByIdRequestModel model);
        
        Task<List<OrderRequestModel>> OrderDetailsbyUser<TRequest, TResponse>(OrderRequestModel model);
        Task<OrderStatusResponse> OrderStatus<TRequest,TResponse>(UpdateOrderStatusRequest model);
    }

}
