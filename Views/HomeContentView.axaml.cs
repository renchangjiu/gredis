using Avalonia.ReactiveUI;
using gredis.ViewModels;

namespace gredis.Views; 

public partial class HomeContentView : ReactiveUserControl<HomeContentViewModel> {

    public HomeContentView() {
        InitializeComponent();
        DataContext = Apps.getService<HomeContentViewModel>();
    }

}