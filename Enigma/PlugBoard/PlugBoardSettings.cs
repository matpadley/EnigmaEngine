namespace Enigma.PlugBoard;

public class PlugBoardSettings(PlugBoardPairs plugBoardPairs)
{
    public char Get(char letter, PlugBoardDirection direction)
    {
        if (direction == PlugBoardDirection.ToReflector)
        {
            var letterToReturn = plugBoardPairs.Pairs.ToArray().FirstOrDefault(f => f.First == letter);
            
            if (letterToReturn != null)
            {
                return letterToReturn.Second;
            }
        }
        else
        {
            var letterToReturn = plugBoardPairs.Pairs.ToArray().FirstOrDefault(f => f.Second == letter);
            
            if (letterToReturn != null)
            {
                return letterToReturn.First;
            }
        }

        return letter;
    }
}

public enum PlugBoardDirection
{
    ToReflector,
    FromReflector
}