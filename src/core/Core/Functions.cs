using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ToText.Core
{
    public static class Functions
    {
        public static PrintedType PrintType(Type type, string separator)
        {
            if (type == null)
                return new PrintedType(string.Empty, 0);
            string value = string.Format("{0}{1}", type.Name, separator);
            return new PrintedType(value, value.Length);
        }

        public static IReadOnlyCollection<Accessor<T>> CreateAccessors<T>(
            T instance,
            Expression<Func<T, dynamic>>[] memberExpressions)
        {
            var accessors = new Accessor<T>[memberExpressions.Length];
            for (int i = 0; i < memberExpressions.Length; i++)
            {
                accessors[i] = new Accessor<T>(instance, memberExpressions[i]);
            }
            return accessors;
        }
    }
}