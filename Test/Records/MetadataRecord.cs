using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace OrangeTentacle.FixedWidth.Test.Records
{
    /// <summary>
    /// Simple record where fixedwidth column attributes
    /// are stored in metadata class, not primary class.
    /// </summary>
    [MetadataType(typeof(MetadataRecordMetaData))]
    public class MetadataRecord
    {
        public string StringColumn { get; set; }
    }

    public class MetadataRecordMetaData
    {
        [FixedWidthColumn(0, 10)]
        public string StringColumn { get; set; }
    }
}
