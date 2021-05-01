using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zillow.Data.Models;

namespace Zillow.Core.DTO
{
   public class CreateCustomerDTO
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public int AddressId { get; set; }
    }
}
