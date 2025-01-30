using System;

namespace Cpsc370Final
{
    class Program
    {
        static void Main(string[] args)
        {
            string username = GenerateUsername(args);
            Console.WriteLine("Generated Username: " + username);
        }

        private static string GenerateUsername(string[] words)
        {
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
    }
    
    public static void ClosingStatement(string username)
    {
        Console.WriteLine($"I hope your new username, '{username}', brings you great joy! Feel free to come back anytime if you ever want a new one.");
    }
  
    private static string[] AskUserQuestions(string filename)
    {
        //TODO pull questions from file into an array
        return ["bob"];
    }

    private static string[] StartSurvey(int numQuestionsToAsk)
    {
        Console.WriteLine("The survey has started!");
        
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
        string unverifiedAnswer;
        QueryAQuestion();
        do
        {
            Console.Write("Enter your response (1-10 characters, no spaces): ");
            unverifiedAnswer = Console.ReadLine();

            if (unverifiedAnswer.Length < 1 || unverifiedAnswer.Length > 10 || unverifiedAnswer.Contains(" "))
            {
                Console.WriteLine("Invalid input. Your response must be between 1-10 characters and cannot contain spaces.");
            }
            else
            {
                break;
            }
        } while (true);

        return unverifiedAnswer;
    }

    private static void QueryAQuestion()
    {
        //TODO Print a random question from the list of questions
        //TODO Then remove that question from the available questions
    }
}