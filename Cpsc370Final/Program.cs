using System;

namespace Cpsc370Final
{
    class Program
    {
        static void Main(string[] args)
        {
            string username = GenerateUsername(args);
            Console.WriteLine("Generated Username: " + username);
            ClosingStatement(username);
        }

        private static string GenerateUsername(string[] words)
        {
            if (words.Length < 2)
            {
                Console.WriteLine("Please provide at least two words.");
                return "DefaultUser" + new Random().Next(100, 999);
            }

            Random random = new Random();
            int index1 = random.Next(words.Length);
            int index2;

            do
            {
                index2 = random.Next(words.Length);
            } while (index1 == index2); // Ensures two different words are chosen

            string combinedWords = words[index1] + words[index2];
            int randomNumber = random.Next(100, 999); // Generate a random number between 100-999

            return combinedWords + randomNumber;
        }

        private static void ClosingStatement(string username)
        {
            Console.WriteLine($"I hope your new username, '{username}', brings you great joy! Feel free to come back anytime if you ever want a new one.");
        }
    }
}