using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.JSInterop;
using System;
using System.Globalization;
using System.Security.Claims;
using System.Threading.Tasks;

namespace DayEaseServices.Services
{
    /// <summary>
    /// Single source of truth for User / Guest identity and location.
    /// </summary>
    public sealed class UserLocationManager
    {
        private readonly IJSRuntime _js;
        private readonly AuthenticationStateProvider _authProvider;
        private readonly Blazored.LocalStorage.ILocalStorageService _localStorage;

        private const string GuestUserIdKey = "guestUserId";
        private const string LatitudeKey = "latitude";
        private const string LongitudeKey = "longitude";
        

        private bool _isInitialized;

        public string? UserId { get; private set; }
        public string? GuestUserId { get; private set; }

        public double Latitude { get; private set; }
        public double Longitude { get; private set; }

        public bool IsGuestUser => string.IsNullOrWhiteSpace(UserId);

       
        public UserLocationManager(
            IJSRuntime js,
            AuthenticationStateProvider authProvider,
            Blazored.LocalStorage.ILocalStorageService localStorage)
        {
            _js = js;
            _authProvider = authProvider;
            _localStorage = localStorage;

            _authProvider.AuthenticationStateChanged += OnAuthStateChanged;
        }

        private async void OnAuthStateChanged(Task<AuthenticationState> task)
        {
            var authState = await task;
            var user = authState.User;

            _isInitialized = false; // 🔑 allow re-init

            if (user.Identity?.IsAuthenticated == true)
            {
                await InitializeLoggedInUserAsync(user);
            }
            else
            {
                await InitializeGuestUserAsync();
            }

            _isInitialized = true;
        }

        /// <summary>
        /// Initialize identity + location.
        /// SAFE to call multiple times.
        /// </summary>
        public async Task InitializeAsync()
        {
            if (_isInitialized) return;

            var authState = await _authProvider.GetAuthenticationStateAsync();
            var user = authState.User;

            if (user.Identity?.IsAuthenticated == true)
            {
                await InitializeLoggedInUserAsync(user);
            }
            else
            {
                await InitializeGuestUserAsync();
            }

            _isInitialized = true;
        }


        /// <summary>
        /// Set location for logged-in user after login
        /// </summary>
        public void SetLoggedInUserLocation(string userId, double latitude, double longitude)
        {
            UserId = userId;
            Latitude = latitude;
            Longitude = longitude;
            _isInitialized = true;
        }

        /// <summary>
        /// Clear guest session on login
        /// </summary>
        public async Task ClearGuestSessionAsync()
        {
            await _js.InvokeVoidAsync("window.sessionStore.remove", GuestUserIdKey);
            await _js.InvokeVoidAsync("window.sessionStore.remove", LatitudeKey);
            await _js.InvokeVoidAsync("window.sessionStore.remove", LongitudeKey);
            GuestUserId = null;
        }

        /// <summary>
        /// Ensure guest location exists (used when logging in as guest)
        /// </summary>
        public async Task EnsureGuestLocationAsync()
        {
            await InitializeGuestUserAsync();
        }

        // =========================
        // PRIVATE INITIALIZERS
        // =========================

        private async Task InitializeLoggedInUserAsync(ClaimsPrincipal user)
        {
            UserId =
                user.FindFirst(ClaimTypes.NameIdentifier)?.Value
                ?? user.FindFirst("userId")?.Value
                ?? user.FindFirst("UserId")?.Value
                ?? await _localStorage.GetItemAsync<string>("userId"); // 🔥 fallback

            Latitude = ParseDouble(user.FindFirst("Latitude")?.Value);
            Longitude = ParseDouble(user.FindFirst("Longitude")?.Value);

            if (Latitude == 0 || Longitude == 0)
                await FetchAndStoreBrowserLocationAsync();

            await ClearGuestSessionAsync();
        }

        private async Task InitializeGuestUserAsync()
        {
            UserId = null;
            GuestUserId = await GetOrCreateGuestIdAsync();

            Latitude = await GetOrFetchCoordinateAsync(LatitudeKey);
            Longitude = await GetOrFetchCoordinateAsync(LongitudeKey);
        }

        private async Task<string> GetOrCreateGuestIdAsync()
        {
            var guestId = await _js.InvokeAsync<string>("window.sessionStore.get", GuestUserIdKey);

            if (string.IsNullOrWhiteSpace(guestId))
            {
                guestId = Guid.NewGuid().ToString();
                await _js.InvokeVoidAsync("window.sessionStore.set", GuestUserIdKey, guestId);
            }

            return guestId;
        }

        private async Task<double> GetOrFetchCoordinateAsync(string key)
        {
            var stored = await _js.InvokeAsync<string>("window.sessionStore.get", key);

            if (double.TryParse(stored, NumberStyles.Any, CultureInfo.InvariantCulture, out var value))
                return value;

            return await FetchAndStoreBrowserLocationAsync(key);
        }

        private async Task<double> FetchAndStoreBrowserLocationAsync(string? returnKey = null)
        {
            try
            {
                var pos = await _js.InvokeAsync<GeoCoordinates>("window.geoLocation.getCurrentLocation");

                Latitude = pos.latitude;
                Longitude = pos.longitude;

                await _js.InvokeVoidAsync("window.sessionStore.set", LatitudeKey, Latitude.ToString(CultureInfo.InvariantCulture));
                await _js.InvokeVoidAsync("window.sessionStore.set", LongitudeKey, Longitude.ToString(CultureInfo.InvariantCulture));

                if (returnKey == LatitudeKey) return Latitude;
                if (returnKey == LongitudeKey) return Longitude;

                return 0;
            }
            catch
            {
                // Fallback to default coordinates (optional)
                Latitude = 0;
                Longitude = 0;
                return 0;
            }
        }

        private static double ParseDouble(string? value)
        {
            return double.TryParse(value, NumberStyles.Any, CultureInfo.InvariantCulture, out var result) ? result : 0;
        }
        public void Reset()
        {
            _isInitialized = false;
        }

        private class GeoCoordinates
        {
            public double latitude { get; set; }
            public double longitude { get; set; }
        }
    }
}
