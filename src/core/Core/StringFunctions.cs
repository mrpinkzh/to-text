using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;

namespace ToText.Core
{
    public static class StringFunctions
    {
        public static IReadOnlyCollection<string> SplitLines(this string item, string newLineIdentifier)
        {
            return item.Split(new []{newLineIdentifier}, StringSplitOptions.None);
        }

        public static string ToNullAwareString(this object instance, string nullString = "null")
        {
            if (instance == null)
                return nullString;
            return instance.ToString();
        }

        public static string Indent(this string value, int indentation)
        {
            return Indent(value, indentation, Environment.NewLine);
        }

        public static string Indent(this string value, int indentation, string newLineIdentifier)
        {
            IReadOnlyCollection<string> lines = value.SplitLines(newLineIdentifier);
            IEnumerable<string> indentedSubLines = lines.Select(x => string.Format("{0}{1}", indentation.Spaces(), x));
            return string.Join(newLineIdentifier, indentedSubLines);
        }

        public static string HangingIndent(this string value, int indentation)
        {
            return HangingIndent(value, indentation, Environment.NewLine);
        }

        public static string HangingIndent(this string value, int indentation, string newLineIdentifier)
        {
            IReadOnlyCollection<string> lines = value.SplitLines(newLineIdentifier);
            IEnumerable<string> indentedSubLines = lines.Rest().Select(x => string.Format("{0}{1}", indentation.Spaces(), x));
            IReadOnlyCollection<string> result = SystemFunctions.Cons(lines.First(), indentedSubLines);
            return string.Join(newLineIdentifier, result);
        }

        public static string HangingIndent(string unindentedPrefix, string indentedBlock)
        {
            return HangingIndent(unindentedPrefix, indentedBlock, Environment.NewLine);
        }

        public static string HangingIndent(string unindentedPrefix, string indentedBlock, string newLineIdentifier)
        {
            return string.Format("{0}{1}", unindentedPrefix, indentedBlock).HangingIndent(unindentedPrefix.Length);
        }
    }
}