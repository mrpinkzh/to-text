using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace ToText
{
    public static class MemberExpressionEvaluation
    {
        public static bool HasMembers(this IEnumerable<LambdaExpression> expressions)
        {
            return expressions.Any(e => e.IsMember());
        }

        public static bool IsMember(this LambdaExpression expression)
        {
            MemberExpression memberExpression = expression.ExtractMemberExpression();
            return memberExpression != null;
        }

        public static string ExtractMemberName(this LambdaExpression expression)
        {
            if (expression.IsMember())
            {
                MemberExpression memberExpression = expression.ExtractMemberExpression();
                return memberExpression.ComposeMemberName();
            }
            return string.Empty;
        }

        public static string ComposeMemberName(this MemberExpression expression)
        {
            var childExpression = expression.Expression as MemberExpression;
            if (childExpression == null)
                return expression.Member.Name;
            string composeMemberName = string.Format("{0}.{1}", childExpression.ComposeMemberName(), expression.Member.Name);
            return composeMemberName;
        }

        public static MemberExpression ExtractMemberExpression(this LambdaExpression expression)
        {
            if (expression == null)
                return null;
            Expression body = expression.Body;
            var memberExpression = body as MemberExpression;
            if (memberExpression != null)
                return memberExpression;
            var unaryExpression = body as UnaryExpression;
            if (unaryExpression != null)
                memberExpression = unaryExpression.Operand as MemberExpression;
            return memberExpression;
        }
    }
}