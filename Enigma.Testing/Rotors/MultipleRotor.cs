using System.Diagnostics;
using Enigma.Data;
using Enigma.Machine;
using FluentAssertions;
using Newtonsoft.Json;

namespace TestProject1.Rotors;

public class MultipleRotor: BaseRotorLayer
{
    
    [SetUp]
    public void Setup()
    {
    }
    
    [TestCase(0, 'A', 'G')]
    [TestCase(0, 'H', 'Z')]
    [TestCase(0, 'Z', 'J')]
    [TestCase(0, 'B', 'E')]
    [TestCase(0, 'Y', 'V')]
    [TestCase(1, 'A', 'J')]
    [TestCase(1, 'Z', 'V')]
    public void SingleRotor_ReturnsExpectedPosition(int startPosition, 
        char inputLetter, 
        char expectedLetter)
    {
        // Arrange
        var rotorModel = JsonConvert.DeserializeObject<RotorModel>(FirstRotorJson);
        var rotor = new Rotor(rotorModel, startPosition);

        var rotorSet = new RotorSet(new[] {  rotor });
        
        // Act
        var result = rotorSet.Process(inputLetter);
        
        // Assert
        result.Should().Be(expectedLetter);
    }
    
    
    [TestCase(0, 0,'H', 'J')]
    [TestCase(0, 0,'A', 'Q')]
    [TestCase(0, 0,'C', 'W')]
    [TestCase(0, 0,'K', 'E')]
    //[TestCase(0,0, 'Z', 'P')]
    //[TestCase(1,0, 'Z', 'P')]
    //[TestCase(0,0, 'B', 'E')]
    //[TestCase(0,0, 'Y', 'R')]
    //[TestCase(1, 2, 'A', 'J')]
    public void TwoRotor_ReturnsExpectedPosition(int firstRotorStartPosition, 
        int secondRotorStartPosition, 
        char inputLetter, 
        char expectedLetter)
    {
       // "J => P ---> P => M";
        // Arrange
        var rotorModelFirst = JsonConvert.DeserializeObject<RotorModel>(FirstRotorJson);
        var rotorModelSecond = JsonConvert.DeserializeObject<RotorModel>(SecondRotorJson);
        var rotorFirst = new Rotor(rotorModelFirst, firstRotorStartPosition);
        var rotorSecond = new Rotor(rotorModelSecond, secondRotorStartPosition);

        var rotorSet = new RotorSet(new[] { rotorFirst, rotorSecond });
        
        // Act
        var result = rotorSet.Process(inputLetter);
        
        // Assert
        result.Should().Be(expectedLetter);
    }
    
    [TestCase(0, 0, "HA", "ZJ")]
    [TestCase(0, 0, "HACK", "ZJGZ")]
    //[TestCase(1, 1, "HELLO", "QHNNO")]
    //[TestCase(26, 1, "HELLO", "QHNNO")]
    //[TestCase(26, 1, "ABCDEFGHUJKLMNOPQRSTUVWQYZ", "SLWIHRKQAETNMFOUVPZCAXJVDB")]
    public void AdvancePosition_ReturnsExpectedWord(int firstRotorStartPosition,
        int secondRotorStartPosition, 
        string inputWord, 
        string expectedWord)
    {
        // Arrange
        var rotorModelFirst = JsonConvert.DeserializeObject<RotorModel>(FirstRotorJson);
        var rotorModelSecond = JsonConvert.DeserializeObject<RotorModel>(SecondRotorJson);
        var rotorFirst = new Rotor(rotorModelFirst, firstRotorStartPosition);
        var rotorSecond = new Rotor(rotorModelSecond, secondRotorStartPosition);
        var inputChars = inputWord.ToCharArray();
        var outputChars = new List<char>();
        var rotorSet = new RotorSet(new[] { rotorFirst, rotorSecond });
        
        // Act
        foreach (var inputChar in inputChars)
        {
            outputChars.Add(rotorSet.Process(inputChar));
        }
        
        // Assert
        var encryptedWork = new string(outputChars.ToArray());
        
        encryptedWork.Should().Be(expectedWord);
    }
}