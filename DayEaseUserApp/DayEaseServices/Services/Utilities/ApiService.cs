using Domain.RequestModels;
using Microsoft.Extensions.Options;
using Registration.IApiService;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

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
            var jsonContent = new StringContent(JsonSerializer.Serialize(request), Encoding.UTF8, "application/json");

            var response = await _httpclient.PostAsync($"{_settings.DayEase_API}/{endpoint}", jsonContent);
            response.EnsureSuccessStatusCode();

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


