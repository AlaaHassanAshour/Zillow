using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Zillow.Core.DTO;
using Zillow.Servises.Servises.Address;
using Zillow.Servises.Servises.Users;

namespace ZillowAPI.Controllers
{
    public class UserController : BaseController
    {
        private IUserServises _UserServises;
        public UserController(IUserServises UserServises)
        {
            _UserServises = UserServises;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var users = _UserServises.GetAll();
            return Ok(GetRespons(users));
        }
        [AllowAnonymous]
        [HttpPost]
        public async Task< IActionResult> Create([FromBody]CraeteUserDTO dto)
        {
           await   _UserServises.Create(dto);
            return Ok(GetRespons(dto, "success"));

        }
        [HttpPut]
        public IActionResult Update([FromBody] UpdateUserDTO dto)
        {
            _UserServises.Update(dto);
            return Ok(GetRespons(dto, "Done"));
        
        }
        
        [HttpDelete]
        public IActionResult Delete(string id)
        {
            _UserServises.Delete(id);
            return Ok(GetRespons( null, "Done"));
        }
    }
}
