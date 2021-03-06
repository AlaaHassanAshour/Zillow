using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zillow.Data.Models
{
     public class Contract: BaseEntity
    {
        [Required]
        public string Type{ get; set; }
        [Required]
        public float Price{ get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public int RealEstateId { get; set; }
        public RealEstate RealEstate { get; set; }

    }
}
