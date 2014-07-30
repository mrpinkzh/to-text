using System;
using System.Linq.Expressions;

namespace ToText.Api
{
    public static class ToTextMethods
    {
        public static string ToText<T>(this T item, params Expression<Func<T, dynamic>>[] members)
        {
            string type = typeof (T).Name;
            if (members.HasMembers())
                return string.Format("{0}: {1}", type, members.EnBlock(m => m.PrintMember(item)));
            return type;
        }
    }
}