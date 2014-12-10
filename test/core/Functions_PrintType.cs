using System;
using NUnit.Framework;
using ToText.Configuration;
using ToText.Core;
using ToText.Infrastructure;

namespace ToText
{
    [TestFixture]
    public class Functions_PrintType
    {
        [Test]
        public void WithNinjaAndDefaultSeparator_ShouldReturnDefaultNinjaWithLength7()
        {
            PrintedType printedType = Functions.PrintType(typeof (Ninja), FormatConfiguration.DefaultClassToProperatySeparator);
            Assert.That(printedType.value, Is.EqualTo("Ninja: "));
            Assert.That(printedType.length, Is.EqualTo(7));
        }

        [Test]
        public void WithInt32AndCommaAsSeparator_ShouldReturnInt32CommaWithLength6()
        {
            PrintedType printedType = Functions.PrintType(typeof (Int32), ",");
            Assert.That(printedType.value, Is.EqualTo("Int32,"));
            Assert.That(printedType.length, Is.EqualTo(6));
        }

        [Test]
        public void WithNullAsTypeAndDefaultSeparator_ShouldReturnEmptyStringWithLength0()
        {
            PrintedType printedType = Functions.PrintType(null, FormatConfiguration.DefaultClassToProperatySeparator);
            Assert.That(printedType.value, Is.Empty);
            Assert.That(printedType.length, Is.EqualTo(0));
        }

        [Test]
        public void WithNinjaAndNullSeparator_ShouldReturnJustNinjaWithLength5()
        {
            PrintedType printedType = Functions.PrintType(typeof (Ninja), null);
            Assert.That(printedType.value, Is.EqualTo("Ninja"));
            Assert.That(printedType.length, Is.EqualTo(5));
        }
    }
}