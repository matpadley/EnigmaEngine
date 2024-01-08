using Enigma.Data;

namespace Enigma.Rotor;

public class Rotor
{
    public Rotor(RotorModel rotorModelRotorModel, int startPosition)
    {
        Label = rotorModelRotorModel.Label;
        Positions = rotorModelRotorModel.Wiring?.ToCharArray() ?? Array.Empty<char>();        
        CurrentPosition = Positions[startPosition];
    }

    public char AdvancePosition()
    {
        var currentIndex = Array.IndexOf(Positions, CurrentPosition);
        var nextIndex = (currentIndex + 1) % Positions.Length;
        CurrentPosition = Positions[nextIndex];
        return CurrentPosition;
    }

    public char CurrentPosition { get; private set; }

    private char[] Positions { get; set; }

    public string Label { get; private set; }
}