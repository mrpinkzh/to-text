using NUnit.Framework;
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
            string member = MemberPrint.PrintMember(n => n.Name, naruto);
            Assert.That(member, Is.EqualTo("Name = 'Naruto'"));
        }

        [Test]
        public void WithKazujamaAndAge_ShouldReturnAge30()
        {
            string member = MemberPrint.PrintMember(n => n.Age, kazujama);
            Assert.That(member, Is.EqualTo("Age = '30'"));
        }

        [Test]
        public void WithNarutoAndAgeAnd5_ShouldReturnAgeWithSpacesAnd12()
        {
            string member = MemberPrint.PrintMember(n => n.Age, naruto, minMemberNameLength:5);
            Assert.That(member, Is.EqualTo("Age   = '12'"));
        }

        [Test]
        public void WithNullAndAge_ShouldReturnAgeAndEmptyString()
        {
            string member = MemberPrint.PrintMember(n => n.Age, (Ninja) null);
            Assert.That(member, Is.EqualTo("Age = ''"));
        }

        [Test]
        public void WithNarutoAndNull_ShouldReturnEmptyString()
        {
            string member = MemberPrint.PrintMember(null, naruto);
            Assert.That(member, Is.Empty);
        }
    }
}