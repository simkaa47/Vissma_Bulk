using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Input;
using Avalonia.Interactivity;
using CommunityToolkit.Mvvm.Messaging;
using Core.Models.AccesControl;
using Core.ViewModels;
using System;
using System.Threading.Tasks;
using View.Utilites;
using View.ViewModels;

namespace View.Windows;

public partial class AuthorizationWindow : Window
{
    public AuthorizationWindow()
    {
        InitializeComponent();
        this.Opened += OnOpened;
        this.AddHandler<FocusChangedEventArgs>(InputElement.GotFocusEvent, openVirtualKeyboard);
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
                    if (main.ActivityLogVm is null)
                    {
                        var activityVm = App.Current.CreateInstance<ActivityLogViewModel>();
                        main.ActivityLogVm = activityVm;
                    }

                }
                await Task.Delay(200);
                desktop.MainWindow.Show();
                this.Close();

            }
        }

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


    private void OnOpened(object? sender, EventArgs e)
    {
        //this.WindowState = WindowState.Maximized;
        this.InvalidateVisual();
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

}