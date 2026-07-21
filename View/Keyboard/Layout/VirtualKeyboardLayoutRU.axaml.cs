using Avalonia.Markup.Xaml;

namespace View.Keyboard.Layout;

public partial class VirtualKeyboardLayoutRU : KeyboardLayout
{
    public VirtualKeyboardLayoutRU()
    {
        InitializeComponent();
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public string LayoutName => "ru-RU";
}