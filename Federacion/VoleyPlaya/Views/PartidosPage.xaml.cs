using VoleyPlaya.ViewModels;

namespace VoleyPlaya.Views;

public partial class PartidosPage : ContentPage
{
	public PartidosPage(EdicionViewModel edicion)
	{
        BindingContext = edicion;
		InitializeComponent();
	}

    private void ResultadoParcial_Changed(object sender, TextChangedEventArgs e)
    {
        (BindingContext as EdicionViewModel).UpdatePartidos();
    }
}