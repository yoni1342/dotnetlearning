using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace blog.Helpers
{
    public class AppException : Exception
    {
        public AppException() : base() {}
        public AppException(string message) : base(message) {}
        
    }
}