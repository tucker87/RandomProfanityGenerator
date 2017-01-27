using System;

namespace RandomProfanityGenerator
{
    public class SentencePattern
    {
        public Type[] WordTypes { get; set; }
        public SentencePattern(params Type[] wordTypes)
        {
            WordTypes = wordTypes;
        }
    }
}
