using Enigma.Data;

namespace TestProject1;

public abstract class BaseRotorLayer
{
    protected const string FirstRotorJson = @"{
        ""label"": ""I"",
        ""wiring"": ""GETNDHQZUPBRCOXMKYAWFILSVJ""
    }";    
    
    protected const string SecondRotorJson = @"{
        ""label"": ""II"",
        ""wiring"": ""GETNDHQZUPBRCOXMKYAWFILSVJ""
    }";

    /*
    private string _rotorJson = @"{
        ""label"": ""I"",
        ""wiring"": ""EKMFLGDQVZNTOWYHXUSPAIBRCJ""
                      GETNDHQZUPBRCOXMKYAMFILSVJ
    }";
    */
    
    protected RotorModel? RotorModel = new();
}