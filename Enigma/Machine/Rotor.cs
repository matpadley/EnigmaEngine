using Enigma.Data;

namespace Enigma.Machine;

public class Rotor
{
    public Rotor(RotorModel rotorModel, int startPosition, char[] inputModel = null)
    {
        Label = rotorModel.Label;
        Positions = rotorModel.Wiring?.ToCharArray() ?? Array.Empty<char>();    
        _inputModel = inputModel ?? "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
        CurrentPosition = Positions[startPosition];
    }

    public char AdvancePosition(char input)
    {
        var www = _inputModel.IndexOf(input);
        if (_inputModel.IndexOf(input) == _inputModel.Count - 1)
        {
            CurrentPosition = Positions[0];
        }
        else
        {
            CurrentPosition = Positions[_inputModel.IndexOf(input) + 1];
        }
        
        return CurrentPosition;
    }

    public char CurrentPosition { get; private set; }

    private char[] Positions { get; set; }

    public string? Label { get; private set; }
    
    public int CurrentIndex => Array.IndexOf(Positions, CurrentPosition);

    private readonly IList<char> _inputModel;
}