using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.DomainModels;
using Domain.RequestModels;
using Domain.ResponseModels;

namespace DayEaseServices.Services.IServices
{
    
        public interface IStoreService
        {
            Task<NearbyStoresResponse> GetNearbyStoresAsync(NearbyStoresRequest request);
            Task<List<UserRecentOrders>> GetRecentOrdersForUserId(UserRecentOrderRequest recentOrderRequest);
    }

    
}
