using System.Collections;
using System.Collections.Generic;
using System.Linq;
using ToText.Configuration;

namespace ToText.Core
{
    public static class ValuePrint
    {
        public static string DelimitedPrintValue(
            dynamic value, 
            FormatConfiguration configuration = null)
        {
            if (configuration == null)
                configuration = Format.Default();
            if (value == null)
                return string.Format("{0}{1}", configuration.ValueDelimiter.Length.Spaces(), ToString(value, configuration));
            string printedValue = PrintValue(value, configuration);
            return string.Format("{0}{1}{0}", configuration.ValueDelimiter, printedValue);
        }

        private static string PrintValue(
            dynamic value,
            FormatConfiguration configuration = null)
        {
            if (configuration == null)
                configuration = Format.Default();
            var stringValue = value as string;
            if (stringValue != null)
                return stringValue;
            var enumerable = value as IEnumerable;
            if (enumerable != null)
                return enumerable.ToValueString(configuration);
            return ToString(value, configuration);
        }

        public static string ToValueString(
            this IEnumerable enumerable, 
            FormatConfiguration configuration = null)
        {
            if (configuration == null)
                configuration = Format.Default();
            if (enumerable == null)
                return configuration.NullValueString;
            IEnumerable<object> values = enumerable.Cast<object>();
            IEnumerable<string> valueStrings = values.Select(v => ToString(v, configuration)).ToList();
            if (valueStrings.HasLongerStringsOrNewLines(configuration))
                return string.Join(configuration.Enumerable.LongStringSeparator, valueStrings);    
            return string.Join(configuration.Enumerable.ShortStringSeparator, valueStrings);
        }

        public static bool HasLongerStringsOrNewLines(
            this IEnumerable<string> strings, 
            FormatConfiguration configuration = null)
        {
            if (configuration == null)
                configuration = Format.Default();
            return strings.Any(s => s.Contains(configuration.NewLineString) || s.Length > configuration.Enumerable.ShortStringLimit);
        }

        public static string ToString(object anyObject, FormatConfiguration configuration = null)
        {
            if (configuration == null)
                configuration = Format.Default();
            if (anyObject == null)
                return configuration.NullValueString;
            return anyObject.ToString();
        }
    }
}