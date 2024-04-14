using Microsoft.AspNetCore.Http.HttpResults;
using WebApplication1;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddSingleton<IMockDb, MockDb>();
builder.Services.AddSingleton<IVisitDb, MockVisitDb>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapGet("/manimals", (IMockDb MockDb) =>
{
    return Results.Ok(MockDb.GetAll());
});
app.MapGet("/manimals/{id}", (IMockDb mockDb, int id) =>
{
    var animal = mockDb.GetById(id);
    if (animal is null) return Results.NotFound();
    
    return Results.Ok(animal);
});
app.MapPost("/manimals", (IMockDb mockDb, Animals animals) =>
{
    mockDb.Add(animals);
    return Results.Created();
});
app.MapPut("/manimals/{id:int}", (IMockDb mockDb, int id, Animals animals) =>
{

    var animal = mockDb.GetById(id);
    if (animal is null) return Results.NotFound();
    
    mockDb.Remove(animal);
    mockDb.Add(animals);
    return Results.NoContent();


});
app.MapDelete("/manimal/{id:int}", (IMockDb mockDb, int id) =>
{
    var animal = mockDb.GetById(id);
    if (animal is null) return Results.NotFound();
    mockDb.Remove(animal);
    return Results.NoContent();
});
app.MapGet("/mvisits", (IVisitDb IVisitDb) =>
{
    return Results.Ok(IVisitDb.GetAll());
});
app.MapPost("/mvisits", (IVisitDb IVisitDb, Visit visit) =>
{
    IVisitDb.Add(visit);
    return Results.Created();
});
app.MapControllers();
app.Run();

