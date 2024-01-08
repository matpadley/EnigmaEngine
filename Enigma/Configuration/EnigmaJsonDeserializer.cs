using Enigma.Data;
using Enigma.Machine;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace Enigma.Configuration;

public class EnigmaJsonDeserializer(IConfiguration configuration)
{
    private IConfiguration _Configuration { get; } = configuration;

    public EnigmaDataModel DeserializeEnigmaData()
    {
        var filePath = _Configuration.GetSection("fileLocations")
            .GetChildren()
            .FirstOrDefault(x => x.Key == "enigma");
        
        var jsonData = File.ReadAllText(filePath.Value);
        
        return JsonConvert.DeserializeObject<EnigmaDataModel>(jsonData);
    }
}