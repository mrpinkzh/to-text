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
    }
}