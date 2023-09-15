using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Core.Models.AccesControl;

namespace View.Dialogs.Access;

public partial class UserWindow : Window
{
    public UserWindow()
    {
        InitializeComponent();
    }

    public UserWindow(User user)
    {
        InitializeComponent();
        this.DataContext = user;
    }

    public bool DialogResult { get; set; }

    void Accept_Click(object sender, RoutedEventArgs e)
    {
        DialogResult = true;
        Close();
    }

    void Cancel_Click(object sender, RoutedEventArgs e)
    {
        Close();
    }


}