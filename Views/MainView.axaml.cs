using Avalonia.ReactiveUI;
using gredis.ViewModels;

namespace gredis.Views;

public partial class MainView : ReactiveUserControl<MainViewModel> {

    public MainView() {
        InitializeComponent();
        DataContext = Apps.getService<MainViewModel>();
    }

}