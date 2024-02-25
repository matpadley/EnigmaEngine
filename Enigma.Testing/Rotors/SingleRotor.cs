using Enigma.Data;
using Enigma.Machine;
using FluentAssertions;
using Newtonsoft.Json;

namespace TestProject1.Rotors;

public class SingleRotorTests: BaseRotorLayer
{
    [SetUp]
    public void Setup()
    {
        RotorModel = JsonConvert.DeserializeObject<RotorModel>(FirstRotorJson);
    }
    
    [TestCase(0, 'H', 'Z')]
    [TestCase(0, 'A', 'G')]
    [TestCase(0, 'C', 'T')]
    [TestCase(0, 'K', 'B')]
    [TestCase(0, 'Z', 'J')]
   // [TestCase(0, 'Z', 'N')]
   // [TestCase(0, 'Y', 'E')]
   // [TestCase(1, 'A', 'K')]
    public void AdvancePosition_ReturnsExpectedPosition(int startPosition, 
        char inputLetter, 
        char expectedLetter)
    {
        // Arrange
        var rotor = new Rotor(RotorModel, startPosition);
        
        // Act
        var encryptedChar = rotor.NextPosition(inputLetter);
        
        // Assert
        expectedLetter.Should().Be(encryptedChar);
    }    
    
    [TestCase(0, "H", "Z", false)]
    [TestCase(0, "HA", "ZJ", false)]
    [TestCase(0, "HAC", "ZJG", false)]
    [TestCase(0, "HACK", "ZJGZ", false)]
    public void AdvancePosition_ReturnsExpectedWord(int startPosition, 
        string inputWord, 
        string expectedWord,
        bool hasRotated)
    {
        // Arrange
        var rotor = new Rotor(RotorModel, startPosition);
        var inputChars = inputWord.ToCharArray();
        var outputChars = new List<char>();
        
        // Act
        foreach (var inputChar in inputChars)
        {
            var encryptdChar = rotor.NextPosition(inputChar, true);
            outputChars.Add(encryptdChar);
        }
        
        // Assert
        var encryptedWork = new string(outputChars.ToArray());
        
        encryptedWork.Should().Be(expectedWord);
    }
    
}