using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ToText
{
    public static class MemberPrint
    {
        private const string MemberNameValueSeparator = " = ";
        private const string ValueDelimiter = "'";

        public static string PrintMember<T>(this T item, Expression<Func<T, dynamic>> expression, int minMemberNameLength = -1, int baseIndentation = 0)
        {
            string memberName = expression.PrintMemberName(minMemberNameLength);
            if (expression.IsMember())
            {
                string value = item.EvaluateValue(expression).ToString();
                IEnumerable<string> valuesMultiLined = value.ExtractLines();
                int indentationOfFollowingLines = memberName.Length + MemberNameValueSeparator.Length + ValueDelimiter.Length;
                return string.Format("{0}{1}{3}{2}{3}", memberName, MemberNameValueSeparator, valuesMultiLined.EnBlock(s => s.ToString(), indentationOfFollowingLines), ValueDelimiter);
            }
            return string.Empty;
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