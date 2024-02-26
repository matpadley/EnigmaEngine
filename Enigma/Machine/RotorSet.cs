namespace Enigma.Machine;

public class RotorSet(Rotor[] rotors)
{
    private Rotor[] Rotors { get; set; } = rotors;

    public char Process(char input)
    {
        var outputChar = input;
        
        foreach (var rotor in Rotors)
        {
            var isFirstRotor = rotor == Rotors[0];
            outputChar = rotor.NextPosition(outputChar, isFirstRotor);
        }
        
        return outputChar;
    }
}