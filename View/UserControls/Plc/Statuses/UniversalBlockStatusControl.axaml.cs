using Avalonia;
using System.Collections.Generic;
using View.UserControls.Parameters;

namespace View.UserControls.Plc.Statuses;

public partial class UniversalBlockStatusControl : ParameterCommon
{
    public UniversalBlockStatusControl()
    {
        InitializeComponent();
        AffectsMeasure<ProbotborStatus>(StatusNameProperty);
        AffectsMeasure<ProbotborStatus>(StatusesProperty);
        AffectsMeasure<ProbotborStatus>(IndexProperty);
    }

    #region StatusName
    public string StatusName
    {
        get { return (string)GetValue(StatusNameProperty); }
        set { SetValue(StatusNameProperty, value); }
    }

    // Using a DependencyProperty as the backing store for State.  This enables animation, styling, binding, etc...
    public static readonly StyledProperty<string> StatusNameProperty =
        AvaloniaProperty.Register<UniversalBlockStatusControl, string>(nameof(StatusName));
    #endregion

    #region Statuses
    public IEnumerable<string> Statuses
    {
        get { return (IEnumerable<string>)GetValue(StatusesProperty); }
        set { SetValue(StatusesProperty, value); }
    }

    // Using a DependencyProperty as the backing store for State.  This enables animation, styling, binding, etc...
    public static readonly StyledProperty<IEnumerable<string>> StatusesProperty =
        AvaloniaProperty.Register<UniversalBlockStatusControl, IEnumerable<string>>(nameof(Statuses));
    #endregion

    #region Index
    public int Index
    {
        get { return (int)GetValue(IndexProperty); }
        set { SetValue(IndexProperty, value); }
    }

    // Using a DependencyProperty as the backing store for State.  This enables animation, styling, binding, etc...
    public static readonly StyledProperty<int> IndexProperty =
        AvaloniaProperty.Register<UniversalBlockStatusControl, int>(nameof(Index));
    #endregion


}