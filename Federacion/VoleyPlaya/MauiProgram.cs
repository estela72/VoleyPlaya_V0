using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

using Newtonsoft.Json;

using System;
using System.Reflection;
using System.Text.Json;

using VoleyPlaya.Models;
using VoleyPlaya.Repository;

using static System.Net.Mime.MediaTypeNames;

namespace VoleyPlaya
{
    public static class MauiProgram
    {
        public static IConfiguration Configuration { get; private set; }
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .LoadConfigFiles()
                .RegisterAppServices()
                .RegisterViewModels()
                .RegisterViews()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
            builder.Logging.AddDebug();
#endif
            
            return builder.Build();
        }
        public static MauiAppBuilder RegisterAppServices(this MauiAppBuilder mauiAppBuilder)
        {
#if WINDOWS
		    mauiAppBuilder.Services.AddTransient<IFolderPicker, Platforms.Windows.FolderPicker>();
#endif
            mauiAppBuilder.Services.AddRepositoryStartup();
            return mauiAppBuilder;
        }
        public static MauiAppBuilder RegisterViewModels(this MauiAppBuilder mauiAppBuilder)
        {
            mauiAppBuilder.Services.AddScoped<ViewModels.EdicionesViewModel>();
            mauiAppBuilder.Services.AddScoped<ViewModels.EdicionViewModel>();
            mauiAppBuilder.Services.AddScoped<ViewModels.ConfiguracionViewModel>();
            mauiAppBuilder.Services.AddScoped<ViewModels.MainPageViewModel>();
            mauiAppBuilder.Services.AddScoped<ViewModels.TablaCalendarioViewModel>();
            mauiAppBuilder.Services.AddScoped<ViewModels.TablasCalendariosViewModel>();
            return mauiAppBuilder;
        }
        public static MauiAppBuilder RegisterViews(this MauiAppBuilder mauiAppBuilder)
        {
            mauiAppBuilder.Services.AddScoped<Views.EdicionesPage>();
            mauiAppBuilder.Services.AddScoped<Views.EdicionPage>();
            mauiAppBuilder.Services.AddScoped<Views.ConfiguracionPage>();
            mauiAppBuilder.Services.AddScoped<Views.MainPage>();
            mauiAppBuilder.Services.AddScoped<Views.PartidosPage>();
            mauiAppBuilder.Services.AddTransient<Views.TablaCalendarioPage>();
            mauiAppBuilder.Services.AddScoped<Views.TablasCalendariosPage>();
            return mauiAppBuilder;
        }
        public static MauiAppBuilder LoadConfigFiles(this MauiAppBuilder mauiAppBuilder)
        {
            var a = Assembly.GetExecutingAssembly();
            using var stream = a.GetManifestResourceStream("VoleyPlaya.appsettings.json");
            Configuration = new ConfigurationBuilder()
                        .AddJsonStream(stream)
                        .Build();
            mauiAppBuilder.Configuration.AddConfiguration(Configuration);
            return mauiAppBuilder;
        }
    }
}