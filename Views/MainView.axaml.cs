using System;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Media;
using Avalonia.Media.Imaging;
using Avalonia.ReactiveUI;
using Avalonia.Styling;
using FluentAvalonia.UI.Controls;
using gredis.Components;
using gredis.Utils;
using gredis.ViewModels;
using ReactiveUI;

namespace gredis.Views;

public partial class MainView : ReactiveUserControl<MainViewModel> {

    private Settings settings { get; }

    public MainView() {
        InitializeComponent();
        DataContext = Apps.getService<MainViewModel>();
        settings = Apps.getService<Settings>();
        nvSample.Content = new SettingViewModel();
        this.WhenAnyValue(v => v.settings.Config.Theme)
            .Subscribe(theme => {
                ImageIconSource source = new();
                source.Source = CommonUtils.GetBitmapFromAsset(
                    theme == nameof(ThemeVariant.Dark) ? "/Assets/github-mark-white.png" : "/Assets/github-mark.png"
                );
                NavItemGithub.IconSource = source;
            });
    }

    private void NvSample_OnSelectionChanged(object? sender, NavigationViewSelectionChangedEventArgs e) {
        NavigationViewItem item = ((NavigationViewItem)e.SelectedItem);
        string content = (string)item.Content!;
        switch (content) {
            case "Home":
                break;
            case "Source":
                CommonUtils.OpenBrowser("https://github.com/renchangjiu/gredis");
                break;
            case "Setting":
                break;
        }

        Console.WriteLine("");
    }

}