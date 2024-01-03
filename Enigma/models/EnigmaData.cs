public class EnigmaData
{
    public List<EnigmaModel> EnigmaMachines { get; set; }
    public List<Rotor> Reflectors { get; set; }

    public string[] AvaiableMachines => EnigmaMachines.Select(f => f.Model).ToArray();
}