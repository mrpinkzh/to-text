namespace ToText.Configuration
{
    public class EnumerableConfiguration
    {
        public const string DefaulShortStringSeparator = ", ";
        public const int DefaultShortStringLimit = 100;
        public const string DefaultLongStringSeparator = ",\r\n";

        public static EnumerableConfiguration Default() { return new EnumerableConfiguration(); }

        private readonly string shortStringSeparator;
        private readonly int shortStringLimit;
        private readonly string longStringSeparator;

        public EnumerableConfiguration(
            string shortStringSeparator = DefaulShortStringSeparator, 
            int shortStringLimit = DefaultShortStringLimit, 
            string longStringSeparator = DefaultLongStringSeparator)
        {
            this.longStringSeparator = longStringSeparator;
            this.shortStringLimit = shortStringLimit;
            this.shortStringSeparator = shortStringSeparator;
        }

        public string ShortStringSeparator
        {
            get { return shortStringSeparator; }
        }

        public int ShortStringLimit
        {
            get { return shortStringLimit; }
        }

        public string LongStringSeparator
        {
            get { return longStringSeparator; }
        }
    }
}