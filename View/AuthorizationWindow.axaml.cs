using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Interactivity;
using Core.Models.AccesControl;
using Core.ViewModels;
using System;

namespace View
{
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
                    desktop.MainWindow = new MainWindow
                    {
                        DataContext = this.DataContext
                    };
                    desktop.MainWindow.Show();
                    this.Close();

                }
            }

        }

        private void OnOpened(object? sender, EventArgs e)
        {
            this.WindowState = WindowState.Maximized;
        }
    }
}
