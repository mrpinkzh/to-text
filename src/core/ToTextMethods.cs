using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using ToText.Configuration;
using ToText.Core;

namespace ToText
{
    public static class ToTextMethods
    {
        public static string ToText<T>(
            this T item, 
            FormatConfiguration configuration,
            params Expression<Func<T, dynamic>>[] members)
        {
            if (item == null)
                return configuration.NullValueString;
            if (members.Length > 0)
            {
                int minMemberNameSize = members.MaxMemberLength();
                if (members.HasMembers())
                {
                    PrintedType printedType = Functions.PrintType(typeof(T), configuration.ClassToPropertySeparator);
                    string memberBlock = members.EnBlock(
                                                    m => item.PrintMember(
                                                                    m, 
                                                                    minMemberNameSize, 
                                                                    configuration:configuration), 
                                                    printedType.length);
                    return string.Format("{0}{1}", printedType.value, memberBlock);
                }
            }
            return typeof(T).Name;
        }

        public static string ToText<T>(this T item, params Expression<Func<T, dynamic>>[] members)
        {
            return item.ToText(Format.Default(), members);
        }

        public static string ToText<T>(this IEnumerable<T> items, FormatConfiguration configuration, params Expression<Func<T, dynamic>>[] itemMembers)
        {
            return items.Select(i => i.ToText(configuration, itemMembers)).ToValueString();
        }

        public static string ToText<T>(this IEnumerable<T> items, params Expression<Func<T, dynamic>>[] itemMembers)
        {
            return ToText(items, Format.Default(), itemMembers);
        }
    }
}