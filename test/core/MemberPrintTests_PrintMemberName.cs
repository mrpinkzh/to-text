using System;
using System.Linq.Expressions;
using NUnit.Framework;
using ToText.Infrastructure;

namespace ToText
{
    [TestFixture]
    public class MemberPrintTests_PrintMemberName
    {
        [Test]
        public void WithNinjasName_ShouldReturnName()
        {
            MemberExpression expression = MemberExpressionOf<Ninja>(n => n.Name);
            string memberName = expression.PrintMemberName();
            Assert.That(memberName, Is.EqualTo("Name"));
        }

        [Test]
        public void WithNinjasAge_ShouldReturnAge()
        {
            MemberExpression expression = MemberExpressionOf<Ninja>(n => n.Age);
            string memberName = expression.PrintMemberName();
            Assert.That(memberName, Is.EqualTo("Age"));
        }

        [Test]
        public void WithNinjaAgeAnd5_ShouldReturnAgeAndTwoSpaces()
        {
            MemberExpression expression = MemberExpressionOf<Ninja>(n => n.Age);
            string memberName = expression.PrintMemberName(minResultStringLength:5);
            Assert.That(memberName, Is.EqualTo("Age  "));
        }

        [Test]
        public void WithNinjaAgeAnd0_ShouldReturnAge()
        {
            MemberExpression expression = MemberExpressionOf<Ninja>(n => n.Age);
            string memberName = expression.PrintMemberName(minResultStringLength:0);
            Assert.That(memberName, Is.EqualTo("Age"));
        }

        [Test]
        public void WithNinjaAgeAnd2_ShouldReturnAge()
        {
            MemberExpression expression = MemberExpressionOf<Ninja>(n => n.Age);
            string memberName = expression.PrintMemberName(minResultStringLength: 2);
            Assert.That(memberName, Is.EqualTo("Age"));
        }

        [Test]
        public void WithNinjaNameLength_ShouldReturnNameLength()
        {
            MemberExpression expression = MemberExpressionOf<Ninja>(n => n.Name.Length);
            string memberName = expression.PrintMemberName();
            Assert.That(memberName, Is.EqualTo("Name.Length"));
        }

        [Test]
        public void WithNull_ShouldReturnEmptyString()
        {
            MemberExpression expression = null;
            string memberName = expression.PrintMemberName();
            Assert.That(memberName, Is.Empty);
        }

        private MemberExpression MemberExpressionOf<T>(Expression<Func<T, dynamic>> expression)
        {
            return expression.ExtractMemberExpression();
        }
    }
}