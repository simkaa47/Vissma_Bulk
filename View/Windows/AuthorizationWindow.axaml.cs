using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Interactivity;
using Core.Models.AccesControl;
using Core.ViewModels;
using System;
using View.Utilites;
using View.ViewModels;

namespace View.Windows;

public partial class AuthorizationWindow : Window
{
    public AuthorizationWindow()
    {
        InitializeComponent();
        this.Opened += OnOpened;
    }

    private async void LoginClick(object? sender, RoutedEventArgs args)
    {
        if (this.DataContext is null) return;
        if (!(this.DataContext is MainViewModel vm)) return;
        if (vm is null || vm.AccessViewModel is null) return;
        if (this.Resources["LoginModel"] == null) return;
        if (!(this.Resources["LoginModel"] is Login login)) return;
        await vm.AccessViewModel.Login(login);
        if (login.IsSuccessLogin)
        {
            if (App.Current?.ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                desktop.MainWindow = new ControlWindow
                {
                    DataContext = this.DataContext
                };
                if (this.DataContext is not null && this.DataContext is MainViewModel main)
                {
                    if (main.EventsVm is null)
                    {
                        var eventVm = App.Current.CreateInstance<EventViewModel>();
                        main.EventsVm = eventVm;
                    }

                }
                desktop.MainWindow.Show();
                this.Close();

            }
        }

    }

    private void OnOpened(object? sender, EventArgs e)
    {
        //this.WindowState = WindowState.Maximized;
        this.InvalidateVisual();
    }
}