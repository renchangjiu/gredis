using FluentAvalonia.UI.Controls;

namespace gredis.ViewModels;

public class ConnAddViewModel : ViewModelBase {

    private readonly ContentDialog dialog;

    public ConnAddViewModel(ContentDialog dialog) {
        this.dialog = dialog;
    }

}