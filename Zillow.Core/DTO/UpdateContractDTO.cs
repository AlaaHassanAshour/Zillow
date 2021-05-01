using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zillow.Core.ViweModel;

namespace Zillow.Core.DTO
{
   public class UpdateContractDTO
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public float Price { get; set; }
        public int CustomerId { get; set; }
        public int RealEstateId { get; set; }
    }
}
