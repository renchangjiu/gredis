using Avalonia.ReactiveUI;
using gredis.ViewModels;

namespace gredis.Views;

public partial class HomeSideBarView : ReactiveUserControl<HomeSideBarViewModel> {

    public HomeSideBarView() {
        InitializeComponent();

        DataContext = Apps.getService<HomeSideBarViewModel>();
    }

}