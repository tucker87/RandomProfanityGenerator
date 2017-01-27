using System;
using System.Linq;

namespace RandomProfanityGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            var profanityGenerator = new ProfanityGenerator();

            while (true)
            {
                for (var c = 0; c < 10; c++)
                    Console.WriteLine(profanityGenerator.BuildSentence().ToString());

                Console.ReadLine();
            }
        }   
    }
}
