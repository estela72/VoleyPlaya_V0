using VoleyPlaya.ViewModels;

namespace VoleyPlaya.Views;

public partial class EdicionPage : ContentPage
{
	public EdicionPage(EdicionViewModel edicionViewModel)
	{
        BindingContext = edicionViewModel;
        InitializeComponent();
    }

    private void NumJornadasEntry_Completed(object sender, EventArgs e)
    {
		if (((Entry)sender).BindingContext is IEdicionVM edicionVM)
            edicionVM.OnNumJornadasChanged();
    }

    private void NumEquiposEntry_Completed(object sender, EventArgs e)
    {
        if (((Entry)sender).BindingContext is IEdicionVM edicionVM)
            edicionVM.OnNumEquiposChanged();
    }
}