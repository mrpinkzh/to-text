using NUnit.Framework;
using ToText.Core;
using ToText.Infrastructure;

namespace ToText
{
    [TestFixture]
    public class MemberPrintTests_PrintMember
    {
        private Ninja naruto;
        private Ninja kazujama;

        [SetUp]
        public void SetupContext()
        {
            naruto = new Ninja {Age = 12, Name = "Naruto"};
            kazujama = new Ninja {Age = 30, Name = "Kazujama"};
        }

        [Test]
        public void WithNarutoAndName_ShouldRerturnNameNaruto()
        {
            string member = naruto.PrintMember(n => n.Name);
            Assert.That(member, Is.EqualTo("Name = 'Naruto'"));
        }

        [Test]
        public void WithKazujamaAndAge_ShouldReturnAge30()
        {
            string member = kazujama.PrintMember(k => k.Age);
            Assert.That(member, Is.EqualTo("Age = '30'"));
        }

        [Test]
        public void WithNarutoAndAgeAnd5_ShouldReturnAgeWithSpacesAnd12()
        {
            string member = naruto.PrintMember(k => k.Age, minMemberNameLength:5);
            Assert.That(member, Is.EqualTo("Age   = '12'"));
        }

        [Test]
        public void WithNullAndAge_ShouldReturnAgeAndEmptyString()
        {
            string member = MemberPrint.PrintMember((Ninja) null, n => n.Age);
            Assert.That(member, Is.EqualTo("Age = ''"));
        }
    }
}