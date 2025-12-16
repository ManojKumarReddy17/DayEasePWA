using Domain.DomainModels;
using Domain.RequestModels;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DayEaseServices.Services.IServices
{
    public interface IRegistration
    {
        Task<UserOtpResponseModel> PostAsync(MobileNumberRequest model);
        Task<UserOtpResponseModel> ValidateOtp(OtpVerificationRequest model);
        Task<UserOtpResponseModel> ResendOtp(MobileNumberRequest model);
        Task<List<StateModel>> GetStatesAsync();
        Task<List<CityModel>> GetCityAsync(CityModel StateId);
        Task<List<AreaModel>> GetAreaByCityId(AreaModel cityModel);
        Task<List<SubAreaModel>> GetSubAreaByAreaId(SubAreaModel areaModel);

        Task<UserResponseModel> RegisterUserAsync(UserModel userModel);
        Task<UserResponseModel> UpdateUser(UserProfileModel UserProfileModel);
        Task<UserOtpResponseModel>ForgotPassword(ForgotPasswordModel model);
    }

}
