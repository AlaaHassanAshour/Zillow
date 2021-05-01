using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zillow.Data.Models;

namespace Zillow.Core.DTO
{
   public class CreateRealEstateDTO
    {
        public string Name { get; set; }
        public string Decrption { get; set; }
        public int CategoryId { get; set; }
        public int AddressId { get; set; }
       public List<IFormFile> Imeges { get; set; }
    }
}