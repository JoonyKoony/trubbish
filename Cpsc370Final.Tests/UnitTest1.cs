namespace Cpsc370Final.Tests;

public class UnitTest1
{
    [Fact]
    public void Test1()
    {
    }
    
    [Theory]
    [InlineData("Hello World", false)]
    [InlineData(" ", false)]
    [InlineData("Hello", true)]
    [InlineData("im123oldinyears", false)]
    [InlineData("Turtle", true)]
    public void ValidInputForGettingUserAnswer(string input, bool expected)
    {
        // Arrange

        // Act
        bool isValid = input.Length < 10 && !input.Contains(" ");

        // Assert
        Assert.Equal(expected, isValid);
    }
}