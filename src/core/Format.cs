using System;
using ToText.Configuration;

namespace ToText
{
    public static class Format
    {
        public static FormatConfiguration Default()
        {
            return new FormatConfiguration();
        }

        public static FormatConfiguration Configure(
            string newLineString,
            string classToPropertySeparator = FormatConfiguration.DefaultClassToProperatySeparator,
            string nullValueString = FormatConfiguration.DefaultNullValueString,
            string valueDelimiter = FormatConfiguration.DefaultValueDelimiter,
            string enumerableShortStringSeparator = EnumerableConfiguration.DefaulShortStringSeparator,
            string enumerableLongStringSeparator = EnumerableConfiguration.DefaultLongStringSeparator,
            int enumerableShortStringLimit = EnumerableConfiguration.DefaultShortStringLimit)
        {
            return new FormatConfiguration(
                classToPropertySeparator, 
                newLineString, 
                nullValueString, 
                valueDelimiter,
                new EnumerableConfiguration(
                    enumerableShortStringSeparator, 
                    enumerableShortStringLimit,
                    enumerableLongStringSeparator));
        }

        public static FormatConfiguration Configure(
            string classToPropertySeparator = FormatConfiguration.DefaultClassToProperatySeparator,
            string nullValueString = FormatConfiguration.DefaultNullValueString,
            string valueDelimiter = FormatConfiguration.DefaultValueDelimiter,
            string enumerableShortStringSeparator = EnumerableConfiguration.DefaulShortStringSeparator,
            string enumerableLongStringSeparator = EnumerableConfiguration.DefaultLongStringSeparator,
            int enumerableShortStringLimit = EnumerableConfiguration.DefaultShortStringLimit)
        {
            string newLineString = Environment.NewLine;
            return new FormatConfiguration(
                classToPropertySeparator,
                newLineString,
                nullValueString,
                valueDelimiter,
                new EnumerableConfiguration(
                    enumerableShortStringSeparator,
                    enumerableShortStringLimit,
                    enumerableLongStringSeparator));
        }
    }
}