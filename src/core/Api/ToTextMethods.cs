using System;
using System.Linq.Expressions;

namespace ToText.Api
{
    public static class ToTextMethods
    {
        public static string ToText<T>(this T item, params Expression<Func<T, dynamic>>[] members)
        {
            string type = typeof (T).Name;
            int minMemberNameSize = members.MaxMemberLength();
            if (members.HasMembers())
                return string.Format("{0}: {1}", type, members.EnBlock(m => m.PrintMember(item, minMemberNameSize)));
            return type;
        }
    }
}