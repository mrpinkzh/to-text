using System;
using System.Linq.Expressions;
using NUnit.Framework;

namespace ToText
{
    [TestFixture]
    public class ExpressionEvaluationTests_ExtractMemberName : ExpressionEvaluationTests_Base
    {
        [Test]
        public void WithStringLength_ShouldReturnLength()
        {            
            string memberName = stringLengthExpression.ExtractMemberName();
            Assert.That(memberName, Is.EqualTo("Length"));
        }

        [Test]
        public void WithStringLengthObject_ShouldReturnLength()
        {
            string memberName = stringLengthObjectExpression.ExtractMemberName();
            Assert.That(memberName, Is.EqualTo("Length"));
        }

        [Test]
        public void WithNull_ShouldReturnEmptyString()
        {
            Expression<Func<string, object>> expression = null;
            string memberName = expression.ExtractMemberName();
            Assert.That(memberName, Is.Empty);
        }
    }
}