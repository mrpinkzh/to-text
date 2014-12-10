using System;
using System.Linq.Expressions;

namespace ToText.Core
{
    public struct Accessor<T>
    {
        public readonly T instance;
        public readonly Expression<Func<T, dynamic>> func;

        public Accessor(T instance, Expression<Func<T, dynamic>> func)
        {
            this.instance = instance;
            this.func = func;
        }
    }
}