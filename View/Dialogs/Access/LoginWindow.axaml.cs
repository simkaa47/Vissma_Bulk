using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Core.Models.AccesControl;
using Core.ViewModels;

namespace View.Dialogs.Access;

public partial class LoginWindow : Window
{
    public LoginWindow()
    {
        InitializeComponent();
    }

    private void LoginClick(object? sender, RoutedEventArgs args)
    {
        if (this.DataContext is null) return;
        if (!(this.DataContext is AccessViewModel vm)) return;
        if (this.Resources["LoginModel"] == null) return;
        if (!(this.Resources["LoginModel"] is Login login)) return;
        vm.Login(login);
        if (login.IsSuccessLogin)
            this.Close();
    }
}