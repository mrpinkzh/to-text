using System;
using NUnit.Framework;

namespace ToText.Core
{
    [TestFixture]
    public class IndentationFunctions_Indent
    {
        [Test]
        public void WithString_And2_ShouldReturnStringWithIndentation2()
        {
            string result = IndentationFunctions.Indent("String", 2);
            Assert.AreEqual("  String", result);
        }

        [Test]
        public void WithMultiLineString_And3_ShouldIndentAllLinesWith3()
        {
            string result = IndentationFunctions.Indent("MultiLine".NewLine().Add("String"), 3);
            Assert.AreEqual("   MultiLine"+Environment.NewLine
                          + "   String",
                            result);
        }

        [Test]
        public void WithNull_And1_ShouldReturnNull()
        {
            Assert.IsNull(IndentationFunctions.Indent(null, 1));
        }

        [Test]
        public void WithString_AndMinus3_ShouldReturnUnindetedString()
        {
            string result = IndentationFunctions.Indent("String", -3);
            Assert.AreEqual("String", result);
        }
    }
}