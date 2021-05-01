using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Zillow.Core.DTO;
using Zillow.Servises.Servises.Contract;

namespace ZillowAPI.Controllers
{
    public class ContractController : BaseController
    {
        private IContractServies _IContractServies;
        public ContractController(IContractServies IContractServies)
        {
            _IContractServies = IContractServies;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var contract = _IContractServies.GetAll();
            return Ok(GetRespons(contract, "Done"));
        }
        [HttpPost]
        public IActionResult Create([FromBody] CreateContractDTO dto)
        {
            _IContractServies.Create(dto);
            return Ok(GetRespons(dto, "Done"));
        }
        [HttpPut]
        public IActionResult Update([FromBody] UpdateContractDTO dto)
        {
            _IContractServies.Update(dto);
            return Ok(GetRespons(dto, "Done"));
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            _IContractServies.Delete(id);
            return Ok(GetRespons(null, "Done"));
        }
    }
}
