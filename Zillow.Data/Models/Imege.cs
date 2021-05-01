using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zillow.Data.Models
{
    public class Imege: BaseEntity
    {
        public string ImegPath{ get; set; }
        public int RealEstateId { get; set; }
        public RealEstate RealEstate { get; set; }
    }
}
