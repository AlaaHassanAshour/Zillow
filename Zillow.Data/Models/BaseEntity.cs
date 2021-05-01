using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zillow.Data.Models
{
   public class BaseEntity
    {
        public int Id{ get; set; }
        public bool IsDelete { get; set; }
        public BaseEntity()
        {
            IsDelete = false;
        }
    }
}
