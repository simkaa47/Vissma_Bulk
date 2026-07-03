using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Input;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Core.ViewModels;
using System.Threading.Tasks;
using View.Windows;

namespace View.UserControls.Equipment.Probootbor;

public partial class ProbotbornikControl : UserControl
{
    public ProbotbornikControl()
    {
        InitializeComponent();
        //AddHandlerToButton();
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

    private void AddHandlerToButton()
    {
        // Находим кнопку по имени
        var repeatButton = this.FindControl<RepeatButton>("WaterButton");

        if (repeatButton != null)
        {
            // Подписываемся на PointerPressed с разрешением обрабатывать уже перехваченные события
            repeatButton.AddHandler(
                InputElement.PointerPressedEvent,
                OnPointerPressed,
                RoutingStrategies.Bubble,
                handledEventsToo: true);

            // Подписываемся на PointerReleased
            repeatButton.AddHandler(
                InputElement.PointerReleasedEvent,
                OnPointerReleased,
                RoutingStrategies.Bubble,
                handledEventsToo: true);
        }
    }

    private async void OnPointerPressed(object? sender, Avalonia.Input.PointerPressedEventArgs pressedEventArgs)
    {
        var dataContext = this.DataContext;
        if (dataContext is MainViewModel mainViewModel)
        {
            mainViewModel.PlcViewModel.IsFlooding = true;
        }
    }

    private async void OnPointerReleased(object? sender, Avalonia.Input.PointerReleasedEventArgs releasedEventArgs)
    {
        var dataContext = this.DataContext;
        if (dataContext is MainViewModel mainViewModel)
        {
            mainViewModel.PlcViewModel.IsFlooding = false;
        }
    }

}