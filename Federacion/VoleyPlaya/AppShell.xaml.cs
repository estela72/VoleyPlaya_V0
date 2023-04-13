namespace VoleyPlaya
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(Views.EdicionesPage), typeof(Views.EdicionesPage));
            Routing.RegisterRoute(nameof(Views.EdicionPage), typeof(Views.EdicionPage));
            Routing.RegisterRoute(nameof(Views.PartidosPage), typeof(Views.PartidosPage));
            Routing.RegisterRoute(nameof(Views.ConfiguracionPage), typeof(Views.ConfiguracionPage));
            Routing.RegisterRoute(nameof(Views.TablasCalendariosPage), typeof(Views.TablasCalendariosPage));
            Routing.RegisterRoute(nameof(Views.TablaCalendarioPage), typeof(Views.TablaCalendarioPage));
        }
    }
}