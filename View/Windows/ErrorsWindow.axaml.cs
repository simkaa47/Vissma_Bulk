using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Core.ViewModels;
using Microsoft.Extensions.Logging;
using System;
using View.Utilites;
using View.ViewModels;

namespace View.Windows;

public partial class ErrorsWindow : Window
{
    public ErrorsWindow()
    {
        InitializeComponent();
        this.Opened += OnOpened;
       
    }

    MainViewModel mainVm;
    EventViewModel eventVm;

    private void OnOpened(object? sender, EventArgs e)
    {
        eventVm = App.Current.CreateInstance<EventViewModel>();
        if(this.DataContext is MainViewModel main)
        {
            mainVm = main;
        }        
        this.DataContext = eventVm;
        this.WindowState = WindowState.Maximized;
    }

    private void OpenControlWindow(object? sender, RoutedEventArgs args)
    {
        if (App.Current?.ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            var current = desktop.MainWindow;
            desktop.MainWindow = new ControlWindow
            { 
                
                DataContext = mainVm
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
                DataContext = mainVm
            };
            desktop.MainWindow.Show();
            current.Close();
        }
    }
}