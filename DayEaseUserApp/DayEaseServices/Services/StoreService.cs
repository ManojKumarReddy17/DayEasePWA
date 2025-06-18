using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DayEaseServices.Services.IServices;
using Domain.DomainModels;
using Domain.RequestModels;
using Registration.IApiService;

namespace DayEaseServices.Services
{
    public class StoreService : IStoreService
    {
        private readonly IApiService _apiService;

        public StoreService(IApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task<NearbyStoresResponse> GetNearbyStoresAsync(NearbyStoresRequest request)
        {
            
            var response = await _apiService.PostAsync<NearbyStoresRequest, NearbyStoresResponse>("User/GetStoresbyDistance", request);

            return response;
        }
    }

}
