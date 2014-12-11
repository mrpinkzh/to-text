using NUnit.Framework;
using ToText.Core;

namespace ToText
{
    [TestFixture]
    public class FunctionsTests_EvaluateMemberValue : FunctionsTests_Base
    {
        [Test]
        public void WithNinjaNarutoAndName_ShouldReturnNameAndNaruto()
        {
            MemberValueTuple memberValue = Functions.EvaluateMemberValue(Accessor(naruto, n => n.Name));
            Assert.AreEqual(memberValue.name, "Name");
            Assert.AreEqual(memberValue.value, "Naruto");
        }

        [Test]
        public void WithNinjaNarutoAndAge_ShouldReturnAgeAnd12()
        {
            MemberValueTuple memberValue = Functions.EvaluateMemberValue(Accessor(naruto, n => n.Age));
            Assert.AreEqual(memberValue.name, "Age");
            Assert.AreEqual(memberValue.value, 12);
        }
    }
}