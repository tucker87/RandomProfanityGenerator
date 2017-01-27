using System;

namespace RandomProfanityGenerator
{
    public class WordTypeAttribute : Attribute
    {
        public WordTypeAttribute(WordType wordType)
        {
            WordType = wordType;
        }
        public WordType WordType { get; set; }
    }
}