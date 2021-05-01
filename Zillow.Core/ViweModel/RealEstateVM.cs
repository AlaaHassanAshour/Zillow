using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zillow.Data.Models;

namespace Zillow.Core.ViweModel
{
   public class RealEstateVM
    {
        public string Name { get; set; }
        public string Decrption { get; set; }
        public CategoryVM Category { get; set; } 
        public AddressVM Address { get; set; }
        public List<ImegeVM> Imeges { get; set; }
        public List<ContractVM> Contracts { get; set; }
        public List<string> Imege{ get; set; }
    }
}
