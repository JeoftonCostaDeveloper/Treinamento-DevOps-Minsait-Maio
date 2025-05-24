
namespace MinimalApiPokemon
    {
    public class Program
        {
        public static void Main(string[] args) {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddAuthorization();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddHttpClient();
            builder.Services.AddScoped<PokeApiService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if(app.Environment.IsDevelopment())
                {
                app.UseSwagger();
                app.UseSwaggerUI();
                }

            //app.UseHttpsRedirection();

            //app.UseAuthorization();

            app.MapGet("/pokemon/{name}", async (string name, PokeApiService service) =>
            {
                var result = await service.GetPokemonInfoAsync(name.ToLower());
                return result is not null ? Results.Ok(result) : Results.NotFound($"Pokémon '{name}' não encontrado.");
            });
            app.Run();
            }
        }
    }
