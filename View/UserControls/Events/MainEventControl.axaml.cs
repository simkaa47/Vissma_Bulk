using Avalonia.Controls;
using Avalonia.Media;
using JetBrains.Annotations;
using System;
using View.Utilites;
using View.ViewModels;

namespace View.UserControls.Events;

public partial class MainEventControl : UserControl
{
    public MainEventControl()
    {
        InitializeComponent();
        var vm = App.Current.CreateInstance<EventViewModel>();
        DataContext = vm;
    }

    


}