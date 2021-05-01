using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zillow.Data.Models
{
    public class RealEstate:BaseEntity
    {
        [Required]
        public string Name{ get; set; }
        [Required]
        public string Decrption{ get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public int AddressId { get; set; }
        public Address Address { get; set; }
        public List<Imege> Imeges { get; set; }
        public List<Contract> Contracts { get; set; }
    }
}
