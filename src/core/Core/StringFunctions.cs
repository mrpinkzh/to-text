using System;
using System.Collections.Generic;
using System.Linq;

namespace ToText.Core
{
    public static class StringFunctions
    {
        public static string NewLine(this string value)
        {
            return string.Format("{0}{1}", value, Environment.NewLine);
        }

        public static string Add(this string value, string valueToConcat)
        {
            return string.Format("{0}{1}", value, valueToConcat);
        }

        public static IReadOnlyCollection<string> SplitLines(this string item, string newLineIdentifier)
        {
            return item.Split(new []{newLineIdentifier}, StringSplitOptions.None);
        }

        public static string ToNullAwareString(this object instance, string nullString = "null")
        {
            if (instance == null)
                return nullString;
            return instance.ToString();
        }
    }
}