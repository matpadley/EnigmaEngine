using Enigma.models;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace Enigma.Configuration;

public class EnigmaJsonDeserializer
{
    private IConfiguration _Configuration { get; }

    public EnigmaJsonDeserializer(IConfiguration configuration)
    {
        _Configuration = configuration;
    }

    public EnigmaData DeserializeEnigmaData()
    {
        var filePath = GetFilePath("enigma");
        var jsonData = File.ReadAllText(filePath);
        return JsonConvert.DeserializeObject<EnigmaData>(jsonData);
    }

    private string GetFilePath(string name)
    {
        //return "test";
        return _Configuration.GetSection("fileLocations")
            .GetChildren()
            .FirstOrDefault(x => x.Key == name).Value;

        return string.Empty;
        // .GetChildren()
        //        .FirstOrDefault(x => x.Key ==  name).Value;
    }
}