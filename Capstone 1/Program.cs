using System;

namespace Capstone_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Pig Latin Translator");
            bool run = true;
            while (run)
            {

                Console.WriteLine("Enter a line to be translated:");

                string input = Console.ReadLine().ToLower().Trim();

                while (string.IsNullOrEmpty(input))
                {
                    Console.WriteLine("This can't be empty. Enter a line to be translated:");
                    input = Console.ReadLine().ToLower().Trim();
                }

                string[] words = input.Split();

                foreach (string word in words)
                {
                    TranslateWord(word);
                }

                run = Ask();
            }
        }

        public static void TranslateWord(string input)
        {
            char[] word = input.ToCharArray();

            string output = "";

            int firstVowelIndex = FindFirstVowel(word);

            bool special = FindSpecial(word);

            if (special == true)
            {
                output = input;
            }
            else if (firstVowelIndex == 0)
            {
                output = input + "way";
            }
            else if (firstVowelIndex == -1)
            {
                output = input;
            }
            else
            {
                string prefix = input.Substring(firstVowelIndex);
                string postfix = input.Substring(0, firstVowelIndex) + "ay";
                output = prefix + postfix;
            }

            Console.Write(output + " ");
        }

        public static bool IsVowel(char c)
        {
            char[] vowels = { 'a', 'e', 'i', 'o', 'u' };
            foreach (char vowel in vowels)
            {
                if (vowel == c)
                {
                    return true;
                }
            }

            return false;
        }

        public static int FindFirstVowel(char[] word)
        {
            for (int i = 0; i < word.Length; i++)
            {
                char letter = word[i];
                if (IsVowel(letter))
                {
                    return i;
                }
            }
            return -1;
        }

        public static bool IsSpecial(char s)
        {
            char[] specials = { '!', '@', '#', '$', '%', '^', '&', '*', '(', ')', '-', '_', '+', '=', '1', '2', '3', '4', '5', '6', '7', '8', '9', '0' };
            foreach (char special in specials)
            {
                if (special == s)
                {
                    return true;
                }
            }
            return false;
        }

        public static bool FindSpecial(char[] word)
        {
            for (int i = 0; i < word.Length; i++)
            {
                char letter = word[i];
                if (IsSpecial(letter))
                {
                    return true;
                }
            }
            return false;
        }

        public static bool Ask()
        {
            Console.WriteLine();
            Console.WriteLine("Translate another line? (y/n):");
            string input = Console.ReadLine();
            if (input.ToLower() == "y")
            {
                return true;
            }
            else if (input.ToLower() == "n")
            {
                Console.WriteLine("arewellfay");
                return false;
            }
            else
            {
                Console.WriteLine("Sorry, I did not understand that. Please try again.");
                return Ask();
            }
        }
    }
}
