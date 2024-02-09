using Enigma.PlugBoard;

namespace enigma.tests.Plugboard;

[TestFixture]
public class PlugBoardTests
{
    [TestCase('A', PlugBoardDirection.ToReflector, 'B')]
    [TestCase('C', PlugBoardDirection.ToReflector, 'C')]
    [TestCase('C', PlugBoardDirection.FromReflector, 'C')]
    [TestCase('B', PlugBoardDirection.FromReflector, 'A')]
    public void Get_ReturnsCorrectMappedLetter(char input, PlugBoardDirection direction, char expected)
    {
        var plugBoardPairs = new[] { new Pair('A', 'B') };
        var plugboardPairs = new Pairs { PlugBoardPairs = plugBoardPairs };
        var plugBoard = new Settings(plugboardPairs);

        var result = plugBoard.Get(input, direction);

        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Get_ReturnsInputLetterWhenNoMapping()
    {
        var plugBoardPairs = new[] { new Pair('A', 'B') };
        
        var plugboardPairs = new Pairs { PlugBoardPairs = plugBoardPairs };
        var plugBoard = new Settings(plugboardPairs);

        var result = plugBoard.Get('C', PlugBoardDirection.ToReflector);

        Assert.That(result, Is.EqualTo('C'));
    }

    [Test]
    public void PlugBoardPair_ConstructorSetsPropertiesCorrectly()
    {
        var plugBoardPair = new Pair('A', 'B');

        Assert.That(plugBoardPair.First, Is.EqualTo('A'));
        Assert.That(plugBoardPair.Second, Is.EqualTo('B'));
    }
}