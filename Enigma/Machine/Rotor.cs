using Enigma.Data;

namespace Enigma.Machine;

public class Rotor
{
    RotorModel? _rotorModel;
    readonly char[] _alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
    char[]? _rotorWiring;
    
    public Rotor(RotorModel? rotorModel, int startPosition)
    {
        this._rotorModel = rotorModel;
        this._rotorWiring = ShiftLeft(rotorModel?.Wiring?.ToCharArray(), startPosition);
    }

    public Rotor(char[]? rotorWiring)
    {
        _rotorWiring = rotorWiring;
    }

    private char[]? ShiftLeft(char[]? rotorWiring, int shift)
    {
        char[]? shiftedAlphabet = new char[_alphabet.Length];
        
        for (int i = 0; i < _alphabet.Length; i++)
        {
            var newIndex = (i + shift) % _alphabet.Length;
            if (rotorWiring != null) shiftedAlphabet[newIndex] = rotorWiring[i];
        }
        
        //return shiftedAlphabet;
        return shiftedAlphabet;
    }
    
    public char NextPosition(char letterToEncrypt)
    {
        var shifted = ShiftLeft(_rotorWiring, 1);
        
        var index = Array.IndexOf(_alphabet, letterToEncrypt);
        
        var encryptedChar = _rotorWiring![index];
        
        _rotorWiring = ShiftLeft(_rotorWiring, 1);
        
        return encryptedChar;
    }
}