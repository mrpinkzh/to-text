using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using ToText.Configuration;

namespace ToText.Core
{
    public static class Functions
    {
        public static PrintedType PrintType(Type type, string separator)
        {
            if (type == null)
                return new PrintedType(string.Empty, 0);
            string value = string.Format("{0}{1}", type.Name, separator);
            return new PrintedType(value, value.Length);
        }

        public static IReadOnlyCollection<Accessor<T>> CreateAccessors<T>(
            T instance,
            Expression<Func<T, dynamic>>[] memberExpressions)
        {
            var accessors = new Accessor<T>[memberExpressions.Length];
            for (int i = 0; i < memberExpressions.Length; i++)
            {
                accessors[i] = new Accessor<T>(instance, memberExpressions[i]);
            }
            return accessors;
        }

        public static MemberValueTuple EvaluateMemberValue<T>(Accessor<T> accessor)
        {
            string name = MemberExpressionEvaluation.ExtractMemberName(accessor.func);
            dynamic value = EvaluateFunctionValue(accessor);
            return new MemberValueTuple(name, value);
        }

        public static dynamic EvaluateFunctionValue<T>(Accessor<T> accessor)
        {
            if (!typeof(T).IsValueType)
                if (Equals(accessor.instance, default(T)))
                    return null;
            if (accessor.func == null)
                return null;
            return accessor.func.Compile()(accessor.instance);
        }

        public static IReadOnlyCollection<string> PrintMemberList(
            IReadOnlyCollection<MemberValueTuple> memberValueTuples,
            FormatConfiguration format)
        {
            int lengthOfLongestMemberName = memberValueTuples.Select(mv => mv.name.Length).Max();
            return PrintMemberList(memberValueTuples, lengthOfLongestMemberName, format);
        }

        public static IReadOnlyCollection<string> PrintMemberList(
            IReadOnlyCollection<MemberValueTuple> memberValueTuples,
            int lengthOfLongestMemberName,
            FormatConfiguration format)
        {
            if (!memberValueTuples.Any())
                return new string[0];
            MemberValueTuple memberValueTuple = memberValueTuples.FirstOrDefault();
            string printedMember = PrintMember(memberValueTuple, lengthOfLongestMemberName, format);
            var printedMembers = new List<string> {printedMember};
            printedMembers.AddRange(PrintMemberList(memberValueTuples.Skip(1).ToList(), lengthOfLongestMemberName, format));
            return printedMembers;
        }

        private static string PrintMember(MemberValueTuple memberValueTuple, int lengthOfLongestMemberName,
            FormatConfiguration format)
        {
            int amountOfSpaces = lengthOfLongestMemberName - memberValueTuple.name.Length;
            string valuePrefix = string.Format("{0}{1} = {2}", memberValueTuple.name, amountOfSpaces.Spaces(), format.ValueDelimiter);
            string memberValueString = memberValueTuple.value.ToNullAwareString(format.NullValueString);
            string indentedValue = StringFunctions.HangingIndent(memberValueString, valuePrefix.Length);
            return string.Format("{0}{1}{2}", valuePrefix, indentedValue, format.ValueDelimiter);
        }

        public static string PrintHangingIndented(string unindentedPrefix, IReadOnlyCollection<string> lines, FormatConfiguration format)
        {
            return PrintHangingIndented(unindentedPrefix, string.Join(format.NewLineString, lines), format);
        }

        public static string PrintHangingIndented(string unindentedPrefix, string indentedBlock, FormatConfiguration format)
        {
            string[] blockLines = indentedBlock.Split(new[] {format.NewLineString}, StringSplitOptions.None);
            string firstLine = string.Format("{0}{1}", unindentedPrefix, blockLines.FirstOrDefault());
            IEnumerable<string> restLines = Indent(blockLines.Rest(), unindentedPrefix.Length, format);
            return string.Join(format.NewLineString, List(firstLine, restLines));
        }

        public static IReadOnlyCollection<string> Indent(IReadOnlyCollection<string> lines, int indentation, FormatConfiguration format)
        {
            string firstLine = lines.FirstOrDefault();
            if (firstLine == null)
                return new string[0];
            string indentedFirstLine = Indent(firstLine, indentation, format);
            IReadOnlyCollection<string> indentedNextLines = Indent(lines.Rest(), indentation, format);
            return List(indentedFirstLine, indentedNextLines);
        }

        public static string Indent(string line, int indentation, FormatConfiguration format)
        {
            if (line == null)
                return null;
            if (format == null)
                format = Format.Default();
            string[] subLines = line.Split(new[] {format.NewLineString}, StringSplitOptions.None);
            IEnumerable<string> indentedSubLines = subLines.Select(x => string.Format("{0}{1}", indentation.Spaces(), x));
            return string.Join(format.NewLineString, indentedSubLines);
        } 

        public static IReadOnlyCollection<T> List<T>(T firstItem, IEnumerable<T> restItems)
        {
            var list = new List<T>{firstItem};
            list.AddRange(restItems);
            return list;
        }
    }
}