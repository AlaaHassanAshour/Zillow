using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zillow.Core.DTO
{
    public  class UpdateAddressDTO
    {
        public int Id{ get; set; }
        public string CountryName { get; set; }
        public string CityName { get; set; }
    }
}
