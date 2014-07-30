using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace ToText
{
    public static class IndentationEvaluation
    {
        public static int EvaluateMemberLength<T>(this Expression<T> expression)
        {
            return expression.ExtractMemberName().Length;
        }

        public static int MaxMemberLength<T>(this IEnumerable<Expression<T>> expressions)
        {
            return expressions.Max(exp => exp.EvaluateMemberLength());
        }
    }
}