namespace Enigma.Machine;

public abstract class RotorBase
{
    protected readonly char[] Alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
    protected char[]? RotorWiring;
}