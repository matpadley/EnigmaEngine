namespace Enigma.Machine;

public class Model
{
    public string ModelName { get; set; }
    public string IntroductionDate { get; set; }
    public List<Rotor.Model> Rotors { get; set; }
}