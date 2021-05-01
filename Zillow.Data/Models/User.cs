using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zillow.Data.Models
{
   public class User:IdentityUser
    {
        [Required]
        public string FirstName{ get; set; }
        [Required]
        public string LastName{ get; set; }
        public DateTime? DOB{ get; set; }
        public bool IsDelete { get; set; }
       public string FCMToken { get; set; }
    }
}
