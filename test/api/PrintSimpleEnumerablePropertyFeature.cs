using NUnit.Framework;
using ToText.Core;
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
            edo = new City {Dojos = new[] {new Dojo {Name = "Dojo Tsubasa"}, new Dojo()}};
        }

        [Test]
        public void OnCityWithTwoDojos_ShouldReturnBoth()
        {
            string text = edo.ToText(c => c.Dojos.ToText(d => d.Name));
            Assert.That(text, Is.EqualTo("City: Dojos = 'Dojo: Name = 'Dojo Tsubasa', Dojo: Name =  null'"));
        }
    }
}