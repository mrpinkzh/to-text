using System;
using System.Collections.Generic;
using System.Linq;

namespace ToText.Core
{
    public static class StringFunctions
    {
        public static string NewLine(this string value)
        {
            return String.Format("{0}{1}", value, Environment.NewLine);
        }

        public static string Add(this string value, string valueToConcat)
        {
            return String.Format("{0}{1}", value, valueToConcat);
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

        public static string Spaces(this int amount)
        {
            if (amount <= 0)
                return String.Empty;
            return String.Format(" {0}",(amount - 1).Spaces());
        }
    }
}