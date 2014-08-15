using NUnit.Framework;
using ToText.Infrastructure;

namespace ToText.Api
{
    [TestFixture]
    public class PrintSimpleEnumerablePropertyFeature
    {
        private City edo;

        [SetUp]
        public void SetupContext()
        {
            edo = new City {Dojos = new[] {new Dojo(), new Dojo()}};
        }

        [Test]
        public void OnCityWithTwoDojos_ShouldReturnBoth()
        {
            string text = edo.ToText(c => c.Dojos);
            Assert.That(text, Is.EqualTo("City: Dojos = 'Dojo, Dojo'"));
        }
    }
}