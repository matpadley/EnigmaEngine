using Enigma.Machine;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace Enigma.Configuration;

public class EnigmaJsonDeserializer(IConfiguration configuration)
{
    private IConfiguration _Configuration { get; } = configuration;

    public EnigmaData DeserializeEnigmaData()
    {
        var filePath = _Configuration.GetSection("fileLocations")
            .GetChildren()
            .FirstOrDefault(x => x.Key == "Enigma").Value;
        
        var jsonData = File.ReadAllText(filePath);
        
        return JsonConvert.DeserializeObject<EnigmaData>(jsonData);
    }
}