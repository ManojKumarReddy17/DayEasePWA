using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.DomainModels;
using Microsoft.JSInterop;

namespace DayEaseServices.Services
{
    public class GeoLocationService
    {
        private readonly IJSRuntime _js;

        public GeoLocationService(IJSRuntime js)
        {
            _js = js;
        }

        public async Task<LocationModel> GetCurrentLocationAsync()
        {
            return await _js.InvokeAsync<LocationModel>(
                "geoLocation.getCurrentLocation");
        }
    }

}
