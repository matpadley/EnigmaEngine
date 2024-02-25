using Enigma.Exceptions;
using Enigma.PlugBoard;
using FluentAssertions;

namespace enigma.tests.Plugboard;

[TestFixture]
public class PlugBoardPairsTests
{
    [Test]
    public void AddPlugBoardPair_AddsPair_WhenNoDuplicates()
    {
        // Arrange
        var pairs = new Pairs();
        var pair = new Pair('A', 'B');

        // Act
        pairs.AddPlugBoardPair(pair);

        // Assert
        Assert.That(pairs.PlugBoardPairs.Contains(pair));
    }

    [Test]
    public void AddPlugBoardPair_ReturnsFalse_WhenDuplicates()
    {
        // Arrange
        var plugBoardPairs = new Pairs();
        var pair1 = new Pair('A', 'B');
        var pair2 = new Pair('A', 'C');
        plugBoardPairs.AddPlugBoardPair(pair1);

        // Assert// Act & Assert
        Assert.Throws<PlugBoardPairException>(() => plugBoardPairs.AddPlugBoardPair(pair2));

    }

    [Test]
    public void Pairs_IsInitialized()
    {
        // Arrange
        var plugBoardPairs = new Pairs();

        // Assert
        Assert.That(plugBoardPairs.PlugBoardPairs == null);
    }
}