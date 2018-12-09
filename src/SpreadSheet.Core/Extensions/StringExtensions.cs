using System;
using System.Collections.Generic;
using System.Text;

namespace SpreadSheet.Extensions
{
    public static class StringExtensions
    {
        public static string Repeat(this string str, int repeatCount, string separator = "")
        {
            var sb = new StringBuilder();
            for (var i = 0; i < repeatCount; i++)
            {
                sb.Append($"{str}{separator}");
            }
            return sb.Remove((sb.Length - separator.Length), separator.Length).ToString();
        }
    }
}
