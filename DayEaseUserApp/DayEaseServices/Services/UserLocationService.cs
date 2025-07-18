using DayEaseServices.Services.IServices;
using Domain.RequestModels;
using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;
using System.Threading.Tasks;

namespace DayEaseServices.Services
{
    public class UserLocationService : IUserLocationService
    {
        private readonly AuthenticationStateProvider _authProvider;

        public UserLocationService(AuthenticationStateProvider authProvider)
        {
            _authProvider = authProvider;
        }

        public async Task<UserLocationState> GetUserLocationAsync()
        {
            var authState = await _authProvider.GetAuthenticationStateAsync();
            var user = authState.User;
            var location = new UserLocationState();

            if (user.Identity != null && user.Identity.IsAuthenticated)
            {
                location.UserId = user.FindFirst("nameid")?.Value;
                location.AreaId = user.FindFirst("Location")?.Value;
                location.Latitude = user.FindFirst("Latitude")?.Value?.Trim();
                location.Longitude = user.FindFirst("Longitude")?.Value?.Trim();
            }

            return location;
        }
    }
}
