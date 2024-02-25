using Enigma.Data;

namespace enigma.tests;

public abstract class BaseRotorLayer
{
    protected const string FirstRotorJson = @"{
        ""label"": ""I"",
        ""wiring"": ""GETNDHQZUPBRCOXMKYAMFILSVJ""
    }";    
    
    protected const string SecondRotorJson = @"{
        ""label"": ""I"",
        ""wiring"": ""GETNDHQZUPBRCOXMKYAMFILSVJ""
    }";

    /*
    private string _rotorJson = @"{
        ""label"": ""I"",
        ""wiring"": ""EKMFLGDQVZNTOWYHXUSPAIBRCJ""
                      GETNDHQZUPBRCOXMKYAMFILSVJ
    }";
    */
    
    protected RotorModel RotorModel = new();
}