using Avalonia.Controls;

namespace View.Keyboard.Layout
{
    public abstract class KeyboardLayout : UserControl
    {
        string LayoutName { get; } = string.Empty;        
    }
}
