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
       
        Task<PlaceOrderResponseModel> CreateAsync(OrderRequestModel model);
        Task<OrderResponseModel> GetOrder(GetOrderDetailsByIdRequestModel model);
        
        Task<List<OrderRequestModel>> OrderDetailsbyUser(OrderRequestModel model);
        Task<OrderStatusResponse> OrderStatus(UpdateOrderStatusRequest model);
    }

}
