using OrangeTentacle.FixedWidth;

namespace OrangeTentacle.FixedWidth.Test.Records
{
    /// <summary>
    /// Simple record consisting of a single integer column.
    /// </summary>
    public class SingleIntRecord
    {
        [FixedWidthColumn(0, 10)]
        public int IntColumn { get; set; }
    }
}