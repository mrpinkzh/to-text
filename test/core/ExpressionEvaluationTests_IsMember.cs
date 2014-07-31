using System;
using System.Linq.Expressions;
using NUnit.Framework;

namespace ToText
{
    [TestFixture]
    public class ExpressionEvaluationTests_IsMember : ExpressionEvaluationTests_Base
    {
        [Test]
        public void WithStringLength_ShouldReturnTrue()
        {
            Assert.That(stringLengthExpression.IsMember(), Is.True);
        }

        [Test]
        public void WithStringLengthObject_ShouldReturnTrue()
        {
            Assert.That(stringLengthObjectExpression.IsMember(), Is.True);
        }

        [Test]
        public void WithNull_ShouldReturnFalse()
        {
            Expression<Func<string, string>> nullExpression = null;
            Assert.That(nullExpression.IsMember(), Is.False);
        }
    }
}