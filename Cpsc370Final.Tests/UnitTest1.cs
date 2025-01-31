namespace Cpsc370Final.Tests;

public class UnitTest1
{
    [Fact]
    public void questions()
    {
    }
    
    [Theory]
    [InlineData(new string[] { "Hello", "World", "Turtle", "CSharp", "Code", "Quick", "Test", "Array", "Single", "Word" }, true)] // All valid
    [InlineData(new string[] { "Hello World", "Turtle", "CSharp", "Code", "Quick", "Test", "Array", "Single", "Word", "Valid" }, false)] // One invalid (contains space)
    [InlineData(new string[] { "ThisIsTooLong", "Turtle", "CSharp", "Code", "Quick", "Test", "Array", "Single", "Word", "Valid" }, false)] // One invalid (too long)
    [InlineData(new string[] { " ", "Turtle", "CSharp", "Code", "Quick", "Test", "Array", "Single", "Word", "Valid" }, false)] // One invalid (only space)
    [InlineData(new string[] { "Hello", "World", "Turtle", "CSharp", "Code", "Quick", "Test", "Array", "Single", " " }, false)] // Last one invalid
    public void ValidateArrayOfStrings(string[] inputArray, bool expected)
    {
        // Arrange

        // Act
        bool isValid = inputArray.All(input => input.Length < 10 && !input.Contains(" "));

        // Assert
        Assert.Equal(expected, isValid);
    }
    
    [Fact]
    public void ClosingStatement_PrintsExpectedMessage()
    {
        // Arrange
        string username = "EpicGamer42";
        string expectedMessage = $"I hope your new username, '{username}', brings you great joy! Feel free to come back anytime if you ever want a new one.\n";

        using (StringWriter sw = new StringWriter())
        {
            Console.SetOut(sw); // Redirect console output

            // Act
            Cpsc370Final.Program.ClosingStatement(username);
            
            // Assert
            Assert.Equal(expectedMessage, sw.ToString());
        }
    }

    [Fact]
    public void AskForAnotherUsername_GeneratesNewUsername_WhenUserSaysYesThenNo()
    {
        // Arrange
        string[] words = { "Cool", "Swift", "Epic" };
        string initialUsername = "Cool123";
        string userInput = "yes\nno\n"; // Simulating user typing "yes" then "no"
        
        using (StringReader sr = new StringReader(userInput))
        using (StringWriter sw = new StringWriter())
        {
            Console.SetIn(sr);  // Redirect input
            Console.SetOut(sw); // Redirect output

            // Act
            string finalUsername = Cpsc370Final.Program.AskForAnotherUsername(initialUsername, words);

            // Assert
            Assert.NotEqual(initialUsername, finalUsername); // Ensures a new username was generated
        }
    }

    [Fact]
    public void AskForAnotherUsername_ReturnsSameUsername_WhenUserSaysNoImmediately()
    {
        // Arrange
        string[] words = { "Cool", "Swift", "Epic" };
        string initialUsername = "Cool123";
        string userInput = "no\n"; // Simulating user typing "no"

        using (StringReader sr = new StringReader(userInput))
        using (StringWriter sw = new StringWriter())
        {
            Console.SetIn(sr);  // Redirect input
            Console.SetOut(sw); // Redirect output

            // Act
            string finalUsername = Cpsc370Final.Program.AskForAnotherUsername(initialUsername, words);

            // Assert
            Assert.Equal(initialUsername, finalUsername); // Ensures username remains unchanged
        }
    }
    
    
    public class UsernameGeneratorTests
    {
        [Fact]
        public void GenerateUsername_ReturnsString()
        {
            // Arrange
            string[] words = { "Alpha", "Bravo" };

            // Act
            string result = GenerateUsername(words);

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
        }

        private static string GenerateUsername(string[] words)
        {
            if (words.Length < 2)
            {
                return "DefaultUser" + new Random().Next(100, 999);
            }

            return words[0] + words[1] + new Random().Next(100, 999);
        }
    }
    
    public class GiveQuestionTests
    {
        private readonly string testFilePath = Path.Combine(Directory.GetCurrentDirectory(), "List_of_questions.txt");

        public GiveQuestionTests()
        {
            // Ensure a clean test environment before each test
            if (File.Exists(testFilePath))
            {
                File.Delete(testFilePath);
            }

            // Clear the static list of questions before each test
            typeof(Program)
                .GetField("questionsList", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Static)
                ?.SetValue(null, new List<string>());
        }

        [Fact]
        public void GiveQuestion_ShouldReturnNoQuestions_WhenFileDoesNotExist()
        {
            // Ensure the file does not exist
            if (File.Exists(testFilePath))
                File.Delete(testFilePath);

            // Act
            string result = Program.GiveQuestion();

            // Assert
            Assert.Equal("No questions available.", result);
        }

        [Fact]
        public void GiveQuestion_ShouldReturnNoQuestions_WhenFileIsEmpty()
        {
            // Arrange
            File.WriteAllText(testFilePath, "");

            // Act
            string result = Program.GiveQuestion();

            // Assert
            Assert.Equal("No questions available.", result);
        }

        [Theory]
        [InlineData("What is your name?\nHow old are you?\nWhere do you live?")]
        [InlineData("Who won the world cup?\nWhat is AI?\nExplain gravity.")]
        public void GiveQuestion_ShouldReturnAQuestion_WhenFileHasQuestions(string fileContent)
        {
            // Arrange
            File.WriteAllText(testFilePath, fileContent);

            // Act
            string result = Program.GiveQuestion();

            // Assert
            Assert.Contains(result, fileContent.Split("\n")); // Ensures result is one of the questions
        }

        [Fact]
        public void GiveQuestion_ShouldNotDuplicateQuestions_WhenCalledMultipleTimes()
        {
            // Arrange
            string[] questions = { "Q1", "Q2", "Q3" };
            File.WriteAllText(testFilePath, string.Join("\n", questions));

            // Act
            string result1 = Program.GiveQuestion();
            string result2 = Program.GiveQuestion();
            string result3 = Program.GiveQuestion();

            // Assert: Ensure all results are valid questions
            Assert.Contains(result1, questions);
            Assert.Contains(result2, questions);
            Assert.Contains(result3, questions);

            // Fail if any of the returned questions are duplicates
            bool allUnique = (result1 != result2) && (result2 != result3) && (result1 != result3);
            Assert.True(
                allUnique,
                "The function returned duplicate questions."
            );
        }
    }
}

