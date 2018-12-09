using System;
using System.Collections.Generic;
using System.Linq;

namespace SpreadSheet.Extensions
{
    public static class ArrayExtensions
    {
        public static IEnumerable<T[]> CutArrayForAppointCount<T>(this T[] array, int cutCount)
        {
            var result = new List<T[]>();
            if (array.Length % cutCount != 0)
            {
                throw new ArgumentException("无法为指定的数组切分为指定的段数");
            }
            for (var i = 0; i < array.Length; i += cutCount)
            {
                result.Add(array.Skip(i).Take(cutCount).ToArray());
            }

            return result;
        }
    }
}
