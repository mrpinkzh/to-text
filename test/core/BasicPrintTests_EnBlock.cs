using System;
using System.Collections.Generic;
using NUnit.Framework;
using ToText.Api.Infrastructure;

namespace ToText
{
    [TestFixture]
    public class BasicPrintTests_EnBlock
    {
        [Test]
        public void EnBlock_WithTwoStrings_ShouldSeparateThemWithNewLine()
        {
            IEnumerable<string> strings = new[] {"first", "second"};
            string block = strings.EnBlock(s => s.ToString());
            Assert.That(block, Is.EqualTo("first" + Environment.NewLine +
                                          "second"));
        }

        [Test]
        public void EnBlock_WithTwoIntsAndIncreaseMethod_ShouldReturnIncreasedValuesSeparatedWithNewLine()
        {
            IEnumerable<int> ints = new[] {13, 17};
            string block = ints.EnBlock(i => (++i).ToString());
            Assert.That(block, Is.EqualTo("14" + Environment.NewLine +
                                          "18"));
        }

        [Test]
        public void EnBlock_WithOneString_ShouldReturnString()
        {
            string firstString = CreateRandom.String();
            string block = new[] {firstString}.EnBlock(s => s.ToString());
            Assert.That(block, Is.EqualTo(firstString));
        }

        [Test]
        public void EnBlock_WithIntsAndIndentation3_ShouldIndentFollowerLinesWithThreeSpaces()
        {
            IEnumerable<int> ints = new[] {1, 2, 3};
            string block = ints.EnBlock(i => i.ToString(), indentationOfFollowingLines:3);
            Assert.That(block, Is.EqualTo("1" + Environment.NewLine +
                                          "   2" + Environment.NewLine +
                                          "   3"));
        }

        [Test]
        public void EnBock_OnNull_ShouldReturnEmptyString()
        {
            IEnumerable<int> ints = null;
            string enBlock = ints.EnBlock(i => i.ToString());
            Assert.That(enBlock, Is.EqualTo("null"));
        }

        [Test]
        public void EnBlock_WithNull_ShouldReturnStringValues()
        {
            IEnumerable<int> ints = new[] {2, 3};
            string block = ints.EnBlock(null);
            Assert.That(block, Is.EqualTo("2" + Environment.NewLine +
                                          "3"));
        }
    }
}