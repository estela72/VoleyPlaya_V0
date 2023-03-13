using VoleyPlaya.ViewModels;

namespace VoleyPlaya.Views;

public partial class PartidosPage : ContentPage
{
	public PartidosPage()
	{
		InitializeComponent();
	}

    private void ResultadoParcial_Changed(object sender, TextChangedEventArgs e)
    {
        if (((Entry)sender).BindingContext is ICompeticionVM partido)
            partido.OnResultadoParcialChanged();
    }
}