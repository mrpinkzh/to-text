using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace ToText
{
    public static class ExpressionEvaluation
    {
        public static bool HasMembers<T>(this IEnumerable<Expression<T>> expressions)
        {
            return expressions.Any(e => e.IsMember());
        }

        public static bool IsMember<T>(this Expression<T> expression)
        {
            MemberExpression memberExpression = expression.ExtractMemberExpression();
            return memberExpression != null;
        }

        public static MemberExpression ExtractMemberExpression<T>(this Expression<T> expression)
        {
            Expression body = expression.Body;
            var memberExpression = body as MemberExpression;
            if (memberExpression != null)
                return memberExpression;
            var unaryExpression = body as UnaryExpression;
            if (unaryExpression != null)
                memberExpression = unaryExpression.Operand as MemberExpression;
            return memberExpression;
        }

        public static string ExtractMemberName<T>(this Expression<T> expression)
        {
            var memberExpression = expression.ExtractMemberExpression();
            return memberExpression.Member.Name;
        }
    }
}