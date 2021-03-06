﻿using System.Collections.Generic;
using NUnit.Framework;

namespace ToText.Core
{
    [TestFixture]
    public class FunctionsTests_PrintMemberList
    {
        [Test]
        public void WithMembersAgeAndName_ShouldPrintBoth()
        {
            var memberValueTuples = new[] {MemberValueTuple("Age", 12), MemberValueTuple("Name", "Naruto")};
            IReadOnlyCollection<string> printedMembers = Functions.PrintMemberList(memberValueTuples, Format.Default());
            Assert.That(printedMembers.Count, Is.EqualTo(2));
            Assert.That(printedMembers, Has.Member("Age  = '12'"));
            Assert.That(printedMembers, Has.Member("Name = 'Naruto'"));
        }

        private static MemberValueTuple MemberValueTuple(string name, dynamic value)
        {
            return new MemberValueTuple(name, value);
        }
    }
}