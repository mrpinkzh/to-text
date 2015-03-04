using NUnit.Framework;
using ToText.Infrastructure;

namespace ToText.Core
{
    [TestFixture]
    public class FunctionsTests_EvaluateMemberValue : FunctionsTests_Base
    {
        [Test]
        public void WithNinjaNarutoAndName_ShouldReturnNameAndNaruto()
        {
            MemberValueTuple memberValue = Functions.EvaluateMemberValue(Accessor(naruto, n => n.Name));
            Assert.AreEqual("Name", memberValue.name);
            Assert.AreEqual("Naruto", memberValue.value);
        }

        [Test]
        public void WithNinjaNarutoAndAge_ShouldReturnAgeAnd12()
        {
            MemberValueTuple memberValue = Functions.EvaluateMemberValue(Accessor(naruto, n => n.Age));
            Assert.AreEqual("Age", memberValue.name);
            Assert.AreEqual(12, memberValue.value);
        }

        [Test]
        public void WithNarutosDojoAndMasterName_ShouldReturnMasterNameNaruto()
        {
            MemberValueTuple memberValue = Functions.EvaluateMemberValue(Accessor(narutosDojo, d => d.Master.Name));
            Assert.AreEqual("Master.Name", memberValue.name);
            Assert.AreEqual("Naruto", memberValue.value);
        }

        [Test]
        public void WithNullAndAge_ShouldReturnAgeAndNull()
        {
            MemberValueTuple memberValue = Functions.EvaluateMemberValue(Accessor<Ninja>(null, n => n.Name));
            Assert.AreEqual("Name", memberValue.name);
        }

        [Test]
        public void WithNinjaNarutoAndNull_ShouldReturnEmptyStringAndNull()
        {
            MemberValueTuple memberValue = Functions.EvaluateMemberValue(Accessor(naruto, null));
            Assert.IsEmpty(memberValue.name);
            Assert.IsNull(memberValue.value);
        }
    }
}