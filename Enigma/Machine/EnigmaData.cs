using Enigma.Rotor;

namespace Enigma.Machine;

public class EnigmaData
{
    public List<Model> EnigmaMachines { get; set; }
    public List<Rotor.Model> Reflectors { get; set; }

    public string[] AvailableMachines => EnigmaMachines.Select(f => f.ModelName).ToArray();
}