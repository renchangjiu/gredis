using System;
using System.Globalization;
using Avalonia;
using Avalonia.Controls;
using Avalonia.ReactiveUI;
using Avalonia.Styling;
using gredis.Components;
using gredis.Utils;
using gredis.ViewModels;
using ReactiveUI;

namespace gredis.Views;

public partial class MainWindow : ReactiveWindow<MainWindowViewModel> {

    private Settings settings { get; }

    public MainWindow() {
        InitializeComponent();
        settings = Apps.getService<Settings>();
        this.WhenAnyValue(w => w.settings.Config.Theme)
            .Subscribe(t => {
                Application.Current.RequestedThemeVariant = CommonUtils.GetThemeVariant(t);
            });
        // Assets.Resources.Culture = new CultureInfo("zh_CN");

    }

}