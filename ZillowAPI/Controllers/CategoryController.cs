using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Zillow.Core.DTO;
using Zillow.Servises.Servises.Category;

namespace ZillowAPI.Controllers
{
    public class CategoryController : BaseController
    {

        private ICategoryServises _ICategoryServises;
        public CategoryController(ICategoryServises ICategoryServises)
        {
            _ICategoryServises = ICategoryServises;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
         var category=  _ICategoryServises.GetAll();
            return Ok(GetRespons(category, "Done"));
        }
        [HttpPost]
        public IActionResult Create([FromBody]CreateCategoryDTO dto )
        {
            _ICategoryServises.Create(dto);
            return Ok(GetRespons(dto, "Done"));
        }
        [HttpPut]
        public IActionResult Update([FromBody] UpdateCategoryDTO dto)
        {
            _ICategoryServises.Update(dto);
            return Ok(GetRespons(dto, "Done"));
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            _ICategoryServises.Delete(id);
            return Ok(GetRespons( null, "Done"));

        }
    }
}
