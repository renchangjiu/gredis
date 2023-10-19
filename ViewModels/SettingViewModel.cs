using System;
using System.Collections.Generic;
using gredis.Components;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;

namespace gredis.ViewModels;

public class SettingViewModel : ViewModelBase {

    private Settings Settings { get; }

    public List<ThemeItem> ThemeItems { get; } = new();

    [Reactive]
    public ThemeItem SelectedThemeItem { get; set; }

    public SettingViewModel() {
        Settings = Apps.getService<Settings>();
        ThemeItems.Add(new ThemeItem("Dark"));
        ThemeItems.Add(new ThemeItem("Light"));
        ThemeItems.Add(new ThemeItem("Default"));

        SelectedThemeItem = ThemeItems.Find(item => item.Name == Settings.Config.Theme)!;

        this.WhenAnyValue(vm => vm.SelectedThemeItem)
            .Subscribe(item => { Settings.Config.Theme = item.Name; });
    }

}

public class ThemeItem {

    public string Name { get; set; }

    public ThemeItem(string name) {
        Name = name;
    }

}