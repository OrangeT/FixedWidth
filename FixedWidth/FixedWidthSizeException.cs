using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OrangeTentacle.FixedWidth
{
    /// <summary>
    /// Exception thrown if the maximum column position exceeds 
    /// the size of the line given.
    /// </summary>
    public class FixedWidthSizeException : FixedWidthException
    {
        public int Expected { get; private set; }
        public int Found { get; private set; }
        public string Line { get; private set; }

        public FixedWidthSizeException(int expected, int found, string line)
            : base(
                string.Format("Expected line length {0} exceeded, found {1}, line : {2}",
                expected, found, line))
        {
            Expected = expected;
            Found = found;
            Line = line;
        }
    }
}
