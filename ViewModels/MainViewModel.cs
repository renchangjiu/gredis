using System;
using ReactiveUI.Fody.Helpers;

namespace gredis.ViewModels;

public class MainViewModel : ViewModelBase {

    private SettingViewModel settingViewModel;

    private HomeViewModel homeViewModel;

    [Reactive]
    public ViewModelBase ContentPage { get; private set; }

    /// <summary>
    /// Only for designer preview.
    /// </summary>
    public MainViewModel() {
    }

    public MainViewModel(SettingViewModel settingViewModel, HomeViewModel homeViewModel) {
        this.settingViewModel = settingViewModel;
        this.homeViewModel = homeViewModel;
        ContentPage= this.homeViewModel;
    }

    public void SwitchContentPage(ViewModelBase vm) {
        ContentPage = vm;
    }
}