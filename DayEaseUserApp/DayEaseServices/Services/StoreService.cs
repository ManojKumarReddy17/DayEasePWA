using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DayEaseServices.Services.IServices;
using Domain.DomainModels;
using Domain.RequestModels;
using Domain.ResponseModels;
using Registration.IApiService;

namespace DayEaseServices.Services
{
    public class StoreService(IApiService _apiService) : IStoreService
    {

        public async Task<NearbyStoresResponse> GetNearbyStoresAsync(NearbyStoresRequest request)=> 
           await _apiService.PostAsync<NearbyStoresRequest, NearbyStoresResponse>("User/GetStoresbyDistance", request);

        public async Task<List<UserRecentOrders>> GetRecentOrdersForUserId(UserRecentOrderRequest recentOrderRequest)=>
              await _apiService.PostAsync<UserRecentOrderRequest, List<UserRecentOrders>>("Order/GetRecentOrdersByUserId", recentOrderRequest);

    }

}
