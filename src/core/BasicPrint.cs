using System;
using System.Collections.Generic;
using System.Linq;
using ToText.Api;
using ToText.Configuration;

namespace ToText
{
    public static class BasicPrint
    {
        public static string EnBlock<T>(
            this IEnumerable<T> items, 
            Func<T, string> printMethod,
            int indentationOfFollowingLines = -1,
            FormatConfiguration configuration = null)
        {
            if (configuration == null)
                configuration = Format.Default();
            if (items == null)
                return configuration.NullValueString;
            if (printMethod == null)
                printMethod = t => t.ToString();
            IEnumerable<string> methods = items.Select(printMethod);
            IEnumerable<string> lines = methods.SelectMany(m => m.Split(new[] { configuration.NewLineString }, StringSplitOptions.None));
            return string.Join(configuration.NewLineString + indentationOfFollowingLines.Spaces(), lines);
        }
        
        public static IEnumerable<string> ExtractLines(
            this string block, 
            FormatConfiguration configuration = null)
        {
            if (configuration == null)
                configuration = Format.Default();
            return block.Split(new[] {configuration.NewLineString}, StringSplitOptions.None);
        } 

        public static string Spaces(this int amount)
        {
            if (amount <= 0)
                return string.Empty;
            return string.Format(" {0}",(amount - 1).Spaces());
        }


    }
}