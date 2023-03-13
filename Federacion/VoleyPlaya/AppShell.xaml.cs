namespace VoleyPlaya
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(Views.CompeticionesPage), typeof(Views.CompeticionesPage));
            Routing.RegisterRoute(nameof(Views.CompeticionPage), typeof(Views.CompeticionPage));
            Routing.RegisterRoute(nameof(Views.PartidosPage), typeof(Views.PartidosPage));
            Routing.RegisterRoute(nameof(Views.ConfiguracionPage), typeof(Views.ConfiguracionPage));
            Routing.RegisterRoute(nameof(Views.TablasCalendariosPage), typeof(Views.TablasCalendariosPage));
            Routing.RegisterRoute(nameof(Views.TablaCalendarioPage), typeof(Views.TablaCalendarioPage));
        }
    }
}