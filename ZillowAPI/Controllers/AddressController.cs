using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Zillow.Core.DTO;
using Zillow.Servises.Servises.Address;

namespace ZillowAPI.Controllers
{
    public class AddressController : BaseController
    {
        private IAddressServises _IAddressServises;
        public AddressController(IAddressServises IAddressServises)
        {
            _IAddressServises = IAddressServises;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var addresses = _IAddressServises.GetAll();
            return Ok(GetRespons(addresses, "Done"));
        }
        [HttpPost]
        public IActionResult Create([FromBody]CreateAddressDTO dto)
        {
       _IAddressServises.Create(dto);
            return Ok(GetRespons(dto, "success"));

        }
        [HttpPut]
        public IActionResult Update([FromBody] UpdateAddressDTO dto)
        {
            _IAddressServises.Update(dto);
            return Ok(GetRespons(dto, "Done"));
        
        }
        
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            _IAddressServises.Delete(id);
            return Ok(GetRespons( null, "Done"));
        }
    }
}
