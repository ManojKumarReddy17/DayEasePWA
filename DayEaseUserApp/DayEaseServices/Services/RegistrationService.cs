using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using DayEaseServices.Services.IServices;
using Domain.DomainModels;
using Domain.RequestModels;
using Domain.Utilities;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Registration.IApiService;

public class RegistrationService : IRegistration
{
   
    private readonly IApiService _apiservice;
    public RegistrationService(IApiService apiservice)
    {
        _apiservice = apiservice;
    }

    public async Task<string> PostAsync<TRequest, TRespnse>(MobileNumberRequest model)
    {
        string endpoint = "User/OTPInitiate";
        var result = await _apiservice.PostAsync<MobileNumberRequest, string>(endpoint, model);
        return result;
    }

    public async Task<string> RegisterUserAsync(UserModel userModel)
    {
        string endpoint = "User/Register";
        var response = await _apiservice.PostAsync<UserModel, string>(endpoint, userModel);
        return response;
    }


    public async Task<List<StateModel>> GetStatesAsync()
    {
        string endpoint = "States";
        // If no request body is needed, you can send default or an empty object
        var result = await _apiservice.PostAsync<object, StateResponse>(endpoint, null);
        return result?.Data ?? new List<StateModel>();
    }
   
    public async Task<List<CityModel>> GetCityAsync(CityModel cityModel)
    {
        string endpoint = "Cities/GetCitiesBYStateId";
        var result = await _apiservice.PostAsync<CityModel, List<CityModel>>(endpoint, cityModel);
        return result ?? new List<CityModel>();
    }
    public async Task<List<AreaModel>> GetAreaByCityId(AreaModel cityModel)
    {
        string endpoint = "Area/GetAreaByCityId";
        var result = await _apiservice.PostAsync<AreaModel, List<AreaModel>>(endpoint, cityModel);
        return result ?? new List<AreaModel>();
    }
    public async Task<List<SubAreaModel>> GetSubAreaByAreaId(SubAreaModel areaModel)
    {
        string endpoint = "SubArea/GetSubAreaByAreaId";
        var result = await _apiservice.PostAsync<SubAreaModel, List<SubAreaModel>>(endpoint, areaModel);
        return result ?? new List<SubAreaModel>();
    }

  

    public async Task<string> ValidateOtp<TRequest, TRespnse>(OtpVerificationRequest model)
    {
        string endpoint = "User/OTPValidate";
        var result = await _apiservice.ValidateOtp<OtpVerificationRequest, string>(endpoint, model);
        return result;
    }
    public async Task<UserResponseModel> UpdateUser(UserModel userModel)
    {
        userModel.Password = "wertyu";
        string endpoint = "User/UpdateUser";
        var response = await _apiservice.PostAsync<UserModel, UserResponseModel>(endpoint, userModel);
        return response;
    }
    public async Task<string> ForgotPassword<TRequest, TResponse>(ForgotPasswordModel model)
    {
        string endpoint = "User/ForgotPassword";
        var result = await _apiservice.ValidateOtp<ForgotPasswordModel, string>(endpoint, model);
        return result;
    }
}