using System.Collections.Generic;
using System.Linq;

namespace RandomProfanityGenerator
{
    public class Sentence
    {
        public Sentence(List<Word> words)
        {
            Subject = words.First();
            Words = words;
        }

        public override string ToString()
        {
            return string.Join(" ", Words.Select(w => w.Read(Subject)));
        }

        public Word Subject { get; set; }
        public List<Word> Words { get; set; }

    }
}