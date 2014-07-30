using System;
using System.Collections.Generic;
using System.Linq;

namespace ToText
{
    public static class BasicPrint
    {
        public static string EnBlock<T>(this IEnumerable<T> items, Func<T, string> printMethod)
        {
            return string.Join(Environment.NewLine, items.Select(printMethod));
        }

        public static string Spaces(this int amount)
        {
            if (amount == 1)
                return " ";
            return string.Format(" {0}",(amount - 1).Spaces());
        }
    }
}