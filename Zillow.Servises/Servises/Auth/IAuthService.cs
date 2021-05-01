using Zillow.Core.Dto;
using Zillow.Core.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Zillow.Service.Services.Auth
{
    public interface IAuthService
    {
        Task<LoginResponseViewModel> LoginAsync(LoginDto dto);

        Task SaveFcmToken(string fcm, string userId);


    }
}
