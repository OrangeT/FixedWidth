using OrangeTentacle.FixedWidth;

namespace OrangeTentacle.FixedWidth.Test.Records
{
    /// <summary>
    /// Simple record consisting of a single decimal column.
    /// </summary>
    public class SingleDecimalRecord
    {
        [FixedWidthColumn(0, 10, DecimalPoint = 2)]
        public decimal DecColumn { get; set; }
    }
}