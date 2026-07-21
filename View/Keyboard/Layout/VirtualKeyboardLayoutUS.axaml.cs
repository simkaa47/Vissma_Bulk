using Avalonia.Markup.Xaml;

namespace View.Keyboard.Layout;

public partial class VirtualKeyboardLayoutUS : KeyboardLayout
{
    public VirtualKeyboardLayoutUS()
    {
        InitializeComponent();
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public string LayoutName => "en-US";
}