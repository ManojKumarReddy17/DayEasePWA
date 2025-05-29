using System.Threading.Tasks;

namespace Registration.IApiService
{
    public interface IApiService
    {

        // Task<string> PostAsync<TRequest,TResponse>(string url, TRequest data);
        Task<TResponse> PostAsync<TRequest, TResponse>(string endpoint, TRequest request);
        Task<string> ValidateOtp<TRequest, TResponse>(string url, TRequest data);

        Task<string> UserRegister<TRequest, TResponse>(string url, TRequest data);

        //Task<string> States<TRequest, TResponse>(string url, TRequest data);
       
    }
}

