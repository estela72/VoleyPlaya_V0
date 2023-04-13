using VoleyPlaya.ViewModels;

namespace VoleyPlaya.Views;

public partial class EdicionesPage : ContentPage
{
    public EdicionesPage(EdicionesViewModel edicionesViewModel)
    {
        BindingContext = edicionesViewModel;
        InitializeComponent();
    }

    private void ContentPage_NavigatedTo(object sender, NavigatedToEventArgs e)
    {
        edicionesCollection.SelectedItem = null;
    }
}