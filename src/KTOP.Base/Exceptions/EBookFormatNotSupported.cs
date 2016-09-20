using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KTOP.Base.Exceptions
{
    public class EBookFormatNotSupported : Exception
    {
        public EBookFormatNotSupported()
        {

        }

        public EBookFormatNotSupported(string message)
            : base(message)
        {

        }
    }
}
