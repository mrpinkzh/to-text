using NUnit.Framework;
using ToText.Infrastructure;

namespace ToText.Api
{
    [TestFixture]
    public class PrintComplexPropertyFeature
    {
        private Dojo miyagisDojo;

        [SetUp]
        public void SetupContext()
        {
            miyagisDojo = new Dojo { Master = new Ninja { Name = "Miyagi" } };
        }

        [Test]
        public void OnDojo_WithMaster_ShouldReturnDojosMaster()
        {
            string text = miyagisDojo.ToText(d => d.Master);
            Assert.That(text, Is.EqualTo("Dojo: Master = 'ToText.Infrastructure.Ninja'"));
        }

        [Test]
        public void OnDojo_WithMasterName_ShouldReturnDojoAndMiyagi()
        {
            string text = miyagisDojo.ToText(d => d.Master.Name);
            Assert.That(text, Is.EqualTo("Dojo: Master.Name = 'Miyagi'"));
        }
    }
}