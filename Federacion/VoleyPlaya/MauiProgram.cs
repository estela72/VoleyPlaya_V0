using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

using Newtonsoft.Json;

using System.Reflection;
using System.Text.Json;

using VoleyPlaya.Models;

using static System.Net.Mime.MediaTypeNames;

namespace VoleyPlaya
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
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
            return mauiAppBuilder;
        }
        public static MauiAppBuilder RegisterViewModels(this MauiAppBuilder mauiAppBuilder)
        {
            mauiAppBuilder.Services.AddSingleton<ViewModels.CompeticionesViewModel>();
            mauiAppBuilder.Services.AddSingleton<ViewModels.CompeticionViewModel>();
            mauiAppBuilder.Services.AddSingleton<ViewModels.ConfiguracionViewModel>();
            mauiAppBuilder.Services.AddSingleton<ViewModels.MainPageViewModel>();
            mauiAppBuilder.Services.AddSingleton<ViewModels.TablaCalendarioViewModel>();
            mauiAppBuilder.Services.AddSingleton<ViewModels.TablasCalendariosViewModel>();
            return mauiAppBuilder;
        }
        public static MauiAppBuilder RegisterViews(this MauiAppBuilder mauiAppBuilder)
        {
            mauiAppBuilder.Services.AddTransient<Views.CompeticionesPage>();
            mauiAppBuilder.Services.AddTransient<Views.CompeticionPage>();
            mauiAppBuilder.Services.AddTransient<Views.ConfiguracionPage>();
            mauiAppBuilder.Services.AddTransient<Views.MainPage>();
            mauiAppBuilder.Services.AddTransient<Views.PartidosPage>();
            mauiAppBuilder.Services.AddTransient<Views.TablaCalendarioPage>();
            mauiAppBuilder.Services.AddTransient<Views.TablasCalendariosPage>();
            return mauiAppBuilder;
        }
        public static MauiAppBuilder LoadConfigFiles(this MauiAppBuilder mauiAppBuilder)
        {
            LoadMauiAsset();



            return mauiAppBuilder;
        }

        public static async Task<string> LoadMauiAsset()
        {
            try
            {
                using var stream = await FileSystem.OpenAppPackageFileAsync("calendarios.json");
                using var reader = new StreamReader(stream);

                var json = reader.ReadToEnd();
                RootTablaCalendario calendarios = JsonConvert.DeserializeObject<RootTablaCalendario>(json);
                return json;
            }
            catch (Exception ex)
            {
                return "";
            }

        }

    }
}