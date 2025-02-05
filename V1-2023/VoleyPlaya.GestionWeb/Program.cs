
using AutoMapper;

using General.CrossCutting.Lib;

using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;

using VoleyPlaya.Domain;
using VoleyPlaya.GestionWeb.Areas.Identity;
using VoleyPlaya.GestionWeb.Infrastructure;
using VoleyPlaya.Repository;

var builder = WebApplication.CreateBuilder(args);

var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
var config = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile($"appsettings.{environment}.json")
    .Build();

// Add services
builder.Services.AddDomainStartup();
builder.Services.AddScoped<IEmailService, EmailService>();
//builder.Services.AddScoped<IConfiguracionService, ConfiguracionService>();

// Add Automapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// Configura Identity
builder.Services.AddDefaultIdentity<IdentityUser>()
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<VoleyPlayaDbContext>();

builder.Services.Configure<IdentityOptions>(options =>
{
    // Password settings.
    options.Password.RequireDigit = true;
    options.Password.RequireLowercase = true;
    options.Password.RequireNonAlphanumeric = true;
    options.Password.RequireUppercase = true;
    options.Password.RequiredLength = 6;
    options.Password.RequiredUniqueChars = 1;

    // Lockout settings.
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
    options.Lockout.MaxFailedAccessAttempts = 5;
    options.Lockout.AllowedForNewUsers = true;

    // User settings.
    options.User.AllowedUserNameCharacters = "abcdefghijklmn�opqrstuvwxyzABCDEFGHIJKLMN�OPQRSTUVWXYZ0123456789-._@+ �";
    options.User.AllowedUserNameCharacters = options.User.AllowedUserNameCharacters + "����������";
    options.User.RequireUniqueEmail = false;
    options.SignIn.RequireConfirmedAccount = true;
});
builder.Services.ConfigureApplicationCookie(options =>
{
    // Cookie settings
    options.Cookie.HttpOnly = true;
    options.ExpireTimeSpan = TimeSpan.FromMinutes(60);

    options.LoginPath = "/Identity/Account/Login";
    options.AccessDeniedPath = "/Identity/Account/AccessDenied";
    options.SlidingExpiration = true;
});
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(60); // Aumenta el tiempo de espera de la sesi�n a 60 minutos
    //options.Cookie.IsEssential = true; // Aseg�rate de que la cookie de sesi�n se env�e incluso si el usuario no ha otorgado su consentimiento expl�cito
});
builder.Services.AddAntiforgery(o => o.HeaderName = "XSRF-TOKEN");

builder.Services.Configure<FormOptions>(options =>
{
    options.ValueCountLimit = int.MaxValue;
});

await builder.Services.AddApplicationRoles();
await builder.Services.AddAdminUsers();
await builder.Services.AddPolicies();
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}


app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseSession();

app.MapRazorPages();

app.Run();

