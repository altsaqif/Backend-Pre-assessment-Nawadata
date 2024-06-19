using System;
using System.Text;

namespace TestLogicNawadata
{
    public class Program
    {
        // Global Variable
        private string data = "aiueo";

        // Method Dictionary
        private Dictionary<char, int>GetCharacterCount(string param, string targetChars, bool isVowel)
        {
            var count = new Dictionary<char, int>();

            foreach (var c in param.ToLower())
            {
                if (char.IsWhiteSpace(c))
                    continue;

                bool isTargetChar = isVowel ? targetChars.Contains(c) : !targetChars.Contains(c) && char.IsLetter(c);

                if (isTargetChar)
                {
                    if (!count.ContainsKey(c))
                    {
                        count[c] = 0;
                    }
                    count[c]++;
                }
            }

            return count;
        }

        // Method Vowel
        public string procVowel(string param)
        {
            // Logic Vowel
            StringBuilder result = new StringBuilder();

            var count = GetCharacterCount(param, data, true);

            foreach (var c in param.ToLower())
            {
                if (char.IsWhiteSpace(c))
                    continue;

                if (data.Contains(c) && count.ContainsKey(c) && count[c] > 0)
                {
                    for (var i = 0; i < count[c]; i++)
                    {
                        result.Append(c);
                    }
                    count[c] = 0;
                }
            }

            return result.ToString();
        }

        // Method Consonant
        public string procConsonant(string param)
        {
            // Logic Consonnant
            StringBuilder result = new StringBuilder();

            var count = GetCharacterCount(param, data, false);

            foreach (var c in param.ToLower())
            {
                if (char.IsWhiteSpace(c))
                    continue;

                if (!data.Contains(c) && char.IsLetter(c) && count.ContainsKey(c) && count[c] > 0)
                {
                    for (var i = 0; i < count[c]; i++)
                    {
                        result.Append(c);
                    }
                    count[c] = 0;
                }
            }

            return result.ToString();
        }

        // Method Main
        public void Main()
        {
            Console.Write("Input one line of words (S) : ");
            var input = Console.ReadLine() ?? string.Empty;

            var charVowel = procVowel(input);
            var charConsonant = procConsonant(input);

            Console.WriteLine("Vowel Characters : ");
            Console.WriteLine(charVowel);
            Console.WriteLine("Consonant Characters : ");
            Console.WriteLine(charConsonant);
        }
    }

    class EntryPoint
    {
        static void Main(string[] args)
        {
            Program program = new Program();
            program.Main();
        }
    }
}
