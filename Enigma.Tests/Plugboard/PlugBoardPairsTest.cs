using Enigma.Exceptions;
using Enigma.PlugBoard;

namespace Enigma.Tests.Plugboard;

[TestFixture]
public class PlugBoardPairsTests
{
    [Test]
    public void AddPlugBoardPair_AddsPair_WhenNoDuplicates()
    {
        // Arrange
        var plugBoardPairs = new PlugBoardPairs();
        var pair = new PlugBoardPair('A', 'B');

        // Act
        var result = plugBoardPairs.AddPlugBoardPair(pair);

        // Assert
        Assert.IsTrue(result);
        Assert.Contains(pair, plugBoardPairs.Pairs);
    }

    [Test]
    public void AddPlugBoardPair_ReturnsFalse_WhenDuplicates()
    {
        // Arrange
        var plugBoardPairs = new PlugBoardPairs();
        var pair1 = new PlugBoardPair('A', 'B');
        var pair2 = new PlugBoardPair('A', 'C');
        plugBoardPairs.AddPlugBoardPair(pair1);

        // Assert// Act & Assert
        Assert.Throws<PlugBoardPairException>(() => plugBoardPairs.AddPlugBoardPair(pair2));

    }

    [Test]
    public void Pairs_IsInitialized()
    {
        // Arrange
        var plugBoardPairs = new PlugBoardPairs();

        // Assert
        Assert.IsNotNull(plugBoardPairs.Pairs);
    }
}