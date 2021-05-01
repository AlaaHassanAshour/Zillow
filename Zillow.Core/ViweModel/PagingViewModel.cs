using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zillow.Core.ViweModel
{
  public  class PagingViewModel
    {
        public int NummberOfBage{ get; set; }
        public int CuraentPage{ get; set; }
        public Object Data{ get; set; }
    }
}
