﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zillow.Data.Models
{
     public class Category: BaseEntity
    {
        [Required]
        public string Name{ get; set; }
        [Required]
        public string Decrption{ get; set; }
        public List<RealEstate> RealEstate { get; set; }
    }
}
