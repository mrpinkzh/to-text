using System.Linq.Expressions;

namespace ToText
{
    public static class ExpressionEvaluation
    {
        public static string ExtractMemberName<T>(this Expression<T> expression)
        {
            var memberExpression = expression.Body as MemberExpression;
            if (memberExpression == null)
                return "MEMBER";
            return memberExpression.Member.Name;
        }
    }
}