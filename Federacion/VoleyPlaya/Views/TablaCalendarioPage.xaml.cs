namespace VoleyPlaya.Views;

public partial class TablaCalendarioPage : ContentPage
{
    private readonly IFolderPicker _folderPicker;

    public TablaCalendarioPage(IFolderPicker folderPicker)
	{
        InitializeComponent();
        _folderPicker = folderPicker;
	}
    private async void OnPickFolderClicked(object sender, EventArgs e)
    {
        var pickedFolder = await _folderPicker.PickFolder();

        FolderLabel.Text = pickedFolder;

        SemanticScreenReader.Announce(FolderLabel.Text);
    }
}