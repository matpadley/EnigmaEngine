using Enigma.Exceptions;

namespace Enigma.PlugBoard;

public class PlugBoardPairs
{
    public PlugBoardPair[] Pairs { get; set; } = Array.Empty<PlugBoardPair>();

    public void AddPlugBoardPair(PlugBoardPair plugBoardPair)
    {
        if (Pairs.Any(f => f.First == plugBoardPair.First || f.Second == plugBoardPair.Second))
        {
            throw new PlugBoardPairException("Duplicate PlugBoardPair is not allowed.");
        }

        Pairs = Pairs.Append(plugBoardPair).ToArray();
    }
}