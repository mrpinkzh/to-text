using System.Linq.Expressions;

namespace ToText.Core
{
    public static class CallMethodExpressionEvaluation
    {
        private const string ToText = "ToText";

        public static bool IsToText(this LambdaExpression lambdaExpression)
        {
            Expression body = lambdaExpression.Body;
            var methodCallExpression = body as MethodCallExpression;
            return methodCallExpression.IsToText();
        }

        public static bool IsToText(this MethodCallExpression methodCallExpression)
        {
            if (methodCallExpression == null)
                return false;
            return string.Equals(methodCallExpression.Method.Name, ToText);
        }
    }
}