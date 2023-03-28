using VoleyPlaya.ViewModels;

namespace VoleyPlaya.Views;

public partial class EdicionPage : ContentPage
{
    public EdicionPage(EdicionViewModel edicionViewModel)
    {
        BindingContext = edicionViewModel;
        InitializeComponent();
    }

    private void NumEquiposEntry_TextChanged(object sender, TextChangedEventArgs e)
    {
        (BindingContext as EdicionViewModel).AddEquipos();
    }

    private void NumJornadasEntry_TextChanged(object sender, TextChangedEventArgs e)
    {
        (BindingContext as EdicionViewModel).AddJornadas();
    }
    private void ResultadoParcial_Changed(object sender, TextChangedEventArgs e)
    {
        (BindingContext as EdicionViewModel).UpdatePartidos();
    }
}