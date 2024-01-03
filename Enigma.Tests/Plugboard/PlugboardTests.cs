using Enigma.PlugBoard;

namespace Enigma.Tests.Plugboard;

[TestFixture]
public class PlugBoardTests
{
    [Test]
    public void Get_ReturnsCorrectMappedLetter()
    {
        var plugBoardPairs = new[] { new PlugBoardPair('A', 'B') };
        var plugboardPairs = new PlugBoardPairs { Pairs = plugBoardPairs };
        var plugBoard = new PlugBoardSettings(plugboardPairs);

        var result = plugBoard.Get('A');

        Assert.That(result, Is.EqualTo('B'));
    }

    [Test]
    public void Get_ReturnsInputLetterWhenNoMapping()
    {
        var plugBoardPairs = new[] { new PlugBoardPair('A', 'B') };
        
        var plugboardPairs = new PlugBoardPairs { Pairs = plugBoardPairs };
        var plugBoard = new PlugBoardSettings(plugboardPairs);

        var result = plugBoard.Get('C');

        Assert.That(result, Is.EqualTo('C'));
    }

    [Test]
    public void PlugBoardPair_ConstructorSetsPropertiesCorrectly()
    {
        var plugBoardPair = new PlugBoardPair('A', 'B');

        Assert.That(plugBoardPair.First, Is.EqualTo('A'));
        Assert.That(plugBoardPair.Second, Is.EqualTo('B'));
    }
}