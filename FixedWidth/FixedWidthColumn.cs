using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OrangeTentacle.FixedWidth
{
    /// <summary>
    /// FixedWidthColumnAttribute describes a property which 
    /// can be populated from a fixed width string record.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, Inherited = true)]
    public class FixedWidthColumnAttribute : Attribute
    {
        /// <summary>
        /// Start position of column.
        /// </summary>
        public int Start { get; private set; }

        /// <summary>
        /// End position of column.
        /// </summary>
        public int End { get; private set; }

        /// <summary>
        /// Optional - location of decimal point in column,
        /// expressed as number of places from last position.
        /// Default 0.
        /// </summary>
        public int DecimalPoint { get; set; }

        public FixedWidthColumnAttribute(int start, int end)
        {
            Start = start;
            End = end;
        }
    }
}
