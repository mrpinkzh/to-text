using NUnit.Framework;
using ToText.Core;
using ToText.Infrastructure;

namespace ToText.Api
{
    [TestFixture]
    public class PrintNoPropertyFeature
    {
        [Test]
        public void OnNinja_ShouldReturnNinja()
        {
            var ninja = new Ninja();
            string text = ninja.ToText();
            Assert.That(text, Is.EqualTo("Ninja"));
        }

        [Test]
        public void OnShinobi_ShouldReturnShinobi()
        {
            var ninja = new Shinobi();
            string text = ninja.ToText();
            Assert.That(text, Is.EqualTo("Shinobi"));
        }
    }
}