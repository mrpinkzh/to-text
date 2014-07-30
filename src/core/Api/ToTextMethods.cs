using System;
using System.Linq;
using System.Linq.Expressions;

namespace ToText.Api
{
    public static class ToTextMethods
    {
        public static string ToText<T, TResult>(this T item, params Expression<Func<T, TResult>>[] members)
        {
            string type = typeof (T).Name;
            Expression<Func<T, TResult>> expression = members.First();
            if (expression.IsMember())
            {
                string memberName = expression.ExtractMemberName();
                TResult value = expression.Compile()(item);
                return string.Format("{0}: {1} = '{2}'", type, memberName, value);
            }
            return type;
        }
    }
}