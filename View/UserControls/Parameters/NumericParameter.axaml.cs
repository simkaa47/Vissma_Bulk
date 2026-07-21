using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using System.Windows.Input;
using View.ViewModels;

namespace View.UserControls.Parameters;

public partial class NumericParameter : ParameterCommon
{
    public NumericParameter()
    {
        InitializeComponent();
    }

}