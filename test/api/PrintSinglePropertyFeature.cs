using NUnit.Framework;
using ToText.Api.Infrastructure;
using ToText.Infrastructure;

namespace ToText.Api
{
    [TestFixture]
    public class PrintSinglePropertyFeature
    {
        [Test]
        public void OnNinja_WithName_ShouldReturnNinjasName()
        {
            string randomName = CreateRandom.String();
            var ninja = new Ninja { Name = randomName };
            Assert.That(ninja.ToText(n => n.Name),
             Is.EqualTo("Ninja: Name = '" + randomName + "'"));
        }

        [Test]
        public void OnShinobi_WithAge_ShouldReturnShinobisAge()
        {
            int randomAge = CreateRandom.Int();
            var shinobi = new Shinobi {Age = randomAge};
            Assert.That(shinobi.ToText(s => s.Age),
                Is.EqualTo("Shinobi: Age = '"+randomAge+"'"));
        }

        [Test]
        public void OnNinja_WithHideMethod_ShouldReturnNinja()
        {
            var ninja = new Ninja();
            Assert.That(ninja.ToText(n => n.Hide()),
                Is.EqualTo("Ninja"));
        }
    }
}