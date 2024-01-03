namespace Enigma.PlugBoard;

public class PlugBoardPair(char first, char second)
{
    // Change to AddPluboardPair to validate no duplicates
    public char Second { get; } = second;

    public char First { get; } = first;
}