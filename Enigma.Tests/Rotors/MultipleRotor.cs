using Enigma.Data;
using Enigma.Machine;
using FluentAssertions;
using Newtonsoft.Json;

namespace enigma.tests.Rotors;

public class MultipleRotor
{
    private string _rotorJson_one = @"{
      ""label"": ""I"",
      ""wiring"": ""EKMFLGDQVZNTOWYHXUSPAIBRCJ""
    }";
    
    private string _rotorJson_two = @"{
      ""label"": ""II"",
      ""wiring"": ""AJDKSIRUXBLHWTMCQGZNPYFVOE""
    }";
    
    private IList<Rotor> _rotorModels = new List<Rotor>();
    
    [SetUp]
    public void Setup()
    {
        var rotorModel_One = JsonConvert.DeserializeObject<RotorModel>(_rotorJson_one);
        var rotorModel_Two = JsonConvert.DeserializeObject<RotorModel>(_rotorJson_two);
        _rotorModels.Add(new Rotor(rotorModel_One, 0));
        _rotorModels.Add(new Rotor(rotorModel_Two, 0));
    }
    
    [TestCase(0, 'C')]
    [TestCase(7, 'C')]
    public void MultipleRotors_ReturnsExpectedPosition(int startPosition, char expectedLetter)
    {
        // Arrange
        var rotorSet = new RotorSet(_rotorModels.ToArray());
        
        // Act
        var result = rotorSet.Process('A');
        
        // Assert
        result.Should().Be(expectedLetter);
    }
}