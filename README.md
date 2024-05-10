# EnigmaEngine

This repository houses code for an engine that replicates the functionality of the Enigma Machine. Each setup from WWII is expected to be available.

## Functionality

### Enigma JSON Deserializer

Deserialize data from JSON file to create Enigma machines and reflectors.

Can confirm the expected count of reflectors and Enigma machines.

### PlugBoard

Add pairs to the plugboard without duplicates.

If a duplicate pair is added, an exception is thrown.

Plugboard pairs are initialized correctly.

### Reflector

Maps input letters to expected letters according to a specified rotor model.
Settings

Returns the correct mapped letter depending on the direction (to or from the reflector).

Returns the input letter when there's no mapping.

Please see the test files in the repository for examples and more detailed explanations of these functionalities.
