using System;
using System.Linq.Expressions;
using NUnit.Framework;
using ToText.Api;
using ToText.Infrastructure;

namespace ToText
{
    [TestFixture]
    public class CallMethodExpressionEvaluationTests_IsToText
    {
        [Test]
        public void OnToTextExpression_ShouldReturnTrue()
        {
            var toTextExpression = Expression<Ninja>(n => n.Name.ToText());
            bool isToText = toTextExpression.IsToText();
            Assert.That(isToText, Is.True);
        }

        [Test]
        public void OnNameExpression_ShouldReturnFalse()
        {
            var toTextExpression = Expression<Ninja>(n => n.Name);
            bool isToText = toTextExpression.IsToText();
            Assert.That(isToText, Is.False);
        }

        [Test]
        public void OnHideExpression_ShouldReturnFalse()
        {
            var toTextExpression = Expression<Ninja>(n => n.Hide());
            bool isToText = toTextExpression.IsToText();
            Assert.That(isToText, Is.False);
        }

        private LambdaExpression Expression<T>(Expression<Func<T, object>> expression)
        {
            return expression;
        }
    }
}