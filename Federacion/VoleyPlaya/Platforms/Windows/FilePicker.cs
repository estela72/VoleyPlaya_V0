using WindowsFilePicker = Windows.Storage.Pickers.FileOpenPicker;

namespace VoleyPlaya.Platforms.Windows
{
    public class FilePicker : IFilePicker
    {
        public async Task<string> PickFile()
        {
            var filePicker = new WindowsFilePicker();
            // Might be needed to make it work on Windows 10
            filePicker.FileTypeFilter.Add("*");

            // Get the current window's HWND by passing in the Window object
            var hwnd = ((MauiWinUIWindow)App.Current.Windows[0].Handler.PlatformView).WindowHandle;

            // Associate the HWND with the file picker
            WinRT.Interop.InitializeWithWindow.Initialize(filePicker, hwnd);

            var result = await filePicker.PickSingleFileAsync();

            return result?.Path;
        }
    }
}