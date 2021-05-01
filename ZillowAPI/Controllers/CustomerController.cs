using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Zillow.Core.DTO;
using Zillow.Servises.Servises.Customer;

namespace ZillowAPI.Controllers
{
    public class CustomerController : BaseController
    {
        private ICustomerServises _ICustomerServises;
        public CustomerController(ICustomerServises ICustomerServises)
        {
            _ICustomerServises = ICustomerServises;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
           var customer= _ICustomerServises.GetAll();
            return Ok(GetRespons(customer, "Done"));
        }
        [HttpPost]
        public IActionResult Create([FromBody] CreateCustomerDTO dto)
        {
             _ICustomerServises.Create(dto);
            return Ok(GetRespons(dto, "Success"));
        }
        [HttpPut]
        public IActionResult Update([FromBody] UpdateCustomerDTO dto)
        {
            _ICustomerServises.Update(dto);
            return Ok(GetRespons(dto, "Done"));

        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            _ICustomerServises.Delete(id);
            return Ok(GetRespons(null,"Done"));
        }
    }
}
