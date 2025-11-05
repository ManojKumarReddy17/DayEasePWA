using Blazored.LocalStorage;
using Domain.RequestModels;
using Microsoft.AspNetCore.Components.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;


namespace DayEaseServices.Services
{
    public class CustomAuthStateProvider(ILocalStorageService _localStorage, UserLocationState _userLocationState) : AuthenticationStateProvider
    {

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var savedToken = await _localStorage.GetItemAsync<string>("JwtToken");

            if (string.IsNullOrWhiteSpace(savedToken))
            {
                return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));
            }

            var identity = new ClaimsIdentity(ParseClaimsFromJwt(savedToken), "JwtToken");
            var user = new ClaimsPrincipal(identity);

            // ✅ Update shared state from claims
            SetUserLocationState(user);

            return new AuthenticationState(user);
            //return new AuthenticationState(new ClaimsPrincipal(identity));
        }
        public void NotifyUserAuthentication(string token)
        {
            var identity = new ClaimsIdentity(ParseClaimsFromJwt(token), "JwtToken");
            var user = new ClaimsPrincipal(identity);

            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(user)));
        }

        public void NotifyUserLogout()
        {
            var anonymousUser = new ClaimsPrincipal(new ClaimsIdentity());
            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(anonymousUser)));
        }

        private void SetUserLocationState(ClaimsPrincipal user)
        {
            var userIdClaim = user.FindFirst("nameid")?.Value;
            var areaIdClaim = user.FindFirst("Location")?.Value;
            var latitudeClaim = user.FindFirst("Latitude")?.Value?.Trim();
            var longitudeClaim = user.FindFirst("Longitude")?.Value?.Trim();

            if (!string.IsNullOrEmpty(userIdClaim))
            {
                _userLocationState.UserId = userIdClaim; // Since nameid looks like a string, keep it as string if needed
                _userLocationState.AreaId = areaIdClaim;
                _userLocationState.Latitude = latitudeClaim;
                _userLocationState.Longitude = longitudeClaim;
            }
        }


        private IEnumerable<Claim> ParseClaimsFromJwt(string jwt)
        {
            var payload = jwt.Split('.')[1];
            var jsonBytes = Convert.FromBase64String(payload.PadRight(payload.Length + (4 - payload.Length % 4) % 4, '='));
            var keyValuePairs = JsonSerializer.Deserialize<Dictionary<string, object>>(jsonBytes);

            return keyValuePairs.Select(kvp => new Claim(kvp.Key, kvp.Value.ToString()));
        }
    }
}
