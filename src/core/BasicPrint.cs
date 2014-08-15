using System;
using System.Collections.Generic;
using System.Linq;

namespace ToText
{
    public static class BasicPrint
    {
        public static string EnBlock<T>(
            this IEnumerable<T> items, 
            Func<T, string> printMethod,
            int indentationOfFollowingLines = -1)
        {
            if (items == null)
                return "null";
            if (printMethod == null)
                printMethod = t => t.ToString();
            IEnumerable<string> methods = items.Select(printMethod);
            IEnumerable<string> lines = methods.SelectMany(m => m.Split(new[] {Environment.NewLine}, StringSplitOptions.None));
            return string.Join(Environment.NewLine + indentationOfFollowingLines.Spaces(), lines);
        }
        
        public static IEnumerable<string> ExtractLines(this string block)
        {
            return block.Split(new[] {Environment.NewLine}, StringSplitOptions.None);
        } 

        public static string Spaces(this int amount)
        {
            if (amount <= 0)
                return string.Empty;
            return string.Format(" {0}",(amount - 1).Spaces());
        }


    }
}