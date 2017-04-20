using System;

namespace RandomProfanityGenerator
{
    public class SentencePattern
    {
        public WordFilter[] WordFilters { get; set; }
        public SentencePattern (params WordFilter[] wordFilters)
        {
            WordFilters = wordFilters;
        }
    }
}
