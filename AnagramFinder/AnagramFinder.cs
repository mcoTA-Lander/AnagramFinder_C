using System;
using System.Collections.Generic;
using System.Linq;

namespace AnagramFinderNS
{
    public class AnagramFinder
    {
        public static void Main(string[] args)
        {
            AnagramFinder af = new AnagramFinder();
            List<String> l = new List<String> { "lead", "silent", "dale", "talent", "new york times", "vile", "talent", "deal", "listen", "monkeys write", "evil" };
            List<List<String>> s = af.FindAllAnagramsWithDuplicateLetters(l);
            s.ForEach(Console.WriteLine);
        }

        public List<List<String>> FindAllAnagramsWithDuplicateLetters(List<String> wordList)
        {
         
        }
    }
}
