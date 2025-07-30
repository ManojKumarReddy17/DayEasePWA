using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.RequestModels;
using Microsoft.JSInterop;

namespace DayEaseServices.Services
{
    public class GuestUserService
    {
        private readonly IJSRuntime _js;
        private const string GuestUserIdKey = "guestUserId";
        private const string LatitudeKey = "latitude";
        private const string LongitudeKey = "longitude";

        public string UserId { get; set; }
        public string GuestUserId { get; private set; }
        public string Latitude { get; private set; }
        public string Longitude { get; private set; }

        public bool IsGuestUser => string.IsNullOrEmpty(UserId);

        public GuestUserService(IJSRuntime js)
        {
            _js = js;
        }

        public async Task EnsureLocationAsync(UserLocationState state)
        {
            if (!string.IsNullOrEmpty(UserId)) // Logged-in user
            {
                Latitude = state.Latitude;
                Longitude = state.Longitude;
                return;
            }

            // Guest user logic
            GuestUserId = await GetOrSetGuestIdAsync();
            Latitude = await GetOrFetchAsync(LatitudeKey);
            Longitude = await GetOrFetchAsync(LongitudeKey);
        }

        private async Task<string> GetOrSetGuestIdAsync()
        {
            var guestId = await _js.InvokeAsync<string>("window.sessionStore.get", GuestUserIdKey);

            if (string.IsNullOrWhiteSpace(guestId))
            {
                guestId = Guid.NewGuid().ToString();
                await _js.InvokeVoidAsync("window.sessionStore.set", GuestUserIdKey, guestId);
            }

            return guestId;
        }

        private async Task<string> GetOrFetchAsync(string key)
        {
            var value = await _js.InvokeAsync<string>("window.sessionStore.get", key);
            if (!string.IsNullOrWhiteSpace(value)) return value;

            var pos = await _js.InvokeAsync<GeoCoordinates>("window.geoLocation.getCurrentLocation");
            var coordinate = key == LatitudeKey ? pos.Latitude : pos.Longitude;

            await _js.InvokeVoidAsync("window.sessionStore.set", key, coordinate.ToString());
            return coordinate.ToString();
        }

        private class GeoCoordinates
        {
            public double Latitude { get; set; }
            public double Longitude { get; set; }
        }
    }
}
