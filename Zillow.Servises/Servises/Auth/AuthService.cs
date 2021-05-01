using Zillow.Core.Dto;
using Zillow.Core.Exceptions;
using Zillow.Core.ViewModel;
using Zillow.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Zillow.Service.Services.Auth
{
    public class AuthService : IAuthService
    {
        private ApplicationDbContext _DB;
        private SignInManager<Zillow.Data.Models.User> _signInManager;

        public AuthService(ApplicationDbContext DB, SignInManager<Zillow.Data.Models.User> signInManager)
        {
            _DB = DB;
            _signInManager = signInManager;
        }


        public async Task SaveFcmToken(string fcm,string userId)
        {
            var user = await _DB.Users.SingleOrDefaultAsync(x => x.Id == userId && !x.IsDelete);
           user.FCMToken = fcm;
            _DB.Users.Update(user);
            await _DB.SaveChangesAsync();
        }

        public async Task<LoginResponseViewModel> LoginAsync(LoginDto dto)
        {
            var user = _DB.Users.SingleOrDefault(x => x.UserName == dto.Username && !x.IsDelete);

            if (user == null)
            {
                throw new InvalidUsernameException();
            }

            var result = await _signInManager.CheckPasswordSignInAsync(user, dto.Password, false);

            if (result.Succeeded)
            {
               user.FCMToken = dto.FCM;

                _DB.Users.Update(user);
                _DB.SaveChanges();

                var token = GenerateAccessToken(user);
                var response = new LoginResponseViewModel();
                response.Token = token;
                response.User = new UserViewModel()
                {
                    Id = user.Id,
                    Email = user.Email,
                    PhoneNumber = user.PhoneNumber,
                    DOB = user.DOB,
                    FirstName = user.FirstName,
                    LastName = user.LastName
                };
                return response;
            }
            return null;
        }
        private TokenViewModel GenerateAccessToken(Zillow.Data.Models.User user)
        {
            var claims = new List<Claim>(){
              new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
              new Claim("UserId", user.Id),
              new Claim(JwtRegisteredClaimNames.Email, user.Email),
              new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
             };


            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("fjodsfjdlsfldskfjldskfjdsf"));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.Now.AddMonths(1);
            var accessToken = new JwtSecurityToken("https://localhost:44303/",
                "https://localhost:44303/",
                claims,
                expires: expires,
                signingCredentials: credentials
            );
            var AccessToken = new JwtSecurityTokenHandler().WriteToken(accessToken);
            var response = new TokenViewModel();
            response.AcessToken = AccessToken;
            response.ExpireAt = expires;
            return response;
        }
    }
}
