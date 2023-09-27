using Microsoft.EntityFrameworkCore;
using MusicStore.Entities;
using MusicStore.Persistence;
using MusicStore.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

builder.Services.AddDbContext<MusicStoreDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("MusicStoreDb"));
});

// Trasient - Siempre crea una instacia de la clase expuesta
// Scoped - Utiliza la misma instacia por Sesion (en aplicaciones .NET que tengan frontend) - ASP.NET MVC/BLAZOR
// Singleton - Utiliza la misma instacia por toda la aplicacion
builder.Services.AddTransient<IGenreRepository, GenreRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//app.MapGet("api/Hello", () => "Hola Mundo");

// Minimal API
//app.MapGet("api/Genres", (GenreRepository repository) =>
//{
//    return Results.Ok(repository.List());
//});

//app.MapPost("api/Genres",(GenreRepository repository, Genre entity) =>
//{
//    repository.Add(entity);

//    return Results.Ok(entity.Id);
//});

//app.MapGet("api/Genres/{id:int}", (GenreRepository repository, int id) =>
//{
//    var response = repository.FindById(id);
//    return response != null ? Results.Ok(response) : Results.NotFound();
//});

//app.MapPut("api/Genres/{id:int}", (GenreRepository repository, int id, Genre genre) =>
//{
//    repository.Update(id, genre);
//    return Results.NoContent();
//});

//app.MapDelete("api/Genres/{id:int}", (GenreRepository repository, int id, ILogger<Program> logger) =>
//{
//    try
//    {
//        repository.Delete(id);
//        return Results.Ok();
//    }
//    catch (Exception ex)
//    {
//        logger.LogError(ex, "{Message}", ex.Message);
//        return Results.BadRequest(new { Mensaje = "Error al eliminar"});
//    }
//});

app.MapControllers();

app.Run();