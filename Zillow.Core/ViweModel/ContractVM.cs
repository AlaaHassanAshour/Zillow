using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zillow.Core.ViweModel
{
public class ContractVM
    {
        public int Id{ get; set; }
        public string Type { get; set; }
        public float Price { get; set; }
        public CustomerVM Customer { get; set; }
        public RealEstateVM RealEstate { get; set; }
    }
}
