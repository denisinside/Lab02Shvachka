using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab02Shvachka.Exceptions
{
    class TooYoungAgeError : Exception
    {
        public TooYoungAgeError() { }
        public TooYoungAgeError(string message) : base(message)
        {
        }
    }
}
