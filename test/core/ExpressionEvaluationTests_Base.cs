using System;
using System.Linq.Expressions;
using NUnit.Framework;

namespace ToText
{
    public class ExpressionEvaluationTests_Base
    {
        protected Expression<Func<string, int>> stringLengthExpression;
        protected Expression<Func<string, object>> stringLengthObjectExpression;

        [SetUp]
        public void SetupContext()
        {
            stringLengthExpression = s => s.Length;
            stringLengthObjectExpression = s => s.Length;
        }
    }
}