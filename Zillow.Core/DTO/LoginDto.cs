using System;
using System.Collections.Generic;
using System.Text;

namespace Zillow.Core.Dto
{
    public class LoginDto
    {
        public string Username { get; set; }

        public string Password { get; set; }

       public string FCM { get; set; }
    }
}
