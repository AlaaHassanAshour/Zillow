using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Zillow.Core.DTO;
using Zillow.Servises.Servises.RealEstate;

namespace ZillowAPI.Controllers
{
    public class RealEstateController : BaseController
    {
        private IRealEstateServises _IRealEstateServises;
        public RealEstateController(IRealEstateServises IRealEstateServises)
        {
            _IRealEstateServises = IRealEstateServises;
        }
        [HttpGet]
        public IActionResult GetAll(int page)
        {
           var realEstate= _IRealEstateServises.GetAll(page);
            return Ok(GetRespons(realEstate, "Done"));
        }
        [HttpPost]
        public IActionResult Create([FromForm] CreateRealEstateDTO dto)
        {
            _IRealEstateServises.Create(dto);
            return Ok(GetRespons(dto, "Done"));
        }
        [HttpPut ]
        public IActionResult Update([FromBody] UpdateRealEstateDTO dto)
        {
            _IRealEstateServises.Update(dto);
            return Ok(GetRespons(dto, "Done"));
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            _IRealEstateServises.Delete(id);
            return Ok(GetRespons(null, "Done"));
        }
    }
}
