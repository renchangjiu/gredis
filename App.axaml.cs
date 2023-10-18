using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using gredis.ViewModels;
using gredis.Views;

namespace gredis;

public partial class App : Application {


    public override void Initialize() {
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted() {
        Apps.init();

        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop) {
            desktop.MainWindow = new MainWindow {
                DataContext =Apps.getService<MainWindowViewModel>()
            };
        }

        base.OnFrameworkInitializationCompleted();
    }


}