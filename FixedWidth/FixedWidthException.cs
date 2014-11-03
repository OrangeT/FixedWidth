using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OrangeTentacle.FixedWidth
{
    public class FixedWidthException : Exception
    {
        public FixedWidthException(string message)
            : base(message)
        {
        }
    }
}
