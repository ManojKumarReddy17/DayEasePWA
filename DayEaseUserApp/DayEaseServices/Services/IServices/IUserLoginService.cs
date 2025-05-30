using Domain.DomainModels;
using Domain.RequestModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DayEaseServices.Services.IServices
{
    public interface IUserLoginService
    {
        Task<UserLoginResponse> PostAsync(UserLoginRequest request);
        Task LogoutAsync();
        Task<UserLoginResponse> RefreshTokenAsync();
    }
}
