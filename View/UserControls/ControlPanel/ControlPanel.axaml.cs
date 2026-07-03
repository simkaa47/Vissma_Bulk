using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using System;
using View.UserControls.Equipment;

namespace View.UserControls.ControlPanel;

public partial class ControlPanel : UserControl
{
    public ControlPanel()
    {
        InitializeComponent();
    }

    //private async void OpenEquipmentControl(object sender, RoutedEventArgs e)
    //{
    //    var equipmentControl = new EquipmentControl();

    //    ManageTabItem.Content = equipmentControl;
    //}

    private Control _originalContent;

    private async void OpenEquipmentControl(object sender, RoutedEventArgs e)
    {
        if (_originalContent == null)
        {
            _originalContent = ManageTabItem.Content as Control;
        }

        var equipmentControl = new EquipmentControl();
        equipmentControl.BackRequested += OnEquipmentControlBackRequested;
        ManageTabItem.Content = equipmentControl;
        var button = sender as Button;
        int index = int.Parse( button.CommandParameter?.ToString());
        equipmentControl.slides.SelectedIndex = index;
    }

    private void OnEquipmentControlBackRequested(object sender, EventArgs e)
    {
        // Отписываемся от события, чтобы избежать утечек памяти
        if (sender is EquipmentControl control)
        {
            control.BackRequested -= OnEquipmentControlBackRequested;
        }

        // Возвращаем исходное содержимое
        ManageTabItem.Content = _originalContent;
    }


    private void Button_Click(object? sender, RoutedEventArgs e)
    {
    }
}