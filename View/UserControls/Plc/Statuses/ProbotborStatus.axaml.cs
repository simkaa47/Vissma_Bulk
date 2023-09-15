using Avalonia;
using System.Collections.Generic;
using View.UserControls.Parameters;

namespace View.UserControls.Plc.Statuses;

public partial class ProbotborStatus : ParameterCommon
{
    public ProbotborStatus()
    {
        InitializeComponent();
        AffectsMeasure<ProbotborStatus>(StatusNameProperty);
        AffectsMeasure<ProbotborStatus>(StatusesProperty);
        AffectsMeasure<ProbotborStatus>(IndexProperty);
        AffectsMeasure<ProbotborStatus>(SqHomeAbortParameterProperty);       
        AffectsMeasure<ProbotborStatus>(SqHomeParameterProperty);
        AffectsMeasure<ProbotborStatus>(SqWorkAbortParameterProperty);
        AffectsMeasure<ProbotborStatus>(SqWorkParameterProperty);
        AffectsMeasure<ProbotborStatus>(BusyParameterProperty);
        AffectsMeasure<ProbotborStatus>(ReadyParameterProperty);
        AffectsMeasure<ProbotborStatus>(OtborCmdParameterProperty);
    }

    #region StatusName
    public string StatusName
    {
        get { return (string)GetValue(StatusNameProperty); }
        set { SetValue(StatusNameProperty, value); }
    }

    // Using a DependencyProperty as the backing store for State.  This enables animation, styling, binding, etc...
    public static readonly StyledProperty<string> StatusNameProperty =
        AvaloniaProperty.Register<ProbotborStatus, string>(nameof(StatusName));
    #endregion

    #region Statuses
    public IEnumerable<string> Statuses
    {
        get { return (IEnumerable<string>)GetValue(StatusesProperty); }
        set { SetValue(StatusesProperty, value); }
    }

    // Using a DependencyProperty as the backing store for State.  This enables animation, styling, binding, etc...
    public static readonly StyledProperty<IEnumerable<string>> StatusesProperty =
        AvaloniaProperty.Register<ProbotborStatus, IEnumerable<string>>(nameof(Statuses));
    #endregion

    #region Index
    public int Index
    {
        get { return (int)GetValue(IndexProperty); }
        set { SetValue(IndexProperty, value); }
    }

    // Using a DependencyProperty as the backing store for State.  This enables animation, styling, binding, etc...
    public static readonly StyledProperty<int> IndexProperty =
        AvaloniaProperty.Register<ProbotborStatus, int>(nameof(Index));
    #endregion

    #region Sq home abort 
    public object SqHomeAbortParameter
    {
        get { return GetValue(SqHomeAbortParameterProperty); }
        set { SetValue(SqHomeAbortParameterProperty, value); }
    }

    // Using a DependencyProperty as the backing store for State.  This enables animation, styling, binding, etc...
    public static readonly StyledProperty<object> SqHomeAbortParameterProperty =
        AvaloniaProperty.Register<ProbotborStatus, object>(nameof(SqHomeAbortParameter));
    #endregion

    #region Sq home
    public object SqHomeParameter
    {
        get { return GetValue(SqHomeParameterProperty); }
        set { SetValue(SqHomeParameterProperty, value); }
    }

    // Using a DependencyProperty as the backing store for State.  This enables animation, styling, binding, etc...
    public static readonly StyledProperty<object> SqHomeParameterProperty =
        AvaloniaProperty.Register<ProbotborStatus, object>(nameof(SqHomeParameter));
    #endregion

    #region Sq work abort 
    public object SqWorkAbortParameter
    {
        get { return GetValue(SqWorkAbortParameterProperty); }
        set { SetValue(SqWorkAbortParameterProperty, value); }
    }

    // Using a DependencyProperty as the backing store for State.  This enables animation, styling, binding, etc...
    public static readonly StyledProperty<object> SqWorkAbortParameterProperty =
        AvaloniaProperty.Register<ProbotborStatus, object>(nameof(SqWorkAbortParameter));
    #endregion

    #region Sq work
    public object SqWorkParameter
    {
        get { return GetValue(SqWorkParameterProperty); }
        set { SetValue(SqWorkParameterProperty, value); }
    }

    // Using a DependencyProperty as the backing store for State.  This enables animation, styling, binding, etc...
    public static readonly StyledProperty<object> SqWorkParameterProperty =
        AvaloniaProperty.Register<ProbotborStatus, object>(nameof(SqWorkParameter));
    #endregion

    #region Busy flag
    public object BusyParameter
    {
        get { return GetValue(BusyParameterProperty); }
        set { SetValue(BusyParameterProperty, value); }
    }

    // Using a DependencyProperty as the backing store for State.  This enables animation, styling, binding, etc...
    public static readonly StyledProperty<object> BusyParameterProperty =
        AvaloniaProperty.Register<ProbotborStatus, object>(nameof(BusyParameter));
    #endregion

    #region Ready flag
    public object ReadyParameter
    {
        get { return GetValue(ReadyParameterProperty); }
        set { SetValue(ReadyParameterProperty, value); }
    }

    // Using a DependencyProperty as the backing store for State.  This enables animation, styling, binding, etc...
    public static readonly StyledProperty<object> ReadyParameterProperty =
        AvaloniaProperty.Register<ProbotborStatus, object>(nameof(ReadyParameter));
    #endregion

    #region Otbor cmd parameter
    public object OtborCmdParameter
    {
        get { return GetValue(OtborCmdParameterProperty); }
        set { SetValue(OtborCmdParameterProperty, value); }
    }

    // Using a DependencyProperty as the backing store for State.  This enables animation, styling, binding, etc...
    public static readonly StyledProperty<object> OtborCmdParameterProperty =
        AvaloniaProperty.Register<ProbotborStatus, object>(nameof(OtborCmdParameter));
    #endregion

    #region Return cmd parameter
    public object ReturnCmdParameter
    {
        get { return GetValue(ReturnCmdParameterProperty); }
        set { SetValue(ReturnCmdParameterProperty, value); }
    }

    // Using a DependencyProperty as the backing store for State.  This enables animation, styling, binding, etc...
    public static readonly StyledProperty<object> ReturnCmdParameterProperty =
        AvaloniaProperty.Register<ProbotborStatus, object>(nameof(ReturnCmdParameter));
    #endregion

}