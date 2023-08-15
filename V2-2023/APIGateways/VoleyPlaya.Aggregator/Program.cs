using VoleyPlaya.Aggregator.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddScoped<IEdicionesServices, EdicionesService>();
builder.Services.AddScoped<ITemporadasService, TemporadasService>();
builder.Services.AddScoped<ICompeticionesService, CompeticionesService>();
builder.Services.AddScoped<ICategoriasService, CategoriasService>();
builder.Services.AddScoped<IEdicionGruposServices, EdicionGruposService>();
builder.Services.AddScoped<IJornadasServices,  JornadasService>();
builder.Services.AddScoped<IPartidosServices, PartidosService>();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();

app.Run();
