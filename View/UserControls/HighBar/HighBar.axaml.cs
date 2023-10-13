using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Interactivity;
using Core.ViewModels;
using View.Windows;

namespace View.UserControls.HighBar;

public partial class HighBar : UserControl
{
    public HighBar()
    {
        InitializeComponent();
    }


    private async void OpenParametersWindowClick(object? sender, RoutedEventArgs args)
    {
        if (this.DataContext is null) return;
        if (!(this.DataContext is MainViewModel vm)) return;
        if (vm is null || vm.AccessViewModel is null) return;
        
        if (!(App.Current?.ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop))
        {
            return;
        }
        ParametersWindow parWindow = new ParametersWindow();
        parWindow.DataContext = this.DataContext; ;   
        await parWindow.ShowDialog(desktop.MainWindow);

    }

    private void LogoutClick(object? sender, RoutedEventArgs args)
    {
        if (this.DataContext is null) return;
        if (!(this.DataContext is MainViewModel vm)) return;
        if (vm is null || vm.AccessViewModel is null) return;

        vm.AccessViewModel.Logout();
        if (App.Current?.ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            var current = desktop.MainWindow;
            desktop.MainWindow = new AuthorizationWindow
            {
                DataContext = this.DataContext
            };
            desktop.MainWindow.Show();
            current.Close();
        }
    }
}