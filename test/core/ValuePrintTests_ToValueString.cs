﻿using System;
using System.Linq;
using NUnit.Framework;
using ToText.Api;
using ToText.Core;
using ToText.Infrastructure;

namespace ToText
{
    [TestFixture]
    public class ValuePrintTests_ToValueString
    {
        private Ninja naruto;
        private Ninja matsujama;

        [SetUp]
        public void SetupContext()
        {
            naruto = new Ninja { Name = "Naruto", Age = 14};
            matsujama = new Ninja { Name = "Matsujama", Age = 31};
        }

        [Test]
        public void OnTwoNumbers_ShouldReturnCommaSeparated()
        {
            var numbers = new[] {1, 2};
            string valueString = numbers.ToValueString();
            Assert.That(valueString, Is.EqualTo("1, 2"));
        }

        [Test]
        public void OnTwoLittleStrings_ShouldReturnCommaSeparated()
        {
            var littleStrings = new[] {"John", "Little"};
            string valueString = littleStrings.ToValueString();
            Assert.That(valueString, Is.EqualTo("John, Little"));
        }

        [Test]
        public void OnMixedArray_ShouldReturnCommaSeparated()
        {
            var mixed = new dynamic[] {"string", 5};
            string valueString = mixed.ToValueString();
            Assert.That(valueString, Is.EqualTo("string, 5"));
        }

        [Test]
        public void OnComplexObjectWithToTextSelection_ShouldReturnCommaSeparated()
        {
            var ninjas = new[] {naruto, matsujama};
            string valueString = ninjas.Select(n => n.ToText(x => x.Name)).ToValueString();
            Assert.That(valueString, Is.EqualTo("Ninja: Name = 'Naruto', Ninja: Name = 'Matsujama'"));
        }

        [Test]
        public void OnMultiLineComplexObject_ShouldReturnNewLineSeparated()
        {
            var ninjas = new[] {naruto, matsujama};
            string valueString = ninjas.Select(x => x.ToText(n => n.Name,
                                                             n => n.Age)).ToValueString();
            Assert.That(valueString, Is.EqualTo("Ninja: Name = 'Naruto'"    + Environment.NewLine +
                                                "       Age  = '14',"       + Environment.NewLine +
                                                "Ninja: Name = 'Matsujama'" + Environment.NewLine +
                                                "       Age  = '31'"));
        }

        [Test]
        public void OnTwoLongStrings_ShouldReturnNewLineSeparated()
        {
            var longStrings = new[] {"shorty", "and his much much much much much much longer brother"};
            string valueString = longStrings.ToValueString(Format.Configure(enumerableShortStringLimit:25));
            Assert.That(valueString, Is.EqualTo("shorty," + "\r\n" +
                                                "and his much much much much much much longer brother"));
        }

        [Test]
        public void OnNullValues_ShouldReturnNull()
        {
            var strings = new[] {"Hey Jude", null};
            string valueString = strings.ToValueString();
            Assert.That(valueString, Is.EqualTo("Hey Jude, null"));
        }

        [Test]
        public void OnNull_ShouldReturnNull()
        {
            int[] array = null;
            string valueString = array.ToValueString();
            Assert.That(valueString, Is.EqualTo("null"));
        }
    }
}