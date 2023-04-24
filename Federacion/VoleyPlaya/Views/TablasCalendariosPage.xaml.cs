namespace VoleyPlaya.Views;

public partial class TablasCalendariosPage : ContentPage
{
	public TablasCalendariosPage()
	{
		InitializeComponent();
	}
    private void ContentPage_NavigatedTo(object sender, NavigatedToEventArgs e)
    {
        tablasCalendariosCollection.SelectedItem = null;
    }
}