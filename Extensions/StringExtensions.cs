using System;

namespace S78.Extensions
{
    public static class StringExtensions
    {
        /// <summary>
        /// Retrieves a substring from this instance. The substring starts at the beginning and has a specified length.
        /// </summary>
        /// <exception cref="System.ArgumentOutOfRangeException"></exception>
        public static string Left(this string source, int length)
        {
            return source.Substring(0, length);
        }

        /// <summary>
        /// Converts the first charactor of a Unicode string to its uppercase equivalent.
        /// </summary>
        public static string Capitalize(this string source)
        {
            var chars = source.ToCharArray();

            if (chars.Length > 0)
            {
                chars[0] = Char.ToUpper(chars[0]);
            }

            return new String(chars);
        }

        /// <summary>
        /// Splits a string into substrings based on the strings in an array. You can specify whether the substrings include empty array elements.
        /// </summary>
        /// <param name="separators">A string array that delimits the substrings in this string, an empty array that contains no delimiters, or null.</param>
        public static string[] Split(this string source, params string[] separators)
        {
            return source.Split(separators, StringSplitOptions.None);
        }
    }
}
