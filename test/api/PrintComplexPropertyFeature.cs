using NUnit.Framework;
using ToText.Infrastructure;

namespace ToText.Api
{
    [TestFixture]
    public class PrintComplexPropertyFeature
    {
        [Test]
        public void OnDojo_WithMaster_ShouldReturnDojosMaster()
        {
            var dojo = new Dojo {Master = new Ninja {Name = "Miyagi"}};
            string text = dojo.ToText(d => d.Master);
            Assert.That(text, Is.EqualTo("Dojo: Master = 'ToText.Infrastructure.Ninja'"));
        }
    }
}