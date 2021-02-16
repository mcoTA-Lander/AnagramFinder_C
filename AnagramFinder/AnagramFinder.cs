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
            foreach(List<String> ls in s)
            {
                Console.WriteLine(ls.ToString());
            }
        }

        public List<List<String>> FindAllAnagramsWithDuplicateLetters(List<String> wordList)
        {
            List<List<String>> anagrams = new List<List<String>>();
            List<String> temp = new List<String>();
            String s1, s2;
            char[] c1, c2;
            if (wordList == null)
            {
                throw new ArgumentException("Param 'wordList' is null or empty");
            }
            if (wordList.Count == 0)
            {
                return anagrams;
            }
            if (wordList.Count == 1)
            {
                return anagrams;
            }
            if (wordList.Count == 2)
            {
                c1 = wordList[0].ToLower().ToCharArray();
                c2 = wordList[1].ToLower().ToCharArray();
                Array.Sort(c1);
                Array.Sort(c2);
                if (c1.ToString().Equals(c2.ToString()))
                {
                    wordList.Sort(StringComparer.OrdinalIgnoreCase);
                    anagrams.Add(wordList);
                }
                return anagrams;
            }

            bool[] added = new bool[wordList.Count];

            nullOrEmptyCheck(wordList);
            wordList = removeDuplicate(wordList);
            wordList.Sort(StringComparer.OrdinalIgnoreCase);

            for (int i = 0; i < wordList.Count; i++)
            {
                s1 = wordList[i];
                for (int j = i + 1; j < wordList.Count; j++)
                {
                    s2 = wordList[j];
                    if (!s1.Equals(s2))
                    {
                        c1 = s1.ToLower().ToCharArray();
                        c2 = s2.ToLower().ToCharArray();
                        Array.Sort(c1);
                        Array.Sort(c2);
                        if (c1.ToString().Equals(c2.ToString()))
                        {
                            temp.Add(s2);
                            added[j] = true;
                        }
                    }
                    else
                    {
                        added[j] = true;
                    }
                }
                if (!added[i])
                {
                    temp.Add(s1);

                    anagrams.Add(new List<String>(temp));
                }
                temp.Clear();
            }
            foreach (List<String> h in anagrams)
            {
                h.Sort(StringComparer.OrdinalIgnoreCase);
            }
            return anagrams;
        }

        private void nullOrEmptyCheck(List<String> wordList)
        {
            foreach (String w in wordList)
            {
                if (w == null || w.Equals(""))
                {
                    throw new ArgumentException("Param 'wordList' contains null or empty val");
                }
            }
        }

        public List<String> removeDuplicate(List<String> wordList)
        {
            return new List<String>(new HashSet<String>(wordList));
        }

    }
}
