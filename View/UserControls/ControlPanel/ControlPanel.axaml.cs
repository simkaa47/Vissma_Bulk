using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using View.UserControls.Equipment;

namespace View.UserControls.ControlPanel;

public partial class ControlPanel : UserControl
{
    public ControlPanel()
    {
        InitializeComponent();
    }

    private async void OpenEquipmentControl(object sender, RoutedEventArgs e)
    {
        var equipmentControl = new EquipmentControl();

        ManageTabItem.Content = equipmentControl;
    }

    private void Button_Click(object? sender, RoutedEventArgs e)
    {
    }
}