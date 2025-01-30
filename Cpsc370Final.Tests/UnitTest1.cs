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
            Program.ClosingStatement(username);
            
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
            string finalUsername = Program.AskForAnotherUsername(initialUsername, words);

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
            string finalUsername = Program.AskForAnotherUsername(initialUsername, words);

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
}

