using System;
using System.Collections.Generic;

namespace RandomProfanityGenerator
{
    public static class Extensions
    {
        public static T Random<T>(this List<T> list, Random rnd)
        {
            return list[rnd.Next(list.Count)];
        }

        public static T ToEnum<T>(this string value)
        {
            return (T)Enum.Parse(typeof(T), value, true);
        }
    }
}
