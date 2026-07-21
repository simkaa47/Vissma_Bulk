using Avalonia.Markup.Xaml;

namespace View.Keyboard.Layout;

public partial class FloatKeyboard : KeyboardLayout
{
    public FloatKeyboard()
    {
        InitializeComponent();
    }
    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public string LayoutName => "Float";
}