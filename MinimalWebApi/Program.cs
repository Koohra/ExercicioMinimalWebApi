using MinimalWebApi;
using System.Linq;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

var imoveis = new List<Imovel>();
int idContador = 0;

app.MapGet("/imovel", () => imoveis);

app.MapGet("/imovel/{id}/{endereco}/{tipo}", (int id, string endereco, string tipo) =>
{
    return new { Texto = $"id:{id} -- endereço: {endereco} -- tipo: {tipo}" };
});

app.MapGet("/imovel/{id}", (int id) =>
{
    var imovel = imoveis.FirstOrDefault(i => i.Id == id);
    return imovel;
});

app.MapPost("/imovel", (Imovel imovel) =>
{
    imovel.Id = idContador++;
    imoveis.Add(imovel);
    return Results.Created($"/imovel/{imovel.Id}", imovel);
});

app.Run();