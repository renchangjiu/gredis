using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Markup.Xaml;
using gredis.Utils;

namespace gredis.Controls;

public partial class TitleBar : UserControl {

    public TitleBar() {
        InitializeComponent();
    }

    private void OnPointerPressed(object? sender, PointerPressedEventArgs e) {
        if (sender is DockPanel) {
            UiUtils.GetWindow(this).BeginMoveDrag(e);
        }
    }

}