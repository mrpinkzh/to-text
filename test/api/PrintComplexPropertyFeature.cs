﻿using System;
using NUnit.Framework;
using ToText.Core;
using ToText.Infrastructure;

namespace ToText.Api
{
    [TestFixture]
    public class PrintComplexPropertyFeature
    {
        private Dojo miyagisDojo;

        [SetUp]
        public void SetupContext()
        {
            miyagisDojo = new Dojo { Master = new Ninja { Name = "Miyagi", Age = 78} };
        }

        [Test]
        public void OnDojo_WithMaster_ShouldReturnDojosMaster()
        {
            string text = miyagisDojo.ToText(d => d.Master);
            Assert.That(text, Is.EqualTo("Dojo: Master = 'ToText.Infrastructure.Ninja'"));
        }

        [Test]
        public void OnDojo_WithMasterName_ShouldReturnDojoAndMiyagi()
        {
            string text = miyagisDojo.ToText(d => d.Master.Name);
            Assert.That(text, Is.EqualTo("Dojo: Master.Name = 'Miyagi'"));
        }

        [Test]
        public void OnDojo_WithMasterAndWithName_ShouldReturnDojoAndMiyagi()
        {
            string text = miyagisDojo.ToText(d => d.Master.ToText(m => m.Name));
            Assert.That(text, Is.EqualTo("Dojo: Master = 'Ninja: Name = 'Miyagi''"));
        }

        [Test]
        public void OnDojo_WithMasterAndAgeAndName_ShouldReturnDojoAndMiyageAnd78()
        {
            string text = miyagisDojo.ToText(d => d.Master.ToText(m => m.Name,
                                                                  m => m.Age  ));
            Assert.That(text, Is.EqualTo("Dojo: Master = 'Ninja: Name = 'Miyagi'" + Environment.NewLine +
                                         "                       Age  = '78''"));
        }
    }
}