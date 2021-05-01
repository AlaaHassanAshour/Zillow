using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zillow.Data.Models;

namespace Zillow.Core.ViweModel
{
   public class AddressVM
    {
        public int Id{ get; set; }
        public string CountryName { get; set; }
        public string CityName { get; set; }
        public List<Customer> Customers { get; set; }
    }
}
