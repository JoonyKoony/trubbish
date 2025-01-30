﻿using System;

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

    private static void StartSurvey(int numQuestionsToAsk)
    {
        
    }

    private static string AskQuestion()
    {
        return "helloworld";
    }
}