using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zillow.Data.Models
{
  public class Address:BaseEntity
    {
        [Required]
        public string CountryName{ get; set; }
        [Required]
        public string CityName{ get; set; }
        public List<Customer> Customers { get; set; }
        public List<RealEstate> RealEstates { get; set; }
    }
}
