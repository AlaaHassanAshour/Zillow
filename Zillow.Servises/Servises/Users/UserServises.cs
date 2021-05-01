using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zillow.Core.DTO;
using Zillow.Core.ViweModel;
using Zillow.Data;

namespace Zillow.Servises.Servises.Users
{
   public class UserServises: IUserServises
    {

        private ApplicationDbContext _DB;
        private UserManager<Zillow.Data.Models.User> _userManager;

        public UserServises(ApplicationDbContext DB, UserManager<Zillow.Data.Models.User> userManager)
        {
            _DB = DB;
            _userManager = userManager;
        }
        public List<UserVM> GetAll()
        {
            var user = _DB.Users.Where(x => !x.IsDelete).Select(x => new UserVM()
            {

                Id = x.Id,
                DOB = x.DOB,
                Email = x.Email,
                FirstName = x.FirstName,
                LastName = x.LastName,
                PhoneNumber = x.PhoneNumber,
            }).ToList();
            return user;
        }
        public async Task<bool> Create(CraeteUserDTO dto)
        {
            
                var user = new Zillow.Data.Models.User();
                user.FirstName = dto.FirstName;
                user.LastName = dto.LastName;
                user.DOB = dto.DOB;
                user.PhoneNumber = dto.PhoneNumber;
                user.UserName = dto.PhoneNumber;
                var result = await _userManager.CreateAsync(user, "Alaa99$$");
                return result.Succeeded;
        }
        
            public async Task Update(UpdateUserDTO dto)
            {
                var user = _DB.Users.SingleOrDefault(x => x.Id == dto.Id && !x.IsDelete);
                user.FirstName = dto.FirstName;
                user.LastName = dto.LastName;
                user.Email = dto.Email;
                user.DOB = dto.DOB;

                await _userManager.UpdateAsync(user);
            }
        public void Delete(string id)
        {
            var user = _DB.Users.SingleOrDefault(x => x.Id == id && !x.IsDelete);
            user.IsDelete = true;
            _DB.Users.Update(user);
            _DB.SaveChanges();

        }
    }
}
