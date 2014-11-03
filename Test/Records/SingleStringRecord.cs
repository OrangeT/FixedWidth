using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrangeTentacle.FixedWidth;

namespace OrangeTentacle.FixedWidth.Test.Records
{
    /// <summary>
    /// Simple record consisting of a single string column.
    /// </summary>
    public class SingleStringRecord
    {
        [FixedWidthColumn(0, 10)]
        public string StringColumn { get; set; }
    }
}
