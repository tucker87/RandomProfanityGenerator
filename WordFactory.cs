using System;
using System.Linq;
using System.Reflection;

namespace RandomProfanityGenerator
{
    public static class WordFactory
    {
        public static Word Create(WordType wordType)
        {
            var types = typeof(Word).Assembly.GetTypes()
                .Where(t => !t.IsAbstract && t.IsSubclassOf(typeof(Word)))
                .ToList();

            Word word = null;
            foreach (var type in types)
            {
                var attr = type.GetCustomAttributes<WordTypeAttribute>().First();

                if (attr.WordType != wordType)
                    continue;

                word = Activator.CreateInstance(type) as Word;
                break;
            }

            if (word != null)
                return word;

            var message = $"Could not find a Position to create for id {wordType}.";
            throw new NotSupportedException(message);
        }
    }
}