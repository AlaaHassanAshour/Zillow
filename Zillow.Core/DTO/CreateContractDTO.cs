using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zillow.Data.Models;

namespace Zillow.Core.DTO
{
   public class CreateContractDTO
    {
        public string Type { get; set; }
        public float Price { get; set; }
        public int CustomerId { get; set; }
        public int RealEstateId { get; set; }
    }
}
