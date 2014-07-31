using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace ToText
{
    public static class MemberPrint
    {
        public static IEnumerable<string> PrintMembers<T>(
            this IEnumerable<Expression<Func<T, dynamic>>> expressions,
            T item,
            int minMemberNameLength = -1)
        {
            return expressions.Select(exp => exp.PrintMember(item, minMemberNameLength)).Where(m => m != null);
        }

        public static string PrintMember<T>(this Expression<Func<T, dynamic>> expression, T item, int minMemberNameLength = -1)
        {
            if (expression.IsMember())
            {
                string memberName = expression.ExtractMemberExpression().PrintMemberName(minMemberNameLength);
                dynamic value = expression.Compile()(item);
                return string.Format("{0} = '{1}'", memberName, value);
            }
            return null;
        }

        public static string PrintMemberName(this MemberExpression member, int minResultStringLength = -1)
        {
            string memberName = member.Member.Name;
            int memberNameLength = memberName.Length;
            int spacesToFill = minResultStringLength - memberNameLength;
            if (spacesToFill <= 0)
                return memberName;
            return string.Format("{0}{1}", memberName, spacesToFill.Spaces());
        }
    }
}