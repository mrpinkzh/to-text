using System;
using System.Linq.Expressions;
using NUnit.Framework;
using ToText.Core;
using ToText.Infrastructure;

namespace ToText
{
    [TestFixture]
    public class MemberPrintTests_PrintMemberName
    {
        [Test]
        public void WithNinjasName_ShouldReturnName()
        {
            LambdaExpression expression = MemberExpressionOf<Ninja>(n => n.Name);
            string memberName = expression.PrintMemberName();
            Assert.That(memberName, Is.EqualTo("Name"));
        }

        [Test]
        public void WithNinjasAge_ShouldReturnAge()
        {
            LambdaExpression expression = MemberExpressionOf<Ninja>(n => n.Age);
            string memberName = expression.PrintMemberName();
            Assert.That(memberName, Is.EqualTo("Age"));
        }

        [Test]
        public void WithNinjaAgeAnd5_ShouldReturnAgeAndTwoSpaces()
        {
            LambdaExpression expression = MemberExpressionOf<Ninja>(n => n.Age);
            string memberName = expression.PrintMemberName(minResultStringLength:5);
            Assert.That(memberName, Is.EqualTo("Age  "));
        }

        [Test]
        public void WithNinjaAgeAnd0_ShouldReturnAge()
        {
            LambdaExpression expression = MemberExpressionOf<Ninja>(n => n.Age);
            string memberName = expression.PrintMemberName(minResultStringLength:0);
            Assert.That(memberName, Is.EqualTo("Age"));
        }

        [Test]
        public void WithNinjaAgeAnd2_ShouldReturnAge()
        {
            LambdaExpression expression = MemberExpressionOf<Ninja>(n => n.Age);
            string memberName = expression.PrintMemberName(minResultStringLength: 2);
            Assert.That(memberName, Is.EqualTo("Age"));
        }

        [Test]
        public void WithNinjaNameLength_ShouldReturnNameLength()
        {
            LambdaExpression expression = MemberExpressionOf<Ninja>(n => n.Name.Length);
            string memberName = expression.PrintMemberName();
            Assert.That(memberName, Is.EqualTo("Name.Length"));
        }

        [Test]
        public void WithNull_ShouldReturnEmptyString()
        {
            LambdaExpression expression = null;
            string memberName = expression.PrintMemberName();
            Assert.That(memberName, Is.Empty);
        }

        private LambdaExpression MemberExpressionOf<T>(Expression<Func<T, dynamic>> expression)
        {
            return expression;
        }
    }
}