using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVETSDA
{
    public class CustomExceptions
    {
        public class ValidationFailureException : Exception
        {
            public ValidationFailureException(string input) : base($"ValidationFailureException: {input}") { }
        }
    }
}
