using OrangeTentacle.FixedWidth;

namespace OrangeTentacle.FixedWidth.Test.Records
{
    /// <summary>
    /// Represents a complex record consisting of multiple 
    /// columns.
    /// </summary>
    public class ComplexRecord
    {
        [FixedWidthColumn(0, 10)]
        public string StringColumn { get; set; }

        [FixedWidthColumn(10, 20)]
        public int IntColumn { get; set; }

        [FixedWidthColumn(20, 30, DecimalPoint = 2)]
        public decimal DecColumn { get; set; }
    }
}