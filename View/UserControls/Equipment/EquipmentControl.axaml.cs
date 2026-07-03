using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using System;
using View.Windows;

namespace View.UserControls.Equipment;

public partial class EquipmentControl : UserControl
{
    public EquipmentControl()
    {
        InitializeComponent();
    }

    public event EventHandler BackRequested;

    private void OnBackButtonClick(object sender, RoutedEventArgs e)
    {
        BackRequested?.Invoke(this, EventArgs.Empty);
    }

    public void Next(object source, RoutedEventArgs args)
    {
        slides.Next();
    }

    public void Previous(object source, RoutedEventArgs args)
    {
        slides.Previous();
    }


    private async void OpenPitetelWindow(object? sender, RoutedEventArgs args)
    {
        if (App.Current?.ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            //var current = desktop.MainWindow;
            var pitWindow = new PitatelSettingsWindow
            {
                DataContext = this.DataContext
            };
            //desktop.MainWindow.Show();
            await pitWindow.ShowDialog(desktop.MainWindow);
            //current.Close();
        }
    }


    private async void OpenNakopitelWindow(object? sender, RoutedEventArgs args)
    {
        if (App.Current?.ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {

            var nakWindow = new NakopitelSettingsWindow
            {
                DataContext = this.DataContext
            };
            await nakWindow.ShowDialog(desktop.MainWindow);

        }
    }

    private async void OpenDrobilkaWindow(object? sender, RoutedEventArgs args)
    {
        if (App.Current?.ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            //var current = desktop.MainWindow;
            var drobWindow = new DrobilkaSettingsWindow
            {
                DataContext = this.DataContext
            };
            //desktop.MainWindow.Show();
            //current.Close();

            await drobWindow.ShowDialog(desktop.MainWindow);
        }
    }

    private async void OpenDelitelWindow(object? sender, RoutedEventArgs args)
    {
        if (App.Current?.ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            //var current = desktop.MainWindow;
            var delWindow = new DelitelSettingsWindow
            {
                DataContext = this.DataContext
            };

            await delWindow.ShowDialog(desktop.MainWindow);

            //desktop.MainWindow.Show();
            //current.Close();
        }
    }

    private async void OpenDryWindow(object? sender, RoutedEventArgs args)
    {
        if (App.Current?.ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            var dryWindow = new DrySettingsWindow
            {
                DataContext = this.DataContext
            };

            await dryWindow.ShowDialog(desktop.MainWindow);


        }
    }

    private void OpenIstiratelWindow(object? sender, RoutedEventArgs args)
    {
        if (App.Current?.ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            var current = desktop.MainWindow;
            desktop.MainWindow = new IstiratelSettingsWindow
            {
                DataContext = this.DataContext
            };
            desktop.MainWindow.Show();
            current.Close();
        }
    }



    private void OpenSysReturnWindow(object? sender, RoutedEventArgs args)
    {
        if (App.Current?.ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            var current = desktop.MainWindow;
            desktop.MainWindow = new SysReturnSettingsWindow
            {
                DataContext = this.DataContext
            };
            desktop.MainWindow.Show();
            current.Close();
        }
    }

    private void OpenEquipWindow(object? sender, RoutedEventArgs args)
    {
        if (App.Current?.ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            var current = desktop.MainWindow;
            desktop.MainWindow = new EquipmentWindow
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