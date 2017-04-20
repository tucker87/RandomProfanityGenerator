using System;
using System.Collections.Generic;
using System.Linq;

namespace RandomProfanityGenerator
{
    public class WordFilter
    {
        public Type WordType { get; set; }
        public List<Func<Word, bool>> Filters { get; set; }

        public static WordFilter CreateFilter<T>(params Func<Word, bool>[] filters)
        {
            var wordFilter = new WordFilter
            {
                WordType = typeof(T),
                Filters = filters.ToList()
            };

            return wordFilter;
        }

    }
}
