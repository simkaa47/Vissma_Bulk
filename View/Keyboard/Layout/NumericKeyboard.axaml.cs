using Avalonia.Markup.Xaml;

namespace View.Keyboard.Layout;

public partial class NumericKeyboard : KeyboardLayout
{
    public NumericKeyboard()
    {
        InitializeComponent();
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);        
    }

    public string LayoutName => "Int";
}