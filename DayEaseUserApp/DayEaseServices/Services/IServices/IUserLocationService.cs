using Domain.RequestModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DayEaseServices.Services.IServices
{
    public interface IUserLocationService
    {
        Task<UserLocationState> GetUserLocationAsync();

    }
}
