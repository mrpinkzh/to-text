using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace ToText
{
    public static class MemberPrint
    {
        public static string PrintMember<T>(this Expression<Func<T, dynamic>> expression, T item)
        {
            if (expression.IsMember())
            {
                string memberName = expression.ExtractMemberName();
                dynamic value = expression.Compile()(item);
                return string.Format("{0} = '{1}'", memberName, value);
            }
            return null;
        }

        public static IEnumerable<string> PrintMembers<T>(
            this IEnumerable<Expression<Func<T, dynamic>>> expressions,
            T item)
        {
            return expressions.Select(exp => exp.PrintMember(item)).Where(m => m != null);
        }
    }
}