using Enigma.Data;

namespace Enigma.Machine;

public class Reflector(RotorModel rotorModel) : RotorBase
{
    char[] _reflectorWiring = rotorModel.Wiring.ToCharArray();

    public char Process(char inputLetter)
    {
        var alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
        var position = Array.IndexOf(alphabet, inputLetter);
        return _reflectorWiring[position];
    }
}