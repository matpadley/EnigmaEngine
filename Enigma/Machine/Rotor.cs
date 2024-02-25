using System.Runtime.InteropServices.JavaScript;
using Enigma.Data;

namespace Enigma.Machine;

public class Rotor
{
    RotorModel rotorModel;
    char[] alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
    char[] rotorWiring;
    
    public Rotor(RotorModel rotorModel, int startPosition)
    {
        this.rotorModel = rotorModel;
        this.rotorWiring = ShiftLeft(rotorModel.Wiring.ToCharArray(), startPosition);
    }
    private char[] ShiftLeft(char[] rotorWiring, int shift)
    {
        char[] shiftedAlphabet = new char[alphabet.Length];
        
        for (int i = 0; i < alphabet.Length; i++)
        {
            int newIndex = (i + shift) % alphabet.Length;
            shiftedAlphabet[newIndex] = rotorWiring[i];
        }
        
        //return shiftedAlphabet;
        return shiftedAlphabet;
    }
    
    public char NextPosition(char letterToEncrypt)
    {
        var shifted = ShiftLeft(rotorWiring, 1);
        
        var index = Array.IndexOf(alphabet, letterToEncrypt);
        
        var encryptedChar = rotorWiring[index];
        
        rotorWiring = ShiftLeft(rotorWiring, 1);
        
        return encryptedChar;
    }
}