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
        Task<string> PostAsync<TRequest,TResponse>(RegistrationRequest model);
        Task<string> ValidateOtp<TRequest, TRespnse>(OtpVerificationRequest model);
        Task<List<StateModel>> GetStatesAsync();
        Task<List<CityModel>> GetCityAsync(CityModel StateId);
        Task<List<AreaModel>> GetAreaByCityId(AreaModel cityModel);
        Task<List<SubAreaModel>> GetSubAreaByAreaId(SubAreaModel areaModel);

        Task<string> RegisterUserAsync(UserModel userModel);
    }

}
