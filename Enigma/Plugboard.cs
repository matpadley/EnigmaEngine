namespace Enigma;

public class PlugBoard
{
    private readonly PlugBoardPair[] _plugBoardPairs;

    public PlugBoard(PlugBoardPair[] plugBoardPairs)
    {
        _plugBoardPairs = plugBoardPairs;
    }
    
    public char Get(char letter)
    {
        var mappedLetter =
            _plugBoardPairs.ToArray().FirstOrDefault(f => f.First == letter);


        return mappedLetter?.Second ?? letter;
    }

}

public class PlugBoardPair
{
    // Change to AddPluboardPair to validate no duplicates
    public char Second { get; private set; }

    public char First { get; private set; }
    
    public PlugBoardPair(char first, char second)
    {
        First = first;
        Second = second;
    }
    
    
    
}