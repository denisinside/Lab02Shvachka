using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab02Shvachka.Exceptions
{
    class EmailFormatError : Exception
    {
        public EmailFormatError() { }
        public EmailFormatError(string message) : base(message)
        {
        }
    }
}
