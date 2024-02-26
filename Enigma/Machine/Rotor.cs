using Enigma.Data;

namespace Enigma.Machine;

public class Rotor: RotorBase
{
    private int _rotationCount = 0;
    
    public Rotor(RotorModel? rotorModel, int startPosition)
    {
        //_rotorModel = rotorModel;
        RotorWiring = ShiftLeft(rotorModel?.Wiring?.ToCharArray(), startPosition);
    }

    private char[]? ShiftLeft(char[]? rotorWiring, int shift, bool shouldRotate = false)
    {
        var shiftedAlphabet = new char[Alphabet.Length];
        
        for (var i = 0; i < Alphabet.Length; i++)
        {
            var newIndex = (i + shift) % Alphabet.Length;
            shiftedAlphabet[newIndex] = rotorWiring[i];
        }
        
        return shiftedAlphabet;
    }

    public char NextPosition(char letterToEncrypt, bool shouldRotate = false)
    {
        var index = Array.IndexOf(Alphabet, letterToEncrypt);

        var encryptedChar = RotorWiring![index];

        if (shouldRotate)
        {
            RotorWiring = ShiftLeft(RotorWiring, 1, shouldRotate);
        }

        _rotationCount++;

        return encryptedChar;
    }
}