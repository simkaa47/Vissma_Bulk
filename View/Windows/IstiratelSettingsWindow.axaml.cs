using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Interactivity;
using System;

namespace View.Windows;

public partial class IstiratelSettingsWindow : Window
{
    public IstiratelSettingsWindow()
    {
        InitializeComponent();
        this.Opened += OnOpened;
    }

    private void OnOpened(object? sender, EventArgs e)
    {
        this.WindowState = WindowState.Maximized;
    }

    private void OpenControlWindow(object? sender, RoutedEventArgs args)
    {
        if (App.Current?.ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            var current = desktop.MainWindow;
            desktop.MainWindow = new ControlWindow
            {
                DataContext = this.DataContext
            };
            desktop.MainWindow.Show();
            current.Close();
        }
    }

    private void OpenErrorsWindow(object? sender, RoutedEventArgs args)
    {
        if (App.Current?.ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            var current = desktop.MainWindow;
            desktop.MainWindow = new ErrorsWindow
            {
                DataContext = this.DataContext
            };
            desktop.MainWindow.Show();
            current.Close();
        }
    }
}