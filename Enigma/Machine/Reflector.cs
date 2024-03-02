using Enigma.Data;

namespace Enigma.Machine;

public class Reflector(RotorModel rotorModel) : RotorBase(rotorModel.Wiring)
{
    public char Process(char inputLetter)
    {
        return RotorWiring[Position(inputLetter)];
    }
}