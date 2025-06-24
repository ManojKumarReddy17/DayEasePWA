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

    }
}
