using System;

namespace Cpsc370Final
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] surveyAnswers = StartSurvey(5);
            string username = GenerateUsername(surveyAnswers);
            Console.WriteLine("Generated Username: " + username);
            username = AskForAnotherUsername();
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
            Console.WriteLine(
                $"I hope your new username, '{username}', brings you great joy! Feel free to come back anytime if you ever want a new one.");
        }

        private static string[] AskUserQuestions(string filename)
        {
            //TODO pull questions from file into an array
            return ["bob"];
        }

        public static string[] StartSurvey(int numQuestionsToAsk)
        {
            Console.WriteLine("The survey has started with " + numQuestionsToAsk + " questions.");

            string[] answers = new string[numQuestionsToAsk];

            for (int i = 0; i < numQuestionsToAsk; i++)
            {
                Console.WriteLine($"Question {i + 1}:");
                answers[i] = AskQuestion();
            }

            Console.WriteLine("\nThe survey has ended. Thank you for your participation!");

            return answers;

        }

        private static string AskQuestion()
        {
            QueryAQuestion();
            string userInput;
            do
            {
                Console.Write("Enter your response (1-10 characters, no spaces): ");
                userInput = Console.ReadLine();

                if (!IsValidResponse(userInput))
                {
                    Console.WriteLine("Invalid input. Your response must be between 1-10 characters and cannot contain spaces.");
                }
            } while (!IsValidResponse(userInput));

            return userInput;
        }

        private static bool IsValidResponse(string response)
        {
            return !string.IsNullOrEmpty(response) && response.Length >= 1 && response.Length <= 10 && !response.Contains(" ");
        }

        private static void QueryAQuestion()
        {
            Console.WriteLine("What is your name?");
            //TODO Print a random question from the list of questions
            //TODO Then remove that question from the available questions
        }
        private static string AskForAnotherUsername(string username)
        {
            while (true)
            {
                Console.Write("Would you like to generate another username? (yes/no): ");
                string response = Console.ReadLine()?.Trim().ToLower();

                if (response == "yes")
                {
                    string newUsername = GenerateUsername(words);
                    Console.WriteLine($"Your new username is: {newUsername}");
                }
                else if (response == "no")
                {
                    return newUsername;
                    break;
                }
                else
                {
                    Console.WriteLine("Please enter 'yes' or 'no'.");
                }
            }
        }
    }

    
}