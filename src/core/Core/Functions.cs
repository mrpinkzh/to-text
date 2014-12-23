using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection.Emit;

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
            string delimiter)
        {
            int lengthOfLongestMemberName = memberValueTuples.Select(mv => mv.name.Length).Max();
            return PrintMemberList(memberValueTuples, lengthOfLongestMemberName, delimiter);
        }

        public static IReadOnlyCollection<string> PrintMemberList(
            IReadOnlyCollection<MemberValueTuple> memberValueTuples,
            int lengthOfLongestMemberName,
            string delimiter)
        {
            if (!memberValueTuples.Any())
                return new string[0];
            MemberValueTuple memberValueTuple = memberValueTuples.FirstOrDefault();
            string printedMember = PrintMember(memberValueTuple, lengthOfLongestMemberName, delimiter);
            var printedMembers = new List<string> {printedMember};
            printedMembers.AddRange(PrintMemberList(memberValueTuples.Skip(1).ToList(), lengthOfLongestMemberName, delimiter));
            return printedMembers;
        }

        private static string PrintMember(MemberValueTuple memberValueTuple, int lengthOfLongestMemberName,
            string delimiter)
        {
            int amountOfSpaces = lengthOfLongestMemberName - memberValueTuple.name.Length;
            return string.Format("{0}{1}{2}{3}{4}{5}",
                memberValueTuple.name,
                amountOfSpaces.Spaces(),
                " = ",
                delimiter,
                memberValueTuple.value,
                delimiter);
        }
    }
}