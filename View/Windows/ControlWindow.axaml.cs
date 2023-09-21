using Avalonia.Controls;
using System;

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
        this.WindowState = WindowState.Maximized;
    }
}