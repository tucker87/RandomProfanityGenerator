using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace RandomProfanityGenerator
{
    public class ProfanityGenerator
    {
        private readonly Random _random = new Random();
        private List<string> Profanities { get; }
        private List<string> Starters { get; }
        public ProfanityGenerator()
        {
            Profanities = XDocument.Load("swearWords.xml")
                .Descendants("word")
                .Select(word => word.Value)
                .ToList();

            var sentences = XDocument.Load("sentenceStructures.xml")
                .Descendants("sentence").ToList();

            Starters = sentences
                .SelectMany(sentence => sentences.Descendants("first"))
                .Select(f => f.Value).ToList();
        }

        public string GetRandomOpener()
        {
            return Starters[_random.Next(Starters.Count)];
        }

        public string GetRandomProfanity()
        {
            return Profanities[_random.Next(Profanities.Count)];
        }

        public string BuildSentence()
        {
            var profanity = new List<string> {GetRandomOpener()};

            var numberOfWords = _random.Next(3, 8);
            for (var i = 0; i < numberOfWords; i++)
                profanity.Add(GetRandomProfanity());

            return string.Join(" ", profanity);
        }
    }
}