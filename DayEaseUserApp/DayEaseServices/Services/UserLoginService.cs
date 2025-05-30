using DayEaseServices.Services.IServices;
using Domain.DomainModels;
using Domain.RequestModels;
using Registration.IApiService;
using Blazored.LocalStorage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DayEaseServices.Services
{
    public class UserLoginService : IUserLoginService
    {
        private readonly IApiService _apiService;
        private readonly ILocalStorageService _localStorage;

        public UserLoginService(IApiService apiService, ILocalStorageService localStorage)
        {
            _apiService = apiService;
            _localStorage = localStorage;
        }

        public async Task<UserLoginResponse> PostAsync(UserLoginRequest request)
        {
            var response = await _apiService.PostAsync<UserLoginRequest, UserLoginResponse>("/User/Login", request);

            if (response != null && !string.IsNullOrEmpty(response.JwtToken))
            {
                await _localStorage.SetItemAsync("authToken", response.JwtToken);
                await _localStorage.SetItemAsync("refreshToken", response.RefreshToken);
                await _localStorage.SetItemAsync("userId", response.UserId);
                _apiService.SetAuthorizationHeader(response.JwtToken);
            }

            return response;
        }

        public async Task LogoutAsync()
        {
            await _localStorage.RemoveItemAsync("authToken");
            await _localStorage.RemoveItemAsync("refreshToken");
            await _localStorage.RemoveItemAsync("userId");
            _apiService.RemoveAuthorizationHeader();
        }

        public async Task<UserLoginResponse> RefreshTokenAsync()
        {
            var refreshToken = await _localStorage.GetItemAsync<string>("refreshToken");
            var userId = await _localStorage.GetItemAsync<string>("userId");

            if (string.IsNullOrEmpty(refreshToken) || string.IsNullOrEmpty(userId))
                return null;

            var request = new RefreshTokenRequest
            {
                UserId = userId,
                RefreshToken = refreshToken
            };

            var response = await _apiService.PostWithoutAuthAsync<RefreshTokenRequest, UserLoginResponse>("User/RefreshToken", request);

            if (response != null)
            {
                await _localStorage.SetItemAsync("authToken", response.JwtToken);
                await _localStorage.SetItemAsync("refreshToken", response.RefreshToken);
                await _localStorage.SetItemAsync("userId", response.UserId);
                _apiService.SetAuthorizationHeader(response.JwtToken);
            }

            return response;
        }
    }
}