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
        //private Dictionary<WordFilter, Func<List<Word>>> WordTypes { get; set; }
        public List<SentencePattern> Patterns { get; set; }
        public ProfanityGenerator()
        {
            Words = JsonConvert.DeserializeObject<List<Word>>(File.ReadAllText("swearWords.json"), new WordConverter());
            
            Patterns = new List<SentencePattern>
            {
                new SentencePattern(
                    WordFilter.CreateFilter<Subject>(s => !s.Possessive), 
                    WordFilter.CreateFilter<Verb>(), 
                    WordFilter.CreateFilter<Noun>()),

                new SentencePattern(
                    WordFilter.CreateFilter<Subject>(s => s.Possessive), 
                    WordFilter.CreateFilter<Person>(), 
                    WordFilter.CreateFilter<Verb>(), 
                    WordFilter.CreateFilter<Noun>())
            };
        }
        
        public Word GetRandom(WordFilter wordFilter)
        {
            return Words
                .Where(w => w.GetType() == wordFilter.WordType)
                .Where(w => wordFilter.Filters.All(f => f(w)))
                .ToList()
                .Random(_random);
        }

        //public T GetRandom<T>() where T : Word
        //{
        //    return (T) WordTypes[new WordFilter<T>()]().Random(_random);
        //}

        public Sentence BuildSentence()
        {
            var pattern = Patterns.Random(_random);
            return new Sentence(pattern.WordFilters.Select(GetRandom).ToList());
            
        }
    }
}