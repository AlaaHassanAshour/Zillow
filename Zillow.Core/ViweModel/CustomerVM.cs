using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zillow.Data.Models;

namespace Zillow.Core.ViweModel
{
   public class CustomerVM
    {
        public int Id{ get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public List<Contract> Contractss { get; set; }
    }
}
