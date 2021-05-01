using System;
using System.Collections.Generic;
using System.Text;

namespace Zillow.Core.ViewModel
{
    public class LoginResponseViewModel
    {
        public UserViewModel User { get; set; }

        public TokenViewModel Token { get; set; }

    }
}
