using Avalonia;
using Avalonia.Controls;
using System.Windows.Input;

namespace View.UserControls.Parameters
{
    public class ParameterCommon : UserControl
    {
        public ParameterCommon()
        {
            AffectsMeasure<ParameterCommon>(CommandProperty);
            AffectsMeasure<ParameterCommon>(CommandParameterProperty);
            AffectsMeasure<ParameterCommon>(DescriptionInvisibleProperty);
            AffectsMeasure<ParameterCommon>(ParamWidthProperty);
        }

        #region Command
        public ICommand Command
        {
            get { return (ICommand)GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }

        // Using a DependencyProperty as the backing store for State.  This enables animation, styling, binding, etc...
        public static readonly StyledProperty<ICommand> CommandProperty =
            AvaloniaProperty.Register<ParameterCommon, ICommand>(nameof(Command));
        #endregion

        #region DescriptionInvisible
        public bool DescriptionInvisible
        {
            get { return (bool)GetValue(DescriptionInvisibleProperty); }
            set { SetValue(DescriptionInvisibleProperty, value); }
        }

        // Using a DependencyProperty as the backing store for State.  This enables animation, styling, binding, etc...
        public static readonly StyledProperty<bool> DescriptionInvisibleProperty =
            AvaloniaProperty.Register<ParameterCommon, bool>(nameof(DescriptionInvisible));
        #endregion

        #region CommandParameter
        public object CommandParameter
        {
            get { return GetValue(CommandParameterProperty); }
            set { SetValue(CommandParameterProperty, value); }
        }

        // Using a DependencyProperty as the backing store for State.  This enables animation, styling, binding, etc...
        public static readonly StyledProperty<object> CommandParameterProperty =
            AvaloniaProperty.Register<ParameterCommon, object>(nameof(CommandParameter));
        #endregion

        #region ParamWidth
        public int ParamWidth
        {
            get { return (int)GetValue(ParamWidthProperty); }
            set { SetValue(ParamWidthProperty, value); }
        }

        // Using a DependencyProperty as the backing store for State.  This enables animation, styling, binding, etc...
        public static readonly StyledProperty<int> ParamWidthProperty =
            AvaloniaProperty.Register<ParameterCommon, int>(nameof(ParamWidth), defaultValue:40);
        #endregion

    }
}
