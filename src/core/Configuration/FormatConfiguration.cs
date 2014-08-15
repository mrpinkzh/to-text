using System;

namespace ToText.Configuration
{
    public class FormatConfiguration
    {
        public const string DefaultClassToProperatySeparator = ": ";
        public const string DefaultNullValueString = "null";
        public const string DefaultValueDelimiter = "'";

        private readonly string classToPropertySeparator;
        private readonly string newLineString;
        private readonly string nullValueString;
        private readonly string valueDelimiter;
        private readonly EnumerableConfiguration enumerableConfiguration;

        public FormatConfiguration(
            string classToPropertySeparator = DefaultClassToProperatySeparator, 
            string newLineString = null, 
            string nullValueString = DefaultNullValueString, 
            string valueDelimiter = DefaultValueDelimiter, 
            EnumerableConfiguration enumerableConfiguration = null)
        {
            if (newLineString == null)
                newLineString = Environment.NewLine;
            if (enumerableConfiguration == null)
                enumerableConfiguration = EnumerableConfiguration.Default();
            this.classToPropertySeparator = classToPropertySeparator;
            this.enumerableConfiguration = enumerableConfiguration;
            this.newLineString = newLineString;
            this.nullValueString = nullValueString;
            this.valueDelimiter = valueDelimiter;
        }

        public string ClassToPropertySeparator
        {
            get { return classToPropertySeparator; }
        }

        public string NewLineString
        {
            get { return newLineString; }
        }

        public string NullValueString
        {
            get { return nullValueString; }
        }

        public EnumerableConfiguration Enumerable
        {
            get { return enumerableConfiguration; }
        }

        public string ValueDelimiter
        {
            get
            {
                if (valueDelimiter == null)
                    return string.Empty;
                return valueDelimiter;
            }
        }
    }
}