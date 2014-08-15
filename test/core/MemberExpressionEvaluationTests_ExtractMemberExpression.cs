using System.Linq.Expressions;
using NUnit.Framework;
using ToText.Api;
using ToText.Core;
using ToText.Infrastructure;

namespace ToText
{
    [TestFixture]
    public class MemberExpressionEvaluationTests_ExtractMemberExpression : MemberExpressionEvaluationTests_Base
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

        [Test]
        public void OnMasterToText_ShouldReturnMasterExpression()
        {
            LambdaExpression masterToTextExpression = ExpressionOf<Dojo>(d => d.Master.ToText());
            MemberExpression memberExpression = masterToTextExpression.ExtractMemberExpression();
            Assert.That(memberExpression.ToString(), Is.EqualTo("d.Master"));
        }

        [Test]
        public void OnNinjaToText_ShouldReturnNull()
        {
            LambdaExpression masterToTextExpression = ExpressionOf<Dojo>(d => d.ToText());
            MemberExpression memberExpression = masterToTextExpression.ExtractMemberExpression();
            Assert.That(memberExpression, Is.Null);
        }
    }
}