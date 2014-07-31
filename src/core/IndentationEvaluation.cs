using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace ToText
{
    public static class IndentationEvaluation
    {
        public static int EvaluateMemberLength(this LambdaExpression expression)
        {
            return expression.ExtractMemberName().Length;
        }

        public static int MaxMemberLength(this IEnumerable<LambdaExpression> expressions)
        {
            return expressions.Max(exp => exp.EvaluateMemberLength());
        }
    }
}