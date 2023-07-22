using General.CrossCutting.Lib;

using Ligamania.API.Lib;
using Ligamania.Web.Services;

var builder = WebApplication.CreateBuilder(new WebApplicationOptions
{
    //ApplicationName = typeof(Program).Assembly.FullName,
    //ContentRootPath = Directory.GetCurrentDirectory(),
    //EnvironmentName = Environments.Staging,
    //WebRootPath = "customwwwroot"
});

Console.WriteLine($"Application Name: {builder.Environment.ApplicationName}");
Console.WriteLine($"Environment Name: {builder.Environment.EnvironmentName}");
Console.WriteLine($"ContentRoot Path: {builder.Environment.ContentRootPath}");
Console.WriteLine($"WebRootPath: {builder.Environment.WebRootPath}");

// Wait 30 seconds for graceful shutdown.
builder.Host.ConfigureHostOptions(o => o.ShutdownTimeout = TimeSpan.FromSeconds(30));


// Add services to the container.
builder.Services.AddControllersWithViews();

//builder.Configuration.AddIniFile("appsettings.json");

// Configure JSON logging to the console.
builder.Logging.AddJsonConsole();

// Add the memory cache services.
builder.Services.AddMemoryCache();

builder.Services.AddSingleton<ILigamaniaConfiguration, LigamaniaConfiguration>();

builder.Services.AddDistributedMemoryCache(); //This way ASP.NET Core will use a Memory Cache to store session variables
builder.Services.AddHttpContextAccessor();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromDays(1); // It depends on user requirements.
});

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.ConfigureApplicationCookie(options =>
{
    // Cookie settings
    options.Cookie.HttpOnly = true;
    options.ExpireTimeSpan = TimeSpan.FromMinutes(30);

    options.LoginPath = "/Account/Login";
    options.AccessDeniedPath = "/Account/AccessDenied";
    options.SlidingExpiration = true;
});

builder.Services.AddAPIStartup();

builder.Services
        .AddScoped<ILocalStorageService, LocalStorageService>()
        .AddScoped<IAuthenticationService, AuthenticationService>()
        .AddScoped<IGestionService, GestionService>()
        .AddScoped<IPreparacionService, PreparacionService>()
        .AddScoped<IGestionTemporadaService, GestionTemporadaService>()
;

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

// global error handler
app.UseMiddleware<ErrorHandlerMiddleware>(); // added

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();
app.UseAuthentication();        // added

app.UseSession();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.UseAPI();       // added

app.Run();
