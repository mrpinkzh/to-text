using System;
using System.Linq.Expressions;

namespace ToText
{
    public static class MemberPrint
    {
        public static string PrintMember<T>(this T item, Expression<Func<T, dynamic>> expression, int minMemberNameLength = -1)
        {
            string memberName = expression.PrintMemberName(minMemberNameLength);
            dynamic value = item.EvaluateValue(expression);
            return string.Format("{0} = '{1}'", memberName, value);
        }

        private static dynamic EvaluateValue<T>(this T item, Expression<Func<T, dynamic>> expression)
        {
            if (!typeof(T).IsValueType && item != null)
                return expression.Compile()(item);
            return string.Empty;
        }

        public static string PrintMemberName(this LambdaExpression member, int minResultStringLength = -1)
        {
            if (member == null)
                return string.Empty;
            string memberName = member.ExtractMemberName();
            int memberNameLength = memberName.Length;
            int spacesToFill = minResultStringLength - memberNameLength;
            if (spacesToFill <= 0)
                return memberName;
            return string.Format("{0}{1}", memberName, spacesToFill.Spaces());
        }
    }
}