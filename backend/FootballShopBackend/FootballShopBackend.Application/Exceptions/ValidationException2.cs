using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballShopBackend.Application.Exceptions
{
    public class ValidationException2 : Exception
    {
        public ValidationException2() : base() { }

        public ValidationException2(string message) : base(message) { }

        public ValidationException2(string message, Exception innerException) : base(message, innerException) { }
    }
}
