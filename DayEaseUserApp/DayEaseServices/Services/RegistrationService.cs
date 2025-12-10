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

public class RegistrationService (IApiService _apiservice): IRegistration
{

    public async Task<string> PostAsync(MobileNumberRequest model)=> await _apiservice.PostAsync<MobileNumberRequest, string>("User/OTPInitiate", model);

    public async Task<string> ResendOtp(MobileNumberRequest model) => await _apiservice.PostAsync<MobileNumberRequest, string>("User/OTPResend", model);

    public async Task<string> RegisterUserAsync(UserModel userModel)=> await _apiservice.PostAsync<UserModel, string>("User/Register", userModel);

    public async Task<List<StateModel>> GetStatesAsync()
    => (await _apiservice.PostAsync<object, StateResponse>("States", null))?.Data
       ?? new List<StateModel>();

    public async Task<List<CityModel>> GetCityAsync(CityModel cityModel)
        => await _apiservice.PostAsync<CityModel, List<CityModel>>("Cities/GetCitiesBYStateId", cityModel)
           ?? new List<CityModel>();

    public async Task<List<AreaModel>> GetAreaByCityId(AreaModel model)
        => await _apiservice.PostAsync<AreaModel, List<AreaModel>>("Area/GetAreaByCityId", model)
           ?? new List<AreaModel>();

    public async Task<List<SubAreaModel>> GetSubAreaByAreaId(SubAreaModel model)
        => await _apiservice.PostAsync<SubAreaModel, List<SubAreaModel>>("SubArea/GetSubAreaByAreaId", model)
           ?? new List<SubAreaModel>();

    public async Task<string> ValidateOtp(OtpVerificationRequest model)
        => await _apiservice.PostAsync<OtpVerificationRequest, string>("User/OTPValidate", model);

    public async Task<UserResponseModel> UpdateUser(UserProfileModel UserProfileModel)
     =>  await _apiservice.PostAsync<UserProfileModel, UserResponseModel>("User/UpdateUser", UserProfileModel);

    public async Task<UserOtpResponseModel> ForgotPassword(ForgotPasswordModel model)
        => await _apiservice.PostAsync<ForgotPasswordModel, UserOtpResponseModel>("User/ForgotPassword", model);

}