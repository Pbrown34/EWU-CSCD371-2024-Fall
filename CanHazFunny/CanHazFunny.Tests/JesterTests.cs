using System;
using System.IO;
using Xunit;

namespace CanHazFunny.Tests;

public class JesterTests
{
    [Fact]
    public void Jester_Constructor_NotNull()
    {
        // Arrange
        Jester jester = new();
        // Act
   
        // Assert
        Assert.NotNull(jester);
    }

    [Fact]
    public void JokeService_Construtor_NotNull()
    {
        // Arrange
        JokeService jokeService = new();
        // Act

        // Assert
        Assert.NotNull(jokeService);
    }
    [Fact]
    public void TellJokeJson_Return_Joke()
    {
        //Arrange
        Jester jester = new();
        //Act
   
        //Assert
        Assert.True(jester.TellJokeJson());
    }
    
   
    [Fact]
    public void Main_WrongInput_Return_String()
    {
        // Arrange
        var stringWriter = new StringWriter();
        Console.SetOut(stringWriter);
        var inputs = new[] { "A", "Y" };
        Console.SetIn(new StringReader(string.Join(Environment.NewLine, inputs)));
        // Act
        Program.Main(Array.Empty<string>());
        // Assert
        var output = stringWriter.ToString();
        Assert.Contains("Invalid input. Please enter Y or N.", output);
        Assert.Contains("Would you like to hear a joke? (Y/N) or Change formats (F)", output);
    }
   [Fact]
   public void Main_SwitchToJson_SwitchToHttp()
   {
        // Arrange
        var stringWriter = new StringWriter();
        Console.SetOut(stringWriter);
        var inputs = new[] { "F", "F" }; 
        Console.SetIn(new StringReader(string.Join(Environment.NewLine, inputs)));
        // Act
        Program.Main(Array.Empty<string>());
        // Assert
        var output = stringWriter.ToString();
        Assert.Contains("Format changed to: Json" + System.Environment.NewLine, output);
        Assert.Contains("Would you like to hear a joke? (Y/N) or Change formats (F)", output);
        Assert.Contains("Format changed to: Http" + System.Environment.NewLine, output);
        Assert.Contains("Would you like to hear a joke? (Y/N) or Change formats (F)", output);
   }
}
