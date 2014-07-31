using NUnit.Framework;
using ToText.Api.Infrastructure;

namespace ToText
{
    [TestFixture]
    public class BasicPrintTests_Spaces
    {
        [Test]
        public void On1_ShouldReturnOneSpace()
        {
            string spaces = 1.Spaces();
            Assert.That(spaces, Is.EqualTo(" "));
        }

        [Test]
        public void On2_ShouldReturnTwoSpaces()
        {
            Assert.That(2.Spaces(), Is.EqualTo("  "));
        }

        [Test]
        public void On0_ShouldReturnEmptyString()
        {
            Assert.That(0.Spaces(), Is.Empty);
        }

        [Test]
        public void OnMinusValue_ShouldReturnEmptyString()
        {
            int minusValue = 0 - CreateRandom.Int();
            Assert.That(minusValue.Spaces(), Is.Empty);
        }
    }
}