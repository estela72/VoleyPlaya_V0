namespace VoleyPlaya.Views;

public partial class CompeticionesPage : ContentPage
{
    public CompeticionesPage()
    {
        InitializeComponent();
    }

    private void ContentPage_NavigatedTo(object sender, NavigatedToEventArgs e)
    {
        competicionesCollection.SelectedItem = null;
    }
}