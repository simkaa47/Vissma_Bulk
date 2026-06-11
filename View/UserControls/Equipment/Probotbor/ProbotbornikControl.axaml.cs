using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using System.Threading.Tasks;
using View.Windows;

namespace View.UserControls.Equipment.Probootbor;

public partial class ProbotbornikControl : UserControl
{
    public ProbotbornikControl()
    {
        InitializeComponent();
    }

    private async void OpenProbotborWindow(object? sender, RoutedEventArgs args)
    {
        if (App.Current?.ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            var current = desktop.MainWindow;
            var probWindow = new ProbotbornikSettingsWindow
            {
                DataContext = this.DataContext
            };
            //desktop.MainWindow.Show();
            await probWindow.ShowDialog(desktop.MainWindow);
            //current.Close();
        }
    }
}