using Enigma.Exceptions;

namespace Enigma.PlugBoard;

public class Pairs
{
    public Pair[] PlugBoardPairs { get; set; } = Array.Empty<Pair>();

    public void AddPlugBoardPair(Pair pair)
    {
        if (PlugBoardPairs.Any(f => f.First == pair.First || f.Second == pair.Second))
        {
            throw new PlugBoardPairException("Duplicate PlugBoardPair is not allowed.");
        }

        PlugBoardPairs = PlugBoardPairs.Append(pair).ToArray();
    }
}