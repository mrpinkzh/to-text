using System;
using System.Collections.Generic;
using System.Linq;

namespace ToText.Core
{
    public static class IndentationFunctions
    {
        /// <summary>
        /// Indents the specified <paramref name="value"/> using the specified number of
        /// whitespaces (<paramref name="indentation"/>).
        /// If the <paramref name="value"/> spans over multiple lines (separated by <see cref="Environment.NewLine"/>, 
        /// all of those get indented.
        /// </summary>
        /// <param name="value">
        /// A regular string value or null.
        /// </param>
        /// <param name="indentation">
        /// The amount of whitespaces desired in front of the <paramref name="value"/>.
        /// </param>
        /// <returns>
        /// The <paramref name="value"/> indented by the desired amount of whitespaces.
        /// </returns>
        public static string Indent(this string value, int indentation)
        {
            return Indent(value, indentation, Environment.NewLine);
        }

        /// <summary>
        /// Indents the specified <paramref name="value"/> using the specified number of
        /// whitespaces (<paramref name="indentation"/>).
        /// If the <paramref name="value"/> spans over multiple lines, all of those get indented.
        /// </summary>
        /// <param name="value">
        /// A regular string value or null.
        /// </param>
        /// <param name="indentation">
        /// The amount of whitespaces desired in front of the <paramref name="value"/>.
        /// </param>
        /// <param name="newLineIdentifier">
        /// The newline string used in a possible multi-line string as <paramref name="newLineIdentifier"/>.
        /// </param>
        /// <returns>
        /// The <paramref name="value"/> indented by the desired amount of whitespaces.
        /// </returns>
        public static string Indent(this string value, int indentation, string newLineIdentifier)
        {
            if (value == null) 
                return null;
            IReadOnlyCollection<string> lines = value.SplitLines(newLineIdentifier);
            IEnumerable<string> indentedSubLines = lines.Select(x => String.Format("{0}{1}", indentation.Spaces(), x));
            return String.Join(newLineIdentifier, indentedSubLines);
        }

        /// <summary>
        /// Indents all but the first line of the specified <paramref name="value"/> using the specified number of
        /// whitespaces (<paramref name="indentation"/>).
        /// If the <paramref name="value"/> does not span multiple lines, nothing will get indented.
        /// </summary>
        /// <param name="value">
        /// A regular string value or null.
        /// </param>
        /// <param name="indentation">
        /// The amount of whitespaces desired in front of the second and following lines of <paramref name="value"/>.
        /// </param>
        /// <returns>
        /// The <paramref name="value"/> indented by the desired amount of whitespaces.
        /// </returns>
        public static string HangingIndent(this string value, int indentation)
        {
            return HangingIndent(value, indentation, Environment.NewLine);
        }

        /// <summary>
        /// Indents all but the first line of the specified <paramref name="value"/> using the specified number of
        /// whitespaces (<paramref name="indentation"/>).
        /// If the <paramref name="value"/> does not span multiple lines, nothing will get indented.
        /// </summary>
        /// <param name="value">
        /// A regular string value or null.
        /// </param>
        /// <param name="indentation">
        /// The amount of whitespaces desired in front of the second and following lines of <paramref name="value"/>.
        /// </param>
        /// <param name="newLineIdentifier">
        /// The newline string used in a possible multi-line string as <paramref name="newLineIdentifier"/>.
        /// </param>
        /// <returns>
        /// The <paramref name="value"/> indented by the desired amount of whitespaces.
        /// </returns>
        public static string HangingIndent(this string value, int indentation, string newLineIdentifier)
        {
            if (value == null)
                return null;
            IReadOnlyCollection<string> lines = value.SplitLines(newLineIdentifier);
            IEnumerable<string> indentedSubLines = lines.Rest().Select(x => String.Format("{0}{1}", indentation.Spaces(), x));
            IReadOnlyCollection<string> result = SystemFunctions.Cons(lines.First(), indentedSubLines);
            return String.Join(newLineIdentifier, result);
        }

        /// <summary>
        /// Sets the specified <paramref name="unindentedPrefix"/> in front of the first line of <paramref name="indentedBlock"/>
        /// and indents all following lines by the length of the <paramref name="unindentedPrefix"/> using whitespaces.
        /// </summary>
        /// <param name="unindentedPrefix">
        /// A regular string value or null.
        /// </param>
        /// <param name="indentedBlock">
        /// The amount of whitespaces desired in front of the second and following lines of <paramref name="value"/>.
        /// </param>
        /// <returns>
        /// The <paramref name="indentedBlock"/> prefixed by <paramref name="unindentedPrefix"/> 
        /// and indented by its length.
        /// </returns>
        public static string HangingIndent(string unindentedPrefix, string indentedBlock)
        {
            return HangingIndent(unindentedPrefix, indentedBlock, Environment.NewLine);
        }

        /// <summary>
        /// Sets the specified <paramref name="unindentedPrefix"/> in front of the first line of <paramref name="indentedBlock"/>
        /// and indents all following lines by the length of the <paramref name="unindentedPrefix"/> using whitespaces.
        /// </summary>
        /// <param name="unindentedPrefix">
        /// A regular string value or null.
        /// </param>
        /// <param name="indentedBlock">
        /// The amount of whitespaces desired in front of the second and following lines of <paramref name="value"/>.
        /// </param>
        /// <param name="newLineIdentifier">
        /// The newline string used in a possible multi-line string as <paramref name="newLineIdentifier"/>.
        /// </param>
        /// <returns>
        /// The <paramref name="indentedBlock"/> prefixed by <paramref name="unindentedPrefix"/> 
        /// and indented by its length.
        /// </returns>
        public static string HangingIndent(string unindentedPrefix, string indentedBlock, string newLineIdentifier)
        {
            int indentation = 0;
            if (unindentedPrefix != null)
                indentation = unindentedPrefix.Length;
            return String.Format("{0}{1}", unindentedPrefix, indentedBlock).HangingIndent(indentation);
        }
    }
}