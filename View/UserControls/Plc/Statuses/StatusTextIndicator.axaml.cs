using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using System.Collections;
using System.Collections.Generic;
using View.UserControls.Parameters;

namespace View.UserControls.Plc;

public partial class StatusTextIndicator : UserControl
{
    public StatusTextIndicator()
    {
        InitializeComponent();
        AffectsMeasure<StatusTextIndicator>(StatusNameProperty);
        AffectsMeasure<StatusTextIndicator>(StatusesProperty);
        AffectsMeasure<StatusTextIndicator>(IndexProperty);
    }

    #region StatusName
    public string StatusName
    {
        get { return (string)GetValue(StatusNameProperty); }
        set { SetValue(StatusNameProperty, value); }
    }

    // Using a DependencyProperty as the backing store for State.  This enables animation, styling, binding, etc...
    public static readonly StyledProperty<string> StatusNameProperty =
        AvaloniaProperty.Register<StatusTextIndicator, string>(nameof(StatusName));
    #endregion

    #region Statuses
    public IEnumerable<string> Statuses
    {
        get { return (IEnumerable<string>)GetValue(StatusesProperty); }
        set { SetValue(StatusesProperty, value); }
    }

    // Using a DependencyProperty as the backing store for State.  This enables animation, styling, binding, etc...
    public static readonly StyledProperty<IEnumerable<string>> StatusesProperty =
        AvaloniaProperty.Register<StatusTextIndicator, IEnumerable<string>>(nameof(Statuses));
    #endregion

    #region Index
    public int Index
    {
        get { return (int)GetValue(IndexProperty); }
        set { SetValue(IndexProperty, value); }
    }

    // Using a DependencyProperty as the backing store for State.  This enables animation, styling, binding, etc...
    public static readonly StyledProperty<int> IndexProperty =
        AvaloniaProperty.Register<StatusTextIndicator, int>(nameof(Index));
    #endregion
}