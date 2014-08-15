using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using ToText.Configuration;

namespace ToText.Api
{
    public static class ToTextMethods
    {
        public static string ToText<T>(
            this T item, 
            FormatConfiguration configuration,
            params Expression<Func<T, dynamic>>[] members)
        {
            string type = typeof(T).Name;
            int indentationOfFollowingLines = type.Length + configuration.ClassToPropertySeparator.Length;
            if (members.Length > 0)
            {
                int minMemberNameSize = members.MaxMemberLength();
                if (members.HasMembers())
                {
                    string memberBlock = members.EnBlock(
                                                    m => item.PrintMember(
                                                                    m, 
                                                                    minMemberNameSize, 
                                                                    configuration:configuration), 
                                                    indentationOfFollowingLines);
                    return string.Format("{0}{2}{1}", type, memberBlock, configuration.ClassToPropertySeparator);
                }
            }
            return type;
        }

        public static string ToText<T>(this T item, params Expression<Func<T, dynamic>>[] members)
        {
            return item.ToText(Format.Default(), members);
        }

        public static string ToText<T>(this IEnumerable<T> items, params Expression<Func<T, dynamic>>[] itemMembers)
        {
            return items.Select(i => i.ToText(itemMembers)).ToValueString();
        }
    }
}