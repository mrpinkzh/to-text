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

            if (members.Length <= 0) 
                return typeof (T).Name;

            if (!members.HasMembers())
                return typeof (T).Name;

            PrintedType printedType = Functions.PrintType(typeof(T), configuration.ClassToPropertySeparator);
            IReadOnlyCollection<Accessor<T>> accessors = Functions.CreateAccessors(item, members);
            IReadOnlyCollection<MemberValueTuple> memberValueList = accessors.Select(Functions.EvaluateMemberValue).ToList();
            int lengthOfLongestMemberName = memberValueList.Select(mv => mv.name.Length).Max();
            IReadOnlyCollection<string> memberList = Functions.PrintMemberList(memberValueList, lengthOfLongestMemberName, configuration);
            return IndentationFunctions.HangingIndent(printedType.value, string.Join(configuration.NewLineString, memberList), configuration.NewLineString);
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