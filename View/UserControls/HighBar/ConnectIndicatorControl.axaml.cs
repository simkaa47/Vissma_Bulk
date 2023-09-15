using Avalonia;
using Avalonia.Controls;

namespace View.UserControls.HighBar;

public partial class ConnectIndicatorControl : UserControl
{
    public ConnectIndicatorControl()
    {
        InitializeComponent();
        AffectsMeasure<ConnectIndicatorControl>(StateProperty);
        AffectsMeasure<ConnectIndicatorControl>(DescriptionProperty);
    }





    #region State
    public bool State
    {
        get { return (bool)GetValue(StateProperty); }
        set { SetValue(StateProperty, value); }
    }

    // Using a DependencyProperty as the backing store for State.  This enables animation, styling, binding, etc...
    public static readonly StyledProperty<bool> StateProperty =
        AvaloniaProperty.Register<ConnectIndicatorControl, bool>(nameof(State));
    #endregion
    #region Description
    public string Description
    {
        get { return (string)GetValue(DescriptionProperty); }
        set { SetValue(DescriptionProperty, value); }
    }

    // Using a DependencyProperty as the backing store for State.  This enables animation, styling, binding, etc...
    public static readonly StyledProperty<string> DescriptionProperty =
        AvaloniaProperty.Register<ConnectIndicatorControl, string>(nameof(Description));
    #endregion



}