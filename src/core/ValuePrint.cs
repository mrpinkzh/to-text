using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ToText
{
    public static class ValuePrint
    {
        public static string PrintValue(dynamic value)
        {
            //if value is normal -> toString
            //if value is enumerable -> PrintEnumerable
            throw new NotImplementedException();
        }

        public static string ToValueString(
            this IEnumerable enumerable, 
            string shortStringSeparator = ", ",
            string longStringSeparator = ",\r\n",
            int shortStringLimit = 100)
        {
            IEnumerable<object> values = enumerable.Cast<object>();
            IEnumerable<string> valueStrings = values.Select(v => v.ToString()).ToList();
            if (valueStrings.HasLongerStringsOrNewLines(shortStringLimit))
                return string.Join(longStringSeparator, valueStrings);    
            return string.Join(shortStringSeparator, valueStrings);
        }

        public static bool HasLongerStringsOrNewLines(this IEnumerable<string> strings, int shortStringlimit)
        {
            return strings.Any(s => s.Contains(Environment.NewLine) || s.Length > shortStringlimit);
        }
    }
}