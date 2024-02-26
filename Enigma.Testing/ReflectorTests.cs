using Enigma.Data;
using Enigma.Machine;
using FluentAssertions;
using Newtonsoft.Json;

namespace TestProject1;

public class ReflectorTests
{
    
    [TestCase('A', 'E')]
    [TestCase('B', 'J')]
    [TestCase('F', 'L')]
    public void Refelctor_Returns_Expected_Letter(char inputLetter, char expectedLetter)
    {
        // Arrange
        var relfector = @"{
            ""name"": ""Reflector A"",
            ""wiring"": ""EJMZALYXVBWFCRQUONTSPIKHGD""
        }";  
        
        var reflector = new Reflector(JsonConvert.DeserializeObject<RotorModel>(relfector));
        
        // Act
        var result = reflector.Process(inputLetter);
        
        // Assert
        result.Should().Be(expectedLetter);
    }
}