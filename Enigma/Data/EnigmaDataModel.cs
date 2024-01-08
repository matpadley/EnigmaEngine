using Enigma.Data;
using Enigma.Rotor;

namespace Enigma.Machine;

public class EnigmaDataModel
{
    public List<EnigmaModel> EnigmaMachines { get; set; }
    public List<RotorModel> Reflectors { get; set; }

    public string[] AvailableMachines => EnigmaMachines.Select(f => f.ModelName).ToArray();
}