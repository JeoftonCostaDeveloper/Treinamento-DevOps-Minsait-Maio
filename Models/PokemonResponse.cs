namespace PokeMinimalApi.Models;

public class PokemonResponse
    {
    public string Name { get; set; } = "";
    public int Height { get; set; }
    public int Weight { get; set; }
    public int Order { get; set; }
    public List<string> Types { get; set; } = new();
    public string ImageUrl { get; set; }
    }

// Para desserializar a resposta original da PokeAPI:
public class PokeApiRawResponse
    {
    public string Name { get; set; } = "";
    public int Height { get; set; }
    public int Weight { get; set; }
    public int Order { get; set; }
    public List<TypeSlot> Types { get; set; } = new();
    public Sprites Sprites { get; set; } = new();
    }

public class TypeSlot
    {
    public int Slot { get; set; }
    public TypeInfo Type { get; set; } = new();
    }

public class TypeInfo
    {
    public string Name { get; set; } = "";
    }

public class Sprites
    {
    public string FrontDefault { get; set; }
    }
