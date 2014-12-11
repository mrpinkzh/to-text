using NUnit.Framework;
using ToText.Core;
using ToText.Infrastructure;

namespace ToText
{
    [TestFixture]
    public class Functions_EvaluateFunctionValue
    {
        private Ninja naruto;
        private Dojo narutosDojo;

        [SetUp]
        public void SetupContext()
        {
            naruto = new Ninja { Name = "Naruto" };
            narutosDojo = new Dojo { Master = naruto };
        }

        [Test]
        public void WithNinjaNarutoAndName_ShouldReturnNaruto()
        {
            dynamic value = Functions.EvaluateFunctionValue(new Accessor<Ninja>(naruto, n => n.Name));
            Assert.That(value, Is.EqualTo("Naruto"));
        }

        [Test]
        public void WithNarutosDojoAndMaster_ShouldReturnNinjaNaruto()
        {
            dynamic value = Functions.EvaluateFunctionValue(new Accessor<Dojo>(narutosDojo, x => x.Master));
            Assert.That(value, Is.EqualTo(naruto));
        }

        [Test]
        public void WithNullInstanceAndMaster_ShouldReturnNull()
        {
            dynamic value = Functions.EvaluateFunctionValue(new Accessor<Dojo>(null, x => x.Master));
            Assert.That(value, Is.Null);
        }

        [Test]
        public void WithInt5AndIncrement_ShouldReturn6()
        {
            dynamic value = Functions.EvaluateFunctionValue(new Accessor<int>(5, i => i + 1));
            Assert.That(value, Is.EqualTo(6));
        }

        [Test]
        public void WithInt0AndIncrement_ShouldReturn1()
        {
            dynamic value = Functions.EvaluateFunctionValue(new Accessor<int>(0, i => i + 1));
            Assert.That(value, Is.EqualTo(1));
        }

        [Test]
        public void WithNinjaNarutoAndNull_ShouldReturnNull()
        {
            dynamic value = Functions.EvaluateFunctionValue(new Accessor<Ninja>(naruto, null));
            Assert.That(value, Is.Null);
        }
    }
}