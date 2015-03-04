using System;
using NUnit.Framework;
using ToText.Core;

namespace ToText
{
    [TestFixture]
    public class FunctionsTests_PrintHangingIndented
    {
        [Test]
        public void WithNinjaAndNarutosProperties_ShouldReturnIndentedNinjaNaruto()
        {
            string result = Functions.PrintHangingIndented("Ninja: ", new[] {"Name = 'Naruto'", "Age  = '12'"}, Format.Default());
            Assert.That(result, Is.EqualTo("Ninja: Name = 'Naruto'" + Environment.NewLine
                                         + "       Age  = '12'"));
        }

        [Test]
        public void WithNarutosDojo_ShouldReturnIndentedDojo()
        {
            string result = Functions.PrintHangingIndented("Dojo: ", new[] {"Master = 'Ninja: Name = 'Naruto'",
                                                                            "                 Age  = '12''" }, Format.Default());
            Assert.That(result, Is.EqualTo("Dojo: Master = 'Ninja: Name = 'Naruto'" + Environment.NewLine
                                         + "                       Age  = '12''"));
        }

        [Test]
        public void WithNewLineInPropertyString_ShouldIndentNewLineInPropertyToo()
        {
            string result = Functions.PrintHangingIndented("Ninja: ", new[] { "Name = 'Naruto'" + Environment.NewLine
                                                                            + "Age  = '12'"}, Format.Default());
            Assert.That(result, Is.EqualTo("Ninja: Name = 'Naruto'" + Environment.NewLine
                                         + "       Age  = '12'"));
        }
    }
}