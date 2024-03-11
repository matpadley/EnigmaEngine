namespace Enigma.Machine;

public abstract class RotorBase
{
    public RotorBase(string rotorWiring)
    {
        RotorWiring = rotorWiring.ToCharArray();
    }
    protected readonly char[] Alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
    protected char[]? RotorWiring;
    protected int Position(char letter) => Array.IndexOf(Alphabet, letter); 
}