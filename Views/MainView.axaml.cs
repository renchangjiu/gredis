using System;
using Avalonia;
using Avalonia.ReactiveUI;
using Avalonia.Styling;
using gredis.ViewModels;

namespace gredis.Views;

public partial class MainView : ReactiveUserControl<MainViewModel> {

    public MainView() {
        InitializeComponent();
        DataContext = Apps.getService<MainViewModel>();
        Application.Current.RequestedThemeVariant = ThemeVariant.Dark;
    }

}