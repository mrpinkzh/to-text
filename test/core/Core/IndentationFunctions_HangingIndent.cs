using System;
using NUnit.Framework;

namespace ToText.Core
{
    [TestFixture]
    public class IndentationFunctions_HangingIndent
    {
        [Test]
        public void WithString_And3_ShouldReturnUnindentedString()
        {
            string result = IndentationFunctions.HangingIndent("String", 3);
            Assert.AreEqual("String", result);
        }

        [Test]
        public void WithMultiLineString_And2_ShouldReturnMutliLineStringWithSecondLineIndented()
        {
            string result = IndentationFunctions.HangingIndent("MultiLine".NewLine().Add("String"), 2);
            Assert.AreEqual("MultiLine"+Environment.NewLine
                          + "  String",
                            result);
        }

        [Test]
        public void WithNull_And1_ShouldReturnNull()
        {
            Assert.IsNull(IndentationFunctions.HangingIndent(null, 1));
        }

        [Test]
        public void WithPrefix_AndString_ShouldReturnUnintendedPrefixString()
        {
            string result = IndentationFunctions.HangingIndent("Prefix ", "String");
            Assert.AreEqual("Prefix String", result);
        }

        [Test]
        public void WithPrefix_AndMultiLineString_ShouldReturnPrefixedMultiLineStringWithSecondLineIndented()
        {
            string result = IndentationFunctions.HangingIndent("Prefix ", "MultiLine".NewLine().Add("String"));
            Assert.AreEqual("Prefix MultiLine" + Environment.NewLine
                          + "       String",
                            result);
        }

        [Test]
        public void WithNull_AndString_ShouldReturnUnindentedString()
        {
            string result = IndentationFunctions.HangingIndent(null, "String");
            Assert.AreEqual("String", result);
        }

        [Test]
        public void WithPrefix_AndNull_ShouldReturnPrefix()
        {
            string result = IndentationFunctions.HangingIndent("Prefix ", null);
            Assert.AreEqual("Prefix ", result);
        }
    }
}