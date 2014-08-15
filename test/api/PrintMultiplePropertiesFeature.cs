using System;
using NUnit.Framework;
using ToText.Api.Infrastructure;
using ToText.Core;
using ToText.Infrastructure;

namespace ToText.Api
{
    [TestFixture]
    public class PrintMultiplePropertiesFeature
    {
        [Test]
        public void OnNinja_WithAgeAndName_ShouldReturnBoth()
        {
            int randomAge = CreateRandom.Int();
            string randomName = CreateRandom.String();
            var ninja = new Ninja {Age = randomAge, Name = randomName};
            Assert.That(ninja.ToText(n => n.Age, 
                                     n => n.Name),
             Is.EqualTo("Ninja: Age  = '"+randomAge+"'" + Environment.NewLine +
                        "       Name = '"+randomName+"'"));
        }
    }
}