using Enigma.Configuration;
using FluentAssertions;
using Microsoft.Extensions.Configuration;

namespace TestProject1.EnigmaMachines;

[TestFixture]
public class EnigmaJsonDeserializerTests(EnigmaJsonDeserializer deserializer)
{
    private EnigmaJsonDeserializer _deserializer;

    [SetUp]
    public void SetUp()
    {
        var configuration = new ConfigurationBuilder()
            .AddInMemoryCollection(new Dictionary<string, string>
            {
                { "fileLocations:enigma", "./data/enigmas.json" },
            }!)
            .Build();

        _deserializer = new EnigmaJsonDeserializer(configuration);
    }

    [Test]
    public void DeserializeEnigmaData_ReturnsExpectedReflectorCount()
    {
        // Act
        var data = _deserializer.DeserializeEnigmaData().Reflectors;

        // Assert
        data?.Count.Should().Be(3);
    }

    [Test]
    public void DeserializeEnigmaData_ReturnsExpectedEnigmaCount()
    {
        // Act
        var data = _deserializer.DeserializeEnigmaData();

        // Assert
        data.Should().NotBeNull();
        data.EnigmaMachines.Should().NotBeNull();
        data.EnigmaMachines.Count.Should().Be(6);
    }
}