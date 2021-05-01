using System;
using System.Collections.Generic;
using System.Text;

namespace Zillow.Core.Exceptions
{
    public class InvalidUsernameException : Exception
    {

        public InvalidUsernameException():base("Test Invalid Username Message")
        {

        }

    }
}
