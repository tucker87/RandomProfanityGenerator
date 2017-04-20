using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace RandomProfanityGenerator
{
    public class ProfanityGenerator
    {
        private readonly Random _random = new Random();
        public List<Word> Words { get; set; }
        private Dictionary<Type, Func<List<Word>>> WordTypes { get; set; }
        public List<SentencePattern> Patterns { get; set; }
        public ProfanityGenerator()
        {
            Words = JsonConvert.DeserializeObject<List<Word>>(File.ReadAllText("swearWords.json"), new WordConverter());
            
            WordTypes = new Dictionary<Type, Func<List<Word>>>
            {
                { typeof(Noun), () => Words.OfType<Noun>().Select(n => (Word)n).ToList()},
                { typeof(Subject), () => Words.OfType<Subject>().Select(n => (Word)n).ToList()},
                { typeof(Verb), () => Words.OfType<Verb>().Select(n => (Word)n).ToList()}
            };

            Patterns = new List<SentencePattern>
            {
                new SentencePattern(typeof(Subject), typeof(Verb), typeof(Noun))
            };
        }
        
        public Word GetRandom(Type wordType)
        {
            return WordTypes[wordType]().Random(_random);
        }

        public T GetRandom<T>() where T : Word
        {
            return (T) WordTypes[typeof(T)]().Random(_random);
        }

        public Sentence BuildSentence()
        {
            var pattern = Patterns.Random(_random);
            return new Sentence(pattern.WordTypes.Select(GetRandom).ToList());
            
        }
    }
}