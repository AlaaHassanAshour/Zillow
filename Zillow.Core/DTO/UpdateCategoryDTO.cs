using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zillow.Core.DTO
{
   public class UpdateCategoryDTO
    {
        public int Id{ get; set; }

        public string Name { get; set; }

        public string Decrption { get; set; }
    }
}
