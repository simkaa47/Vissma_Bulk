using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Input;
using Avalonia.Interactivity;
using CommunityToolkit.Mvvm.Messaging;
using Core.ViewModels;
using System;
using View.ViewModels;

namespace View.Windows;

public partial class ControlWindow : Window
{
    public ControlWindow()
    {
        InitializeComponent();
        this.Opened += OnOpened;
    }

    private void OnOpened(object? sender, EventArgs e)
    {
        //this.WindowState = WindowState.Maximized;
        this.InvalidateVisual();
        this.AddHandler<FocusChangedEventArgs>(InputElement.GotFocusEvent, openVirtualKeyboard);
    }

    StyledElement? keyboard;

    private void OnKeyboardInitialized(object? sender, RoutedEventArgs e)
    {
        if (sender is not null && sender is StyledElement control)
        {
            keyboard = control;
            control.DataContext = new KeyBoardViewModel();
        }
    }

    private void openVirtualKeyboard(object? sender, FocusChangedEventArgs e)
    {
        if (e.Source!.GetType() == typeof(TextBox) && keyboard is not null && keyboard.DataContext is KeyBoardViewModel vm)
        {

            if (!vm.IsOskVisible)
            {
                WeakReferenceMessenger.Default.Send(new PassObjectMsg(e.Source));
                WeakReferenceMessenger.Default.Send(new OskControlMsg(true));
                e.Handled = true;
            }
            else
            {
                e.Handled = false;
            }
        }
    }



    private void OpenProbotborWindow(object? sender, RoutedEventArgs args)
    { 
        if (App.Current?.ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            var current = desktop.MainWindow;
            desktop.MainWindow = new ProbotbornikSettingsWindow
            {
                DataContext = this.DataContext
            };
            desktop.MainWindow.Show();
            current.Close();
        }
    }

    private void OpenPitetelWindow(object? sender, RoutedEventArgs args)
    {
        if (App.Current?.ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            var current = desktop.MainWindow;
            desktop.MainWindow = new PitatelSettingsWindow
            {
                DataContext = this.DataContext
            };
            desktop.MainWindow.Show();
            current.Close();
        }
    }


    private void OpenDrobilkaWindow(object? sender, RoutedEventArgs args)
    {
        if (App.Current?.ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            var current = desktop.MainWindow;
            desktop.MainWindow = new DrobilkaSettingsWindow
            {
                DataContext = this.DataContext
            };
            desktop.MainWindow.Show();
            current.Close();
        }
    }

    private void OpenDelitelWindow(object? sender, RoutedEventArgs args)
    {
        if (App.Current?.ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            var current = desktop.MainWindow;
            desktop.MainWindow = new DelitelSettingsWindow
            {
                DataContext = this.DataContext
            };
            desktop.MainWindow.Show();
            current.Close();
        }
    }

    private void OpenDryWindow(object? sender, RoutedEventArgs args)
    {
        if (App.Current?.ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            var current = desktop.MainWindow;
            desktop.MainWindow = new DrySettingsWindow
            {
                DataContext = this.DataContext
            };
            desktop.MainWindow.Show();
            current.Close();
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

    private void OpenNakopitelWindow(object? sender, RoutedEventArgs args)
    {
        if (App.Current?.ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            var current = desktop.MainWindow;
            desktop.MainWindow = new NakopitelSettingsWindow
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