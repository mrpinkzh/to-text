using System;
using System.Linq.Expressions;
using NUnit.Framework;

namespace ToText
{
    [TestFixture]
    public class ExpressionEvaluationTests_ExtractMemberName
    {
        [Test]
        public void WithStringLength_ShouldReturnLength()
        {
            Expression<Func<string, int>> expression = s => s.Length;
            string memberName = expression.ExtractMemberName();
            Assert.That(memberName, Is.EqualTo("Length"));
        }

        [Test]
        public void WithStringLengthObject_ShouldReturnLength()
        {
            Expression<Func<string, object>> expression = s => s.Length;
            string memberName = expression.ExtractMemberName();
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