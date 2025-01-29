namespace Cpsc370Final.Tests;

public class UnitTest1
{
    [Fact]
    public void Test1()
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
}