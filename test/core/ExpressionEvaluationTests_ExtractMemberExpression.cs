using System;
using System.Linq;
using System.Linq.Expressions;
using NUnit.Framework;

namespace ToText
{
    [TestFixture]
    public class ExpressionEvaluationTests_ExtractMemberExpression : ExpressionEvaluationTests_Base
    {
        [Test]
        public void WithStringLength_ShouldReturnLengthMemberExpression()
        {
            MemberExpression memberExpression = stringLengthExpression.ExtractMemberExpression();
            Assert.That(memberExpression.ToString(), Is.EqualTo("s.Length"));
        }

        [Test]
        public void WithStringLengthAsObject_ShouldReturnLengthMemberExpression()
        {
            MemberExpression memberExpression = stringLengthObjectExpression.ExtractMemberExpression();
            Assert.That(memberExpression.ToString(), Is.EqualTo("s.Length"));
        }

        [Test]
        public void WithNull_ShouldReturnNull()
        {
            Expression<string> expression = null;
            MemberExpression memberExpression = expression.ExtractMemberExpression();
            Assert.That(memberExpression, Is.Null);
        }
    }
}