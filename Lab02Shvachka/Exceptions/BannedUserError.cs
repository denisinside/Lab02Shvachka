using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab02Shvachka.Exceptions
{
    // i don't know where put exceptions classes, so created new directory
    class BannedUserError : Exception
    {
        public BannedUserError() { }
        public BannedUserError(string message) : base(message)
        {
        }
    }
}
