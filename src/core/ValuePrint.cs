using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ToText
{
    public static class ValuePrint
    {
        public static string DelimitedPrintValue(dynamic value, string valueDelimiter = "'")
        {
            if (value == null)
                return string.Format("{0}{1}", valueDelimiter.Length.Spaces(), ToString(value));
            string printedValue = PrintValue(value);
            return string.Format("{0}{1}{0}", valueDelimiter, printedValue);
        }

        private static string PrintValue(
            dynamic value)
        {
            var stringValue = value as string;
            if (stringValue != null)
                return stringValue;
            var enumerable = value as IEnumerable;
            if (enumerable != null)
                return enumerable.ToValueString();
            return ToString(value);
        }

        public static string ToValueString(
            this IEnumerable enumerable, 
            string shortStringSeparator = ", ",
            string longStringSeparator = ",\r\n",
            int shortStringLimit = 100)
        {
            if (enumerable == null)
                return "null";
            IEnumerable<object> values = enumerable.Cast<object>();
            IEnumerable<string> valueStrings = values.Select(ToString).ToList();
            if (valueStrings.HasLongerStringsOrNewLines(shortStringLimit))
                return string.Join(longStringSeparator, valueStrings);    
            return string.Join(shortStringSeparator, valueStrings);
        }

        public static bool HasLongerStringsOrNewLines(this IEnumerable<string> strings, int shortStringlimit)
        {
            return strings.Any(s => s.Contains(Environment.NewLine) || s.Length > shortStringlimit);
        }

        public static string ToString(object anyObject)
        {
            if (anyObject == null)
                return "null";
            return anyObject.ToString();
        }
    }
}