using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrangeTentacle.FixedWidth.Test.Records;
using Xunit;

namespace OrangeTentacle.FixedWidth.Test
{
    public class ParserTest
    {
        public class String
        {
            [Fact]
            public void Parses_String()
            {
                var line = "This     .";

                var record = FixedWidthParser.Parse<SingleStringRecord>(line);

                Assert.Equal(line, record.StringColumn);
            }

            [Fact]
            public void Trims_Whitespace()
            {
                var line = "This.     ";

                var record = FixedWidthParser.Parse<SingleStringRecord>(line);

                Assert.Equal("This.", record.StringColumn);
            }
        }

        public class Int
        {
            [Fact]
            public void Parses_Int()
            {
                var line = "        32";

                var record = FixedWidthParser.Parse<SingleIntRecord>(line);

                Assert.Equal(32, record.IntColumn);
            }

            [Fact]
            public void Handles_Padded_Zeros()
            {
                var line = "0000000032";

                var record = FixedWidthParser.Parse<SingleIntRecord>(line);

                Assert.Equal(32, record.IntColumn);
            }

            [Fact]
            public void Throws_If_Cant_Convert()
            {
                var line = "0000000a32";

                Assert.Throws<Exception>(
                    () => FixedWidthParser.Parse<SingleIntRecord>(line));
            }
        }

        public class Decimal
        {
            [Fact]
            public void Parses_Decimal()
            {
                var line = "      3212";

                var record = FixedWidthParser.Parse<SingleDecimalRecord>(line);

                Assert.Equal(32.12m, record.DecColumn);
            }

            [Fact]
            public void Handles_Padded_Zeros()
            {
                var line = "0000003212";

                var record = FixedWidthParser.Parse<SingleDecimalRecord>(line);

                Assert.Equal(32.12m, record.DecColumn);
            }

            [Fact]
            public void Throws_If_Cant_Convert()
            {
                var line = "0000000a32";

                Assert.Throws<Exception>(
                    () => FixedWidthParser.Parse<SingleDecimalRecord>(line));
            }
        }

        [Fact]
        public void Returns_Type()
        {
            var record = FixedWidthParser.Parse<EmptyRecord>("");

            Assert.IsType<EmptyRecord>(record);
        }

        [Fact]
        public void Null_Throws()
        {
            Assert.Throws<ArgumentNullException>(
                () => FixedWidthParser.Parse<EmptyRecord>(null));
        }

        [Fact]
        public void Throws_If_Line_Shorter_Than_Defined_Endpoint()
        {
            var line = "This    .";

            Assert.Throws<FixedWidthSizeException>(
                () => FixedWidthParser.Parse<SingleStringRecord>(line));
        }
    }
}
