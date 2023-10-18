using System;
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
                ViewModel.SwitchContentPage(Apps.getService<HomeViewModel>());
                break;
            case "Source":
                CommonUtils.OpenBrowser("https://github.com/renchangjiu/gredis");
                break;
            case "Setting":
                ViewModel.SwitchContentPage(Apps.getService<SettingViewModel>());
                break;
        }

    }

}