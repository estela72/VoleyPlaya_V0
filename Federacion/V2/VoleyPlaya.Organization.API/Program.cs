using Microsoft.EntityFrameworkCore;

using System.Text.Json.Serialization;

using VoleyPlaya.Organization.Application;
using VoleyPlaya.Organization.Infraestructure;
using VoleyPlaya.Organization.Infraestructure.Persistence;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(options => options.SuppressImplicitRequiredAttributeForNonNullableReferenceTypes = true)
    .AddJsonOptions(options => options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles)

    ;
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddApplicationServices();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
using (var scope = app.Services.CreateScope())
{
    scope.ServiceProvider.GetService<VoleyPlayaOrganizationContext>()?.Database.Migrate();
}
app.UseAuthorization();

app.MapControllers();

app.Run();
