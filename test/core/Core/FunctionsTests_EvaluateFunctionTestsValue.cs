using NUnit.Framework;
using ToText.Infrastructure;

namespace ToText.Core
{
    [TestFixture]
    public class FunctionsTests_EvaluateFunctionTestsValue : FunctionsTests_Base
    {
        [Test]
        public void WithNinjaNarutoAndName_ShouldReturnNaruto()
        {
            dynamic value = Functions.EvaluateFunctionValue(Accessor(naruto, n => n.Name));
            Assert.That(value, Is.EqualTo("Naruto"));
        }

        [Test]
        public void WithNarutosDojoAndMaster_ShouldReturnNinjaNaruto()
        {
            dynamic value = Functions.EvaluateFunctionValue(Accessor(narutosDojo, x => x.Master));
            Assert.That(value, Is.EqualTo(naruto));
        }

        [Test]
        public void WithNullInstanceAndMaster_ShouldReturnNull()
        {
            dynamic value = Functions.EvaluateFunctionValue(Accessor<Dojo>(null, x => x.Master));
            Assert.That(value, Is.Null);
        }

        [Test]
        public void WithInt5AndIncrement_ShouldReturn6()
        {
            dynamic value = Functions.EvaluateFunctionValue(Accessor(5, i => i + 1));
            Assert.That(value, Is.EqualTo(6));
        }

        [Test]
        public void WithInt0AndIncrement_ShouldReturn1()
        {
            dynamic value = Functions.EvaluateFunctionValue(Accessor(0, i => i + 1));
            Assert.That(value, Is.EqualTo(1));
        }

        [Test]
        public void WithNinjaNarutoAndNull_ShouldReturnNull()
        {
            dynamic value = Functions.EvaluateFunctionValue(Accessor(naruto, null));
            Assert.That(value, Is.Null);
        }
    }
}