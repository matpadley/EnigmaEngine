namespace enigma.tests;

public class Rotor
{
    private char[] Positions { get; }

    private char CurrentPosition { get; set; }

    public Rotor(char startLetter)
    {
        CurrentPosition = startLetter;
        Positions = Enumerable.Range('a', 26).Select(x => (char)x).ToArray();
    }

    public char AdvancePosition()
    {
        var currentIndex = Array.IndexOf(Positions, CurrentPosition);
        var nextIndex = (currentIndex + 1) % Positions.Length;
        CurrentPosition = Positions[nextIndex];
        return CurrentPosition;
    }
}