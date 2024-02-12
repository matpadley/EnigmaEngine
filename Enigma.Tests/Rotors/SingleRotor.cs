using Enigma.Data;
using Enigma.Machine;
using FluentAssertions;
using Newtonsoft.Json;

namespace enigma.tests.Rotors;

public class SingleRotorTests
{
    private string _rotorJson = @"{
        ""label"": ""I"",
        ""wiring"": ""EKMFLGDQVZNTOWYHXUSPAIBRCJ""
    }";
    
    
    [TestCase(0, 'A', 'K')]
    [TestCase(0, 'Z', 'E')]
    [TestCase(0, 'B', 'M')]
    [TestCase(0, 'Y', 'J')]
    public void AdvancePosition_ReturnsExpectedPosition(int startPosition, 
        char inputLetter, 
        char expectedLetter)
    {
        // Arrange
        var rotorModelOne = JsonConvert.DeserializeObject<RotorModel>(_rotorJson);
        var rotorSet = new Rotor(rotorModelOne,startPosition);
        
        // Act
        var result = rotorSet.AdvancePosition(inputLetter);
        
        // Assert
        result.Should().Be(expectedLetter);
    }
}