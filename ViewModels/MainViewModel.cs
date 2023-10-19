using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Avalonia.Styling;
using FluentAvalonia.UI.Controls;
using gredis.Components;
using gredis.Models;
using gredis.Utils;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;

namespace gredis.ViewModels;

public class MainViewModel : ViewModelBase {

    private readonly SettingViewModel settingViewModel;

    private readonly HomeViewModel homeViewModel;

    public NavMenuItem SourceItem { get; private set; }

    private Settings settings { get; }

    [Reactive]
    public NavMenuItem SelectedItem { get; set; }

    public List<NavMenuItem> NavItems { get; } = new();

    public ObservableCollection<NavMenuItem> NavItemsFooter { get; } = new();

    [Reactive]
    public ViewModelBase ContentPage { get; private set; }


    public MainViewModel() {
        settingViewModel = Apps.getService<SettingViewModel>();
        homeViewModel = Apps.getService<HomeViewModel>();
        settings = Apps.getService<Settings>();

        initItems();

        ContentPage = homeViewModel;

        this.WhenAnyValue(vm => vm.settings.Config.Theme)
            .Subscribe(theme => {
                SourceItem.IconSource =
                    theme == nameof(ThemeVariant.Dark)
                        ? CommonUtils.concatAssetUri("/Assets/github-mark-white.png")
                        : CommonUtils.concatAssetUri("/Assets/github-mark.png");
            });

        this.WhenAnyValue(vm => vm.SelectedItem)
            .Subscribe(item => {
                if (item == SourceItem) {
                    CommonUtils.OpenBrowser(CC.GithubRepoPath);
                } else {
                    ContentPage = item.Page;
                }
            });
    }

    private void initItems() {
        NavItems.Add(new NavMenuItem() {
            Content = "Home",
            IconSource = "Home",
            Page = homeViewModel
        });
        SourceItem = new NavMenuItem {
            Content = "Source",
            IconSource = "",
            Page = null,
        };
        NavItemsFooter.Add(SourceItem);
        NavItemsFooter.Add(new NavMenuItem() {
            Content = "Setting",
            IconSource = "Setting",
            Page = settingViewModel
        });

        SelectedItem = NavItems[0];
    }

}