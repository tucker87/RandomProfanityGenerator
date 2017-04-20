using System.CodeDom;
using System.Linq;

namespace RandomProfanityGenerator
{
    public class Word
    {
        public Word()
        {
        }

        public Word(Word word)
        {
            Base = word.Base;
            Possessive = word.Possessive;
            Target = word.Target;
            Type = word.Type;
        }

        public static string Plural(string singular)
        {
            if(singular.Last() == 'y')
                return singular.Substring(0, singular.Length - 1) + "ies";

            return singular + "s";
        }

        public string Base { get; set; }
        public bool Possessive { get; set; }
        public bool Target { get; set; }
        public WordType Type { get; set; }

        public override string ToString()
        {
            return Base;
        }

        public virtual string Read(Word subject) => Base;
    }

    [WordType(WordType.Noun)]
    public class Noun : Word
    {
    }

    [WordType(WordType.Adjective)]
    public class Adjective : Word
    {
    }

    [WordType(WordType.Adverb)]
    public class Adverb : Word
    {
    }

    [WordType(WordType.Verb)]
    public class Verb : Word
    {
        public override string Read(Word subject)
        {
            return subject.Possessive 
                ? Plural(Base) 
                : Base;
        }
    }

    [WordType(WordType.Participle)]
    public class Participle : Word
    {
    }

    [WordType(WordType.Subject)]
    public class Subject : Word
    {
    }

    [WordType(WordType.Person)]
    public class Person : Word
    {
    }
}
