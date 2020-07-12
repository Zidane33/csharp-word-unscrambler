using System;
using System.Linq;
using System.Collections.Generic;

namespace word_unscrambler
{
    class Program
    {
        private const string wordListFileName = "wordlist.txt";
        private static readonly FileReader fileReader = new FileReader();
        private static readonly WordMatcher wordMatcher = new WordMatcher();

        static void Main(string[] args)
        {
            bool continueProgram = true;
            do
            {
                Console.WriteLine("Please enter the option - F for File and M for Manual");
                var option = Console.ReadLine() ?? String.Empty;
                switch (option.ToUpper())
                {
                    case "F":
                        Console.WriteLine("Enter scrambled words file name: ");
                        ExecuteFile();
                        break;
                    case "M":
                        Console.WriteLine("Enter scrambled words manually: ");
                        ExecuteManually();
                        break;
                    default:
                        Console.WriteLine("Option was not recognized");
                        break;
                }

                var continueWord = string.Empty;
                do
                {
                    Console.WriteLine("Do you want to contiue the program?");
                    continueWord = (Console.ReadLine() ?? string.Empty);
                } while (!continueWord.Equals("y", StringComparison.OrdinalIgnoreCase) && !continueWord.Equals("n", StringComparison.OrdinalIgnoreCase));

                continueProgram = continueWord.Equals("y", StringComparison.OrdinalIgnoreCase);

            } while(continueProgram);
        }
        private static void ExecuteManually()
        {
            var manualInput = Console.ReadLine() ?? string.Empty;
            string[] scrambledWords = manualInput.Split(',');
            displayMatchedWords(scrambledWords);
        }

        private static void ExecuteFile()
        {
            try
            {
                var filename = Console.ReadLine() ?? string.Empty;
                string[] scrambledWords = fileReader.Read(filename);
                displayMatchedWords(scrambledWords);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        
        private static void displayMatchedWords(string[] scrambledWords)
        {
            string[] wordList = fileReader.Read(wordListFileName);
            List<MatchedWord> matchedWords = wordMatcher.Match(scrambledWords, wordList);

            if(matchedWords.Any())
            {
                foreach(var word in matchedWords)
                {
                    Console.WriteLine("Match Found for {0}: {1}", word.ScrambledWord, word);
                }
                
            }
            else
            {
                Console.WriteLine("No matches have been found.");
            }
        }
    }
}
