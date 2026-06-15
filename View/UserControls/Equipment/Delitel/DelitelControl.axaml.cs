using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using View.Windows;

namespace View.UserControls.Equipment.Delitel;

public partial class DelitelControl : UserControl
{
    public DelitelControl()
    {
        InitializeComponent();
    }

    private async void OpenDelitelWindow(object? sender, RoutedEventArgs args)
    {
        if (App.Current?.ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            var current = desktop.MainWindow;
            var delWindow = new DelitelSettingsWindow
            {
                DataContext = this.DataContext
            };

            await delWindow.ShowDialog(desktop.MainWindow);

            //desktop.MainWindow.Show();
            //current.Close();
        }
    }

}