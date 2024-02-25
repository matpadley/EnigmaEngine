using Enigma.Data;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace Enigma.Configuration;

public class EnigmaJsonDeserializer(IConfiguration configuration)
{
    private IConfiguration Configuration { get; } = configuration;

    public EnigmaDataModel DeserializeEnigmaData()
    {
        var filePath = Configuration.GetSection("fileLocations")
            .GetChildren()
            .FirstOrDefault(x => x.Key == "enigma");

        if (filePath?.Value == null) throw new Exception("Could not find file location for enigma data.");
        
        var jsonData = File.ReadAllText(filePath.Value);
        
        return JsonConvert.DeserializeObject<EnigmaDataModel>(jsonData);
    }
}