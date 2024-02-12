namespace Enigma.Machine;

public class RotorSet
{
    public RotorSet(Rotor[] rotors)
    {
        Rotors = rotors;
    }

    private Rotor[] Rotors { get; set; }

    public char Process(char input)
    {
        var result = input;
        
        for(var i = 0; i < Rotors.Length; i++)
        {
            if (i == 0)
            {
                result = Rotors[i].AdvancePosition(input);
            }
            else if (Rotors[Rotors.Length-1].CurrentIndex <= 24)
            {
                result = Rotors[Rotors.Length-1].CurrentPosition;
            }
            else
            {
                result = Rotors[Rotors.Length-1].AdvancePosition(input);
            }
        }

        return result;
    }
}