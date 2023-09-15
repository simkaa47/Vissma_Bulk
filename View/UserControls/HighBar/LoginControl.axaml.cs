using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using View.Dialogs.Access;

namespace View.UserControls.HighBar;

public partial class LoginControl : UserControl
{
    public LoginControl()
    {
        InitializeComponent();
    }

    private async void ShowLoginWindow(object? sender, RoutedEventArgs args)
    {
        if (!(App.Current?.ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop))
        {
            return;
        }        
        var loginWindow = new LoginWindow();
        loginWindow.DataContext = this.DataContext;
        await loginWindow.ShowDialog(desktop.MainWindow);

    }
}