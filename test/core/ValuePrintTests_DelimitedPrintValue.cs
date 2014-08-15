using NUnit.Framework;
using ToText.Api;
using ToText.Core;

namespace ToText
{
    [TestFixture]
    public class ValuePrintTests_DelimitedPrintValue
    {
        [Test]
        public void WithString_ShouldReturnDelimitedString()
        {
            string result = ValuePrint.DelimitedPrintValue("string");
            Assert.That(result, Is.EqualTo("'string'"));
        }

        [Test]
        public void WithStrings_ShouldReturnDelimitedStrings()
        {
            string result = ValuePrint.DelimitedPrintValue(new[] {"string", "wing"});
            Assert.That(result, Is.EqualTo("'string, wing'"));
        }

        [Test]
        public void WithMixed_ShouldReturnDelimitedStrings()
        {
            string result = ValuePrint.DelimitedPrintValue(new dynamic[] {"string", 7});
            Assert.That(result, Is.EqualTo("'string, 7'"));
        }

        [Test]
        public void WithNull_ShouldReturnSpacePrecededNull()
        {
            string result = ValuePrint.DelimitedPrintValue(null);
            Assert.That(result, Is.EqualTo(" null"));
        }

        [Test]
        public void WithNullDelimiter_ShouldReturnUndelimitedString()
        {
            string result = ValuePrint.DelimitedPrintValue("string", Format.Configure(valueDelimiter:null));
            Assert.That(result, Is.EqualTo("string"));
        }

        [Test]
        public void WithNullAndNullDelimiter_ShouldReturnUndelimitedNull()
        {
            string result = ValuePrint.DelimitedPrintValue(null, Format.Configure(valueDelimiter:null));
            Assert.That(result, Is.EqualTo("null"));
        }
    }
}