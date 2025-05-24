using System.Net.Http.Json;
using PokeMinimalApi.Models;

public class PokeApiService
    {
    private readonly HttpClient _httpClient;
    private const string BaseUrl = "https://pokeapi.co/api/v2/pokemon/";

    public PokeApiService(HttpClient httpClient) {
        _httpClient = httpClient;
        }

    public async Task<PokemonResponse?> GetPokemonInfoAsync(string name) {
        try
            {
            var response = await _httpClient.GetFromJsonAsync<PokeApiRawResponse>($"{BaseUrl}{name}");

            if(response == null) return null;

            return new PokemonResponse
                {
                Name = response.Name,
                Height = response.Height,
                Weight = response.Weight,
                Order = response.Order,
                Types = response.Types.Select(t => t.Type.Name).ToList(),
                };
            }
        catch
            {
            return null;
            }
        }
    }
