using System;

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
    }
}