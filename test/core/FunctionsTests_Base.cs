using System;
using System.Linq.Expressions;
using NUnit.Framework;
using ToText.Core;
using ToText.Infrastructure;

namespace ToText
{
    public class FunctionsTests_Base
    {
        protected Ninja naruto;
        protected Dojo narutosDojo;

        [SetUp]
        public void SetupContext()
        {
            naruto = new Ninja { Name = "Naruto", Age = 12};
            narutosDojo = new Dojo { Master = naruto };
        }

        protected static Accessor<T> Accessor<T>(T instance, Expression<Func<T, dynamic>> func)
        {
            return new Accessor<T>(instance, func);
        } 
    }
}