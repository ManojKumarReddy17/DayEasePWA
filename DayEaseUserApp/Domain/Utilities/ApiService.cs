using Amazon.Runtime.Internal;
using Domain.RequestModels;
using Domain.ResponseModels;
using Microsoft.Extensions.Options;
using Registration.IApiService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Domain.Utilities
{
    public class ApiService : IApiService
    {
        private readonly ApiSettings _settings;
        private readonly HttpClient _httpclient;

        public ApiService(IOptions<ApiSettings> settings, HttpClient httpclient)
        {
            _settings = settings.Value;
            _httpclient = httpclient;
        }
        public async Task<TResponse> PostAsync<TRequest, TResponse>(string endpoint, TRequest request)
        {
            var jsonContent = new StringContent(
                System.Text.Json.JsonSerializer.Serialize(request),
                System.Text.Encoding.UTF8,
                "application/json");

            var response = await _httpclient.PostAsync($"{_settings.DayEase_API}/{endpoint}", jsonContent);
            response.EnsureSuccessStatusCode();

            var jsonString = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<TResponse>(jsonString);
        }


        public async Task<string> UserRegister<TRequest, TResponse>(string url, TRequest request)
        {
            var jsonContent = new StringContent(
                JsonSerializer.Serialize(request),
                Encoding.UTF8,
                "application/json");

            var response = await _httpclient.PostAsync($"{_settings.DayEase_API}/{url}", jsonContent);
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsStringAsync();
        }

        public async Task<string> ValidateOtp<TRequest, TResponse>(string url, TRequest request)
        {
            var jsonContent = new StringContent(
                JsonSerializer.Serialize(request),
                Encoding.UTF8,
                "application/json");

            var response = await _httpclient.PostAsync($"{_settings.DayEase_API}/{url}", jsonContent);
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsStringAsync();
        }
  public async Task<string> ForgotPassword<TRequest, TResponse>(string url, TRequest request)
        {
            var jsonContent = new StringContent(
               JsonSerializer.Serialize(request),
               Encoding.UTF8,
               "application/json");

            var response = await _httpclient.PostAsync($"{_settings.DayEase_API}/{url}", jsonContent);
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsStringAsync();
        }

        public async Task<TResponse> Post<TRequest, TResponse>(string endpoint, TRequest request)
        {
            var jsonContent = new StringContent(JsonSerializer.Serialize(request), Encoding.UTF8, "application/json");
            var response = await _httpclient.PostAsync($"{_settings.DayEase_API}{endpoint}", jsonContent);
            var jsonString = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<TResponse>(jsonString);
        }

        public async Task<TResponse> PostWithoutAuthAsync<TRequest, TResponse>(string endpoint, TRequest request)
        {
            var jsonContent = new StringContent(JsonSerializer.Serialize(request), Encoding.UTF8, "application/json");
            var httpRequest = new HttpRequestMessage(HttpMethod.Post, $"{_settings.DayEase_API}{endpoint}")
            {
                Content = jsonContent
            };
            httpRequest.Headers.Authorization = null;
            var response = await _httpclient.SendAsync(httpRequest);
            response.EnsureSuccessStatusCode();
            var jsonString = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<TResponse>(jsonString);
        }

        public void SetAuthorizationHeader(string token)
        {
            _httpclient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        }

        public void RemoveAuthorizationHeader()
        {
            _httpclient.DefaultRequestHeaders.Authorization = null;
        }

       
    }
}


