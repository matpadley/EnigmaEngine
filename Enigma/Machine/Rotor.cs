using Enigma.Data;

namespace Enigma.Machine;

public class Rotor
{
    RotorModel? _rotorModel;
    readonly char[] _alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
    char[]? _rotorWiring;
    private int _rotationCount = 0;
    
    public Rotor(RotorModel? rotorModel, int startPosition)
    {
        this._rotorModel = rotorModel;
        this._rotorWiring = ShiftLeft(rotorModel?.Wiring?.ToCharArray(), startPosition);
    }

    public Rotor(char[]? rotorWiring)
    {
        _rotorWiring = rotorWiring;
    }

    private char[]? ShiftLeft(char[]? rotorWiring, int shift, bool shouldRotate = false)
    {
        char[]? shiftedAlphabet = new char[_alphabet.Length];
        
        for (var i = 0; i < _alphabet.Length; i++)
        {
            var newIndex = (i + shift) % _alphabet.Length;
            shiftedAlphabet[newIndex] = rotorWiring[i];
        }

        _rotationCount++;
        
        return shiftedAlphabet;
    }

    public char NextPosition(char letterToEncrypt, bool shouldRotate = false)
    {
        var index = Array.IndexOf(_alphabet, letterToEncrypt);

        var encryptedChar = _rotorWiring![index];

        if (shouldRotate)
        {
            _rotorWiring = ShiftLeft(_rotorWiring, 1, shouldRotate);
        }

        return encryptedChar;
    }
    
    public bool ShouldRotateNext => _rotationCount == _rotorWiring.Length;
}