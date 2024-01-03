namespace Enigma.PlugBoard;

public class PlugBoardSettings
{
    private readonly PlugBoardPairs _plugBoardPairs;

    public PlugBoardSettings(PlugBoardPairs plugBoardPairs)
    {
        _plugBoardPairs = plugBoardPairs;
    }
    
    public char Get(char letter)
    {
        var mappedLetter =
            _plugBoardPairs.Pairs.ToArray().FirstOrDefault(f => f.First == letter);


        return mappedLetter?.Second ?? letter;
    }

}