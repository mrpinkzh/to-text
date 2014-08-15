using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using ToText.Configuration;

namespace ToText.Core
{
    public static class MemberPrint
    {
        private const string MemberNameValueSeparator = " = ";
        private const string ValueDelimiter = "'";

        public static string PrintMember<T>(
            this T item, 
            Expression<Func<T, dynamic>> expression, 
            int minMemberNameLength = -1, 
            int baseIndentation = 0,
            FormatConfiguration configuration = null)
        {
            if (configuration == null)
                configuration = Format.Default();
            string memberName = expression.PrintMemberName(minMemberNameLength);
            if (expression.IsMember())
            {
                dynamic value = item.EvaluateValue(expression);
                string printedValue = ValuePrint.DelimitedPrintValue(value, configuration);
                IEnumerable<string> valuesMultiLined = printedValue.ExtractLines();
                int indentationOfFollowingLines = memberName.Length + MemberNameValueSeparator.Length + ValueDelimiter.Length;
                return string.Format("{0}{1}{2}", memberName, MemberNameValueSeparator, valuesMultiLined.EnBlock(s => s.ToString(), indentationOfFollowingLines));
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