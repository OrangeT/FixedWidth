using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;

namespace OrangeTentacle.FixedWidth
{
    public static class FixedWidthParser
    {
        /// <summary>
        /// Parses a line of text in fixed width format, populating an 
        /// object of type T where properties are decorated with 
        /// FixedWithColumnAttribute.
        /// </summary>
        /// <typeparam name="T">Target type</typeparam>
        /// <param name="line">Fixed width line to parse.</param>
        /// <returns>A new() object of type T.</returns>
        public static T Parse<T>(string line)
            where T : class, new()
        {
            if (line == null)
                throw new ArgumentNullException("line", "Line can not be null");

            // Find decorated properties.
            var props = typeof (T).GetProperties(BindingFlags.Public | BindingFlags.Instance)
                .Where(p => p.GetCustomAttributes(
                    typeof (FixedWidthColumnAttribute), false).Count() == 1)
                .ToList();

            // Return the last known end point.
            var max = props.Any()
                ? props.Max(p => ((FixedWidthColumnAttribute) p.GetCustomAttributes(
                    typeof (FixedWidthColumnAttribute), false).Single()).End)
                : 0;

            // Throw exception if expected end point is beyond line.
            if (line.Length < max)
                throw new FixedWidthSizeException(max, line.Length, line);

            var returnVal = new T();

            foreach (var prop in props)
            {
                var attr = (FixedWidthColumnAttribute)prop.GetCustomAttributes(
                    typeof (FixedWidthColumnAttribute), false).Single();

                // Return the string for the column.
                var length = attr.End - attr.Start;
                var rawValue = line.Substring(attr.Start, length);

                // If defined, insert decimal point.
                if (attr.DecimalPoint > 0)
                    rawValue = rawValue.Insert(length - attr.DecimalPoint, ".");

                // Convert to target type.
                var value =  TypeDescriptor
                    .GetConverter(prop.PropertyType)
                    .ConvertFromString(rawValue.Trim());

                // Set value.
                prop.SetValue(returnVal, value, null);
            }

            return returnVal;
        }
    }
}
