using VoleyPlaya.ViewModels;

namespace VoleyPlaya.Views;

public partial class CompeticionPage : ContentPage
{
	public CompeticionPage()
	{
		InitializeComponent();
	}

    private void NumJornadasEntry_Completed(object sender, EventArgs e)
    {
		if (((Entry)sender).BindingContext is ICompeticionVM competicionVM)
			competicionVM.OnNumJornadasChanged();
    }

    private void NumEquiposEntry_Completed(object sender, EventArgs e)
    {
        if (((Entry)sender).BindingContext is ICompeticionVM competicionVM)
            competicionVM.OnNumEquiposChanged();
    }
}